@echo off
if exist .build\New-Package.ps1 (powershell -File .build\New-Package.ps1 -Symbols & goto end)
if exist ..\.build\New-Package.ps1 (powershell -File ..\.build\New-Package.ps1 -Symbols & goto end)
if exist ..\..\.build\New-Package.ps1 (powershell -File ..\..\.build\New-Package.ps1 -Symbols & goto end)
if exist ..\..\..\.build\New-Package.ps1 (powershell -File ..\..\..\.build\New-Package.ps1 -Symbols & goto end)
if exist ..\..\..\..\.build\New-Package.ps1 (powershell -File ..\..\..\..\.build\New-Package.ps1 -Symbols & goto end)
if exist ..\..\..\..\..\.build\New-Package.ps1 (powershell -File ..\..\..\..\..\.build\New-Package.ps1 -Symbols & goto end)
echo Unable to find a .build folder in any parent folders.
:end
pause
