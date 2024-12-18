using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService
{
    public static class PhoneService
    {
        public static void ActivateService(Abonent abonent, Service service)
        {
            abonent.Services.Add(service);
            Console.WriteLine($"Услуга {service.Name} активирована для абонента {abonent.Name}.");
        }

        public static void DeactivateService(Abonent abonent, Service service)
        {
            abonent.Services.Remove(service);
            Console.WriteLine($"Услуга {service.Name} деактивирована для абонента {abonent.Name}.");
        }
    }
}
