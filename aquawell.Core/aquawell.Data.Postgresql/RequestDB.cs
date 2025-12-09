using System.Data;
using aquawell.Data.Postgresql.Models;

namespace aquawell.Data.Postgresql;

public class RequestDB
{
    public async Task PastOrders(string clientName, string clientMail, string clientPhone)
    {
        string query = await File.ReadAllTextAsync("Data/Sql/PostOrder.sql");
        
        BDWork db = new BDWork();
        
        var parameters = new Dictionary<string, object>
        {
            {"@clientName", clientName},
            {"@clientmail", clientMail},
            {"@clientphonenum", clientPhone},
            {"@datesubmissionorder",  DateTime.Now},
        };

        await db.Insert(query, parameters);
    }
}