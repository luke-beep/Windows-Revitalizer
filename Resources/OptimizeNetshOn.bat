netsh int tcp set global dca=enabled
	netsh int tcp set global netdma=enabled
	netsh interface isatap set state disabled
	netsh int tcp set global timestamps=disabled
	netsh int tcp set global rss=enabled
	netsh int tcp set global nonsackrttresiliency=disabled
	netsh int tcp set global initialRto=2000
	netsh int tcp set supplemental template=custom icw=10
	netsh interface ip set interface ethernet currenthoplimit=64
