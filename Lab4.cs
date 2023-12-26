Лабораторная работа №4

———————#2
using System;

namespace ConsoleApp1
{
    internal class Program2
    {
        static void Main(string[] args)
        {
            double[,] a = new double[5, 7] {{1, 2, 3, 4, 5, 6, 7 }, { 1, 2, 3, 4, 5, 6, 7 }, { 1, 2, 3, 4, 5, 6, 7 }, { 1, 2, 3, 4, 5, 6, 7 }, { 1, 2, 3, 4, 5, 6, 7 } };
            int count = 5 * 7;
            double sr = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (a[i, j] > 0)
                    {
                        sr += a[i, j];
                    }
                }
            }
            sr = sr / count;
            Console.WriteLine(sr);

        }
    }
}
————————#6
using System;

namespace ConsoleApp1
{
    internal class Program2
    {
        static void Main(string[] args)
        {
            double[,] a = new double[4, 7] { { 1, 2, 3, 4, 5, 6, 7 }, { 4, 2, 3, 1, 5, 6, 7 }, { 1, 2, 3, 4, 5, 6, 7 }, { 1, 2, 3, 4, 5, 6, 7 } };
            double[] b = new double[4];
            for (int i = 0; i < 4; i++)
            {
                double min = 1e9;
                double index = 0;
                for (int j = 0; j < 7; j++)
                {
                    if (min > a[i, j])
                    {
                        min = a[i, j];
                        index = j;
                    }
                }
                b[i] = index;
            }
            Console.WriteLine("{0}", string.Join(", ", b));

        }
    }
}
———————————#10
using System;

namespace ConsoleApp1
{
    internal class Program2
    {
        static void Main(string[] args)
        {
            double[,] a = new double[5, 7] {
                { 1, 2, 389, 4, 5, 6, 8 },
                { 7, 8, 9, 10, 11, 12, 9 },
                { 13, 14, 15, 16, 17, 18, 10 },
                { 19, 20, 21, 22, 23, 24, 67 },
                { 13, 14, 15, 16, 17, 18, 56 }
                                            };

            int maxi = 0;
            double max = a[3, 0];
            for (int i = 0; i < 5; i++)
            {
                if (a[i, 2] > max)
                {
                    max = a[i, 2];
                    maxi = i;
                }
            }
            for (int j = 0; j < 7; j++)
            {
                double rev = a[3, j];
                a[3, j] = a[maxi, j];
                a[maxi, j] = rev;
            }


            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                    Console.Write("{0} ", a[i, j]);
                    Console.WriteLine();
            }
        }
    }
}
——————————————#14
using System;
using System.Data;

namespace ConsoleApp1
{
    internal class Program2
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int m = Convert.ToInt32(Console.ReadLine());
            int[,] a = new int[n, m];
            int[] b = new int[m];
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < m; j++)
                {
                    a[i, j] = Convert.ToInt32(Console.ReadLine());
                    if (a[i, j] < 0)
                    {
                        b[j]++;
                    }
                }
            }

            foreach (var i in b)
            {
                Console.Write(i + " ");
            }
        }
    }
}
—————————————————#14/2.0/ using System;
using System.Data;

namespace ConsoleApp1
{
    internal class Program2
    {
        static void Main(string[] args)
        {
            double[,] a = new double[4, 3] {
                { 1, -2, 389},
                { 7, -8, -9},
                { 13, 14, 15},
                { -13, -14, -15}
                                            };
            double[] b = new double[3];

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (a[i, j] < 0)
                    {
                        b[j]++;
                    }
                }

            }
            Console.WriteLine("{0}", string.Join(", ", b));
        }
    }
}
————————————————#18
using System;

class Program
{
    static void Main()
    {
        int[,] D = { { -1, -2, -3, -4 }, { 5, -6, 7, -8 }, { 9, 10, -11, 12 } };
        int n = D.GetLength(0);
        int m = D.GetLength(1);

        for (int i = 0; i < n; i++)
        {
            int maxBeforeNegative = int.MinValue;
            int lastNegativeIndex = -1;
            int maxIndex = -1;

            // Поиск максимального элемента до первого отрицательного
            for (int j = 0; j < m; j++)
            {
                if (D[i, j] < 0)
                {
                    if (lastNegativeIndex == -1) // Первый отрицательный элемент
                    {
                        lastNegativeIndex = j;
                        break; // Прерываем поиск, так как нашли первый отрицательный элемент
                    }
                }
                else if (D[i, j] > maxBeforeNegative)
                {
                    maxBeforeNegative = D[i, j];
                    maxIndex = j;
                }
            }

            // Поиск последнего отрицательного элемента в строке
            for (int j = m - 1; j >= 0; j--)
            {
                if (D[i, j] < 0)
                {
                    lastNegativeIndex = j;
                    break;
                }
            }

            // Обмен местами максимального и последнего отрицательного элемента
            if (maxBeforeNegative != int.MinValue && lastNegativeIndex != -1 && maxIndex != lastNegativeIndex)
            {
                int temp = D[i, maxIndex];
                D[i, maxIndex] = D[i, lastNegativeIndex];
                D[i, lastNegativeIndex] = temp;
            }
        }

        // Вывод обработанной матрицы
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write(D[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

}
—————————————#22
using System;

class Program
{
    static void Main()
    {
        double[,] a = new double[6, 8];
        double max = -1 * Math.Pow(10, 100), sum = 0;
        int im = -1, jm = -1, cnt = 0;
        for (int i = 0; i < a.GetLength(0); i++)
        {
            for (int j = 0; j < a.GetLength(1); j++)
            {
                Console.WriteLine("[" + i + "," + j + "]");
                a[i, j] = Double.Parse(Console.ReadLine());
                if (a[i, j] > 0)
                {
                    sum += a[i, j];
                    cnt++;
                }
                if (a[i, j] > max)
                {
                    max = a[i, j];
                    im = i;
                    jm = j;
                }
            }
            Console.WriteLine();
        }
        a[im, jm] = sum / cnt;
        Console.WriteLine();
        for (int i = 0; i < a.GetLength(0); i++)
        {
            for (int j = 0; j < a.GetLength(1); j++)
            {
                Console.Write(a[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}
——————————————#26
using System;

class Program
{
    static void Main()
    {
        double[,] a = new double[3, 7];
        double[] b = new double[7];
        double max = -1 * Math.Pow(10, 100);
        int im = -1, cnt = 0;
        for (int i = 0; i < a.GetLength(0); i++)
        {
            for (int j = 0; j < a.GetLength(1); j++)
            {
                Console.WriteLine("a[" + i + "," + j + "]");
                a[i, j] = Double.Parse(Console.ReadLine());
            }
            if (a[i, 5] > max)
            {
                max = a[i, 5];
                im = i;
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        for (int i = 0; i < a.GetLength(1); i++)
        {
            Console.WriteLine("b[" + i + "]");
            b[i] = Double.Parse(Console.ReadLine());
            a[im, i] = b[i];
        }
        Console.WriteLine();
        for (int i = 0; i < a.GetLength(0); i++)
        {
            for (int j = 0; j < a.GetLength(1); j++)
            {
                Console.Write(a[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}
————————————————#30
using System;

class Program
{
    static void Main()
    {
        double[,] b = new double[5, 5];
        double max = -1 * Math.Pow(10, 100), t;
        int i1 = -1, i2 = -1;
        bool flag = true;
        for (int i = 0; i < b.GetLength(0); i++)
        {
            for (int j = 0; j < b.GetLength(1); j++)
            {
                Console.WriteLine("[" + i + "," + j + "]");
                b[i, j] = Double.Parse(Console.ReadLine());
            }
            if (b[i, i] > max)
            {
                max = b[i, i];
                i1 = i;
            }
            if (b[i, 2] < 0 & flag == true)
            {
                i2 = i;
                flag = false;
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        for (int j = 0; j < b.GetLength(1); j++)
        {
            t = b[i1, j];
            b[i1, j] = b[i2, j];
            b[i2, j] = t;
        }
        for (int i = 0; i < b.GetLength(0); i++)
        {
            for (int j = 0; j < b.GetLength(1); j++)
            {
                Console.Write(b[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}
———————————LVL2||#4
using System;

class Program
{
    static void Main()
    {
        int n = 7, m = 5;
        double[,] a = new double[n, m];

        Random k = new Random();
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                a[i, j] = k.NextDouble() * 10;
            }
        }

        double[] b = new double[m] { 1000, -3, 666, 9, 1 };

        for (int i = 0; i < m; i++)
        {
            double max_elem = -1e9;
            int i_strok = -1;
            for (int j = 0; j < n; j++)
            {
                if (a[j, i] > max_elem)
                {
                    max_elem = a[j, i];
                    i_strok = j;
                }
            }
            if (b[i] > max_elem)
            {
                a[i_strok, i] = b[i];
            }
        }

    }
}
————————————#2.8
using System;

class Program
{
    static void Main()
    {
        int n = 6, m = 6;
        double[,] a = new double[n, m];

        Random k = new Random();
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                a[i, j] = k.NextDouble() * 10;
            }
        }


        for (int i = 0; i < 6; i += 2)
        {
            double max_elem1 = -1e9;
            int i_max1 = -1;
            for (int j = 0; j < n; j++)
            {
                if (a[i, j] > max_elem1)
                {
                    max_elem1 = a[i, j];
                    i_max1 = j;
                }
            }

            double max_elem2 = -1e9;
            int i_max2 = -1;
            for (int j = 0; j < n; j++)
            {
                if (a[i + 1, j] > max_elem2)
                {
                    max_elem2 = a[i + 1, j];
                    i_max2 = j;
                }
            }

            a[i, i_max1] = max_elem2;
            a[i + 1, i_max2] = max_elem1;
        }

    }
}
———————————#3LVL||3.3
using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        if (n != 0)
        {
            double[,] a = new double[n, n];
            double[] ans = new double[n * 2 - 1];

            Random k = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    a[i, j] = Math.Round(k.NextDouble() * 10);
                    ans[j - i + n - 1] += a[i, j];
                }
            }


            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(a[i, j] + "\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine("{0}", string.Join(", ", ans));
        }
        else
        {
            Console.WriteLine("0");
        }
    }
}
————————#3.4
using System;

class Program
{
    static void Main()
    {
        int n = Int32.Parse(Console.ReadLine());
        if (n > 0)
        {
            double[,] a = new double[n, n];
            double sum = 0;
            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.WriteLine("[" + i + "," + j + "]");
                    a[i, j] = Double.Parse(Console.ReadLine());
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            for (int i = n - 1; i > n / 2 - 1; i--)
            {
                for (int j = 0; j < i + 1; j++)
                {
                    a[i, j] = 1;
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(a[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
--------------------------№1
using System;
class Program
{
    static void Main()
    {
        Random randomGenerator = new Random();

        int n = 7;
        int m = 5;
        double[,] a = new double[n, m + 1];
        double[,] b = new double[n, m];

        Console.WriteLine();
        for (int i = 0; i < n; ++i)
        {
            a[i, m] = 0;
            for (int j = 0; j < m; ++j)
            {
                a[i, j] = randomGenerator.NextInt64() % 1000;
                Console.Write(a[i, j] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        double[] minElStr = new double[n];
        for (int i = 0; i < n; ++i)
        {
            minElStr[i] = a[i, 0];
        }
        for (int i = 0; i < n; i++)
        {
            for (int j = 1; j < m; j++)
            {
                if (a[i, j] < minElStr[i])
                {
                    minElStr[i] = a[i, j];
                }
            }
        }
        for (int i = 0; i < n; ++i)
        {
            int maxStrIndex = -1;
            double maxStrEl = -1;
            for (int j = 0; j < n; ++j)
            {
                if (a[j, m] == 0)
                {
                    if (maxStrIndex == -1)
                    {
                        maxStrIndex = j;
                        maxStrEl = minElStr[j];
                    }
                    if (minElStr[j] >= maxStrEl)
                    {
                        maxStrEl = minElStr[j];
                        maxStrIndex = j;
                    }
                }
            }
            Console.WriteLine(
                (i+1).ToString() +
                " Строкой в новой матрице будет " +
                (maxStrIndex+1).ToString()  +
                " строка изначальной матрицы с минимальным элементом " +
                maxStrEl.ToString()
            );
            a[maxStrIndex, m] = 1;
            for (int j = 0; j < m; ++j)
            {
                b[i, j] = a[maxStrIndex, j];
            }
        }
        Console.WriteLine();
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write(b[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}
