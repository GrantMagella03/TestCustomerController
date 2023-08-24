using Microsoft.Data.SqlClient;

namespace CustomersController {
    public class CustomersControllerClass {
        public SqlConnection sqlconn { get; set; }
        public CustomersControllerClass(SqlConnection SqlConn) {
            this.sqlconn = SqlConn;
        }
        public List<Customer> GetAll() {
            var sql = "SELECT * FROM Customers;";
            var cmd = new SqlCommand(sql,sqlconn);
            var reader = cmd.ExecuteReader();
            var customers = new List<Customer>();
            while (reader.Read()) {
                var cust = new Customer();
                cust.ID = (int)reader["ID"];
                cust.Name = (string)reader["Name"];
                cust.City = (string)reader["City"];
                cust.State = (string)reader["State"];
                cust.Sales = (decimal)reader["Sales"];
                cust.Active = (bool)reader["active"];
                customers.Add(cust);
            }
            reader.Close();
            return customers;
        }
        public Customer? GetByID(int Input) {
            if (Input<=0) {
                throw new ArgumentException("ID must be > 0");
            }
            var sql = "SELECT * FROM Customers WHERE ID = @ID;";
            var cmd = new SqlCommand(sql, sqlconn);
            cmd.Parameters.AddWithValue("@ID",Input);
            var reader = cmd.ExecuteReader();
            var cust = new Customer();
            if (!reader.HasRows) {
                reader.Close();
                return null;
            }
            reader.Read();
            cust.ID = (int)reader["ID"];
            cust.Name = (string)reader["Name"];
            cust.City = (string)reader["City"];            
            cust.State = (string)reader["State"];            
            cust.Sales = (decimal)reader["Sales"];                
            cust.Active = (bool)reader["active"];            
            reader.Close();
            return cust;
        }
        public void Insert(Customer c) {
            var sql = " INSERT Customers (Name, City, State, Sales, Active) " +
                      " VALUES ( @Name , @City , @State, @Sales, @Active);";
            var cmd = new SqlCommand(sql, sqlconn);
            cmd.Parameters.AddWithValue("@Name", c.Name);
            cmd.Parameters.AddWithValue("@City", c.City);
            cmd.Parameters.AddWithValue("@State", c.State);
            cmd.Parameters.AddWithValue("@Sales", c.Sales);
            cmd.Parameters.AddWithValue("@Active", c.Active);
            var RTC = cmd.ExecuteNonQuery();
            if(RTC != 1) {
                throw new Exception($"{RTC} Rows Affected, Should be 1");
            } else {
                Console.WriteLine($"1 Row Affected");
            }
        }
        public void Update(int ID,Customer c) {
            var sql = " UPDATE Customers SET " +
                      " Name = @Name, " +
                      " City = @City, " +
                      " State = @State, " +
                      " Sales = @Sales, " +
                      " Active = @Active " +
                      " WHERE ID = @ID;";
            var cmd = new SqlCommand(sql, sqlconn);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@Name", c.Name);
            cmd.Parameters.AddWithValue("@City", c.City);
            cmd.Parameters.AddWithValue("@State", c.State);
            cmd.Parameters.AddWithValue("@Sales", c.Sales);
            cmd.Parameters.AddWithValue("@Active", c.Active);
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
            var C = GetByID(ID);
            C.print();
            Console.Write($"This data (ID:{ID}) will be permanently deleted from the database, Continue(Y/N): ");
            var r = Console.ReadLine();
            if (r == "y" || r == "Y") {
                var sql = " DELETE FROM CUSTOMERS WHERE ID = @ID ";
                var cmd = new SqlCommand(sql, sqlconn);
                cmd.Parameters.AddWithValue("@ID", ID);
                var RTC = cmd.ExecuteNonQuery();
                if (RTC != 1) {
                    throw new Exception($"{RTC} Rows Affected, Should be 1");
                } else {
                    Console.WriteLine($"1 Row Affected");
                }
            } else { Console.WriteLine("Action Aborted, 0 rows affected"); }
        }
    }
}