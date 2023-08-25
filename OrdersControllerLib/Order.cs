using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersControllerLib {
    public class Order {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        public Order(int CID, DateTime InputDate, string inputDescription) { 
            CustomerID = CID;
            Date = InputDate;
            Description = inputDescription;
        }
        public Order() { }
        public void print() { Console.WriteLine($"{ID}|{CustomerID}|{Date}|{Description}"); }

    }
}
