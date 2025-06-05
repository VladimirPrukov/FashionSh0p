public class Size
{
    public Size()
    {
        this.ProductVariants = new HashSet<ProductVariant>();
    }

    public int Id { get; set; }

    public string Name { get; set; } // "S", "M", "L", "XL"

    public virtual ICollection<ProductVariant> ProductVariants { get; set; }
}