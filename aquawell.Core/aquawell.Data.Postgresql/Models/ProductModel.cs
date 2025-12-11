namespace aquawell.Data.Postgresql.Models;

public class ProductModel
{
    public string ProductName { get; set; } = ""; // Имя продукта
    public float ProductWidth { get; set; } // Ширина 
    public float ProductLength { get; set; } // Длинна 
    public float ProductDepth { get; set; } // Глубина
    public string ProductDescription { get; set; } = ""; // Описание
    public decimal ProductPrice { get; set; } // Цена
}