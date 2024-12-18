
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService
{
    public class Admin
    {
        public string Name { get; private set; }

        public Admin(string name)
        {
            Name = name;
        }

        public void ConnectAbonent(Abonent abonent)
        {
            Console.WriteLine($"Абонент {abonent.Name} подключен.");
        }

        public void DisconnectAbonent(Abonent abonent)
        {
            Console.WriteLine($"Абонент {abonent.Name} отключен.");
        }

        public void SendForServiceActivation(Abonent abonent, Service service)
        {
            PhoneService.ActivateService(abonent, service);
            Console.WriteLine($"Запрос на активацию услуги {service.Name} отправлен для {abonent.Name}.");
        }

        public void SendForServiceDeactivation(Abonent abonent, Service service)
        {
            PhoneService.DeactivateService(abonent, service);
            Console.WriteLine($"Запрос на деактивацию услуги {service.Name} отправлен для {abonent.Name}.");
        }


        public Bill CreateBill(Abonent abonent, decimal callCharges)
        {
            decimal serviceCharges = 0;
            foreach (var service in abonent.Services)
            {
                serviceCharges += service.Price;
            }
            Bill bill = new Bill(1, callCharges, serviceCharges);
            abonent.Account = bill;
            Console.WriteLine($"Счет для абонента {abonent.Name} создан.");
            return bill;
        }

        public void ViewUnpaidBills(List<Bill> bills)
        {
            Console.WriteLine("Список неоплаченных счетов:");
            foreach (var bill in bills)
            {
                if (!bill.IsPaid)
                {
                    Console.WriteLine($"Абонент ID: {bill.AbonentId}, Сумма: {bill.TotalAmount}");
                }
            }
        }

        public void BlockAbonent(Abonent abonent)
        {
            abonent.IsBlocked = true;
            Console.WriteLine($"Абонент {abonent.Name} заблокирован.");
        }
    }
}
