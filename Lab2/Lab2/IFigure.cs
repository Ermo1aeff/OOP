using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public interface IFigure
    {
        string Name { get; }
        double Perimeter { get; set; }
        double Square { get; set; }
        List<double> SideLengths { get; set; }

        void GetPerimeter();
        void GetSquare();
    }
}
