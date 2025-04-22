import torch
from deoldify.visualize import *
from pathlib import Path
import argparse
import os
import warnings

warnings.filterwarnings("ignore", category=UserWarning, message=".*?Your .*? set is empty.*?")

# -------------------- CLI 參數 --------------------
parser = argparse.ArgumentParser()
parser.add_argument('--render_factor', type=int, default=35, help='圖片細節等級，預設 35')
parser.add_argument('--input_path', type=str, required=True, help='輸入資料夾')
parser.add_argument('--output_path', type=str, required=True, help='輸出資料夾')
args = parser.parse_args()

input_dir = Path(args.input_path)
output_dir = Path(args.output_path)
output_dir.mkdir(parents=True, exist_ok=True)

# -------------------- 檢查 GPU --------------------
device = "cuda" if torch.cuda.is_available() else "cpu"
print(f"[INFO] Using device: {device.upper()}")

# -------------------- 初始化 DeOldify --------------------
colorizer = get_image_colorizer(artistic=True)

# -------------------- 處理圖片 --------------------
for file in input_dir.iterdir():
    if file.suffix.lower() in ['.jpg', '.jpeg', '.png', '.bmp']:
        print(f"[PROCESSING] {file.name} → colorized_{file.name}")
        colorizer.plot_transformed_image(
            path=file,
            results_dir=output_dir,
            render_factor=args.render_factor,
            post_process=True,
            watermarked=False
        )

print(f"[DONE] All images processed. Output saved in: {output_dir}")
