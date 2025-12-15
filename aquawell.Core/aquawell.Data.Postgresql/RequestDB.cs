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

    public async Task<MinProductModel> GetMinProduct()
    {
        string query = await File.ReadAllTextAsync("Data/Sql/SelectMinProductInfo.sql");
        BDWork db = new BDWork();
        
        DataTable minProduct = await db.GetDataTableAsync(query);
        if (minProduct.Rows.Count < 1)
            return null;
        
        return new MinProductModel
        {
            ProductName = minProduct.Rows[0]["ProductName"].ToString() ?? "",
            ProductPrice = Convert.ToDecimal(minProduct.Rows[0]["ProductPrice"])
        };
    }
}