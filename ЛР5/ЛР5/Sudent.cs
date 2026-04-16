using OopLabJson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ЛР5
{
    public class Student
    {
        public int ListNumber { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal AcademicRating { get; set; }
        public int AdmissionYear { get; set; }

        // Конвертер для красивого отображения Enum в JSON в виде строки, а не числа
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ResidenceType Residence { get; set; }

        public override string ToString()
        {
            return $"[{ListNumber}] {FullName} | Родился: {DateOfBirth:dd.MM.yyyy} | Рейтинг: {AcademicRating} | Поступил: {AdmissionYear} | Проживание: {Residence}";
        }
    }
}
