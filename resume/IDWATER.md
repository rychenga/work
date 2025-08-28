## 🎤 自我介紹稿（面試用）

大家好，我是 Jeff，擁有多年後端開發經驗。主力語言為 C# 和 Golang，近年來也積極投入 Python 生態的學習與實務應用。

我曾在台積電負責 MES 系統維護與重構，也在遊戲平台開發金流後端服務，並在最近的職涯中，參與使用 Nuxt 前端與 Python + GCP 的跨部門專案開發。熟悉 RESTful API、gRPC 與 PostgreSQL 優化，也習慣使用 Git、CI/CD、Docker 等工具確保流程穩定與可持續交付。

---

## 🔧 技術面試問答模擬整合

### 一、自我介紹與背景問題

#### Q：請簡單介紹你自己。

我叫 Jeff，主力語言是 C#、Golang 與 Python，具備十年以上企業後端系統開發經驗，曾參與 MES 系統、財務報表、遊戲平台金流模組與 GCP 雲端架構建置，擅長 RESTful API 設計與系統整合，也有 DevOps 與 CI/CD 實作經驗。

#### Q：你在上一份工作中主要負責哪些內容？

在上一份工作中，我負責一個遊戲平台的金流與用戶系統的後端開發，使用 Golang 和 gRPC 協定，處理第三方支付整合、訂單資料分析、以及內部權限與活動管理模組的建構。我也負責維護技術文件與 API 測試腳本，提升開發與測試效率。

---

### 二、專業技術問題

#### Q：你如何設計一個高效的資料庫？

我會根據業務需求分析資料實體關係，使用正規化方法避免資料冗餘，同時根據查詢特性建立合適索引（如 B-Tree 或 GIN），必要時使用 table partition 或 materialized views，並整合 Redis 快取提升效能。

#### Q：解釋一下資料庫的正規化。

正規化是為了減少資料冗餘與更新異常的資料設計方法，常見有 1NF（消除重複欄位）、2NF（移除部分依賴）、3NF（移除傳遞依賴），透過拆表並用外鍵連結資料，確保資料結構一致性與擴充性。

#### Q：什麼是 RESTful API？如何設計一個好的 API？

RESTful API 是一種以資源導向為基礎的設計風格，使用 HTTP 動詞（GET、POST、PUT、DELETE）對資源進行操作。好的 API 應具備清晰路由、語意明確的狀態碼、一致的錯誤格式、版本控管與良好文件說明（如 OpenAPI/Swagger）。

### Q：你在開發 Python API 時，如何規劃路由與資料驗證？

我會依 RESTful 原則設計資源路由，使用 DRF 的 ViewSet 搭配 Router，自動生成標準 CRUD API。驗證部分使用 Serializer 的 `validate_` 方法與 `validate(self, data)` 作跨欄位邏輯，確保輸入資料一致性與安全性。

#### Q：你如何在實務中應用 Django 或其他框架？

我使用 Django/DRF 開發 RESTful API，利用 Model + Serializer + ViewSet 架構快速實作 CRUD 功能，也透過 drf-yasg 建立 API 文件。需要輕量快速時我會使用 FastAPI，搭配 async 處理提升效能。

#### Q：DRF 的 Serializer 有什麼功能？如何自定義驗證？

Serializer 負責資料序列化與反序列化，並內建欄位型別驗證功能，可透過 `validate_<field>` 或 `validate()` 方法進行自定義驗證。例如：

```python
 def validate_email(self, value):
     if "@gmail.com" not in value:
         raise serializers.ValidationError("Only Gmail addresses are allowed.")
     return value
```

---

### 三、問題解決能力

### Q：資料表超過百萬筆查詢變慢怎麼辦？

我會：

* 使用 EXPLAIN 分析執行計劃
* 建立合適索引（如複合索引）
* 拆表（使用歷史資料表歸檔）
* 考慮 table partition、物化視圖
* 確保 ORM 不造成 N+1 query 問題

#### Q：若你的伺服器出現性能瓶頸，你會怎麼排查與解決？

我會先從監控指標著手（CPU、RAM、I/O、DB 查詢時間），利用工具如 `top`, `htop`, `netstat`, 或 APM（如 Datadog）。對於 DB，我會使用 `EXPLAIN ANALYZE` 找出慢查詢，對於應用層，使用 profiler 或 log 來定位效能熱點。最終優化架構或加快回應速度（例如 async 處理、快取）。

我會：

1. 先用監控工具（如 Grafana/Prometheus）查看 CPU、記憶體與延遲異常指標。
2. 分析慢查詢（使用 PostgreSQL 的 EXPLAIN ANALYZE）或應用層 profiling。
3. 評估快取使用情況（如 Redis），必要時調整程式邏輯（批次處理、分頁查詢、非同步執行）。
4. 若為架構層問題，可能考慮加上 Load Balancer 或做橫向擴充。

---

### 四、團隊合作與溝通能力

#### Q：你如何與前端工程師協作以確保 API 有效性？

我會事先協議 API 文件格式（可用 Swagger/OpenAPI），並與前端同仁同步接口規格與變更。開發過程中透過 mock API 或 postman collections 提供測試數據。也會定期 sync meeting 解決對接問題，確保雙方理解一致。

我習慣使用 OpenAPI 規格同步 API 設計，並使用 Swagger 文件或 Postman collection 測試溝通。開發初期建立 API mock server，快速提供前端測試資料，並在有 breaking change 時提早通知、版本控管。

#### Q：描述一次你在團隊中解決衝突的經歷。

曾有一次在與前端協作中，因權限資料格式理解不同導致整合延遲，我主動召開小會議，提出以 middleware 包裝 API 統一權限格式，並同步 API 規格與測試案例，最後順利完成整合並改善未來合作流程。

---

### 五、進階實作與部署

### Q：請描述你參與過的重構經驗

我曾將舊 C# Windows Service 重構為 Golang 微服務。抽離邏輯層、加上單元測試、逐步替換並保持舊系統並行，確保服務不中斷，最終導入監控工具 Grafana 實現可觀測性。

#### Q：PostgreSQL 如何處理 ACID？

透過 Transaction 機制：

* Atomicity(交易全成或全失)：一組操作要嘛全部成功、要嘛全部失敗
* Consistency(資料符合 Schema 條件)：透過 Constraint 保證一致性
* Isolation：支援多種隔離等級，預設 Read Committed
* Durability：使用 WAL（Write-Ahead Logging）確保系統崩潰後資料仍可復原

#### Q：請描述 JWT 登入與權限控制流程。

用戶登入成功後，系統產生 Access Token 與 Refresh Token。前端透過 HttpOnly Cookie 儲存並使用 Token。Access Token 驗證身份，Refresh Token 續期時使用。搭配 jti 實作黑名單機制，保障安全性。

登入後產生 Access Token + Refresh Token，前端使用 HttpOnly Cookie 儲存。Access 有效期短、Refresh 用來續期。加上 Token blacklist / jti 與定期 rotate，確保安全性。

JWT 流程如下：

* 使用者登入成功後，後端簽發 access token + refresh token。
* access token 存短期有效（如 15 分鐘），refresh token 較長（7 天）。
* 前端儲存在 HttpOnly cookie 以防 XSS。
* 若 access 過期但 refresh 尚未，前端會請求 /token/refresh 取得新 token。

安全措施包括：

* 加入 jti（唯一 ID）以便 blacklist。
* 若使用者改密碼或登出，立即讓 refresh token 失效。
* 定期 rotate refresh token 並強制重新登入。

#### Q：CI/CD 經驗分享

我曾使用 GitHub Actions 建立自動化部署流程：

1. 開發 push 至 main ➜ 自動執行 lint、單元測試
2. 建立 Docker image ➜ 上傳至 GCR
3. 透過 kubectl 將服務部署到 GKE
   也整合 Slack 通報、Secrets 管理 Deploy 憑證，確保流程安全可控。

---

## 📌 面試準備小提醒

* 準備 2\~3 個具代表性的專案簡報範例（STAR 原則：情境、任務、行動、結果）
* 熟練 Git flow、PR review、merge/rebase 衝突處理流程
* 練習將技術答題口語化，避免過度艱澀
* 可攜帶面試小抄筆記本，但回答仍需自然、有條理
