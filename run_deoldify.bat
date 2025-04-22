@echo off
setlocal

REM === 資料夾設定 ===
set INPUT_DIR=%cd%\input
set OUTPUT_DIR=%cd%\output

REM === 建立資料夾（若不存在）===
if not exist "%INPUT_DIR%" mkdir "%INPUT_DIR%"
if not exist "%OUTPUT_DIR%" mkdir "%OUTPUT_DIR%"

echo ================================
echo 🔧 DeOldify 上色處理開始...
echo 📂 Input:  %INPUT_DIR%
echo 📤 Output: %OUTPUT_DIR%
echo ================================

REM === 執行 DeOldify 容器 ===
docker run --gpus all --rm -it ^
  -v "%INPUT_DIR%":/app/input ^
  -v "%OUTPUT_DIR%":/app/output ^
  deoldify:gpu

echo ================================
echo ✅ 上色完成！請查看 output 資料夾。
pause
