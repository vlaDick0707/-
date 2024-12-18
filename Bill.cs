using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService
{
    public class Bill
    {
        public int AbonentId { get; private set; }
        public decimal CallCharges { get; private set; }
        public decimal ServiceCharges { get; private set; }
        public decimal TotalAmount { get; private set; }
        public bool IsPaid { get; private set; }

        public Bill(int abonentId, decimal callCharges, decimal serviceCharges)
        {
            AbonentId = abonentId;
            CallCharges = callCharges;
            ServiceCharges = serviceCharges;
            TotalAmount = callCharges + serviceCharges;
            IsPaid = false;
        }
        public void Pay()
        {
            IsPaid = true;
            Console.WriteLine("Счет оплачен.");
        }
    }

}
