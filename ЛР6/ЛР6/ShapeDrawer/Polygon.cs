using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛР6
{
    public class Polygon : Shape
    {
        public Point[] Points { get; set; }

        public Polygon(Color color, Point[] points) : base(color)
        {
            Points = points;
        }

        public override void Draw(Graphics g)
        {
            if (Points == null || Points.Length < 2) return;

            // Используем using для автоматического освобождения ресурсов кисти
            using (Pen pen = new Pen(ShapeColor, 3)) // 3 - толщина линии
            {
                // Рисуем замкнутый многоугольник по точкам
                g.DrawPolygon(pen, Points);
            }
        }
    }
}
