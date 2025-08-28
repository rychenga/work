
# AutoShorts + Blender + VSCode 整合開發紀錄

---

## 1️⃣ 問：有沒有像 AutoShorts 工具並且是開源免費的？

### ✅ 開源免費替代工具：

1. **ShortGPT**
   - 自動化短影片產生框架。
   - GitHub: https://github.com/RayVentura/ShortGPT

2. **Auto-Shorts by alamshafil**
   - 可生成 Shorts/TikTok 類型影片。
   - GitHub: https://github.com/alamshafil/auto-shorts

3. **AI-Youtube-Shorts-Generator**
   - 長影片轉短影片工具。
   - Reddit: https://www.reddit.com/r/ChatGPTCoding/comments/1e0qoyq/opensource_ai_youtube_shorts_generator/

---

## 2️⃣ 問：免費但非開源的替代工具有哪些？

### ✅ 免費但非開源的影片生成平台：

- **Invideo AI** - https://invideo.io
- **Kapwing AI** - https://www.kapwing.com
- **Vidnoz AI** - https://www.vidnoz.com
- **Clipfly** - https://www.clipfly.ai
- **GizAI** - https://www.giz.ai
- **OpusClip** - https://en.wikipedia.org/wiki/OpusClip

---

## 3️⃣ 問：VSCode + Blender 如何做到像 AutoShorts 功能？

### 答：可行，但需組合多工具。

**模組化流程建議：**

1. 內容腳本 → LLM 生成（ChatGPT 或本地 LLM）
2. 語音生成 → Edge-TTS、Coqui TTS、ElevenLabs
3. 字幕 → Whisper 處理語音時間軸
4. 圖像 → Stable Diffusion 或 API（如 Pexels）
5. Blender 自動合成（使用 Python API）
6. 導出影片 → ffmpeg 或 Blender CLI

---

## 4️⃣ 問：Docker 有 Blender 嗎？

### ✅ 有！

```bash
docker pull blender/blender:latest

# 執行 Blender CLI 指令
docker run --rm -v $(pwd):/blend blender/blender:latest -b my.blend -f 1
```

- 支援 Python 腳本。
- 支援 GPU 渲染（需安裝 NVIDIA Container Toolkit）。

---

## 5️⃣ 問：Docker 有 AutoShorts 嗎？

### ✅ 有！

```bash
git clone https://github.com/alamshafil/auto-shorts
cd auto-shorts
docker build -t auto-shorts .
docker run -p 3000:3000 -p 3001:3001 -p 11434:11434 auto-shorts
```

- 提供前端、後端與本地模型支援。
- 需配置 `.env` 提供 OpenAI/ElevenLabs API Key。

---

## 6️⃣ 問：VSCode + Docker Blender 如何做到像 AutoShorts 功能？
還是結合 docker auto-shorts 會比較好？
還是需要其它工具輔助才行？

### 三種方案比較：

| 路線 | 描述 | 適合對象 |
|------|------|-----------|
| A | 完全自建（VSCode + Blender） | 高客製開發者 |
| B | AutoShorts 生成 → Blender 強化合成 | ✅ **最推薦** |
| C | 全部靠 AutoShorts | 自媒體、短片產生器

推薦使用 Route B：由 AutoShorts 生產腳本與素材，再用 Blender 製作更精緻的動畫與剪輯。

---

## 7️⃣ 問：AutoShorts + Blender + Docker：硬體建議應用？

### 使用者硬體：

- CPU：Intel i7-12700H
- RAM：16GB
- GPU0：Intel Xe（內顯）
- GPU1：RTX 3070 Ti（獨顯）

### 各模組建議用法：

| 模組 | 建議運作方式 | 備註 |
|------|---------------|------|
| AutoShorts | 使用 CPU 即可 | 無需 GPU |
| Blender | 使用 GPU（CUDA） | GPU 加速渲染快數倍 |
| Whisper / TTS | CPU or GPU | GPU 處理 Whisper 更快 |
| 圖像生成 (SD) | 使用 GPU | 可整合 WebUI 容器版本 |

---

## 8️⃣ 指令：請幫我建立整合範本

已建立 docker-compose 範本，整合 AutoShorts + Blender：

```yaml
version: "3.8"

services:
  autoshorts:
    image: ghcr.io/alamshafil/auto-shorts:latest
    ports:
      - "3000:3000"
      - "3001:3001"
      - "11434:11434"
    volumes:
      - ./data:/app/data
    environment:
      - OPENAI_API_KEY=${OPENAI_API_KEY}
      - PEXELS_API_KEY=${PEXELS_API_KEY}
      - ELEVENLABS_API_KEY=${ELEVENLABS_API_KEY}

  blender:
    image: blender/blender:latest
    runtime: nvidia
    environment:
      - NVIDIA_VISIBLE_DEVICES=all
    volumes:
      - ./blender:/app/blender
      - ./data:/app/data
    working_dir: /app/blender
    entrypoint: ["blender", "-b", "template.blend", "-P", "render.py"]
```

---

## ✅ 專案資料夾建議結構：

```
project/
├── docker-compose.yml
├── .env
├── data/
│   ├── voice.mp3
│   ├── background.jpg
│   └── subtitles.srt
├── blender/
│   ├── template.blend
│   └── render.py
```

---

