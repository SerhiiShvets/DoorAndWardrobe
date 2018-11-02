using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Wardrobe
    {
        public double Height;
        public double Length;
        public double Width;
        public double Radius;
        public double[] Dimensions = new double[3];
        public double[] Diagonals = new double[3]; 

        public double[] GetDiagonals(double a, double b, double c)
        {
            double[] Diagonals = new double[3];

            Diagonals[0] = Math.Sqrt(a * a + b * b);
            Diagonals[1] = Math.Sqrt(a * a + c * c);
            Diagonals[2] = Math.Sqrt(c * c + b * b);
            return Diagonals;

        }
    }
}
