using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Lab2
{
    internal class Program
    {
        static List<IFigure> figures = new List<IFigure>();

        static void Main()
        {

            start:

            Console.Clear();
            Console.WriteLine("Выберите один из вариантов действий:");
            Console.WriteLine("1) Создать список фигур");
            Console.WriteLine("2) Добавить фигуру");
            Console.WriteLine("3) Рассчитать площадь и периметр всех элементов списка");

            Console.WriteLine();

            switch (Console.ReadLine())
            {
                case "1":
                    figures = new List<IFigure>();
                    break;
                case "2":
                    AddNewFigure();
                    break;
                case "3":
                    foreach (var item in figures)
                    {
                        item.GetPerimeter();
                        item.GetSquare();
                    }

                    foreach (var item in figures)
                    {
                        Console.WriteLine($"{item.Name}");
                        Console.WriteLine($"Площадь: {item.Square}" );
                        Console.WriteLine($"Периметр: {item.Perimeter}");
                        Console.WriteLine();
                    }
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("Значение указано неверно, повторите попытку.");
                    break;
            }

            goto start;
        }

        static void AddNewFigure()
        {
            IFigure figure;


            Console.Clear();

            Console.WriteLine("Выберите фигуру, которую хотите добавить:");
            Console.WriteLine("1) Квадрат");
            Console.WriteLine("2) Круг");
            Console.WriteLine("3) Треугольник");
            
            start:

            Console.WriteLine();

            switch (Console.ReadLine())
            {
                case "1":
                    figure = new Rectangle();
                    break;
                case "2":
                    figure = new Circle();
                    break;
                case "3":
                    figure = new Triangle();
                    break;
                default:
                    Console.WriteLine("Значение указано неверно, повторите попытку.");
                    goto start;
            }

            Console.WriteLine($"Укажите длины сторон фигуры \"{figure.Name}\" через пробел:");

            LengthsEnter:

            try
            {
                figure.SideLengths = Console.ReadLine().Split(' ').Select(Convert.ToDouble).ToList();
            }
            catch (Exception)
            {
                Console.WriteLine("Правила ввода были нарушены, повторите попытку ввода.");
                goto LengthsEnter;
            }

            figures.Add(figure);
        }
    }

    public class Rectangle : IFigure
    {
        public string Name { get; } = "Прямоугольник";
        public List<double> SideLengths { get; set; }
        public double Perimeter { get; set; }
        public double Square { get; set; }

        public void GetPerimeter()
        {
            Perimeter = SideLengths[0] + SideLengths[1];
        }

        public void GetSquare()
        {
            Square = SideLengths[0] * SideLengths[1];
        }
    }

    public class Circle: IFigure
    {
        public string Name { get; } = "Круг";
        public List<double> SideLengths { get; set; }
        public double Perimeter { get; set; }
        public double Square { get; set; }

        public void GetPerimeter()
        {
            Perimeter = SideLengths[0];
        }

        public void GetSquare()
        {
            Square = SideLengths[0] * Math.PI;
        }
    }

    public class Triangle : IFigure
    {
        public string Name { get; } = "Треугольник";
        public List<double> SideLengths { get; set; }
        public double Perimeter { get; set; }
        public double Square { get; set; }

        public void GetPerimeter()
        {
            Perimeter = SideLengths[0] + SideLengths[1] + SideLengths[2];
        }

        public void GetSquare()
        {
            double p = (SideLengths[0] + SideLengths[1] + SideLengths[2]) / 2;
            Square = Math.Sqrt(p * ((p - SideLengths[0]) * (p - SideLengths[1]) * (p - SideLengths[2])));
        }
    }
}
