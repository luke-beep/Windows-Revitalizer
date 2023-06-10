netsh int ip set global taskoffload=disabled >nul 2>&1
reg add HKLM\SYSTEM\CurrentControlSet\Services\TCPIP\Parameters /v DisableTaskOffload /t REG_DWORD /d 1 /f
