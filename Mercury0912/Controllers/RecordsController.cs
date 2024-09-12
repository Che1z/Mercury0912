using Mercury0912.Service;
using Microsoft.AspNetCore.Mvc;

namespace Mercury0912.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordsController : ControllerBase
    {
        private readonly DatabaseService _databaseService;

        public RecordsController(DatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        // POST 請求：建立新記錄
        [HttpPost("create")]
        public async Task<IActionResult> Create(string tableName, string sid)
        {
            // 呼叫服務層方法以建立新記錄
            await _databaseService.CreateRecordAsync(tableName, sid);
            // 回傳成功訊息
            return Ok("Record created");
        }

        // GET 請求：讀取記錄
        [HttpGet("read")]
        public async Task<IActionResult> Read(string tableName, string sid)
        {
            // 呼叫服務層方法以讀取記錄
            var result = await _databaseService.ReadRecordAsync(tableName, sid);
            // 如果記錄不存在，回傳 404 Not Found
            if (result == null)
                return NotFound("Record not found");
            // 回傳找到的記錄
            return Ok(result);
        }

        // PUT 請求：更新記錄
        [HttpPut("update")]
        public async Task<IActionResult> Update(string tableName, string oldSid, string newSid)
        {
            // 呼叫服務層方法以更新記錄
            await _databaseService.UpdateRecordAsync(tableName, oldSid, newSid);
            // 回傳成功訊息
            return Ok("Record updated");
        }

        // DELETE 請求：刪除記錄
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(string tableName, string sid)
        {
            // 呼叫服務層方法以刪除記錄
            await _databaseService.DeleteRecordAsync(tableName, sid);
            // 回傳成功訊息
            return Ok("Record deleted");
        }
    }
}
