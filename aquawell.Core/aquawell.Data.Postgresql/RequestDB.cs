using System.Data;
using aquawell.Data.Postgresql.Models;

namespace aquawell.Data.Postgresql;

public class RequestDB
{
    public async Task PastOrders(string clientName, string clientMail, string clientPhone)
    {
        string query = "INSERT INTO oreders (clientname, clientmail, clientphonenum) VALUES (@clientName,@clientmail,@clientphonenum)";
        
        BDWork db = new BDWork();
        
        var parameters = new Dictionary<string, object>
        {
            {"@clientName", clientName},
            {"@clientmail", clientMail},
            {"@clientphonenum", clientPhone},
        };

        await db.Insert(query, parameters);
    }
}