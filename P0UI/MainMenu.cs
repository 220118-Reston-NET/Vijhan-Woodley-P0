namespace P0UI;
public class MainMenu : IMenu
{
    public void Display()
    {
        Console.WriteLine("Welcome to the SmoothieShack App!");
        Console.WriteLine("Please type one of the following numbers to navigate through the app");
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        Console.WriteLine("Type [1] to view our collection of smoothies and prices");
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        Console.WriteLine("Type [2] to make a smoothie order");
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        Console.WriteLine("Type [3] to search for a customer.");
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        Console.WriteLine("Type [4] to add personal information.");
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        Console.WriteLine("Type [5] to view order history.");
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        Console.WriteLine("Type [6] to view inventory");
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        Console.WriteLine("Type [7] to exit app");
    }

    public string UserChoice()
    {
        string userInput = Console.ReadLine();

        switch (userInput)
        {
            case "1" :
            return "ViewSmoothies";
            
            case "2" :
            return "AddSmoothie";

            case "3" :
            return "SearchCustomer";

            case "4" :
            return "CustomerInfo";

            case "5" :
            return "ViewOrderHistory";

            case "6" :
            return "ViewStoreInventory";
            
            case "7" :
            return "Exit";
            
            default:
            Console.WriteLine("Please input a valid response");
            Console.WriteLine("Please press Enter to continue");
            Console.ReadLine();
            return "MainMenu";
            
        }
    }
}