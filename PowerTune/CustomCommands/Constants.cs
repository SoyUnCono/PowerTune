
using CommunityToolkit.WinUI.UI.Controls;

namespace PowerTune.CustomCommands;
public class Constants
{
    /// <summary>
    /// Root Keys
    /// </summary>
    public const string HKEY_LOCAL_MACHINE = "HKEY_LOCAL_MACHINE";
    public const string HKEY_CURRENT_USER = "HKEY_CURRENT_USER";

    /// <summary>
    /// Path Strings
    /// </summary>
    public const string uacPath = "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System";
    public const string ApplicationPath = "Software\\RegisteredApplications\\PowerTune";
    public const string verbosePath = "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System";
    public const string SerializePath = "Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Serialize";
    public const string TaskbarPositionPath = "Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced";
    public const string Alt_TabPath = "Software\\Microsoft\\Windows\\CurrentVersion\\Explorer";
    public const string Old_Sound_MixerPath = "Software\\Microsoft\\Windows NT\\CurrentVersion\\MTCUVC";
    public const string BackgroundAccessApplicationsPath = "Software\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications";
    public const string SearchPath = "Software\\Microsoft\\Windows\\CurrentVersion\\Search";
    public const string NarratorPath = "SOFTWARE\\Microsoft\\Narrator\\NoRoam";
    public const string StickyKeysPath = "Control Panel\\Accessibility\\StickyKeys";
    public const string ToggleKeysPath = "Control Panel\\Accessibility\\ToggleKeys";
    public const string KeyboardResponsePath = "Control Panel\\Accessibility\\Keyboard Response";
    public const string GameDVRPath = "SOFTWARE\\Policies\\Microsoft\\Windows\\GameDVR";
    public const string GameBarPath = "Software\\Microsoft\\GameBar";
    public const string AutoFinishSetupPath = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System";
    public const string AutoUpdateMapsPath = "SYSTEM\\Maps";
    public const string RecentlyAddedAppsPath1 = "SOFTWARE\\Policies\\Microsoft\\Windows\\Explorer";
    public const string RecentlyAddedAppsPath2 = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer";
    public const string AlwaysShowIconsPath = "Software\\Microsoft\\Windows\\CurrentVersion\\Explorer";
    public const string NotificationsPath1 = "Software\\Microsoft\\Windows\\CurrentVersion\\Notifications\\Settings";
    public const string NotificationsPath2 = "Software\\Microsoft\\Windows\\CurrentVersion\\PushNotifications";
    public const string NotificationsPath3 = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\UserProfileEngagement";
    public const string NotificationsPath4 = "Software\\Microsoft\\Windows\\CurrentVersion\\Notifications\\Settings\\windows.immersivecontrolpanel_cw5n1h2txyewy!microsoft.windows.immersivecontrolpanel";
    public const string NotificationsPath5 = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Notifications\\Settings\\Microsoft.WindowsStore_8wekyb3d8bbwe!App";
    public const string NotificationsPath6 = "Software\\Microsoft\\Windows\\CurrentVersion\\Notifications\\Settings\\Windows.SystemToast.AutoPlay";
    public const string TabletModePath1 = "Software\\Microsoft\\Windows\\CurrentVersion\\ImmersiveShell";
    public const string TabletModePath2 = "Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced";
    public const string PowerThrottlingPath = "SYSTEM\\CurrentControlSet\\Control\\Power\\PowerThrottling";
    public const string SystemProfilePath = "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Multimedia\\SystemProfile";
    public const string GamesSchedulingPath = "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Multimedia\\SystemProfile\\Tasks\\Games";
    public const string SleepSettingsPath = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FlyoutMenuSettings";
    public const string HibernateSettingsPath = "SYSTEM\\CurrentControlSet\\Control\\Power";
    public const string AutomaticMaintenancePath = "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Schedule\\Maintenance";
    public const string MenuShowDelayPath = "Control Panel\\Desktop";
    public const string ClassicContextMenuPath = "Software\\Classes\\CLSID\\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}\\InprocServer32";
    public const string BackgroundAppsPath = "Software\\Microsoft\\Windows\\CurrentVersion\\BackgroundAccessApplications";
    public const string DisableWindowsWidgetsPath = "SOFTWARE\\Policies\\Microsoft\\Dsh";


    /// <summary>
    /// Value Strings
    /// </summary>
    public const string uacValue = "EnableLUA";
    public const string startUpTimeValue = "EnableBoostStartUp";
    public const string DialogStatus = "EnableDialog";
    public const string verboseValue = "VerboseStatus";
    public const string headerViewContentValue = "ShowHeaderStatus";
    public const string SerializeValue = "StartupDelayInMSec";
    public const string TaskbarPositionValue = "TaskbarAl";
    public const string Alt_TabValue = "AltTabSettings";
    public const string Old_Sound_MixerValue = "EnableMtcUvc";
    public const string GlobalUserDisabledValue = "GlobalUserDisabled";
    public const string BackgroundAppGlobalToggleValue = "BackgroundAppGlobalToggle";
    public const string WinEnterLaunchEnabledValue = "WinEnterLaunchEnabled";
    public const string StickyKeysFlagsValue = "Flags";
    public const string ToggleKeysFlagsValue = "Flags";
    public const string KeyboardResponseFlagsValue = "Flags";
    public const string AllowgameDVRValue = "AllowgameDVR";
    public const string UseNexusForGameBarEnabledValue = "UseNexusForGameBarEnabled";
    public const string DisableAutomaticRestartSignOnValue = "DisableAutomaticRestartSignOn";
    public const string AutoUpdateEnabledValue = "AutoUpdateEnabled";
    public const string HideRecentlyAddedAppsValue1 = "HideRecentlyAddedApps";
    public const string HideRecentlyAddedAppsValue2 = "HideRecentlyAddedApps";
    public const string EnableAutoTrayValue = "EnableAutoTray";
    public const string NotificationsValue1 = "NOC_GLOBAL_SETTING_ALLOW_CRITICAL_TOASTS_ABOVE_LOCK";
    public const string NotificationsValue2 = "NOC_GLOBAL_SETTING_ALLOW_TOASTS_ABOVE_LOCK";
    public const string NotificationsValue8 = "NOC_GLOBAL_SETTING_ALLOW_NOTIFICATION_SOUND";
    public const string NotificationsValue3= "LockScreenToastEnabled";
    public const string NotificationsValue4 = "ToastEnabled";
    public const string NotificationsValue5 = "ScoobeSystemSettingEnabled";
    public const string NotificationsValue6 = "Enabled";
    public const string NotificationsValue7 = "Enabled";
    public const string TabletModeValue1 = "TabletMode";
    public const string TabletModeValue2 = "SignInMode";
    public const string TabletModeValue3 = "ConvertibleSlateModePromptPreference";
    public const string TabletModeValue4 = "TaskbarAppsVisibleInTabletMode";
    public const string TabletModeValue5 = "TaskbarAutoHideInTabletMode";
    public const string VirtualDesktopsValue1 = "VirtualDesktopTaskbarFilter";
    public const string VirtualDesktopsValue2 = "VirtualDesktopAltTabFilter";
    public const string PowerThrottlingValue = "PowerThrottlingOff";
    public const string NetworkThrottlingIndexValue = "NetworkThrottlingIndex";
    public const string SystemResponsivenessValue = "SystemResponsiveness";
    public const string GamesSchedulingAffinityValue = "Affinity";
    public const string GamesSchedulingBackgroundOnlyValue = "Background Only";
    public const string GamesSchedulingClockRateValue = "Clock Rate";
    public const string GamesSchedulingGPUPriorityValue = "GPU Priority";
    public const string GamesSchedulingPriorityValue = "Priority";
    public const string GamesSchedulingSchedulingCategoryValue = "Scheduling Category";
    public const string GamesSchedulingSFIOValue = "SFIO Priority";
    public const string SleepSettingsValue = "ShowSleepOption";
    public const string HibernateSettingsValue = "HibernateEnabled";
    public const string AutomaticMaintenanceValue = "MaintenanceDisabled";
    public const string MenuShowDelayValue = "MenuShowDelay";
    public const string ClassicContextMenuValue = "@";
    public const string BackgroundAppsValue = "GlobalUserDisabled";
    public const string DisableWindowsWidgetsValue = "AllowNewsAndInterests";

    /// <summary>
    /// Important Constants
    /// </summary>s
    public const string restorePointServiceName = "PowerTune_RestorePoint";
}
