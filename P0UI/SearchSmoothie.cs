using P0BL;
using P0Model;

namespace P0UI
{

    public class SearchSmoothie : IMenu
    {
        private ISmoothieBL _smoBL;
        public SearchSmoothie(ISmoothieBL _smoth)
        {
            _smoBL = _smoth;
        }

        public void Display()
        {
           Console.WriteLine("Type [1] to search by name of smoothie.");
           Console.WriteLine("Type [2] to return to main menu.");
        }

        public string UserChoice()
        {
            
            string userInput = Console.ReadLine();

            switch(userInput)
            {
                case "1":
                Console.WriteLine("Type the name of the smoothie to search.");
                string name = Console.ReadLine();

                List<SmoothieModel> ListOfSmoothie = _smoBL.SearchSmoothie(name);
                foreach (SmoothieModel item in ListOfSmoothie)
                {
                    Console.WriteLine("================");
                    Console.WriteLine(item); 
                }    
                Console.WriteLine("Press Enter to continue");
                Console.ReadLine();     
                return "MainMenu";

                case "2":
                return "MainMenu";
                default:
                Console.WriteLine("Please input a valid response");
                Console.WriteLine("Please press Enter to continue");
                Console.ReadLine();
                return "SearchSmoothie";      
            }
        }
    }

    
}