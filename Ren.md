# 以下為GPT準備
下面是一套模擬Ren「Python 後端工程師」筆試風格的【完整考古題練習集】。
題目分為兩部分：邏輯測驗與後端專業技術測驗。每題皆含：題目描述、難度、核心能力、解題思路／標準答案（可作為參考解答）。
為符合「不可查詢」限制，題幹設計皆可在紙筆與本地編輯器思考完成。

---

# 第一部分：邏輯測驗（7 題）

## L1. 數列推理

**題目**：給定數列 2, 6, 15, 31, 56, 92, \_\_\_，請填入下一項。
**難度**：初級
**核心能力**：數學規律觀察、差分推理
**思路**：差分為 4, 9, 16, 25, 36（依序為平方數 2²,3²,4²,5²,6²），下一差分為 7²=49。
**答案**：92 + 49 = **141**。

---

## L2. 布林邏輯最少判斷

**題目**：有三個開關 A、B、C，至少有兩個為真才回傳 True。請寫出最少比較次數的判斷流程（文字描述流程即可）。
**難度**：初級
**核心能力**：布林運算、決策樹最簡化
**思路**：先計數真值數即可；或利用短路：

* 若 A 且 B → True；若 A 異或 B → 取決於 C；若 非(A 或 B) → False。
  **答案**：決策樹示例：

1. 若 A 且 B → True；
2. 否則若 A 或 B 為真 → 回傳 C；
3. 否則 → False。
   （最多 2 次到 3 次判斷，平均較優。）

---

## L3. 工單排程（貪婪）

**題目**：任務皆需 1 小時，給定截止時間與獎勵：
T1(d=2, v=50), T2(d=1, v=10), T3(d=2, v=20), T4(d=1, v=20)。單機，每小時只能做一件，最多做兩小時內的任務，最大化總獎勵。請列出選擇。
**難度**：中級
**核心能力**：貪婪選擇／時窗排程
**思路**：按價值高到低，嘗試填入最靠後可行時段：T1(50)放第2小時、T4(20)或 T2(10)需放第1小時（d=1），比較 T4(20) 與 T3(20)衝突與時窗後選。
**答案**：選 T1（第2小時）+ T4（第1小時），總值 **70**。

---

## L4. 集合覆蓋

**題目**：需覆蓋元素 {1,2,3,4}，候選子集：S1={1,2}, S2={2,3}, S3={3,4}, S4={1,4}, S5={2,4}。選最少子集完成覆蓋。
**難度**：中級
**核心能力**：組合最佳化、集合思維
**思路**：嘗試兩集合覆蓋：S1+S3 覆蓋 {1,2,3,4}。
**答案**：**2** 個子集（如 S1 與 S3）。

---

## L5. 程式片段推理

**題目**（Python 心算）：

```python
def f(nums):
    s = 0
    for i, x in enumerate(nums):
        if i % 2 == 0:
            s += x
        else:
            s -= x
    return s

print(f([3,1,4,1,5,9]))
```

請寫出輸出。
**難度**：初級
**核心能力**：索引、分支邏輯
**思路**：偶位加、奇位減：3-1+4-1+5-9 = 1。
**答案**：**1**。

---

## L6. 最小路徑估算（啟發式）

**題目**：方格 3×3，起點左上、終點右下，只能向右或向下。每格代價如下（行優先）：
Row1: 1, 3, 1
Row2: 1, 5, 1
Row3: 4, 2, 1
求最小代價和（包含起迄格）。
**難度**：中級
**核心能力**：動態規劃思維
**思路**：典型 DP。
**答案**：最小路徑和 **7**（路徑 1→3→1→1→1）。

---

## L7. 快速估算與反例

**題目**：有人主張：「若函式單調遞增，則二分搜尋總能在 O(log n) 找到任意目標值。」請舉一反例說明不一定能「找到」。
**難度**：中級
**核心能力**：邊界條件、反例構造
**思路**：單調遞增但離散查表，目標值不在集合中；或浮點比較誤差。
**答案**：例如有序陣列 \[1,3,5]，目標 2；二分搜尋複雜度 O(log n)，但找不到元素（只能回報不存在）。

---

# 第二部分：後端專業技術測驗（14 題）

## B1. Python 迭代器／生成器

**題目**：寫出生成器 `chunks(iterable, n)`，把可迭代物件分成大小為 n 的區塊（最後不足也回傳）。
**難度**：中級
**核心能力**：生成器、迭代協定
**思路**：累積暫存，湊滿即 `yield`。
**答案**：

```python
def chunks(it, n):
    buf = []
    for x in it:
        buf.append(x)
        if len(buf) == n:
            yield buf
            buf = []
    if buf:
        yield buf
```

---

## B2. Python 可變預設值陷阱

**題目**：解釋下列兩者差異與正確寫法。

```python
def add_item_bad(x, items=[]): ...
def add_item_ok(x, items=None): ...
```

**難度**：初級
**核心能力**：函式呼叫語意、物件生命週期
**思路**：可變預設值在定義時評估且被共用，導致汙染。
**答案**：正確版：

```python
def add_item_ok(x, items=None):
    if items is None:
        items = []
    items.append(x)
    return items
```

---

## B3. Python 同步 vs 非同步

**題目**：說明在 `asyncio` 中，`await`、`async def`、`create_task` 的角色與差異，並舉例何時用 `gather`。
**難度**：中級
**核心能力**：協程模型、並發設計
**答案要點**：

* `async def` 定義協程；`await` 讓出控制權等候可等待物件；`create_task` 將協程排進事件迴圈並行執行。
* `gather` 用於併發等待多個任務並收集結果（如同時呼叫多個外部 API）。

---

## B4. MySQL 索引與查詢計畫

**題目**：有表 `orders(user_id INT, created_at DATETIME, amount DECIMAL, PRIMARY KEY(id))`，高頻查詢：

```sql
SELECT * FROM orders 
WHERE user_id = ? AND created_at BETWEEN ? AND ? 
ORDER BY created_at DESC 
LIMIT 50;
```

請設計合適索引並解釋原因。
**難度**：中級
**核心能力**：複合索引、範圍查詢、排序最佳化
**答案**：建立複合索引 `INDEX idx_user_created (user_id, created_at)`。理由：等值列 `user_id` 放最前，`created_at` 支援範圍與排序（DESC 可用 index order）。LIMIT 受益於索引掃描。若還常以金額排序，另建覆蓋索引或考慮 `INDEX (user_id, created_at, id)` 覆蓋查詢。

---

## B5. MySQL 正規化與反正規化取捨

**題目**：解釋 3NF 重點，並舉一個在讀多寫少報表情境下可考慮反正規化的欄位。
**難度**：中級
**核心能力**：資料建模、正規化原理
**答案**：

* 3NF：每個非鍵屬性只依賴主鍵，且不存在傳遞依賴。
* 反正規化例：在訂單表冗餘存放 `user_name` 或 `category_name`，加速查詢，並以觸發器或應用層維護一致性。

---

## B6. 交易隔離級別

**題目**：說明 MySQL InnoDB 四種隔離級別及常見異常（Dirty Read、Non-repeatable Read、Phantom Read）。
**難度**：中級
**核心能力**：交易一致性、MVCC
**答案要點**：

* Read Uncommitted（可能髒讀）；Read Committed（避免髒讀，仍有不可重複讀）；Repeatable Read（預設，避免不可重複讀，仍可能幻讀，InnoDB 以 Gap Lock/Next-Key Lock 抑制）；Serializable（最嚴格，等同加鎖讀，避免幻讀）。

---

## B7. Django ORM 查詢

**題目**：`Order`(id, user, amount, created\_at) 與 `User` 一對多。找出近 7 天每位使用者的總金額（只取金額 > 1000 的使用者），回傳 `(user_id, total)`。
**難度**：中級
**核心能力**：Django ORM、聚合與過濾
**答案**：

```python
from django.utils import timezone
from django.db.models import Sum

since = timezone.now() - timezone.timedelta(days=7)
qs = (Order.objects
      .filter(created_at__gte=since)
      .values('user_id')
      .annotate(total=Sum('amount'))
      .filter(total__gt=1000))
# 取得清單：list(qs.values_list('user_id', 'total'))
```

---

## B8. Django 中間層與快取

**題目**：描述如何以 Middleware 實作簡易 API 請求日誌；並指出在高讀取 API 如何加上快取（site cache 或 per-view cache），避免 DB 壓力。
**難度**：中級
**核心能力**：Django 請求生命周期、快取策略
**答案要點**：

* Middleware：`__call__` 或 `process_view`/`process_response` 記錄 `path`, `method`, `status_code`, `latency`。
* 快取：設定 `CACHES`，使用 `cache_page(timeout)` 裝飾器或在 `urls.py` 用 `cache_page` 包裝；可依 `Vary` header 或查詢參數分片。

---

## B9. RESTful API 設計

**題目**：設計「訂單」資源 API。列出路由、HTTP 動詞、典型狀態碼與必要的驗證／授權考量。
**難度**：中級
**核心能力**：資源導向設計、HTTP 語意、權限模型
**答案示例**：

* `GET /orders`（200、支援分頁與篩選）
* `POST /orders`（201 Created，回傳 Location）
* `GET /orders/{id}`（200/404）
* `PATCH /orders/{id}`（200/204/409）
* `DELETE /orders/{id}`（204/404）
* 驗證：Bearer Token（OAuth2）、簽章或 HMAC；授權：RBAC/ABAC、資源擁有者檢查；Idempotency-Key 用於重試安全。

---

## B10. Idempotency 與重試

**題目**：說明為何 `POST /payments` 在網路抖動下可能重覆執行，以及如何設計冪等。
**難度**：中級
**核心能力**：分散式穩健性、冪等鍵
**答案**：用戶端提供 `Idempotency-Key`，伺服器以該鍵與請求語義（body hash、user\_id）建立唯一約束，若重複請求，回傳第一次結果與相同 2xx/4xx。DB 層可加唯一索引避免重覆插入。

---

## B11. Git/Gitflow 操作

**題目**：請敘述 Gitflow 的主要分支與一個熱修（hotfix）流程（含標籤）。
**難度**：初級
**核心能力**：版本控制、協作流程
**答案要點**：

* 主要分支：`main`（穩定）、`develop`（開發整合）。
* 支線：`feature/*`、`release/*`、`hotfix/*`。
* Hotfix：從 `main` 切 `hotfix/x.y.z` 修正 → PR 回 `main`，打 tag `vX.Y.Z` 發佈 → 合回 `develop` 同步。

---

## B12. Git 衝突解決情境

**題目**：兩位工程師在同一檔案同一行修改並各自 commit，合併時產生衝突。請列出你處理步驟與如何避免。
**難度**：初級
**核心能力**：衝突處理、協作規範
**答案**：

* 步驟：`git pull --rebase` 或在 PR 中 resolve conflicts；打開檔案手動選擇正確版本 → 本地測試 → `git add` → 完成合併 commit。
* 避免：更細粒度分工、頻繁同步、啟用代碼擁有者與 PR review、模組化拆分。

---

## B13. 第三方服務串接（OAuth2 授權碼流程）

**題目**：以「使用者以 Google 登入」為例，簡述授權碼流程中的關鍵步驟與安全重點（含 redirect\_uri、state、token 儲存）。
**難度**：中級
**核心能力**：OAuth2、Web 安全
**答案要點**：

1. 導向 Google 授權端點（含 client\_id、redirect\_uri、scope、`state`）。
2. 成功後回傳 `code` 與 `state` 至後端。
3. 後端以 `code` 交換 `access_token`（與可選 `refresh_token`）。
4. 以 `access_token` 呼叫 Google API 取得使用者資料。
   安全：檢查 `state` 防 CSRF；`redirect_uri` 須與註冊一致；token 僅存後端（HTTP-only cookie 或 DB），前端不暴露；TLS 強制。

---

## B14. 系統架構與重試、斷路器

**題目**：你在 Django 服務中串接金流供應商，對方偶有延遲。說明你會如何在應用層與基礎設施層處理：重試策略、退避、斷路器、觀測性（指標／日誌／追蹤）。
**難度**：中級
**核心能力**：可靠性工程、可觀測性
**答案要點**：

* 重試：限制次數、指數退避與抖動、僅對可重試錯誤（5xx/網路錯誤）。
* 斷路器：連續失敗達閾值打開，過一段半開試探。
* 超時：連線／讀取合理設定。
* 觀測性：外呼延遲/錯誤率、重試次數、熔斷狀態；結合結構化日誌與分散式追蹤（如 Traceparent header）。
* 業務層：Idempotency-Key、防重覆扣款；資料庫唯一鍵保障請求去重。

---

## B15. Django 設定與環境管理

**題目**：說明如何安全地管理機密（如 DB 密碼、OAuth client secret）並區分 dev/staging/prod 設定。
**難度**：初級
**核心能力**：12-Factor、設定管理
**答案**：

* 使用環境變數或 secrets manager，不把密鑰進版控。
* `settings` 模組依環境載入（或用 `django-environ`/`pydantic-settings`）；不同環境的 DEBUG、ALLOWED\_HOSTS、LOGGING、CACHES、DATABASES 分離。
* 部署時以 CI/CD 注入機密。

---

## B16. MySQL 死鎖排查

**題目**：線上偶發 1213 Deadlock。請提出排查方法與兩個緩解策略。
**難度**：高級
**核心能力**：併發控制、鎖競爭分析
**答案要點**：

* 排查：`SHOW ENGINE INNODB STATUS` 或 performance\_schema 抓 deadlock 形成路徑；分析語句、索引與存取順序。
* 緩解：統一鎖定順序；縮短交易時間、拆小交易；適當索引避免全表掃；降低隔離級別（評估風險）；應用層重試。

---

## B17. Django DRF 範例（序列化與驗證）

**題目**：用 Django REST Framework 實作建立訂單 API，需求：`amount>0`，自動帶 `user` 為目前登入者。請寫出 Serializer 片段（省略 model）。
**難度**：中級
**核心能力**：DRF Serializer、驗證、`create` 覆寫
**答案**：

```python
from rest_framework import serializers

class OrderCreateSerializer(serializers.Serializer):
    amount = serializers.DecimalField(max_digits=12, decimal_places=2)

    def validate_amount(self, v):
        if v <= 0:
            raise serializers.ValidationError("amount must be > 0")
        return v

    def create(self, validated):
        user = self.context['request'].user
        return Order.objects.create(user=user, **validated)
```

---

## B18. REST 安全：輸入驗證與速率限制

**題目**：列出三項你會在公開 API 上實作的安全措施，並簡述理由。
**難度**：初級
**核心能力**：API 安全
**答案**：

1. 驗證與授權（OAuth2/JWT），限制資源存取。
2. 速率限制（per IP/per token），防止暴力與濫用。
3. 請求與輸出驗證／清理（schema validation、避免 SQL/模板注入、XSS），並全站 TLS。

---

## B19. MySQL 覆蓋索引與回表

**題目**：解釋何謂 covering index 與回表，並說明下列查詢如何避免回表：

```sql
SELECT id, user_id, created_at 
FROM orders 
WHERE user_id = ? ORDER BY created_at DESC LIMIT 20;
```

**難度**：中級
**核心能力**：索引結構、IO 優化
**答案**：Covering index：查詢所需欄位皆在索引葉節點，無需回表。可建立 `INDEX (user_id, created_at, id)`，使 `id, user_id, created_at` 全由索引提供。

---

## B20. 部署與靜態檔

**題目**：Django 在生產環境如何服務靜態檔與媒體檔？
**難度**：初級
**核心能力**：部署實務、反向代理
**答案**：`collectstatic` 將靜態檔輸出至目標目錄；由 Nginx/雲端物件儲存（S3/OSS）直接服務；媒體檔路徑隔離、權限控制；應用層只服務動態請求。

---

# 使用方式與建議

* **模擬考**：嚴格限時，先做邏輯題（暖身），再攻專業題；每題先寫「要點版」解法，最後再補細節。
* **無網查**：事先背熟 DRF 常用序列化、QuerySet 聚合、MySQL 索引原則、Gitflow 流程圖。
* **錯題回顧**：把做錯題目標註原因（觀念、粗心、經驗不足）並擬訂補救行動（如練聚合查詢 10 題／天）。

如果你想把這份題集轉成「可列印 PDF／可互動答題版」，我可以直接幫你排版並加上作答區與評分表。

---
# 以下為Grok準備

### 第一部分：邏輯測驗（共6題）

這部分模擬筆試中的邏輯科目，強調數學推理、程式邏輯、演算法思考及問題解決能力。題目設計為無需程式碼執行，但需紙筆計算或推理。時間建議：每題3-5分鐘。

#### 題目1：數學邏輯推理題
**題目描述**：有一個序列：2, 3, 5, 7, 11, ... 請問第10個數字是多少？並解釋序列的規則。  
**難度等級**：初級  
**測試的核心能力**：數學模式辨識與序列推理能力，適用於後端工程師處理數據模式。  
**標準答案或解題思路**：這是質數序列（prime numbers），規則是每個數字只能被1和自己整除。第10個質數是29。思路：列出前10個質數：2,3,5,7,11,13,17,19,23,29。

#### 題目2：程式邏輯思維題
**題目描述**：假設有以下Python偽碼：
```
x = 5
y = 10
if x > y:
    print("A")
elif x < y:
    print("B")
else:
    print("C")
```
請預測輸出，並解釋如果將x改為10，輸出會如何變化？  
**難度等級**：初級  
**測試的核心能力**：條件判斷邏輯與程式執行流程理解，測試後端開發的基本程式思維。  
**標準答案或解題思路**：輸出為"B"，因為5 < 10滿足elif條件。如果x=10，則x==y，輸出"C"。思路：逐步追蹤變數值與條件分支。

#### 題目3：演算法思考題
**題目描述**：你有5個數字：[3,1,4,1,5]，請用氣泡排序（bubble sort）思路排序成升序，並寫出每輪交換後的陣列狀態。  
**難度等級**：中級  
**測試的核心能力**：演算法基本原理與步驟模擬，適用於後端優化數據處理。  
**標準答案或解題思路**：氣泡排序每輪比較相鄰元素並交換。  
- 第一輪：[1,3,1,4,5]（交換3-1,4-1）  
- 第二輪：[1,1,3,4,5]（交換3-1）  
- 第三輪：無交換。最終：[1,1,3,4,5]。思路：重複掃描陣列，直到無交換。

#### 題目4：問題分析與解決題
**題目描述**：一家公司有3個員工A、B、C，他們分別負責任務，但只有一人說真話。A說：“B負責任務。” B說：“C負責任務。” C說：“A負責任務。” 請分析誰負責任務？  
**難度等級**：中級  
**測試的核心能力**：邏輯矛盾分析與真假推理，測試後端工程師的問題診斷能力。  
**標準答案或解題思路**：假設A說真話，則B負責，但B說C負責（假），C說A負責（假），符合一人真話。所以B負責。檢查其他假設會矛盾。

#### 題目5：數學邏輯推理題
**題目描述**：有9個硬幣，其中8個重量相同，一個較輕。使用天平秤，最少秤幾次能找出較輕的硬幣？請描述步驟。  
**難度等級**：高級  
**測試的核心能力**：分治法與決策樹推理，類似後端演算法的二分搜尋優化。  
**標準答案或解題思路**：最少2次。第一次：分3組，每組3個秤兩組，若平衡則輕者在第三組；若不平衡，輕者在較輕組。第二次：從3個中秤2個，找出輕者。思路：每次三等分減少可能性。

#### 題目6：程式邏輯思維題
**題目描述**：假設一個迴圈：for i in range(1,6): if i % 2 == 0: continue else: print(i) 請預測輸出，並解釋如果改成break會如何？  
**難度等級**：中級  
**測試的核心能力**：迴圈控制語句理解與邊緣條件分析，測試Python後端程式邏輯。  
**標準答案或解題思路**：輸出1,3,5（跳過偶數）。如果改成break，輸出1（遇到2時break）。思路：continue跳過本次，break終止迴圈。

### 第二部分：後端專業技術測驗（共12題）

這部分模擬筆試中的後端專業科目，涵蓋職缺要求的技術點。題目設計為描述性或簡單程式碼撰寫，無需實際執行。時間建議：每題5-10分鐘。

#### 題目1：Python語法和進階特性
**題目描述**：寫一個Python函數，使用list comprehension從[1,2,3,4,5,6]中篩選出偶數並平方。  
**難度等級**：初級  
**測試的核心能力**：Python基本語法與列表推導式，測試後端開發效率。  
**標準答案或解題思路**：def even_squares(lst): return [x**2 for x in lst if x % 2 == 0] 調用：[4,16,36]。思路：推導式結合條件與運算。

#### 題目2：MySQL資料庫操作、正規化、特性
**題目描述**：解釋資料庫正規化（Normalization）的第三範式（3NF），並給出一個違反3NF的表格範例及如何修正。  
**難度等級**：中級  
**測試的核心能力**：MySQL資料庫設計原則，測試後端資料儲存優化。  
**標準答案或解題思路**：3NF要求消除非主鍵依賴。範例：表格（訂單ID, 客戶ID, 客戶地址），客戶地址依賴客戶ID。修正：拆成訂單表（訂單ID,客戶ID）和客戶表（客戶ID,地址）。思路：減少冗餘，避免更新異常。

#### 題目3：Django框架應用
**題目描述**：在Django中，如何定義一個模型類別Book，包括欄位title (字串)、author (字串)、publish_date (日期)？請寫出程式碼片段。  
**難度等級**：初級  
**測試的核心能力**：Django模型定義，測試後端框架實作。  
**標準答案或解題思路**：from django.db import models  
class Book(models.Model):  
    title = models.CharField(max_length=100)  
    author = models.CharField(max_length=50)  
    publish_date = models.DateField()  
思路：繼承Model，使用欄位類別定義屬性。

#### 題目4：RESTful API設計原則和實作
**題目描述**：RESTful API中，GET、POST、PUT、DELETE分別用於什麼操作？給出一個書籍資源的API端點範例。  
**難度等級**：初級  
**測試的核心能力**：RESTful設計原則，測試後端API開發。  
**標準答案或解題思路**：GET:讀取, POST:創建, PUT:更新, DELETE:刪除。範例：/books (GET所有書籍), /books/{id} (GET單本), /books (POST新增), /books/{id} (PUT更新), /books/{id} (DELETE刪除)。思路：基於HTTP方法與資源URI。

#### 題目5：Git/Gitflow版本控制操作
**題目描述**：解釋Gitflow工作流程中的develop和feature分支角色，並描述如何從feature合併到develop（包含衝突解決）。  
**難度等級**：中級  
**測試的核心能力**：Git操作與分支管理，測試後端團隊協作。  
**標準答案或解題思路**：develop為主要開發分支，feature為新功能分支。步驟：git checkout develop; git merge feature/xxx; 若衝突，手動編輯檔案後git add .; git commit。思路：使用merge確保穩定。

#### 題目6：Python語法和進階特性
**題目描述**：寫一個Python裝飾器，用來記錄函數執行時間。  
**難度等級**：高級  
**測試的核心能力**：Python進階裝飾器應用，測試後端效能優化。  
**標準答案或解題思路**：import time  
def timer(func):  
    def wrapper(*args, **kwargs):  
        start = time.time()  
        result = func(*args, **kwargs)  
        print(time.time() - start)  
        return result  
    return wrapper  
思路：使用內部函數包裝原函數，計算時間。

#### 題目7：MySQL資料庫操作、正規化、特性
**題目描述**：寫一個MySQL查詢，從users表（id, name, email）和orders表（id, user_id, amount）中，查詢每個用戶的總訂單金額，使用JOIN和GROUP BY。  
**難度等級**：中級  
**測試的核心能力**：MySQL進階查詢，測試後端資料處理。  
**標準答案或解題思路**：SELECT u.name, SUM(o.amount) FROM users u JOIN orders o ON u.id = o.user_id GROUP BY u.id; 思路：內聯結合併表格，聚合函數計算總和。

#### 題目8：Django框架應用
**題目描述**：在Django中，如何處理一個POST請求的表單提交，並儲存到資料庫？請描述視圖函數的步驟。  
**難度等級**：中級  
**測試的核心能力**：Django視圖與表單處理，測試後端應用邏輯。  
**標準答案或解題思路**：def create_book(request): if request.method == 'POST': form = BookForm(request.POST); if form.is_valid(): form.save(); return redirect('list'); else: form = BookForm(); return render(request, 'form.html', {'form': form})。思路：檢查方法，驗證表單，儲存並重導。

#### 題目9：RESTful API設計原則和實作
**題目描述**：設計一個RESTful API端點，用於用戶登入，返回JWT token。討論狀態碼使用。  
**難度等級**：高級  
**測試的核心能力**：RESTful安全設計，測試後端認證實作。  
**標準答案或解題思路**：POST /auth/login，body: {username, password}。成功返回200與token，失敗401。思路：無狀態，使用token避免session。

#### 題目10：Git/Gitflow版本控制操作
**題目描述**：在Git中，如何解決merge衝突？給出命令序列。  
**難度等級**：初級  
**測試的核心能力**：Git衝突處理，測試後端版本控制。  
**標準答案或解題思路**：git merge branch; (衝突出現) 編輯檔案移除<<<===>>>標記; git add .; git commit -m "resolved"。思路：手動合併後提交。

#### 題目11：系統架構和第三方整合
**題目描述**：描述如何在Python後端串接第三方支付API（如Stripe），包含步驟和錯誤處理。  
**難度等級**：高級  
**測試的核心能力**：第三方服務串接，測試後端整合能力。  
**標準答案或解題思路**：安裝stripe庫; import stripe; stripe.api_key = 'key'; try: charge = stripe.Charge.create(amount=100, currency='usd', source='token'); except stripe.error.CardError as e: handle_error。思路：設定API key，呼叫方法，捕捉例外。

#### 題目12：網路安全和認證機制
**題目描述**：解釋OAuth2.0的授權碼流程（Authorization Code Flow），並討論其在後端API中的應用優勢。  
**難度等級**：高級  
**測試的核心能力**：網路API規劃與OAuth認證，測試後端安全機制。  
**標準答案或解題思路**：步驟：用戶重導到授權伺服器，登入後獲code; 後端用code換token; 用token存取資源。優勢：安全，避免直接暴露憑證，適用第三方登入。思路：分離授權與資源伺服器。