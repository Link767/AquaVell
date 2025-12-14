namespace aquawell.Core.Dto;

public class FullProductDto
{
    public string ProductName { get; set; } = null!;
    public double ProductWidth { get; set; } // Шииена
    public double ProductLength { get; set; } // Длинна 
    public double ProductDepth { get; set; } // Глубина
    public string ProductDescription { get; set; } = null!; // Описание
    public decimal ProductPrice { get; set; }
    public List<ProductPhotoDto> ProductPhotos { get; set; } = [];
}