@echo off
setlocal

:: 設定變數
set JAR=ojdbc11.jar
set CLASS=TestJDBC
set JAVA_CODE=%CLASS%.java

:: 建立 Java 檔
echo import java.sql.*; > %JAVA_CODE%
echo public class %CLASS% { >> %JAVA_CODE%
echo     public static void main(String[] args) { >> %JAVA_CODE%
echo         try { >> %JAVA_CODE%
echo             Class.forName("oracle.jdbc.OracleDriver"); >> %JAVA_CODE%
echo             Connection conn = DriverManager.getConnection("jdbc:oracle:thin:@//localhost:1521/XEPDB1", "wms", "wms1234"); >> %JAVA_CODE%
:: echo             System.out.println("✅ 成功連線 Oracle XE!"); >> %JAVA_CODE%
echo             System.out.println("Connected to Oracle XE!"); >> %JAVA_CODE%
echo             conn.close(); >> %JAVA_CODE%
echo         } catch (Exception e) { e.printStackTrace(); } >> %JAVA_CODE%
echo     } >> %JAVA_CODE%
echo } >> %JAVA_CODE%

:: 編譯 Java
javac -cp .;%JAR% %JAVA_CODE%
if errorlevel 1 goto :eof

:: 執行
java -cp .;%JAR% %CLASS%

:: 清除檔案（選擇性）
del %CLASS%.class
del %JAVA_CODE%

endlocal
