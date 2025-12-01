using System.Data;
using Npgsql;

namespace aquawell.Data.Postgresql;

public class BDWork
{
    private string _connectionString = "Server=127.0.0.1;Port=5432;User Id=postgres;Password=1234;Database=aquawell;";

    public async Task Insert(string query, Dictionary<string, object> parameters)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync();

        using var transaction = await connection.BeginTransactionAsync();
        using var command = new NpgsqlCommand(query, connection, transaction);

        // Добавляем параметры в команду
        foreach (var p in parameters)
            command.Parameters.AddWithValue(p.Key, p.Value);

        try
        {
            await command.ExecuteNonQueryAsync();
            await transaction.CommitAsync();
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }


    public async Task<DataTable> GetDataTableAsync(string query)
    {
        using (NpgsqlConnection connection =  new NpgsqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connection))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }
    }
}