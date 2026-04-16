using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using ЛР5;

namespace OopLabJson
{
    // Перечисление для типа проживания
    public enum ResidenceType
    {
        Местный,
        Иногородний
    }

    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "group.json";

            // Создаем группу и добавляем студентов
            Group myGroup = new Group { GroupName = "ИВБ-24" };
            myGroup.Students.Add(new Student
            {
                ListNumber = 1,
                FullName = "Иванов Иван Иванович",
                DateOfBirth = new DateTime(2004, 5, 12),
                AcademicRating = 4.8m,
                AdmissionYear = 2022,
                Residence = ResidenceType.Местный
            });
            myGroup.Students.Add(new Student
            {
                ListNumber = 2,
                FullName = "Петрова Анна Сергеевна",
                DateOfBirth = new DateTime(2005, 11, 23),
                AcademicRating = 5.0m,
                AdmissionYear = 2023,
                Residence = ResidenceType.Иногородний
            });

            Console.WriteLine("Исходные данные программы:");
            myGroup.PrintGroup();

            // Сериализация в JSON
            // Настройка WriteIndented = true делает файл красиво отформатированным и читабельным
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping // Чтобы кириллица читалась нормально
            };

            string jsonString = JsonSerializer.Serialize(myGroup, options);
            File.WriteAllText(filePath, jsonString);

            // Отчет
            Console.WriteLine($"Данные успешно сохранены в файл: {Path.GetFullPath(filePath)}");
            Console.WriteLine("\n--- ОТЧЕТ ---");
            Console.WriteLine("1. Откройте этот файл.");
            Console.WriteLine("2. Отредактируйте данные о студентах.");
            Console.WriteLine("3. Сохраните файл.");
            Console.WriteLine("После сохранения изменений нажмите ENTER в этой консоли");
            Console.ReadLine();

            // Десериализация из JSON
            if (File.Exists(filePath))
            {
                // Чтение строки JSON из файла
                string jsonFromFile = File.ReadAllText(filePath);

                // Десериализация обратно в объект Group
                Group loadedGroup = JsonSerializer.Deserialize<Group>(jsonFromFile, options);

                Console.WriteLine("Данные после загрузки из файла (проверка изменений):");
                loadedGroup.PrintGroup();
            }
            else
            {
                Console.WriteLine("Файл не найден!");
            }

            Console.ReadLine();
        }
    }
}