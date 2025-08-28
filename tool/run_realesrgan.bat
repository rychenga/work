@echo off
setlocal enabledelayedexpansion
chcp 65001 >nul
title Real-ESRGAN Custom Run

echo =====================================
echo Please enter input image filename:
echo (example: sample.jpg - must be in 'inputs\' folder)
set /p INPUT=

echo =====================================
echo Please enter output image filename:
echo (example: folder path:demo - will be saved to 'results\demo')
set /p OUTPUT=

echo =====================================
echo Select a model to use:
echo [1] RealESRGAN_x4plus         - General photo
echo [2] RealESRGAN_x4plus_anime_6B - Anime illustration
echo [3] realesr-animevideov3      - Anime video frames
echo [4] RealESRGAN_x2plus         - 2x upscaling
set /p MODEL_CHOICE=Enter model number (1~4):

if "%MODEL_CHOICE%"=="1" set MODEL=RealESRGAN_x4plus
if "%MODEL_CHOICE%"=="2" set MODEL=RealESRGAN_x4plus_anime_6B
if "%MODEL_CHOICE%"=="3" set MODEL=realesr-animevideov3
if "%MODEL_CHOICE%"=="4" set MODEL=RealESRGAN_x2plus

if "%MODEL%"=="" (
  echo Invalid model choice. Please try again.
  pause
  exit /b
)

echo.
echo Starting Real-ESRGAN with model: %MODEL%
echo Input: inputs\%INPUT%
echo Output: results\%OUTPUT%

docker run --rm --gpus all ^
-v %cd%\inputs:/app/inputs ^
-v %cd%\results:/app/results ^
real-esrgan ^
-n %MODEL% ^
-s 4 --tile 512 --tile_pad 10 ^
-i inputs/%INPUT% ^
-o results/%OUTPUT% ^
--face_enhance

echo.
echo ✅ Done! File saved to results\%OUTPUT%
pause
