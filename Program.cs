using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создание объектов
            Admin admin = new Admin("Администратор");
            Abonent abonent = CreateAbonent();
            List<Service> availableServices = CreateServices();
            List<Bill> bills = new List<Bill>();

            // Подключение абонента
            admin.ConnectAbonent(abonent);

            // Абонент выбирает услуги
            while (true)
            {
                Console.WriteLine("\nДоступные услуги:");
                for (int i = 0; i < availableServices.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {availableServices[i].GetDetails()}");
                }

                Console.WriteLine("\nВыберите номер услуги для подключения (или 0 для выхода):");
                if (!int.TryParse(Console.ReadLine(), out int choice) || choice == 0)
                    break;

                if (choice > 0 && choice <= availableServices.Count)
                {
                    admin.SendForServiceActivation(abonent, availableServices[choice - 1]);
                }
                else
                {
                    Console.WriteLine("Неверный выбор.");
                }
            }

            // Создание счета
            Bill bill = admin.CreateBill(abonent, 100); // звонки на 100
            bills.Add(bill);

            // Оплата счета
            abonent.PayBill(bill);

            // Просмотр неоплаченных счетов
            admin.ViewUnpaidBills(bills);

            // Блокировка абонента
            Console.WriteLine("\nЗаблокировать абонента? (да/нет):");
            string blockChoice = Console.ReadLine();
            if (blockChoice?.ToLower() == "да")
            {
                admin.BlockAbonent(abonent);
            }


            // Отключение услуги
            Console.WriteLine("\nВыберите номер услуги для отключения(или 0 для выхода):");
            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out int choice) || choice == 0)
                    break;

                if (choice > 0 && choice <= availableServices.Count)
                {
                    admin.SendForServiceDeactivation(abonent, availableServices[choice - 1]);
                }
                else
                {
                    Console.WriteLine("Неверный выбор.");
                }
            }


            Console.ReadKey();
        }

        static Abonent CreateAbonent()
        {
            Console.WriteLine("Введите имя абонента:");
            string name = Console.ReadLine();
            Console.WriteLine("Введите номер телефона абонента:");
            string phone = Console.ReadLine();
            return new Abonent(name, phone);
        }

        static List<Service> CreateServices()
        {
            return new List<Service>()
            {
               new Service("Интернет", 150),
               new Service("Телевидение", 200),
               new Service("Мобильная связь", 100),
                new Service("СМС пакет", 50)

            };
        }
    }
}
