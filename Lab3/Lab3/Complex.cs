using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class Complex
    {
        public double Real { get; }
        public double Imaginary { get; }

        public Complex(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }

        // Переопределение оператора +
        public static Complex operator +(Complex a, Complex b)
        {
            return new Complex(a.Real + b.Real, a.Imaginary + b.Imaginary);
        }

        // Переопределение оператора -
        public static Complex operator -(Complex a, Complex b)
        {
            return new Complex(a.Real - b.Real, a.Imaginary - b.Imaginary);
        }

        // Переопределение оператора *
        public static Complex operator *(Complex a, Complex b)
        {
            return new Complex(a.Real * b.Real - a.Imaginary * b.Imaginary,
                               a.Real * b.Imaginary + a.Imaginary * b.Real);
        }

        // Переопределение оператора /
        public static Complex operator /(Complex a, Complex b)
        {
            double denominator = b.Real * b.Real + b.Imaginary * b.Imaginary;
            return new Complex((a.Real * b.Real + a.Imaginary * b.Imaginary) / denominator,
                               (a.Imaginary * b.Real - a.Real * b.Imaginary) / denominator);
        }

        // Переопределение оператора ==
        public static bool operator ==(Complex a, Complex b)
        {
            return ((a.Real == b.Real) && (a.Imaginary == b.Imaginary));
        }

        // Переопределение оператора !=
        public static bool operator !=(Complex a, Complex b)
        {
            return ((a.Real != b.Real) && (a.Imaginary != b.Imaginary));
        }
    }
}
