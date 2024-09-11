using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR_1
{
    // Класс Сотрудник
    abstract class Employee
    {
        public required int Id { get; set; } // Табельный номер
        public string? LastName { get; set; } // Фамилия
        public string? FirstName { get; set; } // Имя
        public string? MiddleName { get; set; } // Отчество
        public string? Phone { get; set; } // Телефон
        public string? Email { get; set; } // Email
    }

    // Класс Кладовщик
    class Storekeeper : Employee
    {

    }

    // Класс Менеджер
    class Manager : Employee
    {

    }

    class MateriallyResponsiblePerson : Employee
    {

    }

    class Warehouse
    {
        public Storekeeper Storekeeper { get; set; }
    }
}
