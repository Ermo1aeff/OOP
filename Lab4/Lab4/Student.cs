using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public class Student
    {
            public string FirstName { get; set; }   // Имя
            public string LastName { get; set; }    // Фамилия
            public string Patronymic { get; set; }  // Отчество
            public DateTime BirthDate { get; set; } // Дата рождения
            public double Rating { get; set; }       // Рейтинг успеваемости
            public int AdmissionYear { get; set; }   // Год поступления
            public int GroupNumber { get; set; }     // Номер в списке группы
            public bool IsLocal { get; set; }     // Проживание (местный или нет)
    }
}
