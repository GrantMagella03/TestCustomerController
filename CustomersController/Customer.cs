﻿using System;
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
        public void print() {
            Console.WriteLine($"{ID}|{Name}|{City}|{State}|{Sales}|{Active}");
        }
    }

}
