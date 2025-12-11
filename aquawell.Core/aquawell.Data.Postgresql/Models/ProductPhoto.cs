namespace aquawell.Data.Postgresql.Models;

public class ProductPhoto
{
    public int IdProductPhoto { get; set; }
    public string ProductPhotoUrl  { get; set; } = ""; // путь где лежит фотка
    public bool IsMain { get; set; } // главная ли фотка 
    public DateTime CreatedAt { get; set; } // Дата добавления
}