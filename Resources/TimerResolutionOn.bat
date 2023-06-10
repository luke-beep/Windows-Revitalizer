sc config STR start=auto
start /b net start STR
bcdedit /set disabledynamictick yes
bcdedit /deletevalue useplatformclock
