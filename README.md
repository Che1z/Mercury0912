<h2>CRUD API 文檔</h2>
這份 API 提供了對DB進行基本 CRUD（創建、讀取、更新、刪除）操作的功能。它使用 ASP.NET Core 框架所建立，並提供了一個靈活的API接口來進行不同的操作。

<hr>

<h3>使用方法</h3>

API 使用 DatabaseService class來處理數據庫操作。
確保在 appsettings.json 中正確配置了數據庫連接字符串：

{
  "ConnectionStrings": {
    "DefaultConnection": "數據庫連接字符串"
  }
}


<h3>API 端點</h3>

1. 創建記錄

URL: /api/records/create
方法: POST

URL 參數:
tableName=[string]
sid=[string]


成功響應:

代碼: 200
內容: "Record created"



範例：
POST /api/records/create?tableName=Users&sid=12345
</hr>
2. 讀取記錄

URL: /api/records/read
方法: GET
URL 參數:

tableName=[string]
sid=[string]


成功響應:

代碼: 200
內容: "12345"


錯誤響應:

代碼: 404 NOT FOUND
內容: "Record not found"



範例：
GET /api/records/read?tableName=Users&sid=12345
</hr>
3. 更新記錄

URL: /api/records/update
方法: PUT
URL 參數:

tableName=[string]
oldSid=[string]
newSid=[string]


成功響應:

代碼: 200
內容: "Record updated"



範例：
PUT /api/records/update?tableName=Users&oldSid=12345&newSid=67890
</hr>
4. 刪除記錄

URL: /api/records/delete
方法: DELETE
URL 參數:

tableName=[string]
sid=[string]


成功響應:

代碼: 200
內容: "Record deleted"



範例：
DELETE /api/records/delete?tableName=Users&sid=12345
錯誤處理

如果請求的記錄不存在，API 將返回 404 Not Found 錯誤。
