using P0BL;
using P0Model;

namespace P0UI
{
    public class ViewOrderHistory : IMenu
    {
        private Customer _customer = new Customer();
        private ICustomerBL _cusBL;
        public ViewOrderHistory(ICustomerBL c_cusBL)
        {
            _cusBL = c_cusBL;
        }
        public void Display()
        {
            Console.WriteLine("Type [1] to view order history for Customer.");
            Console.WriteLine("Type [2] to view order history for SmoothieShackBronx.");
            Console.WriteLine("Type [3] to view order history for SmoothieShackMan.");
            Console.WriteLine("Type [4] to go back.");
        }

        public string UserChoice()
        {
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                Console.WriteLine("What is your email to begin?");
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
                    return "ViewOrderHistory";
                }
               // _customer = _cusBL.SearchSpecificCustomer(_email);
                List<SmoothieModel> SmoothieList = _cusBL.GetSmoothieByCustomer(_customer.cusID);

                foreach (SmoothieModel item in SmoothieList)
                {
                    Console.WriteLine();
                    Console.WriteLine("+++++++++++++++++++++++++++++++++");
                    Console.WriteLine(item);
                    Console.WriteLine("+++++++++++++++++++++++++++++++++");

                }
                Console.WriteLine("Please press Enter to continue");
                Console.ReadLine();
                return "ViewOrderHistory";
                case "2":
                Console.WriteLine("Here are the orders for SmoothieShackBronx");

                List<SmoothieModel> SmoothieLists = _cusBL.GetSmoothieByStore(1);
                foreach (SmoothieModel item in SmoothieLists)
                {
                    Console.WriteLine();
                    Console.WriteLine("+++++++++++++++++++++++++++++++++");
                    Console.WriteLine(item);
                    Console.WriteLine("+++++++++++++++++++++++++++++++++");

                }
                Console.WriteLine("Please press Enter to continue");
                Console.ReadLine();

                return "ViewOrderHistory";
                case "3":
                Console.WriteLine("Here are the orders for SmoothieShackMan");

                List<SmoothieModel> SmoothieListss = _cusBL.GetSmoothieByStore(2);
                foreach (SmoothieModel item in SmoothieListss)
                {
                    Console.WriteLine();
                    Console.WriteLine("+++++++++++++++++++++++++++++++++");
                    Console.WriteLine(item);
                    Console.WriteLine("+++++++++++++++++++++++++++++++++");

                }
                Console.WriteLine("Please press Enter to continue");
                Console.ReadLine();
                return "ViewOrderHistory";
                case "4":
                return "MainMenu";
                default:
                Console.WriteLine("Please input a valid response");
                Console.WriteLine("Please press Enter to continue");
                Console.ReadLine();
                return "ViewOrderHistory";
            }
        }
    }
}