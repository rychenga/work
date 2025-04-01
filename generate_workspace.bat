@echo off
setlocal enabledelayedexpansion

set "OUTPUT=.code-workspace"
> %OUTPUT% echo {
>> %OUTPUT% echo   "folders": [

set "FIRST=1"

for /f "delims=" %%D in ('dir /ad /b /s') do (
    set "FULL=%%D"
    set "REL=!FULL:%CD%\=!"

    rem 過濾 .git 和 .vscode 資料夾
    echo !REL! | findstr /I ".git" >nul
    if errorlevel 1 (
        echo !REL! | findstr /I ".vscode" >nul
        if errorlevel 1 (
            if "!FIRST!"=="1" (
                >> %OUTPUT% echo     { "path": "!REL!" }
                set "FIRST=0"
            ) else (
                >> %OUTPUT% echo    ,{ "path": "!REL!" }
            )
        )
    )
)

>> %OUTPUT% echo   ],
>> %OUTPUT% echo   "settings": {
>> %OUTPUT% echo     "continue.experimental.debugMode": true
>> %OUTPUT% echo   }
>> %OUTPUT% echo }

echo ✅ 已產生 %OUTPUT%
