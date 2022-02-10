using P0Model;

namespace P0DL
{
    public interface ICRepository
    {
        Customer AddCustomer(Customer c_customer);

        List<SmoothieModel> GetSmoothieByCustomer(int c_cusID);

        List<SmoothieModel> GetSmoothieByStore(int s_stoID);

        List<Customer> GetAllCustomers();


    }
}