namespace BrassAndPoem;

//create your ProductType class here
public class ProductType
{
    public string Title { get; set; }
    public int Id { get; set; }
    
    // Constructor
    public ProductType(string title, int id)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentNullException(nameof(title));
        
        Title = title;
        Id = id;
    }
}