
using CommunityToolkit.WinUI.UI.Controls;
using Windows.Web.AtomPub;

namespace PowerTune.Strings;
public class Constants
{
    public const string restorePointServiceName = "PowerTune_RestorePoint";

    /// <summary>
    /// Root Keys
    /// </summary>
    public const string HKEY_LOCAL_MACHINE = "HKEY_LOCAL_MACHINE";
    public const string HKEY_CURRENT_USER = "HKEY_CURRENT_USER";

    #region Path Strings
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
    #endregion
    #region strings value
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
    public const string NotificationsValue3 = "LockScreenToastEnabled";
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
    public const string NotificationsValue9 = "NOC_GLOBAL_SETTING_STYLUS_TOAST_NOTIFICATION";
    public const string NotificationsValue10 = "NOC_GLOBAL_SETTING_3DTOAST_ENABLED";
    #endregion
    #region Import Raw Strings
    public const string RawBasicsOptimizationsW11 = @"
[HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Edge]
""StartupBoostEnabled""=dword:00000000
""HardwareAccelerationModeEnabled""=dword:00000000
""BackgroundModeEnabled""=dword:00000000
[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\MicrosoftEdgeElevationService]
""Start""=dword:00000004
[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\edgeupdate]
""Start""=dword:00000004
[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\edgeupdatem]
""Start""=dword:00000004
[HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Google\Chrome]
""StartupBoostEnabled""=dword:00000000
""HardwareAccelerationModeEnabled""=dword:00000000
""BackgroundModeEnabled""=dword:00000000
[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\GoogleChromeElevationService]
""Start""=dword:00000004
[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\gupdate]
""Start""=dword:00000004
[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\gupdatem]
""Start""=dword:00000004
[HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\WindowsStore]
""AutoDownload""=dword:00000002
[HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced]
""TaskbarAl""=dword:00000000
[HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced]
""TaskbarMn""=dword:00000000
[HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced]
""ShowTaskViewButton""=dword:00000000
[HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Search]
""SearchboxTaskbarMode""=dword:00000000
[-HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Taskband]
[HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Taskband\AuxilliaryPins]
[HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer]
""EnableAutoTray""=dword:00000000
[HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Explorer]
""ShowOrHideMostUsedApps""=dword:00000002
[HKEY_CURRENT_USER\SOFTWARE\Policies\Microsoft\Windows\Explorer]
""ShowOrHideMostUsedApps""=-
[HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer]
""NoStartMenuMFUprogramsList""=-
""NoInstrumentation""=-
[HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\Explorer]
""NoStartMenuMFUprogramsList""=-
""NoInstrumentation""=-
[HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Explorer]
""HideRecentlyAddedApps""=dword:00000001
[HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\Explorer]
""HideRecentlyAddedApps""=dword:00000001
[HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced]
""Start_TrackDocs""=dword:00000000 
[HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced]
""LaunchTo""=dword:00000001
[HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer]
""ShowFrequent""=dword:00000000
[HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced]
""HideFileExt""=dword:00000000
[HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\SearchSettings]
""IsDeviceSearchHistoryEnabled""=dword:00000000
[HKEY_CURRENT_USER\Control Panel\Desktop]
""MenuShowDelay""=""0""
[HKEY_CURRENT_USER\Software\Classes\CLSID\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}\InprocServer32]
@=""""
[HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Dsh] 
""AllowNewsAndInterests""=dword:00000000
[HKEY_CURRENT_USER\Control Panel\Desktop]
""LogPixels""=dword:00000096
""Win8DpiScaling""=dword:00000000
[-HKEY_CURRENT_USER\Control Panel\Desktop\PerMonitorSettings]
[HKEY_CURRENT_USER\Control Panel\Desktop\WindowMetrics]
""AppliedDPI""=dword:00000096
[HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize]
""EnableTransparency""=dword:00000000
[HKEY_CURRENT_USER\Software\Microsoft\Multimedia\Audio]
""UserDuckingPreference""=dword:00000003
[HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\Authentication\LogonUI\BootAnimation]
""DisableStartupSound""=dword:00000001
[HKEY_CURRENT_USER\AppEvents\Schemes]
@="".None""
[-HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\.Default\.Current]
[HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\.Default\.Current]
[-HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\CriticalBatteryAlarm\.Current]
[HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\CriticalBatteryAlarm\.Current]
[-HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\DeviceConnect\.Current]
[HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\DeviceConnect\.Current]
[-HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\DeviceDisconnect\.Current]
[HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\DeviceDisconnect\.Current]
[-HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\DeviceFail\.Current]
[HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\DeviceFail\.Current]
[-HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\FaxBeep\.Current]
[HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\FaxBeep\.Current]
[-HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\LowBatteryAlarm\.Current]
[HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\LowBatteryAlarm\.Current]
[-HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\MailBeep\.Current]
[HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\MailBeep\.Current]
[-HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\MessageNudge\.Current]
[HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\MessageNudge\.Current]
[-HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\Notification.Default\.Current]
[HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\Notification.Default\.Current]
[-HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\Notification.IM\.Current]
[HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\Notification.IM\.Current]
[-HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\Notification.Mail\.Current]
[HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\Notification.Mail\.Current]
[-HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\Notification.Proximity\.Current]
[HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\Notification.Proximity\.Current]
[-HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\Notification.Reminder\.Current]
[HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\Notification.Reminder\.Current]
[-HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\Notification.SMS\.Current]
[HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\Notification.SMS\.Current]
[-HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\ProximityConnection\.Current]
[HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\ProximityConnection\.Current]
[-HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\SystemAsterisk\.Current]
[HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\SystemAsterisk\.Current]
[-HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\SystemExclamation\.Current]
[HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\SystemExclamation\.Current]
[-HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\SystemHand\.Current]
[HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\SystemHand\.Current]
[-HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\SystemNotification\.Current]
[HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\SystemNotification\.Current]
[-HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\WindowsUAC\.Current]
[HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\WindowsUAC\.Current]
[-HKEY_CURRENT_USER\AppEvents\Schemes\Apps\sapisvr\DisNumbersSound\.current]
[HKEY_CURRENT_USER\AppEvents\Schemes\Apps\sapisvr\DisNumbersSound\.current]
[-HKEY_CURRENT_USER\AppEvents\Schemes\Apps\sapisvr\HubOffSound\.current]
[HKEY_CURRENT_USER\AppEvents\Schemes\Apps\sapisvr\HubOffSound\.current]
[-HKEY_CURRENT_USER\AppEvents\Schemes\Apps\sapisvr\HubOnSound\.current]
[HKEY_CURRENT_USER\AppEvents\Schemes\Apps\sapisvr\HubOnSound\.current]
[-HKEY_CURRENT_USER\AppEvents\Schemes\Apps\sapisvr\HubSleepSound\.current]
[HKEY_CURRENT_USER\AppEvents\Schemes\Apps\sapisvr\HubSleepSound\.current]
[-HKEY_CURRENT_USER\AppEvents\Schemes\Apps\sapisvr\MisrecoSound\.current]
[HKEY_CURRENT_USER\AppEvents\Schemes\Apps\sapisvr\MisrecoSound\.current]
[-HKEY_CURRENT_USER\AppEvents\Schemes\Apps\sapisvr\PanelSound\.current]
[HKEY_CURRENT_USER\AppEvents\Schemes\Apps\sapisvr\PanelSound\.current]
[HKEY_CURRENT_USER\Control Panel\Mouse]
""MouseSpeed""=""0""
""MouseThreshold1""=""0""
""MouseThreshold2""=""0""
[HKEY_CURRENT_USER\Control Panel\Cursors]
""AppStarting""=hex(2):00,00
""Arrow""=hex(2):00,00
""ContactVisualization""=dword:00000000
""Crosshair""=hex(2):00,00
""GestureVisualization""=dword:00000000
""Hand""=hex(2):00,00
""Help""=hex(2):00,00
""IBeam""=hex(2):00,00
""No""=hex(2):00,00
""NWPen""=hex(2):00,00
""Scheme Source""=dword:00000000
""SizeAll""=hex(2):00,00
""SizeNESW""=hex(2):00,00
""SizeNS""=hex(2):00,00
""SizeNWSE""=hex(2):00,00
""SizeWE""=hex(2):00,00
""UpArrow""=hex(2):00,00
""Wait""=hex(2):00,00
@=""""
[-HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run]
[-HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Run]
[HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Run]
""ctfmon""=""C:\\Windows\\System32\\ctfmon.exe""
[-HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Schedule\TaskCache\Tree]
[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\Origin Client Service]
""Start""=dword:00000004
[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\Origin Web Helper Service]
""Start""=dword:00000004
[HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\Explorer\FlyoutMenuSettings]
""ShowLockOption""=dword:00000000
[HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\FlyoutMenuSettings]
""ShowSleepOption""=dword:00000000
[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Power]
""HibernateEnabled""=dword:00000000
[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Power\PowerThrottling]
""PowerThrottlingOff""=dword:00000001
[HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile]
""NetworkThrottlingIndex""=dword:ffffffff
""SystemResponsiveness""=dword:00000000
[HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile\Tasks\Games]
""Affinity""=dword:00000000
""Background Only""=""False""
""Clock Rate""=dword:00002710
""GPU Priority""=dword:00000008
""Priority""=dword:00000006
""Scheduling Category""=""High""
""SFIO Priority""=""High""
[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\GraphicsDrivers]
""HwSchMode""=dword:00000002
[HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\VideoSettings]
""VideoQualityOnBattery""=dword:00000001
[HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\VisualEffects]
""VisualFXSetting""=dword:3
[HKEY_CURRENT_USER\Control Panel\Desktop]
""UserPreferencesMask""=hex(2):90,12,03,80,10,00,00,00
[HKEY_CURRENT_USER\Control Panel\Desktop\WindowMetrics]
""MinAnimate""=""0""
[HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced]
""TaskbarAnimations""=dword:0
[HKEY_CURRENT_USER\Software\Microsoft\Windows\DWM]
""EnableAeroPeek""=dword:0
[HKEY_CURRENT_USER\Software\Microsoft\Windows\DWM]
""AlwaysHibernateThumbnails""=dword:0
[HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced]
""IconsOnly""=dword:0
[HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced]
""ListviewAlphaSelect""=dword:0
[HKEY_CURRENT_USER\Control Panel\Desktop]
""DragFullWindows""=""0""
[HKEY_CURRENT_USER\Control Panel\Desktop]
""FontSmoothing""=""2""
[HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced]
""ListviewShadow""=dword:0
[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\PriorityControl]
""Win32PrioritySeparation""=dword:00000026
[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Remote Assistance]
""fAllowToGetHelp""=dword:00000000
[HKEY_CURRENT_USER\System\GameConfigStore]
""GameDVR_Enabled""=dword:00000000
[HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\GameDVR]
""AppCaptureEnabled""=dword:00000000
[HKEY_CURRENT_USER\Software\Microsoft\GameBar]
""UseNexusForGameBarEnabled""=dword:00000000
[HKEY_CURRENT_USER\Software\Microsoft\GameBar]
""AutoGameModeEnabled""=dword:00000001
[HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\GameDVR]
""AudioEncodingBitrate""=dword:0001f400
""AudioCaptureEnabled""=dword:00000000
""CustomVideoEncodingBitrate""=dword:003d0900
""CustomVideoEncodingHeight""=dword:000002d0
""CustomVideoEncodingWidth""=dword:00000500
""HistoricalBufferLength""=dword:0000001e
""HistoricalBufferLengthUnit""=dword:00000001
""HistoricalCaptureEnabled""=dword:00000000
""HistoricalCaptureOnBatteryAllowed""=dword:00000001
""HistoricalCaptureOnWirelessDisplayAllowed""=dword:00000001
""MaximumRecordLength""=hex(b):00,D0,88,C3,10,00,00,00
""VideoEncodingBitrateMode""=dword:00000002
""VideoEncodingResolutionMode""=dword:00000002
""VideoEncodingFrameRateMode""=dword:00000000
""EchoCancellationEnabled""=dword:00000001
""CursorCaptureEnabled""=dword:00000000
""VKToggleGameBar""=dword:00000000
""VKMToggleGameBar""=dword:00000000
""VKSaveHistoricalVideo""=dword:00000000
""VKMSaveHistoricalVideo""=dword:00000000
""VKToggleRecording""=dword:00000000
""VKMToggleRecording""=dword:00000000
""VKTakeScreenshot""=dword:00000000
""VKMTakeScreenshot""=dword:00000000
""VKToggleRecordingIndicator""=dword:00000000
""VKMToggleRecordingIndicator""=dword:00000000
""VKToggleMicrophoneCapture""=dword:00000000
""VKMToggleMicrophoneCapture""=dword:00000000
""VKToggleCameraCapture""=dword:00000000
""VKMToggleCameraCapture""=dword:00000000
""VKToggleBroadcast""=dword:00000000
""VKMToggleBroadcast""=dword:00000000
""MicrophoneCaptureEnabled""=dword:00000000
""SystemAudioGain""=hex(b):10,27,00,00,00,00,00,00
""MicrophoneGain""=hex(b):10,27,00,00,00,00,00,00
[HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\location]
""Value""=""Deny""
[HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\webcam]
""Value""=""Allow""
[Computer\HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\microphone]
""Value""=""Allow""
[HKEY_CURRENT_USER\Software\Microsoft\Speech_OneCore\Settings\VoiceActivation\UserPreferenceForAllApps]
""AgentActivationEnabled""=dword:00000000
[HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\userNotificationListener]
""Value""=""Deny""
[HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\userAccountInformation]
""Value""=""Deny""
[HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\contacts]
""Value""=""Deny""
[HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\appointments]
""Value""=""Deny""
[HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\phoneCall]
""Value""=""Deny""
[HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\phoneCallHistory]
""Value""=""Deny""
[HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\email]
""Value""=""Deny""
[HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\userDataTasks]
""Value""=""Deny""
[HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\chat]
""Value""=""Deny""
[HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\radios]
""Value""=""Deny""
[HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\bluetoothSync]
""Value""=""Deny"" 
[HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\appDiagnostics]
""Value""=""Deny""
[HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\documentsLibrary]
""Value""=""Deny""
[HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\downloadsFolder]
""Value""=""Deny""
[HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\musicLibrary]
""Value""=""Deny""
[HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\picturesLibrary]
""Value""=""Deny""
[HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\videosLibrary]
""Value""=""Deny""
[HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\broadFileSystemAccess]
""Value""=""Deny""
[HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\graphicsCaptureWithoutBorder]
""Value""=""Deny""
[HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\graphicsCaptureProgrammatic]
""Value""=""Allow""
[HKEY_CURRENT_USER\Control Panel\International\User Profile]
""HttpAcceptLanguageOptOut""=dword:00000001
[HKEY_CURRENT_USER\Software\Policies\Microsoft\Windows\EdgeUI]
""DisableMFUTracking""=dword:00000001
[HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\EdgeUI]
""DisableMFUTracking""=dword:00000001
[HKEY_CURRENT_USER\Software\Microsoft\InputPersonalization]
""RestrictImplicitInkCollection""=dword:00000001
""RestrictImplicitTextCollection""=dword:00000001
[HKEY_CURRENT_USER\Software\Microsoft\InputPersonalization\TrainedDataStore]
""HarvestContacts""=dword:00000000
[HKEY_CURRENT_USER\Software\Microsoft\Personalization\Settings]
""AcceptedPrivacyPolicy""=dword:00000000
[HKEY_CURRENT_USER\SOFTWARE\Microsoft\Siuf\Rules]
""NumberOfSIUFInPeriod""=dword:00000000
""PeriodInNanoSeconds""=-
[HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\System]
""PublishUserActivities""=dword:00000000
[HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\SearchSettings]
""SafeSearchMode""=dword:00000000
[HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\SearchSettings]
""IsAADCloudSearchEnabled""=dword:00000000
[HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\SearchSettings]
""IsMSACloudSearchEnabled""=dword:00000000
[HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\PushNotifications]
""ToastEnabled""=dword:00000000
[HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Notifications\Settings\Windows.SystemToast.SecurityAndMaintenance]
""Enabled""=dword:00000000
[HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Notifications\Settings\windows.immersivecontrolpanel_cw5n1h2txyewy!microsoft.windows.immersivecontrolpanel]
""Enabled""=dword:00000000
[HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Notifications\Settings\Windows.SystemToast.CapabilityAccess]
""Enabled""=dword:00000000
[HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Notifications\Settings\Windows.SystemToast.StartupApp]
""Enabled""=dword:00000000
[HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager]
""SubscribedContent-338389Enabled""=dword:00000000
[HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\CloudStore\Store\Cache\DefaultAccount\$$windows.data.notifications.quiethourssettings\Current]
""Data""=hex(3):02,00,00,00,B4,67,2B,68,F0,0B,D8,01,00,00,00,00,43,42,01,00,\
C2,0A,01,D2,14,28,4D,00,69,00,63,00,72,00,6F,00,73,00,6F,00,66,00,74,00,2E,\
00,51,00,75,00,69,00,65,00,74,00,48,00,6F,00,75,00,72,00,73,00,50,00,72,00,\
6F,00,66,00,69,00,6C,00,65,00,2E,00,55,00,6E,00,72,00,65,00,73,00,74,00,72,\
00,69,00,63,00,74,00,65,00,64,00,CA,28,D0,14,02,00,00
[HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\CloudStore\Store\Cache\DefaultAccount\$quietmomentfullscreen$windows.data.notifications.quietmoment\Current]
""Data""=hex(3):02,00,00,00,97,1D,2D,68,F0,0B,D8,01,00,00,00,00,43,42,01,00,\
C2,0A,01,D2,1E,26,4D,00,69,00,63,00,72,00,6F,00,73,00,6F,00,66,00,74,00,2E,\
00,51,00,75,00,69,00,65,00,74,00,48,00,6F,00,75,00,72,00,73,00,50,00,72,00,\
6F,00,66,00,69,00,6C,00,65,00,2E,00,41,00,6C,00,61,00,72,00,6D,00,73,00,4F,\
00,6E,00,6C,00,79,00,C2,28,01,CA,50,00,00
[HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\CloudStore\Store\Cache\DefaultAccount\$quietmomentgame$windows.data.notifications.quietmoment\Current]
""Data""=hex(3):02,00,00,00,6C,39,2D,68,F0,0B,D8,01,00,00,00,00,43,42,01,00,\
C2,0A,01,D2,1E,28,4D,00,69,00,63,00,72,00,6F,00,73,00,6F,00,66,00,74,00,2E,\
00,51,00,75,00,69,00,65,00,74,00,48,00,6F,00,75,00,72,00,73,00,50,00,72,00,\
6F,00,66,00,69,00,6C,00,65,00,2E,00,50,00,72,00,69,00,6F,00,72,00,69,00,74,\
00,79,00,4F,00,6E,00,6C,00,79,00,C2,28,01,CA,50,00,00
[HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\CloudStore\Store\Cache\DefaultAccount\$quietmomentpostoobe$windows.data.notifications.quietmoment\Current]
""Data""=hex(3):02,00,00,00,06,54,2D,68,F0,0B,D8,01,00,00,00,00,43,42,01,00,\
C2,0A,01,D2,1E,28,4D,00,69,00,63,00,72,00,6F,00,73,00,6F,00,66,00,74,00,2E,\
00,51,00,75,00,69,00,65,00,74,00,48,00,6F,00,75,00,72,00,73,00,50,00,72,00,\
6F,00,66,00,69,00,6C,00,65,00,2E,00,50,00,72,00,69,00,6F,00,72,00,69,00,74,\
00,79,00,4F,00,6E,00,6C,00,79,00,C2,28,01,CA,50,00,00
[HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\CloudStore\Store\Cache\DefaultAccount\$quietmomentpresentation$windows.data.notifications.quietmoment\Current]
""Data""=hex(3):02,00,00,00,83,6E,2D,68,F0,0B,D8,01,00,00,00,00,43,42,01,00,\
C2,0A,01,D2,1E,26,4D,00,69,00,63,00,72,00,6F,00,73,00,6F,00,66,00,74,00,2E,\
00,51,00,75,00,69,00,65,00,74,00,48,00,6F,00,75,00,72,00,73,00,50,00,72,00,\
6F,00,66,00,69,00,6C,00,65,00,2E,00,41,00,6C,00,61,00,72,00,6D,00,73,00,4F,\
00,6E,00,6C,00,79,00,C2,28,01,CA,50,00,00
[HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\CloudStore\Store\Cache\DefaultAccount\$quietmomentscheduled$windows.data.notifications.quietmoment\Current]
""Data""=hex(3):02,00,00,00,2E,8A,2D,68,F0,0B,D8,01,00,00,00,00,43,42,01,00,\
C2,0A,01,D2,1E,28,4D,00,69,00,63,00,72,00,6F,00,73,00,6F,00,66,00,74,00,2E,\
00,51,00,75,00,69,00,65,00,74,00,48,00,6F,00,75,00,72,00,73,00,50,00,72,00,\
6F,00,66,00,69,00,6C,00,65,00,2E,00,50,00,72,00,69,00,6F,00,72,00,69,00,74,\
00,79,00,4F,00,6E,00,6C,00,79,00,C2,28,01,D1,32,80,E0,AA,8A,99,30,D1,3C,80,\
E0,F6,C5,D5,0E,CA,50,00,00
[HKEY_CURRENT_USER\Software\Microsoft\Narrator\NoRoam]
""DuckAudio""=dword:00000000
""WinEnterLaunchEnabled""=dword:00000000
""ScriptingEnabled""=dword:00000000
""OnlineServicesEnabled""=dword:00000000
[HKEY_CURRENT_USER\Software\Microsoft\Narrator]
""NarratorCursorHighlight""=dword:00000000
""CoupleNarratorCursorKeyboard""=dword:00000000
[HKEY_CURRENT_USER\Software\Microsoft\Ease of Access]
""selfvoice""=dword:00000000
""selfscan""=dword:00000000
[HKEY_CURRENT_USER\Control Panel\Accessibility]
""Sound on Activation""=dword:00000000
""Warning Sounds""=dword:00000000
[HKEY_CURRENT_USER\Control Panel\Accessibility\HighContrast]
""Flags""=""4194""
[HKEY_CURRENT_USER\Control Panel\Accessibility\Keyboard Response]
""Flags""=""2""
""AutoRepeatRate""=""0""
""AutoRepeatDelay""=""0""
[HKEY_CURRENT_USER\Control Panel\Accessibility\MouseKeys]
""Flags""=""130""
""MaximumSpeed""=""39""
""TimeToMaximumSpeed""=""3000""
[HKEY_CURRENT_USER\Control Panel\Accessibility\StickyKeys]
""Flags""=""2""
[HKEY_CURRENT_USER\Control Panel\Accessibility\ToggleKeys]
""Flags""=""34""
[HKEY_CURRENT_USER\Control Panel\Accessibility\SoundSentry]
""Flags""=""0""
""FSTextEffect""=""0""
""TextEffect""=""0""
""WindowsEffect""=""0""
[HKEY_CURRENT_USER\Control Panel\Accessibility\SlateLaunch]
""ATapp""=""""
""LaunchAT""=dword:00000000
[HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\DriverSearching]
""SearchOrderConfig""=dword:00000000
[HKEY_CURRENT_USER\Software\NVIDIA Corporation\NvTray]
""StartOnLogin""=dword:00000000
[HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Schedule\Maintenance]
""MaintenanceDisabled""=dword:00000001
[HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\BackgroundAccessApplications] 
""GlobalUserDisabled""=dword:00000001
[HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System]
""DisableAutomaticRestartSignOn""=dword:00000001
[HKEY_LOCAL_MACHINE\SYSTEM\Maps]
""AutoUpdateEnabled""=dword:00000000
[HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced]
""MultiTaskingAltTabFilter""=dword:00000003";
    public const string RawBasicsOptimizationsW10 = @"[HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\PowerShell\1\ShellIds\Microsoft.PowerShell]
""Path""=""C:\\Windows\\System32\\WindowsPowerShell\\v1.0\\powershell.exe""
""ExecutionPolicy""=""RemoteSigned""
[HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Microsoft\PowerShell\1\ShellIds\Microsoft.PowerShell]
""Path""=""C:\\Windows\\SysWOW64\\WindowsPowerShell\\v1.0\\powershell.exe""
""ExecutionPolicy""=""RemoteSigned""
[HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Edge]
""StartupBoostEnabled""=dword:00000000
""HardwareAccelerationModeEnabled""=dword:00000000
""BackgroundModeEnabled""=dword:00000000
[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\MicrosoftEdgeElevationService]
""Start""=dword:00000004
[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\edgeupdate]
""Start""=dword:00000004
[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\edgeupdatem]
""Start""=dword:00000004
[HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Google\Chrome]
""StartupBoostEnabled""=dword:00000000
""HardwareAccelerationModeEnabled""=dword:00000000
""BackgroundModeEnabled""=dword:00000000
[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\GoogleChromeElevationService]
""Start""=dword:00000004
[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\gupdate]
""Start""=dword:00000004
[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\gupdatem]
""Start""=dword:00000004
[HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\WindowsStore]
""AutoDownload""=dword:00000002
[HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced]
""TaskbarMn""=dword:00000000
[HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced]
""ShowTaskViewButton""=dword:00000000
[HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Search]
""SearchboxTaskbarMode""=dword:00000000
[HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer]
""HideSCAMeetNow""=dword:00000001
[HKEY_CURRENT_USER\SOFTWARE\Policies\Microsoft\Windows\Explorer]
""DisableNotificationCenter""=dword:00000001
[HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Windows Feeds]
""EnableFeeds""=dword:00000000
[-HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Taskband]
[HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Taskband\AuxilliaryPins]
[HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer]
""EnableAutoTray""=dword:00000000
[HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Explorer]
""ShowOrHideMostUsedApps""=dword:00000002
[HKEY_CURRENT_USER\SOFTWARE\Policies\Microsoft\Windows\Explorer]
""ShowOrHideMostUsedApps""=-
[HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer]
""NoStartMenuMFUprogramsList""=-
""NoInstrumentation""=-
[HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\Explorer]
""NoStartMenuMFUprogramsList""=-
""NoInstrumentation""=-
[HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Explorer]
""HideRecentlyAddedApps""=dword:00000001
[HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\Explorer]
""HideRecentlyAddedApps""=dword:00000001
; Disable show recently opened items in start, jump lists and file explorer
[HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced]
""Start_TrackDocs""=dword:00000000 
[HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced]
""LaunchTo""=dword:00000001
[HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer]
""ShowFrequent""=dword:00000000
[HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced]
""HideFileExt""=dword:00000000
[HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\SearchSettings]
""IsDeviceSearchHistoryEnabled""=dword:00000000
[HKEY_CURRENT_USER\Control Panel\Desktop]
""MenuShowDelay""=""0""
[HKEY_CURRENT_USER\Software\Classes\CLSID\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}\InprocServer32]
@=""""
[HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Themes\Personalize]
""AppsUseLightTheme""=dword:00000000
""SystemUsesLightTheme""=dword:00000000
[HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Themes\Personalize]
""AppsUseLightTheme""=dword:00000000
[HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Accent]
""StartColorMenu""=dword:ff3d3f41
""AccentColorMenu""=dword:ff484a4c
""AccentPalette""=hex(3):DF,DE,DC,00,A6,A5,A1,00,68,65,62,00,4C,4A,48,00,41,\
3F,3D,00,27,25,24,00,10,0D,0D,00,10,7C,10,00
[HKEY_CURRENT_USER\Software\Microsoft\Windows\DWM]
""EnableWindowColorization""=dword:00000001
""AccentColor""=dword:ff484a4c
""ColorizationColor""=dword:c44c4a48
""ColorizationAfterglow""=dword:c44c4a48
[HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Dsh] 
""AllowNewsAndInterests""=dword:00000000
[HKEY_CURRENT_USER\Control Panel\Desktop]
""LogPixels""=dword:00000096
""Win8DpiScaling""=dword:00000000
[HKEY_CURRENT_USER\Control Panel\Desktop]
""EnablePerProcessSystemDPI""=dword:00000000
[-HKEY_CURRENT_USER\Control Panel\Desktop\PerMonitorSettings]
[HKEY_CURRENT_USER\Control Panel\Desktop\WindowMetrics]
""AppliedDPI""=dword:00000096
[HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize]
""EnableTransparency""=dword:00000000
[HKEY_CURRENT_USER\Software\Microsoft\Multimedia\Audio]
""UserDuckingPreference""=dword:00000003
[HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\Authentication\LogonUI\BootAnimation]
""DisableStartupSound""=dword:00000001
[HKEY_CURRENT_USER\AppEvents\Schemes]
@="".None""
[-HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\.Default\.Current]
[HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\.Default\.Current]
[-HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\CriticalBatteryAlarm\.Current]
[HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\CriticalBatteryAlarm\.Current]
[-HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\DeviceConnect\.Current]
[HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\DeviceConnect\.Current]
[-HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\DeviceDisconnect\.Current]
[HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\DeviceDisconnect\.Current]
[-HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\DeviceFail\.Current]
[HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\DeviceFail\.Current]
[-HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\FaxBeep\.Current]
[HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\FaxBeep\.Current]
[-HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\LowBatteryAlarm\.Current]
[HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\LowBatteryAlarm\.Current]
[-HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\MailBeep\.Current]
[HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\MailBeep\.Current]
[-HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\MessageNudge\.Current]
[HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\MessageNudge\.Current]
[-HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\Notification.Default\.Current]
[HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\Notification.Default\.Current]
[-HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\Notification.IM\.Current]
[HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\Notification.IM\.Current]
[-HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\Notification.Mail\.Current]
[HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\Notification.Mail\.Current]
[-HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\Notification.Proximity\.Current]
[HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\Notification.Proximity\.Current]
[-HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\Notification.Reminder\.Current]
[HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\Notification.Reminder\.Current]
[-HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\Notification.SMS\.Current]
[HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\Notification.SMS\.Current]
[-HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\ProximityConnection\.Current]
[HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\ProximityConnection\.Current]
[-HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\SystemAsterisk\.Current]
[HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\SystemAsterisk\.Current]
[-HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\SystemExclamation\.Current]
[HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\SystemExclamation\.Current]
[-HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\SystemHand\.Current]
[HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\SystemHand\.Current]
[-HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\SystemNotification\.Current]
[HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\SystemNotification\.Current]
[-HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\WindowsUAC\.Current]
[HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\WindowsUAC\.Current]
[-HKEY_CURRENT_USER\AppEvents\Schemes\Apps\sapisvr\DisNumbersSound\.current]
[HKEY_CURRENT_USER\AppEvents\Schemes\Apps\sapisvr\DisNumbersSound\.current]
[-HKEY_CURRENT_USER\AppEvents\Schemes\Apps\sapisvr\HubOffSound\.current]
[HKEY_CURRENT_USER\AppEvents\Schemes\Apps\sapisvr\HubOffSound\.current]
[-HKEY_CURRENT_USER\AppEvents\Schemes\Apps\sapisvr\HubOnSound\.current]
[HKEY_CURRENT_USER\AppEvents\Schemes\Apps\sapisvr\HubOnSound\.current]
[-HKEY_CURRENT_USER\AppEvents\Schemes\Apps\sapisvr\HubSleepSound\.current]
[HKEY_CURRENT_USER\AppEvents\Schemes\Apps\sapisvr\HubSleepSound\.current]
[-HKEY_CURRENT_USER\AppEvents\Schemes\Apps\sapisvr\MisrecoSound\.current]
[HKEY_CURRENT_USER\AppEvents\Schemes\Apps\sapisvr\MisrecoSound\.current]
[-HKEY_CURRENT_USER\AppEvents\Schemes\Apps\sapisvr\PanelSound\.current]
[HKEY_CURRENT_USER\AppEvents\Schemes\Apps\sapisvr\PanelSound\.current]
[HKEY_CURRENT_USER\Control Panel\Mouse]
""MouseSpeed""=""0""
""MouseThreshold1""=""0""
""MouseThreshold2""=""0""
[HKEY_CURRENT_USER\Control Panel\Cursors]
""AppStarting""=hex(2):00,00
""Arrow""=hex(2):00,00
""ContactVisualization""=dword:00000000
""Crosshair""=hex(2):00,00
""GestureVisualization""=dword:00000000
""Hand""=hex(2):00,00
""Help""=hex(2):00,00
""IBeam""=hex(2):00,00
""No""=hex(2):00,00
""NWPen""=hex(2):00,00
""Scheme Source""=dword:00000000
""SizeAll""=hex(2):00,00
""SizeNESW""=hex(2):00,00
""SizeNS""=hex(2):00,00
""SizeNWSE""=hex(2):00,00
""SizeWE""=hex(2):00,00
""UpArrow""=hex(2):00,00
""Wait""=hex(2):00,00
@=""""
[-HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run]
[-HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Run]
[HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Run]
""ctfmon""=""C:\\Windows\\System32\\ctfmon.exe""
[-HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Schedule\TaskCache\Tree]
[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\Origin Client Service]
""Start""=dword:00000004
[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\Origin Web Helper Service]
""Start""=dword:00000004
[HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\Explorer\FlyoutMenuSettings]
""ShowLockOption""=dword:00000000
[HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\FlyoutMenuSettings]
""ShowSleepOption""=dword:00000000
[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Power]
""HibernateEnabled""=dword:00000000
[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Power\PowerThrottling]
""PowerThrottlingOff""=dword:00000001
[HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile]
""NetworkThrottlingIndex""=dword:ffffffff
""SystemResponsiveness""=dword:00000000
[HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile\Tasks\Games]
""Affinity""=dword:00000000
""Background Only""=""False""
""Clock Rate""=dword:00002710
""GPU Priority""=dword:00000008
""Priority""=dword:00000006
""Scheduling Category""=""High""
""SFIO Priority""=""High""
[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\GraphicsDrivers]
""HwSchMode""=dword:00000002
[HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\VideoSettings]
""VideoQualityOnBattery""=dword:00000001
[HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\VisualEffects]
""VisualFXSetting""=dword:3
[HKEY_CURRENT_USER\Control Panel\Desktop]
""UserPreferencesMask""=hex(2):90,12,03,80,10,00,00,00
[HKEY_CURRENT_USER\Control Panel\Desktop\WindowMetrics]
""MinAnimate""=""0""
[HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced]
""TaskbarAnimations""=dword:0
[HKEY_CURRENT_USER\Software\Microsoft\Windows\DWM]
""EnableAeroPeek""=dword:0
[HKEY_CURRENT_USER\Software\Microsoft\Windows\DWM]
""AlwaysHibernateThumbnails""=dword:0
[HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced]
""IconsOnly""=dword:0
[HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced]
""ListviewAlphaSelect""=dword:0
[HKEY_CURRENT_USER\Control Panel\Desktop]
""DragFullWindows""=""0""
[HKEY_CURRENT_USER\Control Panel\Desktop]
""FontSmoothing""=""2""
[HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced]
""ListviewShadow""=dword:0
[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\PriorityControl]
""Win32PrioritySeparation""=dword:00000026
[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Remote Assistance]
""fAllowToGetHelp""=dword:00000000
[HKEY_CURRENT_USER\System\GameConfigStore]
""GameDVR_Enabled""=dword:00000000
[HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\GameDVR]
""AppCaptureEnabled""=dword:00000000
[HKEY_CURRENT_USER\Software\Microsoft\GameBar]
""UseNexusForGameBarEnabled""=dword:00000000
[HKEY_CURRENT_USER\Software\Microsoft\GameBar]
""AutoGameModeEnabled""=dword:00000001
[HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\GameDVR]
""AudioEncodingBitrate""=dword:0001f400
""AudioCaptureEnabled""=dword:00000000
""CustomVideoEncodingBitrate""=dword:003d0900
""CustomVideoEncodingHeight""=dword:000002d0
""CustomVideoEncodingWidth""=dword:00000500
""HistoricalBufferLength""=dword:0000001e
""HistoricalBufferLengthUnit""=dword:00000001
""HistoricalCaptureEnabled""=dword:00000000
""HistoricalCaptureOnBatteryAllowed""=dword:00000001
""HistoricalCaptureOnWirelessDisplayAllowed""=dword:00000001
""MaximumRecordLength""=hex(b):00,D0,88,C3,10,00,00,00
""VideoEncodingBitrateMode""=dword:00000002
""VideoEncodingResolutionMode""=dword:00000002
""VideoEncodingFrameRateMode""=dword:00000000
""EchoCancellationEnabled""=dword:00000001
""CursorCaptureEnabled""=dword:00000000
""VKToggleGameBar""=dword:00000000
""VKMToggleGameBar""=dword:00000000
""VKSaveHistoricalVideo""=dword:00000000
""VKMSaveHistoricalVideo""=dword:00000000
""VKToggleRecording""=dword:00000000
""VKMToggleRecording""=dword:00000000
""VKTakeScreenshot""=dword:00000000
""VKMTakeScreenshot""=dword:00000000
""VKToggleRecordingIndicator""=dword:00000000
""VKMToggleRecordingIndicator""=dword:00000000
""VKToggleMicrophoneCapture""=dword:00000000
""VKMToggleMicrophoneCapture""=dword:00000000
""VKToggleCameraCapture""=dword:00000000
""VKMToggleCameraCapture""=dword:00000000
""VKToggleBroadcast""=dword:00000000
""VKMToggleBroadcast""=dword:00000000
""MicrophoneCaptureEnabled""=dword:00000000
""SystemAudioGain""=hex(b):10,27,00,00,00,00,00,00
""MicrophoneGain""=hex(b):10,27,00,00,00,00,00,00
[HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\location]
""Value""=""Deny""
[HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\webcam]
""Value""=""Allow""
[Computer\HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\microphone]
""Value""=""Allow""
[HKEY_CURRENT_USER\Software\Microsoft\Speech_OneCore\Settings\VoiceActivation\UserPreferenceForAllApps]
""AgentActivationEnabled""=dword:00000000
[HKEY_CURRENT_USER\SOFTWARE\Microsoft\Speech_OneCore\Settings\VoiceActivation\UserPreferenceForAllApps]
""AgentActivationLastUsed""=dword:00000000
[HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\userNotificationListener]
""Value""=""Deny""
[HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\userAccountInformation]
""Value""=""Deny""
[HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\contacts]
""Value""=""Deny""
[HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\appointments]
""Value""=""Deny""
[HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\phoneCall]
""Value""=""Deny""
[HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\phoneCallHistory]
""Value""=""Deny""
[HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\email]
""Value""=""Deny""
[HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\userDataTasks]
""Value""=""Deny""
[HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\chat]
""Value""=""Deny""
[HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\radios]
""Value""=""Deny""
[HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\bluetoothSync]
""Value""=""Deny""
[HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\appDiagnostics]
""Value""=""Deny""
[HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\documentsLibrary]
""Value""=""Deny"" 
[HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\downloadsFolder]
""Value""=""Deny""
[HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\musicLibrary]
""Value""=""Deny""
[HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\picturesLibrary]
""Value""=""Deny""
[HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\videosLibrary]
""Value""=""Deny""
[HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\broadFileSystemAccess]
""Value""=""Deny""
[HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\graphicsCaptureWithoutBorder]
""Value""=""Deny""
[HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\graphicsCaptureProgrammatic]
""Value""=""Allow""
[HKEY_CURRENT_USER\Control Panel\International\User Profile]
""HttpAcceptLanguageOptOut""=dword:00000001
[HKEY_CURRENT_USER\Software\Policies\Microsoft\Windows\EdgeUI]
""DisableMFUTracking""=dword:00000001
[HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\EdgeUI]
""DisableMFUTracking""=dword:00000001
[HKEY_CURRENT_USER\Software\Microsoft\InputPersonalization]
""RestrictImplicitInkCollection""=dword:00000001
""RestrictImplicitTextCollection""=dword:00000001
[HKEY_CURRENT_USER\Software\Microsoft\InputPersonalization\TrainedDataStore]
""HarvestContacts""=dword:00000000
[HKEY_CURRENT_USER\Software\Microsoft\Personalization\Settings]
""AcceptedPrivacyPolicy""=dword:00000000
[HKEY_CURRENT_USER\SOFTWARE\Microsoft\Siuf\Rules]
""NumberOfSIUFInPeriod""=dword:00000000
""PeriodInNanoSeconds""=-
[HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\System]
""PublishUserActivities""=dword:00000000
[HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\SearchSettings]
""SafeSearchMode""=dword:00000000
[HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\SearchSettings]
""IsAADCloudSearchEnabled""=dword:00000000
[HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\SearchSettings]
""IsMSACloudSearchEnabled""=dword:00000000
[HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\PushNotifications]
""ToastEnabled""=dword:00000000
[HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Notifications\Settings\Windows.SystemToast.SecurityAndMaintenance]
""Enabled""=dword:00000000
[HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Notifications\Settings\windows.immersivecontrolpanel_cw5n1h2txyewy!microsoft.windows.immersivecontrolpanel]
""Enabled""=dword:00000000
[HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Notifications\Settings\Windows.SystemToast.CapabilityAccess]
""Enabled""=dword:00000000
[HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Notifications\Settings\Windows.SystemToast.StartupApp]
""Enabled""=dword:00000000
[HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager]
""SubscribedContent-338389Enabled""=dword:00000000
[HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\CloudStore\Store\Cache\DefaultAccount\$$windows.data.notifications.quiethourssettings\Current]
""Data""=hex(3):02,00,00,00,B4,67,2B,68,F0,0B,D8,01,00,00,00,00,43,42,01,00,\
C2,0A,01,D2,14,28,4D,00,69,00,63,00,72,00,6F,00,73,00,6F,00,66,00,74,00,2E,\
00,51,00,75,00,69,00,65,00,74,00,48,00,6F,00,75,00,72,00,73,00,50,00,72,00,\
6F,00,66,00,69,00,6C,00,65,00,2E,00,55,00,6E,00,72,00,65,00,73,00,74,00,72,\
00,69,00,63,00,74,00,65,00,64,00,CA,28,D0,14,02,00,00
[HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\CloudStore\Store\Cache\DefaultAccount\$quietmomentfullscreen$windows.data.notifications.quietmoment\Current]
""Data""=hex(3):02,00,00,00,97,1D,2D,68,F0,0B,D8,01,00,00,00,00,43,42,01,00,\
C2,0A,01,D2,1E,26,4D,00,69,00,63,00,72,00,6F,00,73,00,6F,00,66,00,74,00,2E,\
00,51,00,75,00,69,00,65,00,74,00,48,00,6F,00,75,00,72,00,73,00,50,00,72,00,\
6F,00,66,00,69,00,6C,00,65,00,2E,00,41,00,6C,00,61,00,72,00,6D,00,73,00,4F,\
00,6E,00,6C,00,79,00,C2,28,01,CA,50,00,00
[HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\CloudStore\Store\Cache\DefaultAccount\$quietmomentgame$windows.data.notifications.quietmoment\Current]
""Data""=hex(3):02,00,00,00,6C,39,2D,68,F0,0B,D8,01,00,00,00,00,43,42,01,00,\
C2,0A,01,D2,1E,28,4D,00,69,00,63,00,72,00,6F,00,73,00,6F,00,66,00,74,00,2E,\
00,51,00,75,00,69,00,65,00,74,00,48,00,6F,00,75,00,72,00,73,00,50,00,72,00,\
6F,00,66,00,69,00,6C,00,65,00,2E,00,50,00,72,00,69,00,6F,00,72,00,69,00,74,\
00,79,00,4F,00,6E,00,6C,00,79,00,C2,28,01,CA,50,00,00
[HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\CloudStore\Store\Cache\DefaultAccount\$quietmomentpostoobe$windows.data.notifications.quietmoment\Current]
""Data""=hex(3):02,00,00,00,06,54,2D,68,F0,0B,D8,01,00,00,00,00,43,42,01,00,\
C2,0A,01,D2,1E,28,4D,00,69,00,63,00,72,00,6F,00,73,00,6F,00,66,00,74,00,2E,\
00,51,00,75,00,69,00,65,00,74,00,48,00,6F,00,75,00,72,00,73,00,50,00,72,00,\
6F,00,66,00,69,00,6C,00,65,00,2E,00,50,00,72,00,69,00,6F,00,72,00,69,00,74,\
00,79,00,4F,00,6E,00,6C,00,79,00,C2,28,01,CA,50,00,00
[HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\CloudStore\Store\Cache\DefaultAccount\$quietmomentpresentation$windows.data.notifications.quietmoment\Current]
""Data""=hex(3):02,00,00,00,83,6E,2D,68,F0,0B,D8,01,00,00,00,00,43,42,01,00,\
C2,0A,01,D2,1E,26,4D,00,69,00,63,00,72,00,6F,00,73,00,6F,00,66,00,74,00,2E,\
00,51,00,75,00,69,00,65,00,74,00,48,00,6F,00,75,00,72,00,73,00,50,00,72,00,\
6F,00,66,00,69,00,6C,00,65,00,2E,00,41,00,6C,00,61,00,72,00,6D,00,73,00,4F,\
00,6E,00,6C,00,79,00,C2,28,01,CA,50,00,00
[HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\CloudStore\Store\Cache\DefaultAccount\$quietmomentscheduled$windows.data.notifications.quietmoment\Current]
""Data""=hex(3):02,00,00,00,2E,8A,2D,68,F0,0B,D8,01,00,00,00,00,43,42,01,00,\
C2,0A,01,D2,1E,28,4D,00,69,00,63,00,72,00,6F,00,73,00,6F,00,66,00,74,00,2E,\
00,51,00,75,00,69,00,65,00,74,00,48,00,6F,00,75,00,72,00,73,00,50,00,72,00,\
6F,00,66,00,69,00,6C,00,65,00,2E,00,50,00,72,00,69,00,6F,00,72,00,69,00,74,\
00,79,00,4F,00,6E,00,6C,00,79,00,C2,28,01,D1,32,80,E0,AA,8A,99,30,D1,3C,80,\
E0,F6,C5,D5,0E,CA,50,00,00
[HKEY_CURRENT_USER\SOFTWARE\Microsoft\ScreenMagnifier]
""FollowCaret""=dword:00000000
""FollowNarrator""=dword:00000000
""FollowMouse""=dword:00000000
""FollowFocus""=dword:00000000
[HKEY_CURRENT_USER\SOFTWARE\Microsoft\Narrator]
""IntonationPause""=dword:00000000
""ReadHints""=dword:00000000
""ErrorNotificationType""=dword:00000000
""EchoChars""=dword:00000000
""EchoWords""=dword:00000000
[HKEY_CURRENT_USER\SOFTWARE\Microsoft\Narrator\NarratorHome]
""MinimizeType""=dword:00000000
""AutoStart""=dword:00000000
[HKEY_CURRENT_USER\SOFTWARE\Microsoft\Narrator\NoRoam]
""EchoToggleKeys""=dword:00000000
[HKEY_CURRENT_USER\Software\Microsoft\Narrator\NoRoam]
""DuckAudio""=dword:00000000
""WinEnterLaunchEnabled""=dword:00000000
""ScriptingEnabled""=dword:00000000
""OnlineServicesEnabled""=dword:00000000
[HKEY_CURRENT_USER\Software\Microsoft\Narrator]
""NarratorCursorHighlight""=dword:00000000
""CoupleNarratorCursorKeyboard""=dword:00000000
[HKEY_CURRENT_USER\Software\Microsoft\Ease of Access]
""selfvoice""=dword:00000000
""selfscan""=dword:00000000
[HKEY_CURRENT_USER\Control Panel\Accessibility]
""Sound on Activation""=dword:00000000
""Warning Sounds""=dword:00000000
[HKEY_CURRENT_USER\Control Panel\Accessibility\HighContrast]
""Flags""=""4194""
[HKEY_CURRENT_USER\Control Panel\Accessibility\Keyboard Response]
""Flags""=""2""
""AutoRepeatRate""=""0""
""AutoRepeatDelay""=""0""
[HKEY_CURRENT_USER\Control Panel\Accessibility\MouseKeys]
""Flags""=""130""
""MaximumSpeed""=""39""
""TimeToMaximumSpeed""=""3000""
[HKEY_CURRENT_USER\Control Panel\Accessibility\StickyKeys]
""Flags""=""2""
[HKEY_CURRENT_USER\Control Panel\Accessibility\ToggleKeys]
""Flags""=""34""
[HKEY_CURRENT_USER\Control Panel\Accessibility\SoundSentry]
""Flags""=""0""
""FSTextEffect""=""0""
""TextEffect""=""0""
""WindowsEffect""=""0""
[HKEY_CURRENT_USER\Control Panel\Accessibility\SlateLaunch]
""ATapp""=""""
""LaunchAT""=dword:00000000
[HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\DriverSearching]
""SearchOrderConfig""=dword:00000000
[HKEY_CURRENT_USER\Software\NVIDIA Corporation\NvTray]
""StartOnLogin""=dword:00000000
[HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Schedule\Maintenance]
""MaintenanceDisabled""=dword:00000001
[HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\BackgroundAccessApplications] 
""GlobalUserDisabled""=dword:00000001
[HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System]
""DisableAutomaticRestartSignOn""=dword:00000001
[HKEY_LOCAL_MACHINE\SYSTEM\Maps]
""AutoUpdateEnabled""=dword:00000000
[HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced]
""MultiTaskingAltTabFilter""=dword:00000003
";
    #endregion
    #region Raw Hex 
    public const string _TITLE_BAR_6 = @"[HKEY_CURRENT_USER\Control Panel\Desktop\WindowMetrics]
""CaptionFont""=hex:f8,ff,ff,ff,00,00,00,00,00,00,00,00,00,00,00,00,90,01,00,00,00,\
  00,00,01,00,00,00,00,53,00,65,00,67,00,6f,00,65,00,20,00,55,00,49,00,00,00,\
  00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,\
  00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00
""CaptionHeight""=""-270""
""CaptionWidth""=""-270""";
    public const string _TITLE_BAR_6_BOLD = @"[HKEY_CURRENT_USER\Control Panel\Desktop\WindowMetrics]
""CaptionFont""=hex:f8,ff,ff,ff,00,00,00,00,00,00,00,00,00,00,00,00,bc,02,00,00,00,\
  00,00,01,00,00,00,00,53,00,65,00,67,00,6f,00,65,00,20,00,55,00,49,00,00,00,\
  00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,\
  00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00
""CaptionHeight""=""-270""
""CaptionWidth""=""-270""
";
    public const string _TITLE_BAR_7 = @"[HKEY_CURRENT_USER\Control Panel\Desktop\WindowMetrics]
""CaptionFont""=hex:f7,ff,ff,ff,00,00,00,00,00,00,00,00,00,00,00,00,90,01,00,00,00,\
  00,00,01,00,00,00,00,53,00,65,00,67,00,6f,00,65,00,20,00,55,00,49,00,00,00,\
  00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,\
  00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00
""CaptionHeight""=""-270""
""CaptionWidth""=""-270""";
    public const string _TITLE_BAR_7_BOLD = @"[HKEY_CURRENT_USER\Control Panel\Desktop\WindowMetrics]
""CaptionFont""=hex:f7,ff,ff,ff,00,00,00,00,00,00,00,00,00,00,00,00,bc,02,00,00,00,\
  00,00,01,00,00,00,00,53,00,65,00,67,00,6f,00,65,00,20,00,55,00,49,00,00,00,\
  00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,\
  00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00
""CaptionHeight""=""-270""
""CaptionWidth""=""-270""";
    public const string _TITLE_BAR_8 = @"
[HKEY_CURRENT_USER\Control Panel\Desktop\WindowMetrics]
""CaptionFont""=hex:f5,ff,ff,ff,00,00,00,00,00,00,00,00,00,00,00,00,90,01,00,00,00,\
  00,00,01,00,00,00,00,53,00,65,00,67,00,6f,00,65,00,20,00,55,00,49,00,00,00,\
  00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,\
  00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00
""CaptionHeight""=""-270""
""CaptionWidth""=""-270""";
    public const string _TITLE_BAR_8_BOLD = @"[HKEY_CURRENT_USER\Control Panel\Desktop\WindowMetrics]
""CaptionFont""=hex:f5,ff,ff,ff,00,00,00,00,00,00,00,00,00,00,00,00,bc,02,00,00,00,\
  00,00,01,00,00,00,00,53,00,65,00,67,00,6f,00,65,00,20,00,55,00,49,00,00,00,\
  00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,\
  00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00
""CaptionHeight""=""-270""
""CaptionWidth""=""-270""";
    public const string _TITLE_BAR_9 = @"[HKEY_CURRENT_USER\Control Panel\Desktop\WindowMetrics]
""CaptionFont""=hex:f4,ff,ff,ff,00,00,00,00,00,00,00,00,00,00,00,00,90,01,00,00,00,\
  00,00,01,00,00,00,00,53,00,65,00,67,00,6f,00,65,00,20,00,55,00,49,00,00,00,\
  00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,\
  00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00
""CaptionHeight""=""-285""
""CaptionWidth""=""-285""";
    public const string _TITLE_BAR_9_BOLD = @"[HKEY_CURRENT_USER\Control Panel\Desktop\WindowMetrics]
""CaptionFont""=hex:f4,ff,ff,ff,00,00,00,00,00,00,00,00,00,00,00,00,bc,02,00,00,00,\
  00,00,01,00,00,00,00,53,00,65,00,67,00,6f,00,65,00,20,00,55,00,49,00,00,00,\
  00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,\
  00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00
""CaptionHeight""=""-270""
""CaptionWidth""=""-270""";
    public const string _TITLE_BAR_10 = @"[HKEY_CURRENT_USER\Control Panel\Desktop\WindowMetrics]
""CaptionFont""=hex:f3,ff,ff,ff,00,00,00,00,00,00,00,00,00,00,00,00,90,01,00,00,00,\
  00,00,01,00,00,00,00,53,00,65,00,67,00,6f,00,65,00,20,00,55,00,49,00,00,00,\
  00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,\
  00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00
""CaptionHeight""=""-285""
""CaptionWidth""=""-285""";
    public const string _TITLE_BAR_10_BOLD = @"[HKEY_CURRENT_USER\Control Panel\Desktop\WindowMetrics]
""CaptionFont""=hex:f3,ff,ff,ff,00,00,00,00,00,00,00,00,00,00,00,00,bc,02,00,00,00,\
  00,00,01,00,00,00,00,53,00,65,00,67,00,6f,00,65,00,20,00,55,00,49,00,00,00,\
  00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,\
  00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00
""CaptionHeight""=""-285""
""CaptionWidth""=""-285""";
    public const string _TITLE_BAR_11 = @"[HKEY_CURRENT_USER\Control Panel\Desktop\WindowMetrics]
""CaptionFont""=hex:f1,ff,ff,ff,00,00,00,00,00,00,00,00,00,00,00,00,90,01,00,00,00,\
  00,00,01,00,00,00,00,53,00,65,00,67,00,6f,00,65,00,20,00,55,00,49,00,00,00,\
  00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,\
  00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00
""CaptionHeight""=""-330""
""CaptionWidth""=""-330""";
    public const string _TITLE_BAR_11_BOLD = @"[HKEY_CURRENT_USER\Control Panel\Desktop\WindowMetrics]
""CaptionFont""=hex:f1,ff,ff,ff,00,00,00,00,00,00,00,00,00,00,00,00,bc,02,00,00,00,\
  00,00,01,00,00,00,00,53,00,65,00,67,00,6f,00,65,00,20,00,55,00,49,00,00,00,\
  00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,\
  00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00
""CaptionHeight""=""-330""
""CaptionWidth""=""-330""";
    public const string _TITLE_BAR_12 = @"[HKEY_CURRENT_USER\Control Panel\Desktop\WindowMetrics]
""CaptionFont""=hex:f0,ff,ff,ff,00,00,00,00,00,00,00,00,00,00,00,00,90,01,00,00,00,\
  00,00,01,00,00,00,00,53,00,65,00,67,00,6f,00,65,00,20,00,55,00,49,00,00,00,\
  00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,\
  00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00
""CaptionHeight""=""-345""
""CaptionWidth""=""-345""";
    public const string _TITLE_BAR_12_BOLD = @"[HKEY_CURRENT_USER\Control Panel\Desktop\WindowMetrics]
""CaptionFont""=hex:f0,ff,ff,ff,00,00,00,00,00,00,00,00,00,00,00,00,bc,02,00,00,00,\
  00,00,01,00,00,00,00,53,00,65,00,67,00,6f,00,65,00,20,00,55,00,49,00,00,00,\
  00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,\
  00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00
""CaptionHeight""=""-345""
""CaptionWidth""=""-345""";
    public const string _TITLE_BAR_13 = @"[HKEY_CURRENT_USER\Control Panel\Desktop\WindowMetrics]
""CaptionFont""=hex:ef,ff,ff,ff,00,00,00,00,00,00,00,00,00,00,00,00,90,01,00,00,00,\
  00,00,01,00,00,00,00,53,00,65,00,67,00,6f,00,65,00,20,00,55,00,49,00,00,00,\
  00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,\
  00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00
""CaptionHeight""=""-375""
""CaptionWidth""=""-375""";
    public const string _TITLE_BAR_13_BOLD = @"[HKEY_CURRENT_USER\Control Panel\Desktop\WindowMetrics]
""CaptionFont""=hex:ef,ff,ff,ff,00,00,00,00,00,00,00,00,00,00,00,00,bc,02,00,00,00,\
  00,00,01,00,00,00,00,53,00,65,00,67,00,6f,00,65,00,20,00,55,00,49,00,00,00,\
  00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,\
  00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00
""CaptionHeight""=""-375""
""CaptionWidth""=""-375""";
    public const string _TITLE_BAR_14 = @"[HKEY_CURRENT_USER\Control Panel\Desktop\WindowMetrics]
""CaptionFont""=hex:ed,ff,ff,ff,00,00,00,00,00,00,00,00,00,00,00,00,90,01,00,00,00,\
  00,00,01,00,00,00,00,53,00,65,00,67,00,6f,00,65,00,20,00,55,00,49,00,00,00,\
  00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,\
  00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00
""CaptionHeight""=""-405""
""CaptionWidth""=""-405""";
    public const string _TITLE_BAR_14_BOLD = @"[HKEY_CURRENT_USER\Control Panel\Desktop\WindowMetrics]
""CaptionFont""=hex:ed,ff,ff,ff,00,00,00,00,00,00,00,00,00,00,00,00,bc,02,00,00,00,\
  00,00,01,00,00,00,00,53,00,65,00,67,00,6f,00,65,00,20,00,55,00,49,00,00,00,\
  00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,\
  00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00
""CaptionHeight""=""-405""
""CaptionWidth""=""-405""";
    public const string _TITLE_BAR_15 = @"[HKEY_CURRENT_USER\Control Panel\Desktop\WindowMetrics]
""CaptionFont""=hex:ec,ff,ff,ff,00,00,00,00,00,00,00,00,00,00,00,00,90,01,00,00,00,\
  00,00,01,00,00,00,00,53,00,65,00,67,00,6f,00,65,00,20,00,55,00,49,00,00,00,\
  00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,\
  00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00
""CaptionHeight""=""-450""
""CaptionWidth""=""-450""";
    public const string _TITLE_BAR_15_BOLD = @"
[HKEY_CURRENT_USER\Control Panel\Desktop\WindowMetrics]
""CaptionFont""=hex:ec,ff,ff,ff,00,00,00,00,00,00,00,00,00,00,00,00,bc,02,00,00,00,\
  00,00,01,00,00,00,00,53,00,65,00,67,00,6f,00,65,00,20,00,55,00,49,00,00,00,\
  00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,\
  00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00
""CaptionHeight""=""-450""
""CaptionWidth""=""-450""";
    public const string _TITLE_BAR_16 = @"[HKEY_CURRENT_USER\Control Panel\Desktop\WindowMetrics]
""CaptionFont""=hex:eb,ff,ff,ff,00,00,00,00,00,00,00,00,00,00,00,00,90,01,00,00,00,\
  00,00,01,00,00,00,00,53,00,65,00,67,00,6f,00,65,00,20,00,55,00,49,00,00,00,\
  00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,\
  00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00
""CaptionHeight""=""-480""
""CaptionWidth""=""-480""";
    public const string _TITLE_BAR_16_BOLD = @"[HKEY_CURRENT_USER\Control Panel\Desktop\WindowMetrics]
""CaptionFont""=hex:eb,ff,ff,ff,00,00,00,00,00,00,00,00,00,00,00,00,bc,02,00,00,00,\
  00,00,01,00,00,00,00,53,00,65,00,67,00,6f,00,65,00,20,00,55,00,49,00,00,00,\
  00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,\
  00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00
""CaptionHeight""=""-480""
""CaptionWidth""=""-480""";
    public const string _TITLE_BAR_17 = @"[HKEY_CURRENT_USER\Control Panel\Desktop\WindowMetrics]
""CaptionFont""=hex:e9,ff,ff,ff,00,00,00,00,00,00,00,00,00,00,00,00,90,01,00,00,00,\
  00,00,01,00,00,00,00,53,00,65,00,67,00,6f,00,65,00,20,00,55,00,49,00,00,00,\
  00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,\
  00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00
""CaptionHeight""=""-495""
""CaptionWidth""=""-495""";
    public const string _TITLE_BAR_17_BOLD = @"[HKEY_CURRENT_USER\Control Panel\Desktop\WindowMetrics]
""CaptionFont""=hex:e9,ff,ff,ff,00,00,00,00,00,00,00,00,00,00,00,00,bc,02,00,00,00,\
  00,00,01,00,00,00,00,53,00,65,00,67,00,6f,00,65,00,20,00,55,00,49,00,00,00,\
  00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,\
  00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00
""CaptionHeight""=""-495""
""CaptionWidth""=""-495""";
    public const string _TITLE_BAR_18 = @"[HKEY_CURRENT_USER\Control Panel\Desktop\WindowMetrics]
""CaptionFont""=hex:e8,ff,ff,ff,00,00,00,00,00,00,00,00,00,00,00,00,90,01,00,00,00,\
  00,00,01,00,00,00,00,53,00,65,00,67,00,6f,00,65,00,20,00,55,00,49,00,00,00,\
  00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,\
  00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00
""CaptionHeight""=""-510""
""CaptionWidth""=""-510""";
    public const string _TITLE_BAR_18_BOLD = @"[HKEY_CURRENT_USER\Control Panel\Desktop\WindowMetrics]
""CaptionFont""=hex:e8,ff,ff,ff,00,00,00,00,00,00,00,00,00,00,00,00,bc,02,00,00,00,\
  00,00,01,00,00,00,00,53,00,65,00,67,00,6f,00,65,00,20,00,55,00,49,00,00,00,\
  00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,\
  00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00
""CaptionHeight""=""-510""
""CaptionWidth""=""-510""";
    public const string _TITLE_BAR_19 = @"[HKEY_CURRENT_USER\Control Panel\Desktop\WindowMetrics]
""CaptionFont""=hex:e7,ff,ff,ff,00,00,00,00,00,00,00,00,00,00,00,00,90,01,00,00,00,\
  00,00,01,00,00,00,00,53,00,65,00,67,00,6f,00,65,00,20,00,55,00,49,00,00,00,\
  00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,\
  00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00
""CaptionHeight""=""-555""
""CaptionWidth""=""-555""";
    public const string _TITLE_BAR_19_BOLD = @"[HKEY_CURRENT_USER\Control Panel\Desktop\WindowMetrics]
""CaptionFont""=hex:e7,ff,ff,ff,00,00,00,00,00,00,00,00,00,00,00,00,bc,02,00,00,00,\
  00,00,01,00,00,00,00,53,00,65,00,67,00,6f,00,65,00,20,00,55,00,49,00,00,00,\
  00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,\
  00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00
""CaptionHeight""=""-555""
""CaptionWidth""=""-555""";
    public const string _TITLE_BAR_20 = @"[HKEY_CURRENT_USER\Control Panel\Desktop\WindowMetrics]
""CaptionFont""=hex:e5,ff,ff,ff,00,00,00,00,00,00,00,00,00,00,00,00,90,01,00,00,00,\
  00,00,01,00,00,00,00,53,00,65,00,67,00,6f,00,65,00,20,00,55,00,49,00,00,00,\
  00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,\
  00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00
""CaptionHeight""=""-585""
""CaptionWidth""=""-585""";
    public const string _TITLE_BAR_20_BOLD = @"[HKEY_CURRENT_USER\Control Panel\Desktop\WindowMetrics]
""CaptionFont""=hex:e5,ff,ff,ff,00,00,00,00,00,00,00,00,00,00,00,00,bc,02,00,00,00,\
  00,00,01,00,00,00,00,53,00,65,00,67,00,6f,00,65,00,20,00,55,00,49,00,00,00,\
  00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,\
  00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00
""CaptionHeight""=""-585""
""CaptionWidth""=""-585""";
    public const string _TITLE_BAR_21 = @"[HKEY_CURRENT_USER\Control Panel\Desktop\WindowMetrics]
""CaptionFont""=hex:e4,ff,ff,ff,00,00,00,00,00,00,00,00,00,00,00,00,90,01,00,00,00,\
  00,00,01,00,00,00,00,53,00,65,00,67,00,6f,00,65,00,20,00,55,00,49,00,00,00,\
  00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,\
  00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00
""CaptionHeight""=""-600""
""CaptionWidth""=""-600""";
    public const string _TITLE_BAR_21_BOLD = @"[HKEY_CURRENT_USER\Control Panel\Desktop\WindowMetrics]
""CaptionFont""=hex:e4,ff,ff,ff,00,00,00,00,00,00,00,00,00,00,00,00,bc,02,00,00,00,\
  00,00,01,00,00,00,00,53,00,65,00,67,00,6f,00,65,00,20,00,55,00,49,00,00,00,\
  00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,\
  00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00
""CaptionHeight""=""-600""
""CaptionWidth""=""-600""";
    public const string _TITLE_BAR_22 = @"[HKEY_CURRENT_USER\Control Panel\Desktop\WindowMetrics]
""CaptionFont""=hex:e3,ff,ff,ff,00,00,00,00,00,00,00,00,00,00,00,00,90,01,00,00,00,\
  00,00,01,00,00,00,00,53,00,65,00,67,00,6f,00,65,00,20,00,55,00,49,00,00,00,\
  00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,\
  00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00
""CaptionHeight""=""-630""
""CaptionWidth""=""-630""";
    public const string _TITLE_BAR_22_BOLD = @"[HKEY_CURRENT_USER\Control Panel\Desktop\WindowMetrics]
""CaptionFont""=hex:e3,ff,ff,ff,00,00,00,00,00,00,00,00,00,00,00,00,bc,02,00,00,00,\
  00,00,01,00,00,00,00,53,00,65,00,67,00,6f,00,65,00,20,00,55,00,49,00,00,00,\
  00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,\
  00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00
""CaptionHeight""=""-630""
""CaptionWidth""=""-630""";
    public const string _TITLE_BAR_23 = @"[HKEY_CURRENT_USER\Control Panel\Desktop\WindowMetrics]
""CaptionFont""=hex:e1,ff,ff,ff,00,00,00,00,00,00,00,00,00,00,00,00,90,01,00,00,00,\
  00,00,01,00,00,00,00,53,00,65,00,67,00,6f,00,65,00,20,00,55,00,49,00,00,00,\
  00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,\
  00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00
""CaptionHeight""=""-660""
""CaptionWidth""=""-660""";
    public const string _TITLE_BAR_23_BOLD = @"[HKEY_CURRENT_USER\Control Panel\Desktop\WindowMetrics]
""CaptionFont""=hex:e1,ff,ff,ff,00,00,00,00,00,00,00,00,00,00,00,00,bc,02,00,00,00,\
  00,00,01,00,00,00,00,53,00,65,00,67,00,6f,00,65,00,20,00,55,00,49,00,00,00,\
  00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,\
  00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00
""CaptionHeight""=""-660""
""CaptionWidth""=""-660""";
    public const string _TITLE_BAR_24 = @"[HKEY_CURRENT_USER\Control Panel\Desktop\WindowMetrics]
""CaptionFont""=hex:e0,ff,ff,ff,00,00,00,00,00,00,00,00,00,00,00,00,90,01,00,00,00,\
  00,00,01,00,00,00,00,53,00,65,00,67,00,6f,00,65,00,20,00,55,00,49,00,00,00,\
  00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,\
  00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00
""CaptionHeight""=""-705""
""CaptionWidth""=""-705""";
    public const string _TITLE_BAR_24_BOLD = @"[HKEY_CURRENT_USER\Control Panel\Desktop\WindowMetrics]
""CaptionFont""=hex:e0,ff,ff,ff,00,00,00,00,00,00,00,00,00,00,00,00,90,01,00,00,00,\
  00,00,01,00,00,00,00,53,00,65,00,67,00,6f,00,65,00,20,00,55,00,49,00,00,00,\
  00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,\
  00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00
""CaptionHeight""=""-705""
""CaptionWidth""=""-705""";
    #endregion
}
