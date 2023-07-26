using System;
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

    // <summary>
    // Imports registry keys and values from a string representation.
    // </summary>
    // <param name="regContent">The content of the registry to import.</param>
    public static void ImportRegistryFromString(string regContent)
    {
        // Divide the content into sections based on lines starting with "[HKEY_"
        var sections = regContent.Split(new string[] { "[HKEY_" }, StringSplitOptions.RemoveEmptyEntries);

        foreach (var section in sections)
        {
            // Find the end of the current key path
            var keyEndIndex = section.IndexOf(']');
            if (keyEndIndex < 0)
                continue;

            // Extract the key path
            var keyPath = section[..keyEndIndex];

            // Split the section into lines, ignoring empty entries
            var lines = section[(keyEndIndex + 1)..].Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            // Get or create the registry key for the current path
            using var regKey = GetOrCreateRegistryKey(keyPath);

            // Process each line in the section (representing name-value pairs)
            foreach (var line in lines)
            {
                // Find the position of the equals sign to split name and value
                var equalsIndex = line.IndexOf('=');
                if (equalsIndex < 0)
                    continue;

                // Extract the name and value from the line
                var name = line[..equalsIndex].Trim();
                var value = line[(equalsIndex + 1)..].Trim();

                // Remove surrounding quotes from name and value if present
                if (name.StartsWith("\"") && name.EndsWith("\""))
                    name = name.Trim('"');

                if (value.StartsWith("\"") && value.EndsWith("\""))
                    value = value.Trim('"');

                // Set the registry value
                regKey.SetValue(name, value);
            }
        }
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

