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

        public Orders AddOrder(Orders o_order)
        {
            string SQLQuery = @"insert into Orders values(@fcustomer, @fstore, @totalPrice)";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();

                SqlCommand command = new SqlCommand(SQLQuery, con);
                command.Parameters.AddWithValue("@fcustomer", o_order.fcustomer);
                command.Parameters.AddWithValue("@fstore", o_order.fstore);
                command.Parameters.AddWithValue("@totalPrice", o_order.totalPrice);

                command.ExecuteNonQuery();
            }
            return o_order;
        }

        public void AlterOrderPrice(int _orderID, double _totalPrice)
        {
            string SQLQuery = @"update Orders set totalPrice = @totalPrice where OrderID = @OrderID";

             using(SqlConnection con = new SqlConnection(_connectionStrings))
             {
                 con.Open();
                 SqlCommand command = new SqlCommand(SQLQuery, con);
                 command.Parameters.AddWithValue("@totalPrice", _totalPrice);
                 command.Parameters.AddWithValue("@OrderID", _orderID);

                 command.ExecuteNonQuery();
             }
        }

        public void DeleteOrder()
        {
            string SQLQuery = @"delete from Orders where totalPrice = 0;";

            using(SqlConnection con = new SqlConnection(_connectionStrings))
           {
               con.Open();

               SqlCommand command = new SqlCommand(SQLQuery, con);
               
               command.ExecuteNonQuery();
           } 
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

        public List<Orders> GetAllOrders()
        {
            List<Orders> listOfOrders = new List<Orders>();

            string SQLQuery = @"select * from Orders";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {

                con.Open();

                SqlCommand command = new SqlCommand(SQLQuery, con);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    listOfOrders.Add(new Orders(){
                        OrderID = reader.GetInt32(0),
                        fcustomer = reader.GetInt32(1),
                        fstore = reader.GetInt32(2),
                        totalPrice = reader.GetDouble(3)
                    });

                }

            }
            
            return listOfOrders;
        }

        public List<Orders> GetAllOrdersByCustomer(int c_cusID)
        {
            List<Orders> listOfOrders = new List<Orders>();

            string SQLQuery = @"select OrderID, max(totalPrice) from Orders o inner join SmoothieModel s on o.OrderID  = s.forder where s.fcustomer = @cusID group by s.forder, o.OrderID";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {

                con.Open();

                SqlCommand command = new SqlCommand(SQLQuery, con);

                command.Parameters.AddWithValue("@cusID", c_cusID);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    listOfOrders.Add(new Orders(){
                        OrderID = reader.GetInt32(0),
                        //fcustomer = reader.GetInt32(1),
                        //fstore = reader.GetInt32(2),
                        totalPrice = reader.GetDouble(1)
                    });

                }

            }
            
            return listOfOrders;
        }

        public List<Orders> GetAllOrdersByStore(int s_storeID)
        {
            List<Orders> listOfOrders = new List<Orders>();

            string SQLQuery = @"select OrderID, max(totalPrice) from Orders o inner join SmoothieModel s on o.OrderID  = s.forder where s.fstore = @storeID group by s.forder, o.OrderID";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {

                con.Open();

                SqlCommand command = new SqlCommand(SQLQuery, con);

                command.Parameters.AddWithValue("@storeID", s_storeID);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    listOfOrders.Add(new Orders(){
                        OrderID = reader.GetInt32(0),
                        //fcustomer = reader.GetInt32(1),
                        //fstore = reader.GetInt32(2),
                        totalPrice = reader.GetDouble(1)
                    });

                }

            }
            
            return listOfOrders;
        }

        public List<SmoothieModel> GetOrderByCustomer(int o_orderID)
        {
            List<SmoothieModel> SmoothieList = new List<SmoothieModel>();

            string SQLQuery = @"select s.SmoID, s.Name, s.ComboNumb, s.CupSize, s.Price from SmoothieModel s inner join Orders o on o.OrderID  = s.forder where s.forder = @orderID";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();

                SqlCommand command = new SqlCommand(SQLQuery, con);

                command.Parameters.AddWithValue("@orderID", o_orderID);
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

        public Orders GetOrderbyPrice()
        {
            List<Orders> listOfOrders = new List<Orders>();
            Orders _order = new Orders();
            string SQLQuery = @"SELECT * from Orders where totalPrice = 0";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {

                con.Open();

                SqlCommand command = new SqlCommand(SQLQuery, con);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    listOfOrders.Add(new Orders(){
                        OrderID = reader.GetInt32(0),
                        fcustomer = reader.GetInt32(1),
                        fstore = reader.GetInt32(2),
                        totalPrice = reader.GetDouble(3)
                    });

                }

            }
            _order = listOfOrders[0];
            return _order;
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