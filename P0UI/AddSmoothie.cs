using P0BL;
using P0Model;
namespace P0UI;
public class AddSmoothie : IMenu
{
    public static int ComboNumberr { get; set; }
    public static string CupSizee { get; set; }
    private static SmoothieModel _newSmoothie;
    private SmoCollection _soCol;
    private ISmoothieBL _smoBL;
    public AddSmoothie(ISmoothieBL s_smoBL)
    {
        _smoBL = s_smoBL;
    }

    public AddSmoothie(SmoCollection _col)
    {
        _soCol = _col;
    }
    public void Display()
    {
        Console.WriteLine("Please type one of the following numbers to move forward.");
        Console.WriteLine("[1] - To select a smoothie and cup size");
        Console.WriteLine("[2] - Save order");
        Console.WriteLine("[3] - Return to Main Menu");
    }

    public string UserChoice()
    {
        string userInput = Console.ReadLine();
        switch(userInput)
        {
            case "1":
            SmoCollection smo = new SmoCollection();
            smo.Display();
            Console.WriteLine("Please type the order number and cup size for the smoothies you would like to order.");
            Console.WriteLine("Order Number:");
            ComboNumberr = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Cup size:");
            CupSizee = Console.ReadLine();
            _newSmoothie = new SmoothieModel(ComboNumberr, CupSizee);
           //ComboNumberr = _ordernumb;
          // CupSizee = _cup;
           // Console.ReadLine();
            Console.WriteLine("Your smoothie is " +  _newSmoothie.Name + " and the price is $" + _newSmoothie.Price);
         Console.ReadLine();
            Console.WriteLine("Would you like to save this order?");
            Console.WriteLine("If so then type [1]");
            Console.WriteLine("If no then press Enter");
            string input = Console.ReadLine();
            if(input == "1")
            {
               try 
            {
                Log.Information("Saving smoothie \n" + _newSmoothie);
            _smoBL.AddSmoothie(_newSmoothie);
            Log.Information("Successful at saving smoothie.");
            } catch (System.Exception exc)
            {
                Console.WriteLine(exc.Message);
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
            } 
            }
            return "AddSmoothie";
            case "2":
            try 
            {
            Log.Information("Saving smoothie \n" + _newSmoothie);
            _smoBL.AddSmoothie(_newSmoothie);
            Log.Information("Successful at saving smoothie.");
            Console.WriteLine("Order saved");
            Console.ReadLine();
        
            } catch (System.Exception exc)
            {
                Log.Warning("Failed to save smoothie due to reaching total capacity (5)");
                Console.WriteLine(exc.Message);
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
            }
            return "MainMenu";
            case "3":
            return "MainMenu";
            default:
            Console.WriteLine("Please input a valid response");
            Console.WriteLine("Please press Enter to continue");
            Console.ReadLine();
            return "AddSmoothie";
        }
    }
}