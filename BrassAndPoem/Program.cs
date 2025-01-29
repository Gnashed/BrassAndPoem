
using BrassAndPoem;

//create a "products" variable here to include at least five Product instances. Give them appropriate ProductTypeIds.


//create a "productTypes" variable here with a List of ProductTypes, and add "Brass" and "Poem" types to the List. 


// ===================================== DATA SOURCE =====================================



// =============================================== MENU ===============================================

void DisplayMenu()
{
    // throw new NotImplementedException();
    while (true)
    {
        Console.WriteLine("============================================================================================");
        Console.WriteLine();
        Console.WriteLine("Please choose one of the following options: ");
        Console.WriteLine("a: Display all products");
        Console.WriteLine("b: Delete a product");
        Console.WriteLine("c: Add a new product");
        Console.WriteLine("d: Update product properties");
        Console.WriteLine("q: Exit");
        Console.WriteLine();
        string response = Console.ReadLine()?.Trim();

        // PROCESS MENU RESPONSE
        switch (response?.ToLower().Trim())
        {
            case "a":
                Console.Clear();
                Console.WriteLine("All Products Menu");
                DisplayAllProducts();
                continue;
            case "b":
                Console.Clear();
                Console.WriteLine("Delete Menu");
                DeleteProduct();
                continue;
            case "c":
                Console.Clear();
                Console.WriteLine("Add a New Product Menu ");
                AddProduct();
                continue;
            case "d":
                Console.Clear();
                Console.WriteLine("Update Product Properties Menu");
                UpdateProduct();
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
    throw new NotImplementedException();
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
                  "brass musical instruments online.";
Console.WriteLine();
Console.WriteLine();
Console.WriteLine("============================================================================================");
Console.WriteLine(greeting);
DisplayMenu();

// don't move or change this!
public partial class Program { }