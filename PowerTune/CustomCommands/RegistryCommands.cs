using Microsoft.Win32;

namespace PowerTune.CustomCommands;
public static class RegistryCommands
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

}
