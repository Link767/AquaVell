namespace aquawell.Data.Postgresql.Models;

public class OrderModel
{
    public int IdOrder { get; set; }
    public string ClientName { get; set; } = "";
    public string ClientMail { get; set; } = "";
    public string ClientPhoneNum { get; set; } = "";
    public DateTime OrderDate { get; set; }
}