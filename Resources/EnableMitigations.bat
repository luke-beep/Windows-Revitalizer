	reg add "HKLM\SYSTEM\CurrentControlSet\Control\DeviceGuard\Scenarios\HypervisorEnforcedCodeIntegrity" /v "Enabled" /t REG_DWORD /d "1" /f
	REM Enable SEHOP
	reg delete "HKLM\SYSTEM\CurrentControlSet\Control\Session Manager\kernel" /v "DisableExceptionChainValidation" /f
	REM Enable Spectre And Meltdown
	reg delete "HKLM\SYSTEM\CurrentControlSet\Control\Session Manager\Memory Management" /v FeatureSettings /f
	reg delete "HKLM\SYSTEM\CurrentControlSet\Control\Session Manager\Memory Management" /v FeatureSettingsOverride /f
	reg delete "HKLM\SYSTEM\CurrentControlSet\Control\Session Manager\Memory Management" /v FeatureSettingsOverrideMask /f
	cd %TEMP%
	if not exist "%TEMP%\NSudo.exe" curl -g -L -# -o "%TEMP%\NSudo.exe" "https://github.com/auraside/HoneCtrl/raw/main/Files/NSudo.exe"
	NSudo -U:S -ShowWindowMode:Hide -wait cmd /c "reg add "HKLM\SYSTEM\CurrentControlSet\Services\TrustedInstaller" /v "Start" /t Reg_DWORD /d "2" /f"
	NSudo -U:S -ShowWindowMode:Hide -wait cmd /c "sc start "TrustedInstaller"" 
	NSudo -U:T -P:E -M:S -ShowWindowMode:Hide -wait cmd /c "ren %SYSTEMROOT%\System32\mcupdate_GenuineIntel.old mcupdate_GenuineIntel.dll"
	NSudo -U:T -P:E -M:S -ShowWindowMode:Hide -wait cmd /c "ren %SYSTEMROOT%\System32\mcupdate_AuthenticAMD.old mcupdate_AuthenticAMD.dll"
	REM Enable CFG Lock
	reg delete "HKLM\SYSTEM\CurrentControlSet\Control\Session Manager\Memory Management" /v "EnableCfg" /f
	REM Enable NTFS/ReFS and FS Mitigations
	reg delete "HKLM\System\CurrentControlSet\Control\Session Manager" /v "ProtectionMode" /f
