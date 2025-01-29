namespace BrassAndPoem;

//create your Product class here
public class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int ProductTypeId { get; set; }
    
    // Constructor
    public Product
    (
        string name,
        decimal price,
        int productTypeId
    )
    {
        // Validating
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentNullException(nameof(name));
        ArgumentOutOfRangeException.ThrowIfNegative(price);

        Name = name;
        Price = price;
        ProductTypeId = productTypeId;
    }
}