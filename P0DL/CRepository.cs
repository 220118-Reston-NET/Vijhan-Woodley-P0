using System.Data.SqlClient;
using P0Model;

namespace P0DL
{
    public class CRepository : ICRepository
    {
        private readonly string _connectionStrings;

        public CRepository(string c_connectionStrings)
        {
            _connectionStrings = c_connectionStrings;
        }

        public Customer AddCustomer(Customer c_customer)
        {
            string SQLQuery = @"insert into Customer values(@Name, @Email, @Age)";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();

                SqlCommand command = new SqlCommand(SQLQuery, con);
                command.Parameters.AddWithValue("@Name", c_customer.Name);
                command.Parameters.AddWithValue("@Email", c_customer.Email);
                command.Parameters.AddWithValue("@Age", c_customer.Age);

                command.ExecuteNonQuery();
            }

            return c_customer;
        }

        public List<Customer> GetAllCustomers()
        {
            List<Customer> ListOfCustomer = new List<Customer>();

            string SQLQuery = @"select * from Customer";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();

                SqlCommand command = new SqlCommand(SQLQuery, con);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ListOfCustomer.Add(new Customer() {
                        cusID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Email = reader.GetString(2),
                        Age = reader.GetInt32(3),
                        Smoothies = GetSmoothieByCustomer(reader.GetInt32(0))
                    });
                }
            }

            return ListOfCustomer;
        }

        public List<SmoothieModel> GetSmoothieByCustomer(int c_cusID)
        {
            List<SmoothieModel> SmoothieList = new List<SmoothieModel>();

            string SQLQuery = @"select s.SmoID, s.Name, s.ComboNumb, s.CupSize, s.Price from SmoothieModel s inner join Customer c on c.cusID = s.fcustomer where c.cusID = @cusID";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();

                SqlCommand command = new SqlCommand(SQLQuery, con);

                command.Parameters.AddWithValue("@cusID", c_cusID);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    SmoothieList.Add(new SmoothieModel(){
                        SmoID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        ComboNumb = reader.GetInt32(2),
                        CupSize = reader.GetString(3),
                        Price = reader.GetDouble(4)
                    });
                }
            }
            return SmoothieList;
        }

        public List<SmoothieModel> GetSmoothieByStore(int s_stoID)
        {
            List<SmoothieModel> SmoothieList = new List<SmoothieModel>();

            string SQLQuery = @"select s.SmoID, s.Name, s.ComboNumb, s.CupSize, s.Price from SmoothieModel s inner join Store st on st.StoreID = s.fstore where st.StoreID = @StoreID";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();

                SqlCommand command = new SqlCommand(SQLQuery, con);

                command.Parameters.AddWithValue("@StoreID", s_stoID);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    SmoothieList.Add(new SmoothieModel(){
                        SmoID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        ComboNumb = reader.GetInt32(2),
                        CupSize = reader.GetString(3),
                        Price = reader.GetDouble(4)
                    });
                }
            }
            return SmoothieList;
        }


    }
}