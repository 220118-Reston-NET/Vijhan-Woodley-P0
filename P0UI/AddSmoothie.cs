using P0BL;
using P0Model;
namespace P0UI;
public class AddSmoothie : IMenu
{
    public static int ComboNumberr { get; set; }
    public static string CupSizee { get; set; }
    private static SmoothieModel _newSmoothie;

    Store _storeBronx = new Store("SmoothieShackBronx");
    Store _storeMan = new Store("SmoothieShackMan");

    public Customer _customer = new Customer();
    Orders _order = new Orders();
    private ISmoothieBL _smoBL;

    private ICustomerBL _cusBL;
    public AddSmoothie(ICustomerBL c_cusBL, ISmoothieBL s_smoBL)
    {
        _cusBL = c_cusBL;
        _smoBL = s_smoBL;
    }

    private SmoCollection _soCol;
   
    /*public AddSmoothie(ISmoothieBL s_smoBL)
    {
        _smoBL = s_smoBL;
    }*/

    public AddSmoothie(SmoCollection _col)
    {
        _soCol = _col;
    }
    SmoCollection smo = new SmoCollection();

    public void Display()
    {
        Console.WriteLine("Please type what store you want to order from");
        Console.WriteLine("Type [1] for SmoothieShackBronx located in the Bronx, NY");
        Console.WriteLine("Type [2] for SmoothieShackMan located in Manhatten, NY.");
        Console.WriteLine("Type [3] - Save order");
        Console.WriteLine("Type [4] - Return to Main Menu");
    }

    public string UserChoice()
    {
        string userInput = Console.ReadLine();
        switch (userInput)
        {
            case "1":

                Console.WriteLine("What is your email to begin ordering?");
                Console.WriteLine("Format: name@gmail.com");
                string _email = Console.ReadLine();
                try
                {
                    _customer = _cusBL.SearchSpecificCustomer(_email);
                }
                catch (System.Exception exe)
                {
                
                    Console.WriteLine(exe.Message);
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "AddSmoothie";
                }
            
                Console.WriteLine("Hello " + _customer.Name);
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
                

                _storeBronx.Address = "Bronx, NY";
                _order.StoreAdress = "Bronx, NY";
                _storeBronx.StoreID = 1;
                _storeBronx.Name = "SmoothieShackBronx";

                smo.Display();



                Console.WriteLine("Please type the order number and cup size for the smoothies you would like to order.");
                Console.WriteLine("Order Number:");
                ComboNumberr = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Cup size:");
                CupSizee = Console.ReadLine();
                _newSmoothie = new SmoothieModel(ComboNumberr, CupSizee);
                _newSmoothie.fcustomer = _customer.cusID;
                _newSmoothie.fstore = _storeBronx.StoreID;
                Console.WriteLine("Your smoothie is " + _newSmoothie.Name + " and the price is $" + _newSmoothie.Price);
                _customer.AddSmoothie(_newSmoothie);
                _storeBronx.AddSmoothie(_newSmoothie);
                _order.AddSmoothie(_newSmoothie);
                _storeBronx.AddOrder(_order);
                Console.ReadLine();
                Console.WriteLine("Would you like to save this order?");
                Console.WriteLine("If so then type [1]");
                Console.WriteLine("If no then press Enter");
                string _input = Console.ReadLine();
                if (_input == "1")
                {
                    try
                    {
                        Log.Information("Saving smoothie \n" + _newSmoothie);
                        _smoBL.AddSmoothie(_newSmoothie, 1);
                        _smoBL.SubtractInventory(1);
                        Log.Information("Successful at saving smoothie.");
                    }
                    catch (System.Exception exc)
                    {
                        Console.WriteLine(exc.Message);
                        Console.WriteLine("Press enter to continue");
                        Console.ReadLine();
                    }
                }
                return "MainMenu";


            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++



            case "2":

                Console.WriteLine("What is your email to begin ordering?");
                Console.WriteLine("Format: name@gmail.com");
                _email = Console.ReadLine();
                 try
                {
                    _customer = _cusBL.SearchSpecificCustomer(_email);
                }
                catch (System.Exception exe)
                {
                
                    Console.WriteLine(exe.Message);
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "AddSmoothie";
                }
                
                 Console.WriteLine("Press enter to continue");
                 Console.ReadLine();

                _storeMan.Address = "Manhatten, NY";
                _order.StoreAdress = "Manhatten, NY";
                _storeMan.StoreID = 2;
                _storeMan.Name = "SmoothieShackMan";

                smo.Display();
                Console.WriteLine("Please type the order number and cup size for the smoothies you would like to order.");
                Console.WriteLine("Order Number:");
                ComboNumberr = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Cup size:");
                CupSizee = Console.ReadLine();
                _newSmoothie = new SmoothieModel(ComboNumberr, CupSizee);
                _newSmoothie.fcustomer = _customer.cusID;
                _newSmoothie.fstore = _storeMan.StoreID;
                Console.WriteLine("Your smoothie is " + _newSmoothie.Name + " and the price is $" + _newSmoothie.Price);
                _storeMan.AddSmoothie(_newSmoothie);
                _customer.AddSmoothie(_newSmoothie);
                _order.AddSmoothie(_newSmoothie);
                _storeMan.AddOrder(_order);
                Console.ReadLine();
                Console.WriteLine("Would you like to save this order?");
                Console.WriteLine("If so then type [1]");
                Console.WriteLine("If no then press Enter");
                string __input = Console.ReadLine();
                if (__input == "1")
                {
                    try
                    {
                        Log.Information("Saving smoothie \n" + _newSmoothie);
                        _smoBL.AddSmoothie(_newSmoothie, 2);
                        _smoBL.SubtractInventory(2);
                        Log.Information("Successful at saving smoothie.");
                    }
                    catch (System.Exception exc)
                    {
                        Console.WriteLine(exc.Message);
                        Console.WriteLine("Press enter to continue");
                        Console.ReadLine();
                    }
                }
                return "MainMenu";



            /*case "3":
                try
                {
                    Log.Information("Saving smoothie \n" + _newSmoothie);
                    _smoBL.AddSmoothie(_newSmoothie);
                    Log.Information("Successful at saving smoothie.");
                    Console.WriteLine("Order saved");
                    Console.ReadLine();

                }
                catch (System.Exception exc)
                {
                    Log.Warning("Failed to save smoothie due to reaching total capacity (5)");
                    Console.WriteLine(exc.Message);
                    Console.WriteLine("Press enter to continue");
                    Console.ReadLine();
                }
                return "MainMenu";*/
            case "4":
                return "MainMenu";
            default:
                Console.WriteLine("Please input a valid response");
                Console.WriteLine("Please press Enter to continue");
                Console.ReadLine();
                return "AddSmoothie";
        }
    }
}