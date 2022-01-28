// See https://aka.ms/new-console-template for more information
global using Serilog;
using P0Model;
using P0DL;
using P0BL;
using P0UI;

Log.Logger = new LoggerConfiguration()
    .WriteTo.File("./logs/user.txt")
    .CreateLogger();

bool repeat = true;
IMenu menu = new MainMenu();
while(repeat) 
{
Console.Clear();
menu.Display();
string ans = menu.UserChoice();

switch (ans)
{
    case "ViewSmoothies":
    menu = new SmoCollection();
    break;
    case "SearchSmoothie":
    Log.Information("Displaying SearchSmoothie Menu to the user");
    menu = new SearchSmoothie(new SmoothieBL(new Repository()));
    break;
    case "AddSmoothie":
    menu = new AddSmoothie(new SmoothieBL(new Repository()));
    break;
    case "Exit":
    repeat = false;
    break;
    case "MainMenu":
    menu = new MainMenu();
    break;
    default:
    Console.WriteLine("Please enter valid response.");
    Console.WriteLine("Press Enter to continue");
    Console.ReadLine();
    break;
}
}
/*Console.WriteLine("cuppsize:");
string l = Console.ReadLine();
Console.WriteLine("combo num:");
int num = Convert.ToInt32(Console.ReadLine());
SmoothieModel sm = new SmoothieModel(num, l);
Console.WriteLine(sm.Name + sm.CupSize + sm.Price);*/

