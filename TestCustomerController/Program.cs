using Microsoft.Data.SqlClient;
using CustomersController;
using OrdersControllerLib;

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
        test2(conn);
        //------DB Connection Close------
        conn.Close();
    }
    static void test1(SqlConnection conn) {
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
    }
    static void test2(SqlConnection conn) {
        var octrl = new OrdersController(conn);
        var ords1 = octrl.GetAll();
        //var o1 = new Order(39,DateTime.Now,"Test Order");
        //var o2 = octrl.GetByID(11);
        //octrl.Update(30, o1);
        //o2.print();
        //octrl.Insert(o1);
        //octrl.Delete(30);
        foreach (Order O in  ords1) { 
            O.print();
        }
    }
}