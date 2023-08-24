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
        //------DB Connection Open------
        var cctrl = new CustomersControllerClass(conn);
        //var NC = new Customer("ACME INC", "Mason", "OH");
        //cctrl.Delete(40);
        //cctrl.Update(40, NC);
        //cctrl.Insert(NC);
        List<Customer> custs = cctrl.GetByPartialName("er");
        foreach (Customer cust in custs) {
            //Console.WriteLine($"{cust.ID} | {cust.Name}");
            cust.print();
        }
        /*
        Customer? c = cctrl.GetByID(39);
        try {
            c.print();
        } catch {
            Console.WriteLine("Id Does Not Exist");
        }
        */
        //------DB Connection Close------
        conn.Close();
    }
}