—————————————————LVL 2 #1
using System;

namespace ConsoleApp1
{
    internal class Program2
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размер массива: ");
            int n = int.Parse(Console.ReadLine());
            double[] m = new double[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Введите {i + 1}-й элемент массива");
                m[i] = double.Parse(Console.ReadLine());
            }

            int min= 0;
            double mine = 1e9;
            for (int i = 0; i < n; i++)
            {
                if (m[i] < mine)
                {
                    min = i;
                    mine = m[i];
                }
            }
            m[min] *= 2;
            Console.WriteLine("{0}", string.Join(", ", m));


        }
    }
}
—————————————#2
using System;

namespace ConsoleApp1
{
    internal class Program2
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размер массива: ");
            int n = int.Parse(Console.ReadLine());
            double[] m = new double[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Введите {i + 1}-й элемент массива");
                m[i] = double.Parse(Console.ReadLine());
            }

            int max = 0;
            double maxe = -1e9;
            for (int i = 0; i < n; i++)
            {
                if (m[i] > maxe)
                {
                    max = i;
                    maxe = m[i];
                }
            }
            double s = 0;
            for (int i = 0; i < max; i++)
            {
                s += m[i];
            }
            Console.WriteLine(s);



        }
    }
}
————————————#3
using System;

namespace ConsoleApp1
{
    internal class Program2
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размер массива: ");
            int n = int.Parse(Console.ReadLine());
            double[] m = new double[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Введите {i + 1}-й элемент массива");
                m[i] = double.Parse(Console.ReadLine());
            }

            int id = 0;
            double elem = 1e9;
            for (int i = 0; i < n; i++)
            {
                if (m[i] < elem)
                {
                    id = i;
                    elem = m[i];
                }
            }
            for (int i = 0; i < id; i++)
            {
                m[i] = m[i] * 2;
            }


Console.WriteLine("{0}", string.Join(", ", m));

        }
    }
}
——————————#4
using System;

namespace ConsoleApp1
{
    internal class Program2
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размер массива: ");
            int n = int.Parse(Console.ReadLine());
            double[] m = new double[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Введите {i + 1}-й элемент массива");
                m[i] = double.Parse(Console.ReadLine());
            }

            int id = 0;
            double elem = -1e9;
            double sr = 0;
            for (int i = 0; i < n; i++)
            {
                sr += m[i];
                if (m[i] > elem)
                {
                    id = i;
                    elem = m[i];
                }
            }
            sr = sr / n;
            double s = 0;
            for (int i = id + 1; i < n; i++)
            {
                m[i] = sr;
            }
Console.WriteLine("{0}", string.Join(", ", m));

        }
    }
}
———————————#5
using System;

namespace ConsoleApp1
{
    internal class Program2
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размер массива: ");
            int n = int.Parse(Console.ReadLine());
            double[] m = new double[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Введите {i + 1}-й элемент массива");
                m[i] = double.Parse(Console.ReadLine());
            }

            int min_id = 0;
            double min_elem = 1e9;
            for (int i = 0; i < n; i++)
            {
                if (m[i] < min_elem)
                {
                    min_id = i;
                    min_elem = m[i];
                }
            }
            int max_id = 0;
            double max_elem = -1e9;
            for (int i = 0; i < n; i++)
            {
                if (m[i] > max_elem)
                {
                    max_id = i;
                    max_elem = m[i];
                }
            }

            int left = (int)min_elem;
            int right = (int)max_elem;
            int count_otr = 0;
            for (int i = left + 1; i < right; i++)
            {
                if (m[i] < 0)
                {
                    count_otr++;
                }
            }
            double[] b = new double[count_otr];
            int j = 0;
            for (int i = left + 1; i < right; i++)
            {
                if (m[i] < 0)
                {
                    b[j] = m[i];
                    j++;
                }
            }

Console.WriteLine("{0}", string.Join(", ", m));

        }
    }
}
———————————————#6
using System;

namespace ConsoleApp1
{
    internal class Program2
    {
        static void Main(string[] args)
        {
            /*Console.WriteLine("Введите размер массива: ");
            int n = int.Parse(Console.ReadLine());
            double[] m = new double[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Введите {i + 1}-й элемент массива");
                m[i] = double.Parse(Console.ReadLine());
            }*/

            Console.WriteLine("Введите n: ");
            int n = int.Parse(Console.ReadLine());
            double[] m = new double[n + 1];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Введите {i + 1}-й элемент");
                m[i] = double.Parse(Console.ReadLine());
            }


            double p = double.Parse(Console.ReadLine());
            double sr = 0;
            for (int i = 0; i < n; i++)
            {
                sr += m[i];
            }
            sr = sr / n;
            double found = m[0];
            int ifound = 0;
            for (int i = 1; i < n; i++)
            {
                if (Math.Abs(m[i] - sr) < Math.Abs(found - sr))
                {
                    found = m[i];
                    ifound = i;
                }
            }

            for (int i = n - 1; i > ifound; i--)
            {
                m[i + 1] = m[i];
            }
            m[ifound + 1] = p;

            Console.WriteLine("{0}", string.Join(", ", m));
          



        }
    }
}
————————————#7
using System;

namespace ConsoleApp1
{
    internal class Program2
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размер массива: ");
            int n = int.Parse(Console.ReadLine());
            double[] m = new double[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Введите {i + 1}-й элемент массива");
                m[i] = double.Parse(Console.ReadLine());
            }

            int id = 0;
            double el = -1e9;
            for (int i = 0; i < n; i++)
            {
                if (m[i] > el)
                {
                    id = i;
                    el = m[i];
                }
            }
           m[id + 1] *= 2;


Console.WriteLine("{0}", string.Join(", ", m));
        }
    }
}
————————————#8
using System;

namespace ConsoleApp1
{
    internal class Program2
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размер массива: ");
            int n = int.Parse(Console.ReadLine());
            double[] m = new double[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Введите {i + 1}-й элемент массива");
                m[i] = double.Parse(Console.ReadLine());
            }

            int max_id = 0;
            double max_elem = -1e09;
            for (int i = 0; i < n; i++)
            {
                if (m[i] > max_elem)
                {
                    max_id = i;
                    max_elem = m[i];
                }
            }

            int min_id = 0;
            double min_elem = 1e9;
            for (int i = max_id + 1; i < n; i++)
            {
                if (m[i] < min_elem)
                {
                    min_id = i;
                    min_elem = m[i];
                }
            }

            m[max_id] = min_elem;
            m[min_id] = max_elem;



Console.WriteLine("{0}", string.Join(", ", m));
        }
    }
}
———————————#9
using System;

namespace ConsoleApp1
{
    internal class Program2
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размер массива: ");
            int n = int.Parse(Console.ReadLine());
            double[] m = new double[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Введите {i + 1}-й элемент массива");
                m[i] = double.Parse(Console.ReadLine());
            }

            int min_id = 0;
            double min_elem = 1e9;
            for (int i = 0; i < n; i++)
            {
                if (m[i] < min_elem)
                {
                    min_id = i;
                    min_elem = m[i];
                }
            }
            int max_id = 0;
            double max_elem = -1e9;
            for (int i = 0; i < n; i++)
            {
                if (m[i] > max_elem)
                {
                    max_id = i;
                    max_elem = m[i];
                }
            }

            int left = (int)min_elem;
            int right = (int)max_elem;
            double srr = 0;
            for (int i = left + 1; i < right; i++)
            {
                srr += m[i];
            }
            srr = srr / (right - left - 1);
Console.WriteLine("{0}", string.Join(", ", m));
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
            Console.WriteLine("Введите размер массива: ");
            int n = int.Parse(Console.ReadLine());
            double[] m = new double[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Введите {i + 1}-й элемент массива");
                m[i] = double.Parse(Console.ReadLine());
            }

            int min_id = -100;
            double min_elem = 1e9;
            for (int i = 0; i < n; i++)
            {
                if (m[i] < min_elem && m[i] > 0)
                {
                    min_id = i;
                    min_elem = m[i];
                }
            }

            if (min_id != -100)
            {

                for (int i = min_id; i < n-1; ++i)
                { 
                    m[i] = m[i + 1];
                }
                double[] c = new double[n - 1];
                for (int i = 0; i < n - 1; i++)
                {
                    c[i] = m[i];
                }
                Console.WriteLine("{0}", string.Join(", ", c));
            }
            else
            {
                Console.WriteLine("{0}", string.Join(", ", m));
            }
        }
    }
}
———————————#11
using System;

namespace ConsoleApp1
{
    internal class Program2
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размер массива: ");
            int n = int.Parse(Console.ReadLine());
            double[] m = new double[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Введите {i + 1}-й элемент массива");
                m[i] = double.Parse(Console.ReadLine());
            }

            double p = double.Parse(Console.ReadLine());
            int id = -100;
            for (int i = 0; i < n; i++)
            {
                if (m[i] > 0)
                {
                    id = i;
                }
            }

            if (id != -100)
            {
                double[] c = new double[n + 1];

                for (int i = 0; i <= n; i++)
                {
                    if (i <= id)
                    {
                        c[i] = m[i];
                    }
                    else
                    {
                        if (i == id + 1)
                        {
                            c[i] = p;
                        }
                        else
                        {
                            c[i] = m[i - 1];
                        }
                    }
                }

                Console.WriteLine("{0}", string.Join(", ", c));
            }
            else
            {
                Console.WriteLine("{0}", string.Join(", ", m));
            }

        }
    }
}

——————————————#12
using System;

namespace ConsoleApp1
{
    internal class Program2
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размер массива: ");
            int n = int.Parse(Console.ReadLine());
            double[] m = new double[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Введите {i + 1}-й элемент массива");
                m[i] = double.Parse(Console.ReadLine());
            }

            int max_id = 0;
            double max_elem = -1e9;
            for (int i = 0; i < n; i++)
            {
                if (m[i] > max_elem)
                {
                    max_id = i;
                    max_elem = m[i];
                }
            }

            double sum_before_max = 0;
            for (int i = max_id + 1; i < n; i++)
            {
                sum_before_max += m[i];
            }

            for (int i = 0; i < n; ++i)
            {
                if (m[i] < 0)
                {
                    m[i] = sum_before_max;
                    break;
                }
            }
            Console.WriteLine("{0}", string.Join(", ", m));
           
        }
    }
}

—————————————#13
using System;

namespace ConsoleApp1
{
    internal class Program2
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размер массива: ");
            int n = int.Parse(Console.ReadLine());
            double[] m = new double[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Введите {i + 1}-й элемент массива");
                m[i] = double.Parse(Console.ReadLine());
            }

            int max_id = 0;
            double max_elem = -1e9;
            for (int i = 0; i < n; i += 2)
            {
                if (m[i] > max_elem)
                {
                    max_id = i;
                    max_elem = m[i];
                }
            }

            m[max_id] = max_id;
Console.WriteLine("{0}", string.Join(", ", m));
        }
    }
}

———————————#14
using System;

namespace ConsoleApp1
{
    internal class Program2
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размер массива: ");
            int n = int.Parse(Console.ReadLine());
            double[] m = new double[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Введите {i + 1}-й элемент массива");
                m[i] = double.Parse(Console.ReadLine());
            }

            int max_id = 0;
            double max_elem = -1e9;
            for (int i = 0; i < n; i += 2)
            {
                if (m[i] > max_elem)
                {
                    max_id = i;
                    max_elem = m[i];
                }
            }

            int id_first = 0;
            double elem_first = 1e9;
            for (int i = 0; i < n; ++i)
            {
                if (m[i] < 0)
                {
                    id_first = i;
                    elem_first = m[i];
                    break;
                }
            }

            m[max_id] = elem_first;
            m[id_first] = max_elem;

Console.WriteLine("{0}", string.Join(", ", m));
        }
    }
}

————————#15
using System;

namespace ConsoleApp1
{
    internal class Program2
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите n: ");
            int n = int.Parse(Console.ReadLine());
            double[] m1 = new double[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Введите {i + 1}-й элемент");
                m1[i] = double.Parse(Console.ReadLine());
            }

            Console.WriteLine("Введите m: ");
            int m = int.Parse(Console.ReadLine());
            double[] m2 = new double[m];
            for (int i = 0; i < m; i++)
            {
                Console.WriteLine($"Введите {i + 1}-й элемент");
                m2[i] = double.Parse(Console.ReadLine());
            }

            int k = int.Parse(Console.ReadLine());

            double[] c = new double[n + m];
            for (int i = 0; i <= k; i++)
            {
                c[i] = m1[i];
            }
            for (int i = k + 1; i <= k + m; i++)
            {
                c[i] = m2[i - (k + 1)];
            }
            for (int i = k + m + 1; i < m + n; i++)
            {
                c[i] = m1[i - m];
            }
Console.WriteLine("{0}", string.Join(", ", m));
        }
    }
}

——————————#16
using System;

namespace ConsoleApp1
{
    internal class Program2
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размер массива: ");
            int n = int.Parse(Console.ReadLine());
            double[] m = new double[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Введите {i + 1}-й элемент массива");
                m[i] = double.Parse(Console.ReadLine());
            }

            double sr = 0;
            for (int i = 0; i < n; i++)
            {
                sr += m[i];
            }
            sr = sr / n;

            int count = 0;
            for (int i = 0; i < n; i++)
            {
                if (m[i] < sr) { count++; }
            }

            double[] c = new double[count];
            int j = 0;
            for (int i = 0; i < n; i++)
            {
                if (m[i] < sr)
                {
                    c[j] = i;
                    j++;
                }
            }
Console.WriteLine("{0}", string.Join(", ", m));
        }
    }
}
————————————#17
using System;

namespace ConsoleApp1
{
    internal class Program2
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размер массива: ");
            int n = int.Parse(Console.ReadLine());
            double[] m = new double[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Введите {i + 1}-й элемент массива");
                m[i] = double.Parse(Console.ReadLine());
            }

            int min_id = 0;
            double min_elem = 1e9;
            for (int i = 0; i < n; i++)
            {
                if (m[i] < min_elem)
                {
                    min_id = i;
                    min_elem = m[i];
                }
            }
            int max_id = 0;
            double max_elem = -1e9;
            for (int i = 0; i < n; i++)
            {
                if (m[i] > max_elem)
                {
                    max_id = i;
                    max_elem = m[i];
                }
            }

            double sr = 0;
            int count = 0;
            if (max_id < min_id)
            {
                for (int i = 0; i < n; i++)
                {
                    if (m[i] > 0)
                    {
                        sr += m[i];
                        count++;
                    }
                }
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    if (m[i] < 0)
                    {
                        sr += m[i];
                        count++;
                    }
                }
            }
            sr /= count;
Console.WriteLine("{0}", string.Join(", ", m));            
        }
    }
}
———————————#18
using System;

namespace ConsoleApp1
{
    internal class Program2
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размер массива: ");
            int n = int.Parse(Console.ReadLine());
            double[] m = new double[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Введите {i + 1}-й элемент массива");
                m[i] = double.Parse(Console.ReadLine());
            }

            int max_id_chet = 0;
            double max_elem_chet = -1e9;
            for (int i = 0; i < n; i += 2)
            {
                if (m[i] > max_elem_chet)
                {
                    max_id_chet = i;
                    max_elem_chet = m[i];
                }
            }


            int max_id_nechet = 0;
            double max_elem_nechet = -1e9;
            for (int i = 1; i < n; i += 2)
            {
                if (m[i] > max_elem_nechet)
                {
                    max_id_nechet = i;
                    max_elem_nechet = m[i];
                }
            }

            if (max_elem_chet > max_elem_nechet)
            {
                for (int i = 0; i < n / 2; i++)
                {
                    m[i] = 0;
                }
            }
            else
            {
                for (int i = n / 2; i < n; i++)
                {
                    m[i] = 0;
                }
            }
Console.WriteLine("{0}", string.Join(", ", m));

        }
    }
}
—————————#19
using System;

namespace ConsoleApp1
{
    internal class Program2
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размер массива: ");
            int n = int.Parse(Console.ReadLine());
            double[] m = new double[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Введите {i + 1}-й элемент массива");
                m[i] = double.Parse(Console.ReadLine());
            }

            int max_id = 0;
            double max_elem = -1e9;
            double s = 0;
            for (int i = 0; i < n; i++)
            {
                s += m[i];
                if (m[i] > max_elem)
                {
                    max_id = i;
                    max_elem = m[i];
                }
            }

            if (max_elem > s)
            {
                m[max_id] = 0;
            }
            else
            {
                m[max_id] = m[max_id] * 2;
            }

Console.WriteLine("{0}", string.Join(", ", m));
        }
    }
}
——————————#20
using System;

namespace ConsoleApp1
{
    internal class Program2
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размер массива: ");
            int n = int.Parse(Console.ReadLine());
            double[] m = new double[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Введите {i + 1}-й элемент массива");
                m[i] = double.Parse(Console.ReadLine());
            }

            int min_id = 0;
            double min_elem = 1e9;
            for (int i = 0; i < n; i++)
            {
                if (m[i] < min_elem)
                {
                    min_id = i;
                    min_elem = m[i];
                }
            }

            int first_otr = -1;
            for (int i = 0; i < n; i++)
            {
                if (m[i] < 0)
                {
                    first_otr = i;
                    break;
                }
            }

            double s = 0;
            if (first_otr < min_id)
            {
                for (int i = 0; i < n; i += 2)
                {
                    s += m[i];
                }
            }
            else
            {
                for (int i = 1; i < n; i += 2)
                {
                    s += m[i];
                }
            }
Console.WriteLine("{0}", string.Join(", ", m));

        }
    }
}
