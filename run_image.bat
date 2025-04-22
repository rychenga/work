@echo off
docker run --rm --gpus all ^
  -v %cd%\inputs:/app/inputs ^
  -v %cd%\results:/app/results ^
  real-esrgan ^
  -n RealESRGAN_x4plus ^
  -s 4 --tile 512 --tile_pad 10 ^
  -i inputs/sample.jpg ^
  --face_enhance
pause

