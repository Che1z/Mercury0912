using Microsoft.Data.SqlClient;
using System.Data;

namespace Mercury0912.Service
{
    public class DatabaseService
    {
        private readonly string _connectionString;

        public DatabaseService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        /// <summary>
        /// 創建一個新的記錄到指定的資料表中。
        /// </summary>
        /// <param name="tableName">資料表名稱。</param>
        /// <param name="acpdSid">要插入的記錄的 acpd_sid。</param>
        /// <returns>一個表示異步操作完成的任務。</returns>
        public async Task CreateRecordAsync(string tableName, string acpdSid)
        {
            // 使用 SqlConnection 物件連接到 SQL Server 資料庫
            using (var connection = new SqlConnection(_connectionString))
            {
                // 異步打開資料庫連接
                await connection.OpenAsync();

                // 定義 SQL 命令文本，插入新的記錄到指定的資料表
                var commandText = $"INSERT INTO {tableName} (acpd_sid) VALUES (@acpd_sid)";
                using (var command = new SqlCommand(commandText, connection))
                {
                    // 添加參數，以防止 SQL 注入
                    command.Parameters.Add(new SqlParameter("@acpd_sid", SqlDbType.NVarChar) { Value = acpdSid });

                    // 異步執行 SQL 命令，不返回任何結果
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        /// <summary>
        /// 從指定的資料表中讀取記錄。
        /// </summary>
        /// <param name="tableName">資料表名稱。</param>
        /// <param name="acpdSid">要查詢的記錄的 acpd_sid。</param>
        /// <returns>如果找到記錄，則返回記錄的 acpd_sid；否則返回 null。</returns>
        public async Task<string> ReadRecordAsync(string tableName, string acpdSid)
        {
            // 使用 SqlConnection 物件連接到 SQL Server 資料庫
            using (var connection = new SqlConnection(_connectionString))
            {
                // 異步打開資料庫連接
                await connection.OpenAsync();

                // 定義 SQL 命令文本，根據指定的 acpd_sid 查詢記錄
                var commandText = $"SELECT acpd_sid FROM {tableName} WHERE acpd_sid = @acpd_sid";
                using (var command = new SqlCommand(commandText, connection))
                {
                    // 添加參數，以防止 SQL 注入
                    command.Parameters.Add(new SqlParameter("@acpd_sid", SqlDbType.NVarChar) { Value = acpdSid });

                    // 異步執行 SQL 命令並返回結果的第一行第一列值
                    var result = await command.ExecuteScalarAsync();
                    // 將結果轉換為字串並返回
                    return result?.ToString();
                }
            }
        }

        /// <summary>
        /// 更新指定資料表中的記錄。
        /// </summary>
        /// <param name="tableName">資料表名稱。</param>
        /// <param name="oldAcpdSid">要更新的記錄的舊 acpd_sid。</param>
        /// <param name="newAcpdSid">要更新為的新 acpd_sid。</param>
        /// <returns>一個表示異步操作完成的任務。</returns>
        public async Task UpdateRecordAsync(string tableName, string oldAcpdSid, string newAcpdSid)
        {
            // 使用 SqlConnection 物件連接到 SQL Server 資料庫
            using (var connection = new SqlConnection(_connectionString))
            {
                // 異步打開資料庫連接
                await connection.OpenAsync();

                // 定義 SQL 命令文本，根據舊的 acpd_sid 更新記錄的 acpd_sid 為新的值
                var commandText = $"UPDATE {tableName} SET acpd_sid = @NewAcpdSid WHERE acpd_sid = @OldAcpdSid";
                using (var command = new SqlCommand(commandText, connection))
                {
                    // 添加參數，以防止 SQL 注入
                    command.Parameters.Add(new SqlParameter("@OldAcpdSid", SqlDbType.NVarChar) { Value = oldAcpdSid });
                    command.Parameters.Add(new SqlParameter("@NewAcpdSid", SqlDbType.NVarChar) { Value = newAcpdSid });

                    // 異步執行 SQL 命令，不返回任何結果
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        /// <summary>
        /// 刪除指定資料表中的記錄。
        /// </summary>
        /// <param name="tableName">資料表名稱。</param>
        /// <param name="acpdSid">要刪除的記錄的 acpd_sid。</param>
        /// <returns>一個表示異步操作完成的任務。</returns>
        public async Task DeleteRecordAsync(string tableName, string acpdSid)
        {
            // 使用 SqlConnection 物件連接到 SQL Server 資料庫
            using (var connection = new SqlConnection(_connectionString))
            {
                // 異步打開資料庫連接
                await connection.OpenAsync();

                // 定義 SQL 命令文本，根據指定的 acpd_sid 刪除記錄
                var commandText = $"DELETE FROM {tableName} WHERE acpd_sid = @acpd_sid";
                using (var command = new SqlCommand(commandText, connection))
                {
                    // 添加參數，以防止 SQL 注入
                    command.Parameters.Add(new SqlParameter("@acpd_sid", SqlDbType.NVarChar) { Value = acpdSid });

                    // 異步執行 SQL 命令，不返回任何結果
                    await command.ExecuteNonQueryAsync();
                }
            }
        }


    }
}
