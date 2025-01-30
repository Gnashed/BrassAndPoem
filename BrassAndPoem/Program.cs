
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
                UpdateProduct(products, productTypes);
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

void UpdateProduct(List<Product> productsList, List<ProductType> productTypesList)
{
    // throw new NotImplementedException();
        while (true)
    {
        // Loop through product list.
        Console.WriteLine("Please enter number that corresponds to the product you are trying to update: ");
        int counter = 0;
        foreach (Product product in productsList)
        {
            Console.WriteLine($"\t{++counter} -- {product.Name}");
        }

        // Prompt user to enter a number that corresponds to the product they want to update.
        string response = Console.ReadLine()?.Trim();
        
        if (!int.TryParse(response, out counter) && counter < 1)
        {
            Console.WriteLine("Invalid entry. Please pick the number that corresponds to the product.");
            continue;
        }
        
        // Log the existing data to the console.
        Console.Write($"Product name: {productsList[--counter].Name}\n");
        
        // Ask user which field they want to update, then prompt user to enter new info for that field.
        Console.WriteLine("Which field would you like to change? ");
        Console.WriteLine("1 - Product Name");
        Console.WriteLine("2 - Product Type");
        Console.WriteLine("3 - Price");
        string? fieldToUpdate = Console.ReadLine();

        if (!int.TryParse(fieldToUpdate, out int changeInfo))
        {
            Console.WriteLine("Invalid entry. Please pick the number that corresponds to what you are trying to update.");
            continue;
        }
        
        switch (fieldToUpdate)
        {
            case "1":
                Console.WriteLine($"Enter a new product name: ");
                string newProductName = Console.ReadLine()?.Trim();
                if (string.IsNullOrWhiteSpace(newProductName))
                {
                    Console.WriteLine("Please enter a valid product name.");
                    continue;
                }
                // Update record's product name.
                productsList[counter].Name = newProductName;
                break;
            case "2":
                Console.WriteLine($"Enter a new product type: ");
                string newProductType = Console.ReadLine()?.Trim();
                if (string.IsNullOrWhiteSpace(newProductType))
                {
                    Console.WriteLine("Invalid entry. Please enter a name for the product type. ex. guitar: ");
                    continue;
                }
                
                // Check if name exists in database.
                ProductType existingTitle = productTypesList.FirstOrDefault(p => p.Title.ToLower() == newProductType.ToLower());
                if (existingTitle.Title == newProductType)
                {
                    Console.WriteLine($"The product type '{newProductType}' already exists.");
                    productsList[counter].ProductTypeId = existingTitle.Id;
                }
                else
                {
                    // Create a new instance of a ProductType.
                    ProductType newProductTypePayload = new ProductType(newProductType, productTypesList.Count + 1);
                    
                    // Add to productTypeList
                    productTypesList.Add(newProductTypePayload);
                    
                    // Update product id
                    productsList[counter].ProductTypeId = newProductTypePayload.Id;
                    
                    // Console.WriteLine($"Logging new product type: {newProductTypePayload.Title}");
                    // Console.WriteLine($"Logging new product type id: {newProductTypePayload.Id}");
                }
                break;
            case "3":
                Console.WriteLine($"Enter a new product price: ");
                string newPrice = Console.ReadLine()?.Trim();
                if (string.IsNullOrWhiteSpace(newPrice) || !decimal.TryParse(newPrice, out _))
                {
                    Console.WriteLine("Please enter a valid product price. Must be a decimal number. Ex. 19.99");
                    continue;
                }
                // Update record's price.
                productsList[counter].Price = Convert.ToDecimal(newPrice);
                break;
        }
        
        break;
    }
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