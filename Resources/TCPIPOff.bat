powershell -NoProfile -NonInteractive -Command ^
	Set-NetTCPSetting -SettingName "*" -InitialCongestionWindow 4 -ErrorAction SilentlyContinue
	reg delete "HKLM\SYSTEM\CurrentControlSet\Services\Tcpip\Parameters" /v "TcpMaxConnectRetransmissions" /f
	reg delete "HKLM\SYSTEM\CurrentControlSet\Services\Tcpip\Parameters" /v "Tcp1323Opts" /f
	reg delete "HKLM\SYSTEM\CurrentControlSet\Services\Tcpip\Parameters" /v "TcpTimedWaitDelay" /f
	reg delete "HKLM\SYSTEM\CurrentControlSet\Services\Tcpip\Parameters" /v "DelayedAckFrequency" /f
	reg delete "HKLM\SYSTEM\CurrentControlSet\Services\Tcpip\Parameters" /v "DelayedAckTicks" /f
	reg delete "HKLM\SYSTEM\CurrentControlSet\Services\Tcpip\Parameters" /v "CongestionAlgorithm" /f
	reg delete "HKLM\SYSTEM\CurrentControlSet\Services\Tcpip\Parameters" /v "MultihopSets" /f
	reg delete "HKLM\SYSTEM\CurrentControlSet\Services\LanmanServer\Parameters" /v "IRPStackSize" /f
	reg delete "HKLM\SYSTEM\CurrentControlSet\Services\LanmanServer\Parameters" /v "SizReqBuf" /f
	reg delete "HKLM\SYSTEM\CurrentControlSet\Services\LanmanServer\Parameters" /v "Size" /f
	reg delete "HKLM\SYSTEM\CurrentControlSet\Services\Tcpip\QoS" /v "Do not use NLA" /f
	reg delete "HKLM\SYSTEM\CurrentControlSet\Services\Dnscache\Parameters" /v "NegativeCacheTime" /f
	reg delete "HKLM\SYSTEM\CurrentControlSet\Services\Dnscache\Parameters" /v "NegativeSOACacheTime" /f
	reg delete "HKLM\SYSTEM\CurrentControlSet\Services\Dnscache\Parameters" /v "NetFailureCacheTime" /f
	reg delete "HKLM\SOFTWARE\Policies\Microsoft\Windows\DataCollection" /v "AllowTelemetry" /f
	reg delete "HKLM\SOFTWARE\Policies\Microsoft\Windows\DataCollection" /v "DoNotShowFeedbackNotifications" /f
	reg delete "HKLM\SYSTEM\CurrentControlSet\Services\Dnscache\Parameters" /v "EnableAutoDoh" /f
	reg delete "HKLM\SYSTEM\CurrDisableNagleentControlSet\Services\AFD\Parameters" /v "DoNotHoldNicBuffers" /f
	reg delete "HKLM\SYSTEM\CurrentControlSet\Services\AFD\Parameters" /v "DisableRawSecurity" /f
	reg delete "HKLM\SYSTEM\CurrentControlSet\Services\AFD\Parameters" /v "NonBlockingSendSpecialBuffering" /f
	reg delete "HKLM\SYSTEM\CurrentControlSet\Services\AFD\Parameters" /v "IgnorePushBitOnReceives" /f
	reg delete "HKLM\SYSTEM\CurrentControlSet\Services\AFD\Parameters" /v "DynamicSendBufferDisable" /f
	reg delete "HKLM\Software\Microsoft\MSMQ\Parameters" /v "TCPNoDelay" /f
	for /f "tokens=3*" %%i in ('reg query "HKLM\SOFTWARE\Microsoft\Windows NT\CurrentVersion\NetworkCards" /f "ServiceName" /s ^|findstr /i /l "ServiceName"') do (
		reg delete "HKLM\System\CurrentControlSet\Services\Tcpip\Parameters\Interfaces\%%i" /v "TCPNoDelay" /f
		reg delete "HKLM\System\CurrentControlSet\Services\Tcpip\Parameters\Interfaces\%%i" /v "TcpAckFrequency" /f
		reg delete "HKLM\System\CurrentControlSet\Services\Tcpip\Parameters\Interfaces\%%i" /v "TcpDelAckTicks" /f
		reg delete "HKLM\System\CurrentControlSet\Services\Tcpip\Parameters\Interfaces\%%i" /v "TcpInitialRTT" /f
		reg delete "HKLM\SYSTEM\CurrentControlSet\Services\Tcpip\Parameters\Interfaces\%%i" /v "UseZeroBroadcast" /f
		reg delete "HKLM\SYSTEM\CurrentControlSet\Services\Tcpip\Parameters\Interfaces\%%i" /v "DeadGWDetectDefault" /f
	)
start /B cmd /c "ipconfig /release & ipconfig /renew" >nul 2>&1
