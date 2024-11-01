using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Создание экземпляров класса Complex
            Complex a = new Complex(2, 3); // 2 + 3i
            Complex b = new Complex(1, 4); // 1 + 4i

            // Выполнение операций
            Complex sum = a + b;           // Сложение
            Complex difference = a - b;    // Вычитание
            Complex product = a * b;       // Умножение
            Complex quotient = a / b;      // Деление

            // Проверка на эквивалентность
            bool isLess = a == b;           // Сравнение a == b
            bool isGreater = a != b;        // Сравнение a != b

            // Вывод результатов
            Console.WriteLine($"Сумма: {sum.Real} + {sum.Imaginary}i");
            Console.WriteLine($"Разность: {difference.Real} + {difference.Imaginary}i");
            Console.WriteLine($"Произведение: {product.Real} + {product.Imaginary}i");
            Console.WriteLine($"Частное: {quotient.Real} + {quotient.Imaginary}i");
            Console.WriteLine($"a == b: {isLess}");
            Console.WriteLine($"a != b: {isGreater}");
            Console.ReadKey();
        }
    }
}
