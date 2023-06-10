netsh int ip set global taskoffload=enabled >nul 2>&1
reg add HKLM\SYSTEM\CurrentControlSet\Services\TCPIP\Parameters /v DisableTaskOffload /t REG_DWORD /d 0 /f
