
# 🧰 開發者專用 Prompt 套件 (for Golang / SOHO / AI-assisted Development)

## 1. 🐞 Bug 分析型 Prompt

```
你是一位資深 Golang 工程師，請幫我分析以下程式碼出現的 bug 並提供修正建議，請逐步說明：

== 程式碼 ==
```go
<貼上你遇到問題的程式碼>
```

== 錯誤訊息 ==
<貼上錯誤訊息或行為描述>

請幫我：
1. 說明錯誤可能的原因
2. 建議修正方式
3. 若可行，請產出修正後的程式碼
```

---

## 2. 📝 Code Review 輔助 Prompt

```
請你扮演一位有實務經驗的 Golang code reviewer，幫我檢查以下程式碼的可讀性、效能與安全性，請分段給出回饋：

```go
<貼上你的 Golang 程式碼>
```

請指出：
1. 可改進的命名、結構或重複邏輯
2. 有沒有潛在 bug、效能問題或錯誤處理上的缺失
3. 最佳化建議（可用 design pattern、原生語法優化）
```

---

## 3. 🧱 架構設計 + 文件生成 Prompt

```
我想建立一個 Golang Web API 專案，目標是開發一個 CRUD 系統，請依照下列要求產出：

1. 清晰的資料夾架構（有 cmd, internal, pkg, router, config 等）
2. 每個資料夾的用途簡介
3. 提供 README.md 的範例內容
4. 建立一份 OpenAPI 風格的 API 文件範本（YAML 或 Markdown 皆可）
5. 如果可行，請列出單元測試的建議寫法與目標 coverage 比例
```

---

## 4. 🤖 Continue + Ollama Prompt Workflow

```
[角色定義]
你是一位代碼架構顧問，協助開發者設計可擴充的 Golang 系統架構

[任務目標]
幫我根據輸入的專案需求，產出：
- 系統架構建議（含模組分層）
- 資料夾結構設計
- API 介面定義（CRUD + 分頁 + 錯誤處理）
- 基本的開發流程與測試策略
- 一份適合 README 的說明

[使用範例]
我想做一個「線上書店」的 API 後端，用 Gin + GORM + MySQL，請你幫我產出上述所有內容。
```

---

## 📦 附註：使用方式

- 可將這些 Prompt 儲存於 Notion、Obsidian、Markdown 符號庫中
- 或轉成 Continue 專用格式放入 `.continue/presets.json`
