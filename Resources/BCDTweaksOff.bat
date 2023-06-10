	rem Better Input
	bcdedit /deletevalue tscsyncpolicy
	rem Quick Boot
	rem if "%dualboot%" == "no" (bcdedit /timeout 0)
	bcdedit /deletevalue bootux
	bcdedit /set bootmenupolicy standard
	bcdedit /set hypervisorlaunchtype Auto
	bcdedit /deletevalue tpmbootentropy
	bcdedit /deletevalue quietboot
	rem Windows 8 Boot Stuff (windows 8.1)
	rem for /f "tokens=4-9 delims=. " %%i in ('ver') do set winversion=%%i.%%j
	rem if "!winversion!" == "6.3.9600" (
	rem	bcdedit /set {globalsettings} custom:16000067 false
	rem	bcdedit /set {globalsettings} custom:16000069 false
	rem	bcdedit /set {globalsettings} custom:16000068 false
	rem )
	rem nx
	bcdedit /set nx optin
	rem Disable some of the kernel memory mitigations
	bcdedit /set allowedinmemorysettings 0x17000077
	bcdedit /set isolatedcontext Yes
	rem Disable DMA memory protection and cores isolation
	bcdedit /deletevalue vsmlaunchtype
	bcdedit /deletevalue vm
	reg delete "HKLM\Software\Policies\Microsoft\FVE" /v "DisableExternalDMAUnderLock" /f
	reg delete "HKLM\Software\Policies\Microsoft\Windows\DeviceGuard" /v "EnableVirtualizationBasedSecurity" /f
	reg delete "HKLM\Software\Policies\Microsoft\Windows\DeviceGuard" /v "HVCIMATRequired" /f
	bcdedit /deletevalue firstmegabytepolicy
	bcdedit /deletevalue avoidlowmemory
	bcdedit /deletevalue nolowmem
	bcdedit /deletevalue configaccesspolicy
	bcdedit /deletevalue x2apicpolicy
	bcdedit /deletevalue usephysicaldestination
	bcdedit /deletevalue usefirmwarepcisettings
	bcdedit /deletevalue uselegacyapicmode
