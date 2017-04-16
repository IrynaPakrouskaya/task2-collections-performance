using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    public class Circle
    {
        private double x;
        private double y;
        private double radius;

        public double X { get {return x;} }
        public double Y { get {return y;} }
        public double Radius { get { return radius; } }

        public Circle(double x_ = 0, double y_ = 0, double radius_ = 0)
        {
            x = x_;
            y = y_;
            radius = radius_;
        }

        public void display()
        {
            Console.WriteLine("x = {0}, y = {1}, radius = {2}", x, y, radius);
        }
    }
}
