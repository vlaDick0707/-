using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService
{
    public class Service
    {
        public string Name { get; private set; }
        public decimal Price { get; private set; }

        public Service(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public string GetDetails()
        {
            return $"{Name}: {Price:C}";
        }
    }
}
