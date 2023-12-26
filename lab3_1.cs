//————————#1
namespace ConsoleApp1
{
    internal class Program2
    {
        static void Main(string[] args)
        {
            double[] myArray;
            myArray = new double[6];
            myArray[0] = 3;
            myArray[1] = 4;
            myArray[2] = 32;
            myArray[3] = 13;
            myArray[4] = 38;
            myArray[5] = 10;
            double s = 0;
            for (int i = 0; i <= (myArray.Length - 1); i++)
            {
                s += myArray[i];
            }
            for (int i = 0; i <= (myArray.Length - 1); i++)
            {
                myArray[i] = myArray[i] / 2;
                Console.WriteLine(myArray[i]);
            }
        }
    }
}
//—————————#2
namespace ConsoleApp2
    
{
    internal class Program3
    {
        static void Main(string[] args)
        {
            double[] m = new double[8] { 24, 7, 2, -45, 5, -13, -3, 34 };
            double s = 0, count = 0;
            for (int i = 0; i < 8; i++)
            {
                if (m[i] > 0)
                {
                    s += m[i];
                    count++;
                }

            }
            double sr = s / count;
            for (int i = 0; i < 8; i++)
            {
                if (m[i] > 0)
                {
                    m[i] = sr;
                }
            }
        }
    }
}
//—————————————#3
namespace ConsoleApp3
{
    internal class Program2
    {
        static void Main(string[] args)
        {
            double[] m1 = new double[4] { 24, 37, -9, 43 };
            double[] m2 = new double[4] { 22, 21, 46, 76 };
            double[] s = new double[4];
            double[] r = new double[4];
            for (int i = 0; i < 4; i++)
            {
                s[i] = m1[i] + m2[i];
            }
            for (int i = 0; i < 4; i++)
            {
                r[i] = m1[i] - m2[i];
            }

        }
    }
}
//————————————#4

namespace ConsoleApp4
{
    internal class Program2
    {
        static void Main(string[] args)
        {
            double[] m = new double[5] { 3, 4, -5, -7, 12 };
            double sr = 0;
            for (int i = 0; i < 5; i++)
            {
                sr += m[i];
            }
            sr /= 5;
            for (int i = 0; i < 5; i++)
            {
                m[i] = m[i] - sr;
            }


        }
    }
}
//—————————————#5

namespace ConsoleApp5
{
    internal class Program2
    {
        static void Main(string[] args)
        {
            double[] m1 = new double[4] { 34, 54, 65, -67 };
            double[] m2 = new double[4] { 21, 32, 0, 567 };
            double sp = 0;
            for (int i = 0; i < 4; i++)
            {
                sp += m1[i] * m2[i];
            }
            Console.WriteLine(sp);
        }
    }
}
//—————————————#6

namespace ConsoleApp6
{
    internal class Program2
    {
        static void Main(string[] args)
        {
            double[] m = new double[5] { 64, 24, 35, 434, 945 };
            double d = 0;
            for (int i = 0; i < 5; i++)
            {
                d += m[i] * m[i];
            }
            d = Math.Sqrt(d);
            Console.WriteLine(d);

        }
    }
}
//——————————————#7


namespace ConsoleApp7
{
    internal class Program2
    {
        static void Main(string[] args)
        {
            double[] m = new double[7] { 45, 21, 33, 47, 7, 5, 34 };
            double sr = 0;
            for (int i = 0; i < 7; i++)
            {
                sr += m[i];
            }
            sr = sr / 7;
            for (int i = 0; i < 7; i++)
            {
                if (m[i] > sr)
                {
                    m[i] = 0;
                }
            }

        }
    }
}


//——————————————#8
namespace ConsoleApp8
{
    internal class Program2
    {
        static void Main(string[] args)
        {
            double[] m = new double[6] { 41, 52, -63, 44, -45, -12 };
            int count = 0;
            for (int i = 0; i < 6; i++)
            {
                if (m[i] < 0)
                {
                    count++;
                }
            }
            Console.WriteLine(count);

        }
    }
}
//———————————————#9

namespace ConsoleApp9
{
    internal class Program2
    {
        static void Main(string[] args)
        {
            double[] m = new double[8] { 45, 341, 542, 753, 6757, 754, 557, 576 };
            double sr = 0;
            for (int i = 0; i < 8; i++)
            {
                sr += m[i];
            }
            sr = sr / 8;
            int count = 0;
            for (int i = 0; i < 8; i++)
            {
                if (m[i] > sr)
                {
                    count++;
                }
            }
            Console.WriteLine(count);

        }
    }
}
//——————————————#10

namespace ConsoleApp10
{
    internal class Program2
    {
        static void Main(string[] args)
        {
            double[] m = new double[10] { 231, 22, 33, -4, 15, 46, -7, 898, 29, 411 };
            double P = 1;
            double Q = 100;

            int count = 0;
            for (int i = 0; i < 10; i++)
            {
                if (m[i] > P && m[i] < Q)
                {
                    count++;
                }
            }
            Console.WriteLine(count);

        }
    }
}
//—————————————#11


namespace ConsoleApp11
{
    using static System.Runtime.InteropServices.JavaScript.JSType;
    internal class Program2
    {
        static void Main(string[] args)
        {
            double[] m = new double[10] { 87, 782, 4, -76, 15, -198, -17, 548, 98, -654 };
            int count = 0;
            for (int i = 0; i < 10; i++)
            {
                if (m[i] > 0)
                {
                    count++;
                }
            }
            double[] m2 = new double[count];
            int j = 0;
            for (int i = 0; i < 10; i++)
            {
                if (m[i] > 0)
                {
                    m2[j] = m[i];
                    j++;
                }
            }
            for (int i = 0; i <= (m2.Length - 1); i++)
            {
                Console.WriteLine(m2[i]);
            }

        }
    }
}
//——————————————#12

namespace ConsoleApp12
{
    internal class Program2
    {
        static void Main(string[] args)
        {
            double[] m = new double[8] { 31, 52, -15, 667, -23, 80, 97, 16 };
            double n = 0;
            double z = 0;
            for (int i = 0; i < 8; i++)
            {
                if (m[i] < 0)
                {
                    n = i;
                    z = m[i];
                }
            }
            Console.WriteLine(n);
            Console.WriteLine(z);
        }
    }
}
//——————————————#13

namespace ConsoleApp13
{
    internal class Program2
    {
        static void Main(string[] args)
        {
            double[] m = new double[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            double[] chet = new double[5];
            double[] nechet = new double[5];
            int j = 0;
            for (int i = 0; i <= 8; i += 2)
            {
                chet[j] = m[i];
                nechet[j] = m[i + 1];
                j++;
            }
            Console.WriteLine("{0}\t\t{1}", string.Join(", ", chet), string.Join(", ", nechet));


        }
    }
}
//—————————————————#14

namespace ConsoleApp14
{
    internal class Program2
    {
        static void Main(string[] args)
        {
            double[] m = new double[11] { 1234, 21, 23, 323, 54, -4, 15, 26, 47, 68, 978 };
            double s = 0;
            for (int i = 0; i < 11; i++)
            {
                if (m[i] < 0)
                {
                    break;
                }
                else
                {
                    s += m[i] * m[i];
                }
            }
            Console.WriteLine(s);
        }
    }
}
//————————————————#15

namespace ConsoleApp15
{
    internal class Program2
    {
        static void Main(string[] args)
        {
            double[] x = new double[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            double[] y = new double[10];
            for (int i = 0; i < 10; i++)
            {
                y[i] = 0.5 * Math.Log(x[i]);
                Console.WriteLine("{0}\t{1}", x[i], y[i]);
            }
        }
    }
}
