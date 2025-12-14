namespace aquawell.Core.Dto;

public class MinProductDto
{
    public string ProductName { get; set; } = "";
    public decimal ProductPrice { get; set; }
    public List<ProductPhotoDto> ProductPhotos { get; set; } = [];
}