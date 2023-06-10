for /f %%a in ('reg query "HKLM\System\CurrentControlSet\Control\Class\{4d36e968-e325-11ce-bfc1-08002be10318}" /t REG_SZ /s /e /f "NVIDIA" ^| findstr "HKEY"') do (
reg add "%%a" /v "RMHdcpKeyglobZero" /t REG_DWORD /d "0" /f
)
