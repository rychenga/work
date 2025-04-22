# Real-ESRGAN Docker file
FROM nvidia/cuda:11.8.0-cudnn8-runtime-ubuntu22.04

# 安裝 Python 3.10 + 必要圖形函式庫
RUN apt-get update && apt-get install -y \
    python3.10 python3.10-venv python3.10-dev python3-pip git \
    libgl1 libglib2.0-0

# 設定預設 python 版本
RUN update-alternatives --install /usr/bin/python3 python3 /usr/bin/python3.10 1

# 升級 pip 並安裝對應的 NumPy 版本（必須明確安裝）
RUN pip3 install --upgrade pip
RUN pip3 install numpy==1.24.4

# 安裝相容版本的 PyTorch + torchvision（含 functional_tensor 模組）
RUN pip3 install torch==2.0.1 torchvision==0.15.2 --extra-index-url https://download.pytorch.org/whl/cu118

# 安裝 Real-ESRGAN 所需的依賴
RUN pip3 install basicsr facexlib gfpgan realesrgan

# Clone 原始碼 + 開發模式安裝
RUN git clone https://github.com/xinntao/Real-ESRGAN.git /app
WORKDIR /app
RUN python3 setup.py develop

# 預設執行入口點（處理圖片）
ENTRYPOINT ["python3", "inference_realesrgan.py"]
