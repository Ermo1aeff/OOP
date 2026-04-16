using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛР6
{
    public abstract class Shape
    {
        public Color ShapeColor { get; set; }

        public Shape(Color color)
        {
            ShapeColor = color;
        }

        // Абстрактный метод, который каждая фигура будет реализовывать по-своему
        public abstract void Draw(Graphics g);
    }
}
