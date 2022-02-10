using P0Model;

namespace P0BL
{
    public interface ICustomerBL
    {
        /// <summary>
        /// will add customer to database.
        /// </summary>
        /// <param name="c_customer"></param>
        /// <returns></returns>
        Customer AddCustomer(Customer c_customer);

        List<Customer> GetAllCustomers();

        List<SmoothieModel> GetSmoothieByCustomer(int c_cusID);

        List<SmoothieModel> GetSmoothieByStore(int s_stoID);

        List<Customer> SearchCustomer(string c_name);

        Customer SearchSpecificCustomer(string c_email);




    }
}