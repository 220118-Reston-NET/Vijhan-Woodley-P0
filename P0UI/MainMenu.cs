public class MainMenu
{
    public void Display()
    {
        Console.WriteLine("Welcome to the SmoothieShack");
        Console.WriteLine("Please type one of the following numbers to navigate through the app");
        Console.WriteLine("Type [1] to view our collection of smoothies");
        Console.WriteLine("Type [2] to purchase a smoothie");
        Console.WriteLine("Type [3] to exit app");
    }

    public void UserChoice()
    {
        string userInput = Console.ReadLine();

        switch (userInput)
        {
            case "1" :
            break;
            case "2" :
            break;
            case "3" :
            Console.WriteLine("Goodbye.");
            break;
            default:
            break;
        }
    }
}