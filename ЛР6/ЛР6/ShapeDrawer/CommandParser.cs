using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛР6
{
    public static class CommandParser
    {
        // Ожидаемый формат: "Red 50,50 150,50 100,150"
        public static Shape Parse(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentException("Строка не может быть пустой.");

            string[] parts = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length < 3)
                throw new ArgumentException("Недостаточно данных. Укажите цвет и минимум две точки.");

            // Парсим цвет (поддерживаются стандартные английские названия, например: Red, Blue, Green)
            Color color = Color.FromName(parts[0]);
            if (!color.IsKnownColor)
                throw new ArgumentException($"Неизвестный цвет: {parts[0]}");

            // Парсим точки
            Point[] points = new Point[parts.Length - 1];
            for (int i = 1; i < parts.Length; i++)
            {
                string[] coords = parts[i].Split(',');
                if (coords.Length != 2)
                    throw new ArgumentException($"Неверный формат координат: {parts[i]}. Ожидается X,Y");

                if (int.TryParse(coords[0], out int x) && int.TryParse(coords[1], out int y))
                {
                    points[i - 1] = new Point(x, y);
                }
                else
                {
                    throw new ArgumentException($"Координаты должны быть числами: {parts[i]}");
                }
            }

            // Возвращаем готовый объект
            return new Polygon(color, points);
        }
    }
}
