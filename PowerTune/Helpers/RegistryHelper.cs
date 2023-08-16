using System.Globalization;
using Microsoft.Win32;

namespace PowerTune.Helpers;

public static class RegistryHelper
{
    // This method sets a value in the Windows Registry.
    // Parameters:
    //   - rootKey: The root registry key (either "HKEY_LOCAL_MACHINE" or "HKEY_CURRENT_USER").
    //   - keyPath: The path to the registry key where the value should be set.
    //   - valueName: The name of the value to be set.
    //   - value: The value to be set.
    public static void SetRegistryValue(string rootKey, string keyPath, string valueName, object value)
    {
        // Convert the rootKey to uppercase and select the appropriate registry root based on its value.
        var registryRoot = rootKey.ToUpper() switch
        {
            "HKEY_LOCAL_MACHINE" => Registry.LocalMachine,
            "HKEY_CURRENT_USER" => Registry.CurrentUser,
            _ => throw new ArgumentException("Invalid root key specified."),
        };

        // Find the last index of '\\' character in the keyPath.
        var index = keyPath.LastIndexOf('\\');
        // Extract the main key path before the last '\\' character.
        var mainKeyPath = keyPath[..index];
        // Extract the sub key path after the last '\\' character.
        var subKeyPath = keyPath[(index + 1)..];

        // Open the main key in the registry, with write access.
        var mainKey = registryRoot.OpenSubKey(mainKeyPath, true);

        if (mainKey == null)
            throw new ArgumentException("Invalid path key specified.");

        // Open the sub key under the main key, with write access.
        var subKey = mainKey.OpenSubKey(subKeyPath, true);

        if (subKey == null)
            // If the sub key does not exist, create it and set the value.
            mainKey.CreateSubKey(subKeyPath);

        // Set the value in the sub key.
        subKey?.SetValue(valueName, value);
    }

    // This method retrieves the initial value of a toggle switch from the Windows Registry.
    // Parameters:
    //   - registryKeyPath: The path to the registry key containing the value.
    //   - registryValueName: The name of the value to retrieve.
    //   - expectedValue: The expected value to compare against.
    // Returns:
    //   - true if the retrieved value matches the expected value; otherwise, false.
    public static bool GetToggleSwitchInitialValue(string registryKeyPath, string registryValueName, int expectedValue)
    {
        // Retrieve the registry value based on the key path and value name.
        var registryValue = Registry.GetValue(registryKeyPath!, registryValueName, null);

        // Check if the retrieved value is of type int.
        if (registryValue is int registryIntValue)
            return registryIntValue == expectedValue;

        // If the retrieved value is not of type int, return false.
        return false;
    }

    // This method removes a registry key.
    // Parameters:
    //   - rootKey: The root registry key (either "HKEY_LOCAL_MACHINE" or "HKEY_CURRENT_USER").
    //   - keyPath: The path to the registry key to be removed.
    public static void RemoveRegistryKey(string rootKey, string keyPath)
    {
        // Convert the rootKey to uppercase and select the appropriate registry root based on its value.
        var registryRoot = rootKey.ToUpper() switch
        {
            "HKEY_LOCAL_MACHINE" => Registry.LocalMachine,
            "HKEY_CURRENT_USER" => Registry.CurrentUser,
            _ => throw new ArgumentException("Invalid root key specified."),
        };

        // Delete the registry key.
        registryRoot.DeleteSubKeyTree(keyPath, false);
    }

    // This method imports a registry file content in string format.
    // It splits the content into sections based on the "[HKEY_" tag, then processes each section separately.
    public static void ImportRegistryFromString(string regContent)
    {
        // Split the content into sections using "[HKEY_" as the delimiter and remove any empty entries.
        var sections = regContent.Split(new string[] { "[HKEY_" }, StringSplitOptions.RemoveEmptyEntries);

        // Loop through each section to process them individually.
        foreach (var section in sections)
        {
            // Find the end of the key path by locating the first ']'.
            var keyEndIndex = section.IndexOf(']');
            if (keyEndIndex < 0) continue;

            // Extract the key path from the section.
            var keyPath = section[..keyEndIndex];

            // Split the section into lines, removing empty entries and using '\r' and '\n' as delimiters.
            var lines = section[(keyEndIndex + 1)..]
                .Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            // Get or create the registry key based on the extracted key path.
            using var regKey = GetOrCreateRegistryKey(keyPath);

            // Process each line in the section to set registry values.
            foreach (var line in lines)
            {
                // Find the index of '=' to separate the name and value parts.
                var equalsIndex = line.IndexOf('=');
                if (equalsIndex < 0) continue;

                // Extract the name and value parts from the line.
                var name = line[..equalsIndex].Trim();
                var value = line[(equalsIndex + 1)..].Trim();

                // If the name is enclosed in double quotes, remove the quotes.
                if (name.StartsWith("\"") && name.EndsWith("\""))
                    name = name.Trim('"');

                // Check for different value types using switch.
                switch (value)
                {
                    // If the value starts with "dword:", it is a DWORD (32-bit integer) value.
                    // Parse the integer value and set it in the registry key as a DWORD.
                    case string dwordValue when dwordValue.StartsWith("dword:", StringComparison.OrdinalIgnoreCase):
                        if (int.TryParse(dwordValue[6..], NumberStyles.HexNumber, CultureInfo.InvariantCulture,
                                out var intValue))
                            regKey.SetValue(name, intValue, RegistryValueKind.DWord);
                        break;

                    // If the value starts with "hex(", it is a hexadecimal string value.
                    // Parse the hexadecimal value and set it in the registry key as binary data.
                    case string hexValue when hexValue.StartsWith("hex:", StringComparison.OrdinalIgnoreCase):
                        var parsedHexValue = ParseHexValue(hexValue);
                        if (parsedHexValue != null)
                            regKey.SetValue(name, parsedHexValue, RegistryValueKind.Binary);
                        break;

                    // If the value does not match any of the above types, it is a regular string value.
                    // If the value is enclosed in double quotes, remove the quotes.
                    default:
                        if (value.StartsWith("\"") && value.EndsWith("\""))
                            value = value.Trim('"');
                        regKey.SetValue(name, value, RegistryValueKind.String);
                        break;
                }
            }
        }
    }

    // This method parses a hexadecimal value in the "hex(...)" format and returns the byte array represented by it.
    // If the parsing fails, it returns null to indicate invalid hex data.
    private static byte[]? ParseHexValue(string hexValue)
    {
        // Remove the "hex(" and ")" part to get the hex data only.
        var hexData = hexValue[4..^1];

        // Split the hex data by commas to get individual byte representations.
        var hexBytes = hexData.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

        // Create a List<byte> to store the parsed bytes.
        var buffer = new List<byte>();

        // Loop through each byte representation and parse it into a byte value.
        foreach (var hexByte in hexBytes)
        {
            // Try to parse each byte from hex string to a byte value.
            if (byte.TryParse(hexByte.Trim(), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out var byteValue))
                buffer.Add(byteValue);
            else
                return null; // If the parsing fails, return null indicating invalid hex data.
        }

        // Return the byte array containing the parsed bytes.
        return buffer.ToArray();
    }

    // <summary>
    // Gets or creates the registry key based on the key path.
    // </summary>
    // <param name="keyPath">The path of the registry key.</param>
    // <returns>The registry key.</returns>
    private static RegistryKey GetOrCreateRegistryKey(string keyPath)
    {
        // Extract the root key and subkey from the key path
        var rootKey = keyPath[..keyPath.IndexOf('\\')];
        var subKey = keyPath[(keyPath.IndexOf('\\') + 1)..];

        // Create or get the corresponding registry key based on the root key
        var key = rootKey.ToUpper() switch
        {
            "CLASSES_ROOT" => Registry.ClassesRoot.CreateSubKey(subKey),
            "CURRENT_CONFIG" => Registry.CurrentConfig.CreateSubKey(subKey),
            "CURRENT_USER" => Registry.CurrentUser.CreateSubKey(subKey),
            "LOCAL_MACHINE" => Registry.LocalMachine.CreateSubKey(subKey),
            "USERS" => Registry.Users.CreateSubKey(subKey),
            _ => throw new ArgumentException("Root key not supported: " + rootKey),
        };

        return key;
    }
}