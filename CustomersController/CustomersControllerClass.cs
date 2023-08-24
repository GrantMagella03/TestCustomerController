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
    }
}