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
            ProductName = minProduct.Rows[0]["productname"].ToString() ?? "",
            ProductPrice = Convert.ToDecimal(minProduct.Rows[0]["productprice"])
        };
    }

    public async Task<ProductModel> GetProduct(string productName) //переписать на Daper !!!!
    {
        string query = await File.ReadAllTextAsync("Data/Sql/SelectMinProductInfo.sql");
        BDWork db = new BDWork();
        var param = new Dictionary<string, object>
        {
            ["productName"] = productName
        };
        DataTable? fullProduct = await db.GetDataTableAsync(query, param);
        if (fullProduct.Rows.Count < 1)
        {
            Console.WriteLine($"No records in table product\nPlease check data in table");
            return null;
        }
        return new ProductModel
        {
            ProductName = fullProduct.Rows[0]["productname"].ToString() ?? "",
            ProductWidth = Convert.ToSingle(fullProduct.Rows[0]["productwidth"]),
           //  ProductLength = (float) fullProduct.Rows[0]["productlength"],
           // ProductDepth = (float) fullProduct.Rows[0]["productdepth"],
           // ProductDescription = fullProduct.Rows[0]["productdescription"].ToString() ?? "",
            ProductPrice = Convert.ToDecimal(fullProduct.Rows[0]["productprice"])
        };
    }
}