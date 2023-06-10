sc config STR start=disabled
start /b net stop STR
bcdedit /deletevalue useplatformclock
bcdedit /deletevalue useplatformtick
bcdedit /deletevalue disabledynamictick
