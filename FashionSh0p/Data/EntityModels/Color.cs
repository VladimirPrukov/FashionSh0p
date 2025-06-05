public class Color
{
    public Color()
    {
        this.ProductVariants = new List<ProductVariant>();
    }
    
    public int Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<ProductVariant> ProductVariants { get; set; }
}