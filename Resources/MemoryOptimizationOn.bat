reg add "HKLM\Software\Microsoft\FTH" /v "Enabled" /t Reg_DWORD /d "0" /f
REM Disable Desktop Composition
reg add "HKCU\Software\Microsoft\Windows\DWM" /v "Composition" /t REG_DWORD /d "0" /f
REM Disable Background apps
reg add "HKCU\Software\Microsoft\Windows\CurrentVersion\BackgroundAccessApplications" /v "GlobalUserDisabled" /t Reg_DWORD /d "1" /f
reg add "HKLM\Software\Policies\Microsoft\Windows\AppPrivacy" /v "LetAppsRunInBackground" /t Reg_DWORD /d "2" /f
reg add "HKCU\Software\Microsoft\Windows\CurrentVersion\Search" /v "BackgroundAppGlobalToggle" /t Reg_DWORD /d "0" /f
REM Disallow drivers to get paged into virtual memory
reg add "HKLM\SYSTEM\CurrentControlSet\Control\Session Manager\Memory Management" /v "DisablePagingExecutive" /t Reg_DWORD /d "1" /f
REM Disable Page Combining and Memory Compression
powershell -NoProfile -Command "Disable-MMAgent -PageCombining -mc"
reg add "HKLM\System\CurrentControlSet\Control\Session Manager\Memory Management" /v "DisablePageCombining" /t REG_DWORD /d "1" /f
REM Use Large System Cache to improve microstuttering
reg add "HKLM\SYSTEM\CurrentControlSet\Control\Session Manager\Memory Management" /v "LargeSystemCache" /t Reg_DWORD /d "1" /f
REM Free unused ram
reg add "HKLM\System\CurrentControlSet\Control\Session Manager" /v "HeapDeCommitFreeBlockThreshold" /t REG_DWORD /d "262144" /f
REM Auto restart Powershell on error
reg add "HKLM\Software\Microsoft\Windows NT\CurrentVersion\Winlogon" /v "AutoRestartShell" /t REG_DWORD /d "1" /f
REM Disk Optimizations
reg add "HKLM\SYSTEM\CurrentControlSet\Control\FileSystem" /v "DontVerifyRandomDrivers" /t REG_DWORD /d "1" /f
reg add "HKLM\SYSTEM\CurrentControlSet\Control\FileSystem" /v "LongPathsEnabled" /t REG_DWORD /d "0" /f
REM Disable Prefetch and Superfetch
reg add "HKLM\SYSTEM\CurrentControlSet\Control\Session Manager\Memory Management\PrefetchParameters" /v "EnablePrefetcher" /t Reg_DWORD /d "0" /f
reg add "HKLM\SYSTEM\CurrentControlSet\Control\Session Manager\Memory Management\PrefetchParameters" /v "EnableSuperfetch" /t Reg_DWORD /d "0" /f
REM Disable Hibernation + Fast Startup
reg add "HKLM\SYSTEM\CurrentControlSet\Control\Session Manager\Power" /v "HiberbootEnabled" /t REG_DWORD /d "0" /f
reg add "HKLM\SYSTEM\CurrentControlSet\Control\Power" /v "HibernateEnabledDefault" /t REG_DWORD /d "0" /f
reg add "HKLM\SYSTEM\CurrentControlSet\Control\Power" /v "HibernateEnabled" /t REG_DWORD /d "0" /f
REM Wait time to kill app during shutdown
reg add "HKCU\Control Panel\Desktop" /v "WaitToKillAppTimeout" /t Reg_SZ /d "1000" /f
REM Wait to end service at shutdown
reg add "HKLM\System\CurrentControlSet\Control" /v "WaitToKillServiceTimeout" /t Reg_SZ /d "1000" /f
REM Wait to kill non-responding app
reg add "HKCU\Control Panel\Desktop" /v "HungAppTimeout" /t Reg_SZ /d "1000" /f
REM Increase icon cache size
reg add "HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer" /v "Max Cached Icons" /t REG_SZ /d "4096" /f
REM fsutil
if exist "%SYSTEMROOT%\System32\fsutil.exe" (
	REM Raise the limit of paged pool memory
	fsutil behavior set memoryusage 2
	REM https://www.serverbrain.org/solutions-2003/the-mft-zone-can-be-optimized.html
	fsutil behavior set mftzone 2
	REM Disable Last Access information on directories, performance/privacy
	fsutil behavior set disablelastaccess 1
	REM Disable Virtual Memory Pagefile Encryption
	fsutil behavior set encryptpagingfile 0
	REM Disables the creation of legacy 8.3 character-length file names on FAT- and NTFS-formatted volumes.
	fsutil behavior set disable8dot3 1
	REM Disable NTFS compression
	fsutil behavior set disablecompression 1
	REM Enable Trim
	fsutil behavior set disabledeletenotify %SystemDrive% 0
	REM Disable ReFS v2 auto tiering logic for tiered volumes. https://learn.microsoft.com/en-us/windows-server/administration/windows-commands/fsutil-behavior https://forums.veeam.com/veeam-backup-replication-f2/refs-strange-performance-issues-t65280.html
	fsutil behavior set disablewriteautotiering 1
	REM Set the NTFS quota report interval to 90 minutes.
	fsutil behavior set quotanotify 5400
)
