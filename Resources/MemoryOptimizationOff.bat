reg delete "HKLM\Software\Microsoft\FTH" /v "Enabled" /f
REM Delete Desktop Composition
reg delete "HKCU\Software\Microsoft\Windows\DWM" /v "Composition" /f
REM Enable Background apps
reg delete "HKCU\Software\Microsoft\Windows\CurrentVersion\BackgroundAccessApplications" /v "GlobalUserDisabled" /f
reg delete "HKLM\Software\Policies\Microsoft\Windows\AppPrivacy" /v "LetAppsRunInBackground" /f
reg delete "HKCU\Software\Microsoft\Windows\CurrentVersion\Search" /v "BackgroundAppGlobalToggle" /f
REM Disallow drivers to get paged into virtual memory
reg delete "HKLM\SYSTEM\CurrentControlSet\Control\Session Manager\Memory Management" /v "DisablePagingExecutive" /f
REM Enable Page Combining and memory compression
powershell -NoProfile -Command "Enable-MMAgent -PagingCombining -mc"
REM Use Large System Cache to improve microstuttering
reg delete "HKLM\SYSTEM\CurrentControlSet\Control\Session Manager\Memory Management" /v "LargeSystemCache" /f
REM Don't free unused ram
reg delete "HKLM\System\CurrentControlSet\Control\Session Manager" /v "HeapDeCommitFreeBlockThreshold" /f
REM Don't restart Powershell on error
reg add "HKLM\Software\Microsoft\Windows NT\CurrentVersion\Winlogon" /v "AutoRestartShell" /t REG_DWORD /d "0" /f
REM Disk Optimizations
reg delete "HKLM\SYSTEM\CurrentControlSet\Control\FileSystem" /v "DontVerifyRandomDrivers" /f
reg delete "HKLM\SYSTEM\CurrentControlSet\Control\FileSystem" /v "LongPathsEnabled" /f
REM Enable Prefetch
reg add "HKLM\SYSTEM\CurrentControlSet\Control\Session Manager\Memory Management\PrefetchParameters" /v "EnablePrefetcher" /t Reg_DWORD /d "3" /f
reg add "HKLM\SYSTEM\CurrentControlSet\Control\Session Manager\Memory Management\PrefetchParameters" /v "EnableSuperfetch" /t Reg_DWORD /d "3" /f
REM Background Apps
reg add "HKCU\Software\Microsoft\Windows\CurrentVersion\BackgroundAccessApplications" /v "GlobalUserDisabled" /t Reg_DWORD /d "0" /f
reg delete "HKLM\Software\Policies\Microsoft\Windows\AppPrivacy" /v "LetAppsRunInBackground" /f
reg add "HKCU\Software\Microsoft\Windows\CurrentVersion\Search" /v "BackgroundAppGlobalToggle" /t Reg_DWORD /d "1" /f
REM Hibernation + Fast Startup
reg delete "HKLM\SYSTEM\CurrentControlSet\Control\Session Manager\Power" /v "HiberbootEnabled" /f
reg delete "HKLM\SYSTEM\CurrentControlSet\Control\Power" /v "HibernateEnabledDefault" /f
reg delete "HKLM\SYSTEM\CurrentControlSet\Control\Power" /v "HibernateEnabled" /f
REM Wait time to kill app during shutdown
reg add "HKCU\Control Panel\Desktop" /v "WaitToKillAppTimeout" /t Reg_SZ /d "20000" /f
REM Wait to end service at shutdown
reg add "HKLM\System\CurrentControlSet\Control" /v "WaitToKillServiceTimeout" /t Reg_SZ /d "20000" /f
REM Wait to kill non-responding app
reg add "HKCU\Control Panel\Desktop" /v "HungAppTimeout" /t Reg_SZ /d "5000" /f
REM Decrease icon cache size
reg delete "HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer" /v "Max Cached Icons" /f
REM fsutil
if exist "%SYSTEMROOT%\System32\fsutil.exe" (
	REM Set default limit of paged pool memory
	fsutil behavior set memoryusage 1
	REM https://www.serverbrain.org/solutions-2003/the-mft-zone-can-be-optimized.html
	fsutil behavior set mftzone 1
	REM Default Last Access information on directories, performance/privacy value
	fsutil behavior set disablelastaccess 2
	REM Default Virtual Memory Pagefile Encryption value
	fsutil behavior set encryptpagingfile 0
	REM Default creation of legacy 8.3 character-length file names on FAT- and NTFS-formatted volumes value
	fsutil behavior set disable8dot3 1
	REM Default NTFS compression
	fsutil behavior set disablecompression 0
	REM Enable Trim
	fsutil behavior set disabledeletenotify 0
	REM Enable ReFS v2 auto tiering logic for tiered volumes. https://learn.microsoft.com/en-us/windows-server/administration/windows-commands/fsutil-behavior https://forums.veeam.com/veeam-backup-replication-f2/refs-strange-performance-issues-t65280.html
	fsutil behavior set disablewriteautotiering 0
	REM Set the NTFS quota report interval to its default value.
	fsutil behavior set quotanotify 3600
)
