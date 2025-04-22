# 🧠 本地 AI 開發代理人系統（Codex CLI 替代方案）

## 📦 環境組成

- **VSCode**：整合式開發平台
- **Continue Plugin**：自然語言互動與程式輔助編輯
- **Cline Plugin**：AI 指令轉為終端機指令自動執行
- **Ollama**：本地執行大語言模型（LLM）引擎
- **Qwen2.5-Coder:7B-Instruct**：本地模型（支援自然語言與程式理解）

---

## ⚙️ 安裝與設定

### 1️⃣ 安裝 Ollama
```bash
brew install ollama  # macOS 用戶
```
或參見：https://ollama.com/download

### 2️⃣ 下載模型
```bash
ollama run qwen2.5-coder:7b-instruct
```

### 3️⃣ 安裝 VSCode Plugin

- 安裝 [Continue Plugin](https://marketplace.visualstudio.com/items?itemName=Continue.continue)
- 安裝 [Cline CLI 工具](https://www.npmjs.com/package/cline)
```bash
npm install -g cline
```

### 4️⃣ 設定 Continue 配置
`.continue/config.json`
```json
{
  "models": {
    "ollama-qwen": {
      "provider": "ollama",
      "model": "qwen2.5-coder:7b-instruct"
    }
  },
  "defaultModel": "ollama-qwen"
}
```

---

## 💬 Prompt 模板範例

### 🚀 修復專案
```
你是資深軟體工程師，請修復這個專案的 build error。
請逐步：
1. 分析錯誤 log
2. 找出修改檔案及原因
3. 產生修正程式碼
4. 回傳 shell 指令進行修復與測試（如必要）
```

### 🧪 測試驅動生成
```
針對以下 function，自動產生 Golang 測試案例，並提供執行 go test 的指令。
```

---

## 🔄 模式模擬（對應 Codex CLI 三階段）

| 模式         | 使用方式                                       | 範例                         |
|--------------|------------------------------------------------|------------------------------|
| Suggest      | Continue 輸入 prompt，手動修改建議             | "請檢查此函式是否可優化"     |
| Auto Edit    | Continue 提示並修改，配合 Cline 執行測試       | "請修復此 bug 並執行測試"   |
| Full Auto    | Continue + Cline，指令自動送出至 Terminal       | "請修好專案並 build 通過"     |

---

## 🧩 進階功能建議（可選）

| 工具         | 功能描述                              |
|--------------|---------------------------------------|
| LangGraph    | 任務導向流程圖（Task Graph）          |
| LLMGuard     | 輸出安全審核與風險控制                |
| Git Hooks    | Commit 前自動觸發 LLM 編輯/Lint         |
| Promptflow   | 可視化 Prompt 管理與流程編排工具       |

---

## ✅ 任務練習建議

| 任務類型       | 推薦模式     | 說明                             |
|----------------|--------------|----------------------------------|
| 修復 build     | Full Auto    | 自動分析錯誤與修復建置錯誤       |
| 測試產生       | Suggest      | 自動產生單元測試與執行命令       |
| Codebase 掃描  | Suggest      | 分析大型程式結構與死 code         |
| API 文件產生   | Auto Edit    | 為程式自動生成 Swagger 或註解說明 |

---

## 🧠 思考提示

> - 我現在的角色是什麼？
> - 哪些任務我想保留主導權？
> - 我會不會已經依賴它了？

這不是為了懷疑 AI，而是讓你更清楚地主導這個合作關係。

