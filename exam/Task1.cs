using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace Variant_3
{
    public class Task1
    {
        public struct Dot
        {
            private double x = 0;
            private double y = 0;
            private double z = 0;

            public double X
            {
                get { return x; }
            }
            public double Y
            {
                get { return y; }
            }
            public double Z
            {
                get { return z; }
            }
            public Dot(double[] vec)
            {
                if (vec.Length == 3)
                {
                    this.x = vec[0];
                    this.y = vec[1];
                    this.z = vec[2];
                }
            }
            public override string ToString()
            {
                return String.Format("x = {0}, y = {1}, z = {2}", this.x, this.y, this.z);
            }
        }
        public struct Vector
        {
            private Dot a = new Dot();
            private Dot b = new Dot();

            public Dot A
            {
                get { return a; }
            }
            public Dot B
            {
                get { return b; }
            }
            public Vector(Dot x, Dot y)
            {
                this.a = x;
                this.b = y;
            }
            public double Length()
            {
                double x1 = Math.Abs(this.b.X - this.a.X);
                double y1 = Math.Abs(this.b.Y - this.a.Y);
                double z1 = Math.Abs(this.b.Z - this.a.Z);

                return Math.Round(Math.Sqrt(x1 * x1 + y1 * y1 + z1 * z1),2);
            }
            public override string ToString()
            {
                return String.Format("{0}\n{1}\nLength = {2}", this.A.ToString(), this.B.ToString(), this.Length());

            }
        }
        private Vector[] list;
        public Vector[] Vectors { get { return list; } }


        public Task1(Vector[] list)
        {
            this.list = list;
        }

        public void Sorting()
        {
            for (int i = 0; i < list.Length; i++)
            {
                for (int j = 0; j < list.Length; j++)
                {
                    if (list[i].Length() < list[j].Length())
                    {
                        Vector v = list[i];
                        list[i] = list[j];
                        list[j] = v;
                    }
                }
            }
        }
    }
}
