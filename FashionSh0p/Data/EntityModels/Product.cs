public class Product
{
    public Product()
    {
        this.Variants = new HashSet<ProductVariant>();
        this.Images = new HashSet<ProductImage>(); 
    }

    public int Id { get; set; }

    public string ProductName { get; set; }

    public string BrandName { get; set; }

    public string ProductType { get; set; }

    public string Description { get; set; }

    public double Price { get; set; }

    public string ImageUrl { get; set; }

    public int CategoryId { get; set; }

    public virtual Category Category { get; set; }

    public virtual ICollection<ProductVariant> Variants { get; set; }

    public virtual ICollection<ProductImage> Images { get; set; }
}
