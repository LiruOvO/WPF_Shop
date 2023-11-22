using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR9
{
    public class Products
    {
        public string CategoryName { get; set; }
        public int Price { get; set; }
        public virtual string ItemName { get; set; }
    }
    public class Toys : Products
    {
        public override string ItemName { get; set; }
    }
    public class Electronics : Products
    {
        public override string ItemName { get; set; }
    }


    public class Order
    {
        public string PIB { get; set; }
        public string Number { get; set; }
        public string Gmail { get; set; }
        public string Address { get; set; }
        public string Summ { get; set; }
    }
}
