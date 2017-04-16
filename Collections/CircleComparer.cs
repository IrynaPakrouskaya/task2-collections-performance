using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    public class CircleComparer : IComparer
    {
        public int Compare(object x_, object y_)
        {
            Circle x = (Circle)x_;
            Circle y = (Circle)y_;            

            if (x.X.CompareTo(y.X) != 0)
            {
                return x.X.CompareTo(y.X);
            }
            else if (x.Y.CompareTo(y.Y) != 0)
            {
                return x.Y.CompareTo(y.Y);
            }
            else if (x.Radius.CompareTo(y.Radius) != 0)
            {
                return x.Radius.CompareTo(y.Radius);
            }
            else
            {
                return 0;
            }                
        }
    }
}
