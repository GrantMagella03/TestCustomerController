using Microsoft.Data.SqlClient;
using CustomersController;

internal class Program {
    private static void Main(string[] args) {
        var connStr = "server=localhost\\sqlexpress;" +
            "database=SalesDb;" +
            "trusted_connection=true;" +
            "trustServerCertificate=true;";
        var conn = new SqlConnection(connStr);
        conn.Open();
        if (conn.State != System.Data.ConnectionState.Open) {
            throw new Exception("Connection didn't open");
        }
        Console.WriteLine("Connection Opened Successfully");
        //DB Connection Open

        /*
        var cctrl = new CustomersControllerClass(conn);
        List<Customer> custs = cctrl.GetAll();
        foreach (Customer cust in custs) {
            Console.WriteLine($"{cust.ID} | {cust.Name}");
        }
        Customer? c = cctrl.GetByID(39);
        try {
            c.print();
        } catch {
            Console.WriteLine("Id Does Not Exist");
        }
        */
        //DB Connection Close
        conn.Close();
    }
}