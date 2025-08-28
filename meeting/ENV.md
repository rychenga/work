# 環境安裝流程
## 安裝元件

### wms_webapi
- 安裝 dotnet-sdk-6.0.428-win-x64.exe,就可以啟動專案。

### WLocationWeb
- 安裝 dotnet-sdk-6.0.428-win-x64.exe,就可以啟動專案。

### 資料庫版本
- Oracle 21c XE

### Oracle 21c XE 安裝流程
1. 安裝 docker desktop
   - 透過 windwos 11 上的 doceker desktop 安裝 Oracle 21c XE 教學 id 為 wms , password = wms1234
2. 拉取 Oracle 21c XE docker image
    ```bash
    docker pull container-registry.oracle.com/database/express:21.3.0-xe
    ```
3. 執行 Oracle 21c XE 容器並設定 sys 密碼(exp: sys/lucky1314)
    ```bash
    docker run -d --name oracle21c-xe -p 1521:1521 -p 5500:5500 -e ORACLE_PWD=lucky1314 -e ORACLE_CHARACTERSET=AL32UTF8 container-registry.oracle.com/database/express:21.3.0-xe
    ```
4. 檢查 Oracle XE 服務是否正常啟動
    ```bash
    https://localhost:5500/em
    ```
5. 準備建立 wms / wms1234 帳號
   1. sqlplus sys/lucky1314@XEPDB1 as sysdba (DBA帳號連線)
        ```bash
        docker exec -it oracle21c-xe sqlplus sys/lucky1314@XEPDB1 as sysdba
        ```
   2. 建立 wms/wms1234 帳號
        ```bash
        CREATE USER wms IDENTIFIED BY "wms1234";
        GRANT CONNECT, RESOURCE TO wms;
        ALTER USER wms DEFAULT TABLESPACE USERS QUOTA UNLIMITED ON USERS;
        exit
        ```
6. DBeaver連線所需資訊

|連線參數|輸入值|
|---|---|
|Host|localhost|
|Port|1521|
|Service Name|XEPDB1|
|Username|wms|
|Password|wms1234|

7. 建構TABLE Schema
   - setUpBase.sql
8. 匯入資料
   - importData.sql 
9.  備註




