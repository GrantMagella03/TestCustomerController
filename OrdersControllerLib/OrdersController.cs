using Microsoft.Data.SqlClient;

namespace OrdersControllerLib {
    public class OrdersController {
        public SqlConnection sqlconn { get; set; }
        public OrdersController(SqlConnection SqlConn) {
            this.sqlconn = SqlConn;
        }
        public List<Order> GetAll() {
            var sql = "SELECT * FROM Orders;";
            var cmd = new SqlCommand(sql, sqlconn);
            var reader = cmd.ExecuteReader();
            var orders = new List<Order>();
            while (reader.Read()) {
                var ord = new Order();
                ord.ID = (int)reader["ID"];
                ord.CustomerID = (int)reader["CustomerID"];
                ord.Date = (DateTime)reader["Date"];
                ord.Description = (string)reader["Description"];
                orders.Add(ord);
            }
            reader.Close();
            return orders;
        }
        public Order? GetByID(int ID) {
            if (ID <= 0) {
                throw new ArgumentException("ID must be > 0");
            }
            var sql = "SELECT * FROM Orders WHERE ID = @ID;";
            var cmd = new SqlCommand(sql, sqlconn);
            cmd.Parameters.AddWithValue("@ID", ID);
            var reader = cmd.ExecuteReader();
            var ord = new Order();
            if (!reader.HasRows) {
                reader.Close();
                return null;
            }
            reader.Read();
            ord.ID = (int)reader["ID"];
            ord.CustomerID = (int)reader["CustomerID"];
            ord.Date = (DateTime)reader["Date"];
            ord.Description = (string)reader["Description"];
            reader.Close();
            return ord;
        }
        public void Insert(Order O) {
            var sql = " INSERT Orders ( CustomerID, Date, Description ) " +
                      " VALUES ( @CustomerID, @Date, @Description );";
            var cmd = new SqlCommand(sql, sqlconn);
            cmd.Parameters.AddWithValue("@CustomerID", O.CustomerID);
            cmd.Parameters.AddWithValue("@Date", O.Date);
            cmd.Parameters.AddWithValue("@Description", O.Description);
            var RTC = cmd.ExecuteNonQuery();
            if (RTC != 1) {
                throw new Exception($"{RTC} Rows Affected, Should be 1");
            } else {
                Console.WriteLine($"1 Row Affected");
            }
        }
        public void Update(int ID, Order o) {
            var sql = " UPDATE Orders SET " +
                      " CustomerID = @CustomerID, " +
                      " Date = @Date, " +
                      " Description = @Description " +
                      " WHERE ID = @ID;";
            var cmd = new SqlCommand(sql, sqlconn);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@CustomerID", o.CustomerID);
            cmd.Parameters.AddWithValue("@Date", o.Date);
            cmd.Parameters.AddWithValue("@Description", o.Description);
            var RTC = cmd.ExecuteNonQuery();
            if (RTC != 1) {
                throw new Exception($"{RTC} Rows Affected, Should be 1");
            } else {
                Console.WriteLine($"1 Row Affected");
            }
        }
        public void Delete(int ID) {
            if (ID < 0) {
                throw new Exception("int ID must be a valid ID");
            }
            var sql = " DELETE FROM Orders WHERE ID = @ID ";
            var cmd = new SqlCommand(sql, sqlconn);
            cmd.Parameters.AddWithValue("@ID", ID);
            var RTC = cmd.ExecuteNonQuery();
            if (RTC != 1) {
                throw new Exception($"{RTC} Rows Affected, Should be 1");
            } else {
                Console.WriteLine($"1 Row Affected");
            }
        }
        public void Insert(Order O, String CC) {
            throw new NotImplementedException("Column ''Code'' hasn't been implemented into salesDB yet, this method will not work");
            var sql = "SELECT ID FROM Customers Where Code = @Code;";//Code hasnt been added to db yet , this method is useless
            var cmd = new SqlCommand(sql, sqlconn);
            cmd.Parameters.AddWithValue("@Code", CC);
            var CID = Convert.ToInt32(cmd.ExecuteScalar());
            O.CustomerID = CID;
            Insert(O);
        }
    }
}