using System.Management;
using PowerTune.Contracts.Services;
using PowerTune.Strings;

namespace PowerTune.Services;

public class RestorePointService : IRestorePointService
{
    /// <summary>
    /// Main Constructor
    /// </summary>
    public RestorePointService() => EnableSystemRestoreForDrive("C:\\");

    /// <summary>
    /// Runs a restore point operation.
    /// </summary>
    /// <returns>True if a restore point was created; otherwise, false.</returns>
    public async Task<bool> RunRestorePoint()
    {
        // Check if a restore point with the specified service name already exists
        if (await CheckIfRestorePointExists(Constants.RestorePointServiceName))
            return false;

        // Create a new restore point with the specified service name and parameters
        // Return false to indicate that a restore point was not previously present
        await CreateRestorePoint(Constants.RestorePointServiceName, 0, 100);
        return true;
    }

    /// <summary>
    /// Activate RestorePoint Services Before Creating a restore point.
    /// </summary>
    /// <param name="driveLetter">The drive letter for which to enable System Restore.</param>
    private static void EnableSystemRestoreForDrive(string? driveLetter)
    {
        try
        {
            // Create a new instance of ManagementClass to interact with the SystemRestore WMI class
            var srClass = new ManagementClass("root\\default", "SystemRestore", null!);
            // Get the method parameters for the "Enable" method
            var srArgs = srClass.GetMethodParameters("Enable");
            // Set the "Drive" parameter to the specified drive letter
            srArgs["Drive"] = driveLetter!;
            // Invoke the "Enable" method on the SystemRestore class with the provided parameters
            srClass.InvokeMethod("Enable", srArgs, null!);
        }
        catch (Exception ex)
        {
            App.MainWindow.ShowMessageDialogAsync($"{ex.Message}", $"{ex.Source}");
        } // If an exception occurs, throw a new exception with the error message
    }

    /// <summary>
    /// Creates a restore point with the specified name, type, and event type.
    /// </summary>
    /// <param name="rpName">The name or description of the restore point.</param>
    /// <param name="rpType">The type of the restore point.</param>
    /// <param name="eventType">The event type associated with the restore point.</param>
    /// <returns>True if the restore point is created successfully; otherwise, false.</returns>
    private static async Task<bool> CreateRestorePoint(string rpName, int rpType, int eventType)
    {
        // Create an instance of ManagementClass and get the method parameters
        var srArgs = new ManagementClass("//./root/default:SystemRestore")
            .GetMethodParameters("CreateRestorePoint");
        // Set the values for the method parameters
        srArgs["Description"] = rpName;
        srArgs["RestorePointType"] = rpType;
        srArgs["EventType"] = eventType;

        try
        {
            // Invoke the CreateRestorePoint method in a separate task
            // ONLY FOR DEVELOPMENT PROCESS
            var outParams = await Task.Run(() => new ManagementClass("//./root/default:SystemRestore")
              .InvokeMethod("CreateRestorePoint", srArgs, new InvokeMethodOptions(null!, TimeSpan.MaxValue)));

            return true; // Return true indicating successful creation of restore point
        }
        catch
        {
            //TODO: Handler event
            return false;
        }
    }

    /// <summary>
    /// Checks if a restore point with the specified description exists.
    /// </summary>
    /// <param name="description">The description of the restore point to check.</param>
    /// <returns><c>true</c> if a restore point with the specified description exists; otherwise, <c>false</c>.</returns>
    public static async Task<bool> CheckIfRestorePointExists(string? description)
    {
        try
        {
            // Create a new ManagementScope object to connect to the WMI namespace
            var oScope = new ManagementScope("\\\\localhost\\root\\default");
            // Create a new ObjectQuery to specify the query to be executed
            var oQuery = new ObjectQuery("SELECT * FROM SystemRestore");
            // Create a new ManagementObjectSearcher to execute the query on the specified scope
            using var oSearcher = new ManagementObjectSearcher(oScope, oQuery);
            // Execute the query and retrieve the collection of ManagementObjects asynchronously
            var oCollection = await Task.Run(() => oSearcher.Get());
            // Check if any ManagementObject in the collection matches the specified description
            return oCollection.Cast<ManagementObject>().Any(oItem =>
                oItem["Description"].ToString()!.Equals(description, StringComparison.OrdinalIgnoreCase));
        }
        catch (Exception ex)
        {
            App.MainWindow.CreateMessageDialog($"{ex.Message}", $"{ex.Source}");
            return false;
        } // If any exception occurs, return false to indicate that the restore point check failed
    }
}