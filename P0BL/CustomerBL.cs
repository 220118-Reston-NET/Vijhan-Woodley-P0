using P0DL;
using P0Model;

namespace P0BL
{
    public class CustomerBL : ICustomerBL
    {
        private ICRepository _crepo;
        public CustomerBL(ICRepository p_crepo)
        {
            _crepo = p_crepo;
        }
        public Customer AddCustomer(Customer c_customer)
        {
            List<Customer> CustomerList = _crepo.GetAllCustomers();
            foreach (Customer item in CustomerList)
            {
                if (item.Email != c_customer.Email)
                {
                    return _crepo.AddCustomer(c_customer);
                }
                else
                {
                    throw new Exception("The email entered already exists.");
                }
            }
            return _crepo.AddCustomer(c_customer);
        }

        public List<Customer> GetAllCustomers()
        {
            return _crepo.GetAllCustomers();
        }

        public List<SmoothieModel> GetSmoothieByCustomer(int c_cusID)
        {
            return _crepo.GetSmoothieByCustomer(c_cusID);
        }

        public List<SmoothieModel> GetSmoothieByStore(int s_stoID)
        {
            return _crepo.GetSmoothieByStore(s_stoID);
        }

        public List<Customer> SearchCustomer(string c_name)
        {
            List<Customer> CustomerLists = _crepo.GetAllCustomers();
            List<Customer> CustomersFound = new List<Customer>();
           /* foreach (Customer item in CustomerLists)
            {
                Console.WriteLine(item.Name);
            }*/
            
            
            foreach (Customer item in CustomerLists)
            {
                string nam = item.Name;
                if (nam.Contains(c_name, StringComparison.CurrentCultureIgnoreCase))
                {
                    CustomersFound.Add(item);
                } 
            }
            if(CustomersFound.Count() == 0)
                {
                    throw new Exception("Customer with name " + c_name + " was not found.");
                }
            return CustomersFound;
        }

        public Customer SearchSpecificCustomer(string c_email)
        {
            List<Customer> CustomerLists = _crepo.GetAllCustomers();
            Customer _customer = new Customer();
            bool emailFound = false;
            foreach (Customer item in CustomerLists)
            {
                if (item.Email == c_email)
                {
                    _customer = item;
                    emailFound = true;
                    return _customer;
                }
                

            }
            if(!emailFound){
                throw new Exception("Customer email not found.");
            }
            return _customer;
        }
    }
}