
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService
{
    public class Abonent
    {
        public string Name { get; private set; }
        public string PhoneNumber { get; private set; }
        public List<Service> Services { get; private set; }
        public Bill Account { get; set; }
        public bool IsBlocked { get; set; }
        public Abonent(string name, string phoneNumber)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            Services = new List<Service>();
            IsBlocked = false;
        }

        public void SelectService(Service service)
        {
            Services.Add(service);
            Console.WriteLine($"Абонент {Name} выбрал услугу {service.Name}.");
        }


        public void UnselectService(Service service)
        {
            Services.Remove(service);
            Console.WriteLine($"Абонент {Name} отказался от услуги {service.Name}.");
        }


        public void PayBill(Bill bill)
        {
            if (bill.IsPaid)
            {
                Console.WriteLine("Счет уже оплачен.");
            }
            else
            {
                bill.Pay();
                Console.WriteLine($"{Name} оплатил счет.");
            }
        }
    }
}
