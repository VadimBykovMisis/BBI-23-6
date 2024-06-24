using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Variant_3
{
    public class Task2
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

                return Math.Round((Math.Sqrt(x1 * x1 + y1 * y1 + z1 * z1)), 2);
            }
            public override string ToString()
            {
                return String.Format("{0}\n{1}\nLength = {2}", this.A.ToString(), this.B.ToString(), this.Length());

            }
        }

        public abstract class Shape
        {
            protected Dot center = new Dot();
            protected Vector pointer = new Vector();

            public Dot Center
            {
                get { return center; }
            }
            public Vector Pointer
            {
                get { return pointer; }
            }
            public Shape(Dot center)
            {
                this.center = center;
            }

            public void CreateVector(Dot a)
            {
                this.pointer = new Vector(this.center, a);
            }

            public abstract double Volume();
            public override string ToString()
            {
                return String.Format("Shape with V = {0}", this.Volume());
            }
        }
        public class Sphere : Shape
        {
            public override string ToString()
            {
                return String.Format("Sphere with V = {0}", this.Volume());
            }
            public Sphere(Dot center) : base(center)
            {
            }

            public override double Volume()
            {

                double r = this.pointer.Length();
                return Math.Round(((r * r * r * Math.PI * 4 / 3)), 2);
            }
        }
        public class Cube : Shape
        {
            public override string ToString()
            {
                return String.Format("Cube with V = {0}", this.Volume());
            }

            public Cube(Dot center) : base(center)
            {
            }

            public override double Volume()
            {
                double diagonalLength = Math.Round((this.pointer.Length()),2);
                double sideLength = (diagonalLength / Math.Sqrt(3));
                return Math.Round(((Math.Pow(sideLength, 3))), 2);
            }
        }
        private Shape[] list;
        public Shape[] Shapes { get { return list; } }



        public Task2(Shape[] list)
        {
            this.list = list;
        }
        public override string ToString()
        {
            string x = "";
            for (int i = 0; i < list.Length; i++)
            {
                x += list[i].ToString();
            }
            return x;
        }

        public void Sorting()
        {
            for (int i = 0; i < list.Length; i++)
            {
                for (int j = 0; j < list.Length; j++)
                {
                    if (list[i].Volume() < list[j].Volume())
                    {
                        Shape v = list[i];
                        list[i] = list[j];
                        list[j] = v;
                    }
                }
            }
        }




    }
}
