using Microsoft.Data.SqlClient;

namespace Bekend.Data.RequestDataBase;

public class AddOrderRequest : DataBaseWork
{
    public async Task<bool> AddOrderAsunc(string name, string email, string telNum)
    {
        
        await using var conn = new SqlConnection(conStr);
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
            return true;
        }
        catch
        {
            await tran.RollbackAsync();
            throw;
        }
    }
}