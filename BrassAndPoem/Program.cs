
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
        Console.WriteLine("============================================================================================" +
                          "");
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
                DeleteProduct(products, productTypes);
                continue;
            case "c":
                Console.Clear();
                Console.WriteLine("Add a New Product Menu ");
                AddProduct(products, productTypes);
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

void DisplayAllProducts(List<Product> productsList, List<ProductType> productTypesList)
{
    // throw new NotImplementedException();
    while (true)
    {
        int counter = 0;
        foreach (Product product in productsList)
        {
            // Console.WriteLine($"  {product.Name} - {productTypes[product.ProductTypeId - 1].Title}");
            Console.WriteLine($" {++counter}.) {product.Name} -- {product.Price} - {productTypesList[product.ProductTypeId - 1].Title}");
        }
        break;
    }
}

void DeleteProduct(List<Product> productsList, List<ProductType> productTypesList)
{
    // throw new NotImplementedException();
    while (true)
    {
        try
        {
            Console.WriteLine("Please enter the number that corresponds to the product you are trying to remove: ");
            int counter = 0;
            foreach (Product p in productsList)
            {
                Console.WriteLine($"{++counter}. {p.Name}");
            }
            int response = Convert.ToInt32(Console.ReadLine());

            if (response < 1 || response > productsList.Count)
            {
                Console.WriteLine("Invalid entry. Please try again.");
                continue;
            }
            // If selection is valid, remove it from the list.
            // Product chosenProduct = products[response - 1];
            Product chosenProduct = products.Find(p => p.Name == productsList[response - 1].Name);
            productsList.Remove(chosenProduct);
            Console.WriteLine("Removed the product. Here is the updated list:");
            DisplayAllProducts(productsList, productTypesList);
            break;
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid selection. Please pick a number from the list. ");
        }
    }
    DisplayMenu();
}

void AddProduct(List<Product> productsList, List<ProductType> productTypesList)
{
    // throw new NotImplementedException();
    while (true)
    {
        Console.WriteLine("Please enter the following information about the product:");
        
        Console.Write("Product name: ");
        string productName = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(productName))
        {
            Console.WriteLine("Please enter a valid product name.");
            continue;
        }
        
        Console.Write("How much should this item cost? Enter a dollar value. Ex. 29.99: ");
        if (!decimal.TryParse(Console.ReadLine(), out var productPrice))
        {
            Console.WriteLine("Please enter a valid product type.");
            continue;
        }
        
        Console.Write("What type of product is it? ex. poem: ");
        string productTypeName = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(productTypeName))
        {
            Console.WriteLine("Please enter a valid product name.");
            continue;
        }
        
        // Process information.
        Console.WriteLine("Test variables: ");
        Console.WriteLine($"{(nameof(productName))}: {productName}");
        Console.WriteLine($"{(nameof(productPrice))}: {productPrice}");
        
        // Payloads
        ProductType payloadType = new ProductType(productTypeName, (productTypesList.Count + 1));
        Product payload =
            new Product(productName, productPrice, payloadType.Id);

        // Create new records.
        productTypesList.Add(payloadType);
        productsList.Add(payload);
        
        // Confirmation.
        Console.WriteLine($"{payload.Name} was successfully added to the inventory. with an index number of " +
                          $"{payload.ProductTypeId}");
        break;
    }
}

void UpdateProduct(List<Product> products, List<ProductType> productTypes)
{
    throw new NotImplementedException();
}

// ========================= STARTUP GREETING AND PROMPT USER TO MAKE A SELECTION IN THE MENU. =========================
string greeting = "Welcome to Brass & Poem Shop! We offer the best selection of poetry books and " +
                  "brass musical\ninstruments on the web!";
Console.WriteLine();
Console.WriteLine();
Console.WriteLine("============================================================================================");
Console.WriteLine(greeting);
DisplayMenu();

// don't move or change this!
public partial class Program { }