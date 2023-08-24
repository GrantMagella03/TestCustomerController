using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersController {
    public class Customer {
        public int ID { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public decimal? Sales { get; set; }
        public bool Active { get; set; }
        public Customer() { }
        public Customer(string name, string city, string state, decimal sales = 0, bool active = true) {
            Name = name; City = city; State = state; Sales = sales; Active = active;
        }
        //public Customer(int id, string name, string city, string state = "OH", decimal sales = 0, bool active = true) {
            //ID = id; Name = name; City = city; State = state; Sales = sales; Active = active;
        //}
        public void print() {Console.WriteLine($"{ID}|{Name}|{City}|{State}|{Sales}|{Active}");
        }
    }

}
