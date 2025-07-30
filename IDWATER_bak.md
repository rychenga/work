## 🎤 自我介紹稿（面試用）

大家好，我是 Jeff，擁有多年後端開發經驗。主力語言為 C# 和 Golang，近年來也積極投入 Python 生態的學習與實務應用。

我曾在台積電負責 MES 系統維護與重構，也在遊戲平台開發金流後端服務，並在最近的職涯中，參與使用 Nuxt 前端與 Python + GCP 的跨部門專案開發。熟悉 RESTful API、gRPC 與 PostgreSQL 優化，也習慣使用 Git、CI/CD、Docker 等工具確保流程穩定與可持續交付。

我對這份職缺提到的「專家系統」與跨部門整合特別感興趣，希望能持續精進系統設計與高效溝通能力，為團隊創造更多價值。

---

## 🔧 技術面試問答模擬

### Q1：你在開發 Python API 時，如何規劃路由與資料驗證？

我會依 RESTful 原則設計資源路由，使用 DRF 的 ViewSet 搭配 Router，自動生成標準 CRUD API。驗證部分使用 Serializer 的 `validate_` 方法與 `validate(self, data)` 作跨欄位邏輯，確保輸入資料一致性與安全性。

### Q2：DRF 的 Serializer 有什麼功能？如何自定義驗證？

Serializer 處理資料轉換與驗證，可自定義欄位驗證如：

```python
 def validate_email(self, value):
     if "@gmail.com" not in value:
         raise serializers.ValidationError("Only Gmail addresses are allowed.")
     return value
```

### Q3：PostgreSQL 如何處理 ACID？

透過 Transaction 支援：

* Atomicity：交易全成或全失
* Consistency：資料符合 Schema 條件
* Isolation：預設 Read Committed 隔離級別
* Durability：透過 WAL 保證提交資料持久性

### Q4：資料表超過百萬筆查詢變慢怎麼辦？

我會：

* 使用 EXPLAIN 分析執行計劃
* 建立合適索引（如複合索引）
* 考慮 table partition、物化視圖
* 確保 ORM 不造成 N+1 query 問題

### Q5：請描述你參與過的重構經驗

我曾將舊 C# Windows Service 重構為 Golang 微服務。抽離邏輯層、加上單元測試、逐步替換並保持舊系統並行，確保服務不中斷，最終導入監控工具 Grafana 實現可觀測性。

### Q6：請描述 JWT 登入與權限控制流程

登入後產生 Access Token + Refresh Token，前端使用 HttpOnly Cookie 儲存。Access 有效期短、Refresh 用來續期。加上 Token blacklist / jti 與定期 rotate，確保安全性。

### Q7：CI/CD 經驗分享

我使用 GitHub Actions 建立 CI/CD 流程：

* Push main ➜ Run lint/test ➜ Docker build ➜ Push to GCR ➜ kubectl 部署至 GKE
* 使用 Secret 管理憑證與 deploy 權限，並透過 Slack 通報部署狀況

---

## 📌 小提醒

* 準備 2\~3 個具代表性的專案簡報範例
* 熟練 Git rebase / conflict 解法與 PR Review 邏輯
* 面試前可複誦自我介紹與技術答題，保持口條流暢

## 🎤 自我介紹稿（面試用）

大家好，我是 Jeff，擁有多年後端開發經驗。主力語言為 C# 和 Golang，近年來也積極投入 Python 生態的學習與實務應用。

我曾在台積電負責 MES 系統維護與重構，也在遊戲平台開發金流後端服務，並在最近的職涯中，參與使用 Nuxt 前端與 Python + GCP 的跨部門專案開發。熟悉 RESTful API、gRPC 與 PostgreSQL 優化，也習慣使用 Git、CI/CD、Docker 等工具確保流程穩定與可持續交付。

我對這份職缺提到的「專家系統」與跨部門整合特別感興趣，希望能持續精進系統設計與高效溝通能力，為團隊創造更多價值。

---

## 🔧 技術面試問答模擬

### 自我介紹與背景問題

#### Q：請簡單介紹你自己。

我叫 Jeff，主力語言是 C#、Golang 與 Python，具備十年以上企業後端系統開發經驗，曾參與 MES 系統、財務報表、遊戲平台金流模組與 GCP 雲端架構建置，擅長 RESTful API 設計與系統整合，也有 DevOps 與 CI/CD 實作經驗。

#### Q：你在上一份工作中主要負責哪些內容？

在上一份工作中，我負責一個遊戲平台的金流與用戶系統的後端開發，使用 Golang 和 gRPC 協定，處理第三方支付整合、訂單資料分析、以及內部權限與活動管理模組的建構。我也負責維護技術文件與 API 測試腳本，提升開發與測試效率。

---

### 專業技術問題

#### Q：你如何設計一個高效的資料庫？

首先我會根據需求分析資料實體關係，建構正規化資料表結構以避免冗餘，然後根據查詢特性建立合適索引，例如 B-Tree、GIN 索引等。對於高寫入需求的場景，會考慮非同步寫入、分區表或記憶體快取（如 Redis）來輔助效率。

#### Q：什麼是資料庫正規化？

正規化是將資料拆分為多張表以減少冗餘與更新異常，通常會遵循第一至第三正規形（1NF、2NF、3NF）。例如將客戶資料與訂單資料分開設計，透過外鍵做關聯，確保資料一致性。

#### Q：什麼是 RESTful API？如何設計一個好的 API？

RESTful API 是基於資源導向的架構風格，使用 HTTP 動詞表示操作（GET、POST、PUT、DELETE），URL 表示資源。好的 API 應該具備：

* 清楚的命名與分層（如 /users/123/orders）
* 使用適當的狀態碼
* 支援分頁、排序、filter
* 提供一致的錯誤訊息格式與版本控管

#### Q：你如何在實務中應用 Django 或其他框架？

我使用 Django/DRF 來快速構建 API，包括模型定義、序列化與 ViewSet 架構；利用 Django admin 建立管理後台。也會使用 FastAPI 在需要高效能的輕量服務中快速部署。

---

### 問題解決能力

#### Q：若你的伺服器出現性能瓶頸，你會怎麼排查與解決？

我會先從監控指標著手（CPU、RAM、I/O、DB 查詢時間），利用工具如 `top`, `htop`, `netstat`, 或 APM（如 Datadog）。對於 DB，我會使用 `EXPLAIN ANALYZE` 找出慢查詢，對於應用層，使用 profiler 或 log 來定位效能熱點。最終優化架構或加快回應速度（例如 async 處理、快取）。

---

### 團隊合作與溝通能力

#### Q：你如何與前端工程師協作以確保 API 有效性？

我會事先協議 API 文件格式（可用 Swagger/OpenAPI），並與前端同仁同步接口規格與變更。開發過程中透過 mock API 或 postman collections 提供測試數據。也會定期 sync meeting 解決對接問題，確保雙方理解一致。

#### Q：請舉例說明你在團隊中解決衝突的經驗？

我曾在一個跨部門合作中，遇到因權限模組設計不同，與前端產生對接衝突。我主動提出以中介層提供共用服務的架構，讓後端統一處理權限邏輯，前端只需根據結果呈現。透過這方式，不僅解決衝突，還提升整體一致性。

---

## 📌 小提醒

* 準備 2\~3 個具代表性的專案簡報範例
* 熟練 Git rebase / conflict 解法與 PR Review 邏輯
* 面試前可複誦自我介紹與技術答題，保持口條流暢
