
using BrassAndPoem;

// ===================================== DATA SOURCE =====================================

//create a "products" variable here to include at least five Product instances. Give them appropriate ProductTypeIds.
List<Product> products = new List<Product>()
{
   new Product("The Tears that Taught Me", 16.99M, 2),
   new Product("Milk and Honey", 7.83M, 2),
   new Product("Save Me an Orange", 13.01M, 2),
   new Product("Twenty Something", 14.60M, 2),
   new Product("Glory Bb Trumpet", 109.99M, 1),
   new Product("Jean Paul TR-330 Trumpet", 249.99M, 1),
   new Product("Alto Trombone Bb", 149.99M, 1),
   new Product("B Flat 4 Key Single Row French Horn", 369.00M, 1),
   new Product("Double French Horn", 560.00M, 1),
   new Product("Stagg WS - BT235 Tuba with case", 1_383.48M, 1),
   new Product("King Tuba Straight Bell", 989.00M, 1),
   new Product("YAMAHA YBB-103 Tuba", 1_200.00M, 1),
};

//create a "productTypes" variable here with a List of ProductTypes, and add "Brass" and "Poem" types to the List. 
List<ProductType> productTypes = new List<ProductType>()
{
    new ProductType("Brass Instrument", 1),
    new ProductType("Poem", 2),
};

// =============================================== MENU ===============================================

void DisplayMenu()
{
    // throw new NotImplementedException();
    while (true)
    {
        Console.WriteLine("==========================================================================================");
        Console.WriteLine();
        Console.WriteLine("Please choose one of the following options: ");
        Console.WriteLine("a: Display all products");
        Console.WriteLine("b: Delete a product");
        Console.WriteLine("c: Add a new product");
        Console.WriteLine("d: Update product properties");
        Console.WriteLine("e: Exit");
        Console.WriteLine();
        string response = Console.ReadLine()?.Trim();

        // PROCESS MENU RESPONSE
        switch (response?.ToLower().Trim())
        {
            case "a":
                Console.Clear();
                Console.WriteLine("All Products Menu");
                DisplayAllProducts(products, productTypes);
                continue;
            case "b":
                Console.Clear();
                Console.WriteLine("Delete Menu");
                // DeleteProduct();
                continue;
            case "c":
                Console.Clear();
                Console.WriteLine("Add a New Product Menu ");
                // AddProduct();
                continue;
            case "d":
                Console.Clear();
                Console.WriteLine("Update Product Properties Menu");
                // UpdateProduct();
                continue;
            case "e":
                Console.WriteLine("Terminating program...");
                break;
            default:
                Console.WriteLine("Invalid response. Please try again. ");
                Console.WriteLine();
                // Console.Clear();
                continue;
        }
        break;
    }
}

// ===================================== CRUD METHODS FOR MENU =====================================

void DisplayAllProducts(List<Product> products, List<ProductType> productTypes)
{
    // throw new NotImplementedException();
    while (true)
    {
        foreach (Product product in products)
        {
            Console.WriteLine($"  {product.Name} - {productTypes[product.ProductTypeId - 1].Title}");
        }
        break;
    }
}

void DeleteProduct(List<Product> products, List<ProductType> productTypes)
{
    throw new NotImplementedException();
}

void AddProduct(List<Product> products, List<ProductType> productTypes)
{
    throw new NotImplementedException();
}

void UpdateProduct(List<Product> products, List<ProductType> productTypes)
{
    throw new NotImplementedException();
}

// ==================== STARTUP GREETING AND PROMPT USER TO MAKE A SELECTION IN THE MENU. ====================
string greeting = "Welcome to Brass & Poem Shop! We offer the best selection of poetry books and " +
                  "brass musical instruments on the web!";
Console.WriteLine();
Console.WriteLine();
Console.WriteLine("============================================================================================");
Console.WriteLine(greeting);
DisplayMenu();

// don't move or change this!
public partial class Program { }