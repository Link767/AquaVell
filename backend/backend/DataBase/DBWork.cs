using backend.DataBase.Table;
using Microsoft.Data.SqlClient;
using System.Runtime.InteropServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace backend.DataBase
{
    public class DBWork
    {
        string _conStr = "";
        public DBWork(string conStr)
        {
            this._conStr = conStr;
        }
        public async Task AddOrderAsunc(string name, string email, string telNum)
        {
            await using var conn = new SqlConnection(_conStr);
            await conn.OpenAsync();

            await using var tran = await conn.BeginTransactionAsync(); // DbTransaction

            await using var command = conn.CreateCommand();
            command.Transaction = (SqlTransaction)tran;
            command.CommandText = "INSERT INTO [Order] (Name, Email, TelNum) VALUES (@name, @email, @telNum)";
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@telNum", telNum);

            try
            {
                int row = await command.ExecuteNonQueryAsync();
                await tran.CommitAsync();
            }
            catch
            {
                await tran.RollbackAsync();
                throw;
            }
        }
    }
}
