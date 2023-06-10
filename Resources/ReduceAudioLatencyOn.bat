if not exist nssm.exe(
    curl - g - L -# -o "%SYSTEMDRIVE%\WindowsRevitalizer\nssm.exe" "https://github.com/auraside/HoneCtrl/raw/main/Files/nssm.exe"
		curl - g - L -# -o "%SYSTEMDRIVE%\WindowsRevitalizer\REAL.exe" "https://github.com/auraside/HoneCtrl/raw/main/Files/REAL.exe"
		nssm install REAL.exe "%SYSTEMDRIVE%\WindowsRevitalizer\REAL.exe"
        nssm set REAL.exe DisplayName REAL.exe Audio Latency Reducer Service
        nssm set REAL.exe Description Reduces Audio Latency
        nssm set REAL.exe Start SERVICE_AUTO_START
        nssm set REAL.exe AppAffinity 1
)
nssm set REAL.exe start SERVICE_AUTO_START
nssm start REAL.exe
