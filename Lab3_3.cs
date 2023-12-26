————————————LAB#3LVL#3
—————————#2
using System;

namespace ConsoleApp1
{
    internal class Program2
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество элементов в массиве: ");
            int n = Int32.Parse(Console.ReadLine());
            double[] a = new double[n];
            double max = -1 * Math.Pow(10, 100);
            double sum = 0;
            int km = 1;
            Console.WriteLine("Введите элементы массива: ");
            for (int i = 0; i < n; i++)
            {
                a[i] = double.Parse(Console.ReadLine());
                if (a[i] > max)
                    max = a[i];
            }
            for (int i = 0; i < n; i++)
            {
                if (a[i] == max)
                {
                    a[i] += km;
                    km++;
                }
            }

            Console.Write("Результат: ");
            for (int i = 0; i < n; i++)
            {
                Console.Write(a[i] + " ");
            }

        }
    }
}

—————————#3 using System;

namespace ConsoleApp1
{
    internal class Program2
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите n: ");
            int n = int.Parse(Console.ReadLine());
            double[] a = new double[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Введите {i + 1}-й элемент");
                a[i] = double.Parse(Console.ReadLine());
            }

            int max_id = 0;
            double max_elem = -1e9;
            for (int i = 0; i < n; i++)
            {
                if (a[i] > max_elem)
                {
                    max_id = i;
                    max_elem = a[i];
                }
            }

            double now_el = 0;
            for (int i = 0; i < max_id; i += 2)
            {
                now_el = a[i];
                a[i] = a[i + 1];
                a[i + 1] = now_el;
            }
            Console.WriteLine("{0}", string.Join(", ", a));


        }
    }
}

—————————#4
using System;

namespace ConsoleApp1
{
    internal class Program2
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество элементов в массиве: ");
            int n = Int32.Parse(Console.ReadLine());
            double[] a = new double[n];
            double max = -1 * Math.Pow(10, 100);
            double sum = 0;
            Console.WriteLine("Введите элементы массива: ");
            for (int i = 0; i < n; i++)
            {
                a[i] = double.Parse(Console.ReadLine());
                if (a[i] > max)
                    max = a[i];
            }
            Console.Write("Результат: ");
            for (int i = 0; i < n; i++)
            {
                if (a[i] == max)
                {
                    a[i] = sum;
                }
                sum += a[i];
                Console.Write(a[i] + " ");
            }

        }
    }
}
