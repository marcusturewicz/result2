@echo off
if "%~1" == "" (
	echo Please specify a .nupkg file to push.
) else (
	if exist .build\Publish-Package.ps1 (powershell -File .build\Publish-Package.ps1 "%1" & goto end)
	if exist ..\.build\Publish-Package.ps1 (powershell -File ..\.build\Publish-Package.ps1 "%1" & goto end)
	if exist ..\..\.build\Publish-Package.ps1 (powershell -File ..\..\.build\Publish-Package.ps1 "%1" & goto end)
	if exist ..\..\..\.build\Publish-Package.ps1 (powershell -File ..\..\..\.build\Publish-Package.ps1 "%1" & goto end)
	if exist ..\..\..\..\.build\Publish-Package.ps1 (powershell -File ..\..\..\..\.build\Publish-Package.ps1 "%1" & goto end)
	echo Unable to find a .build folder in any parent folders.
)
:end
pause
