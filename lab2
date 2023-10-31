using System;

namespace ConsoleApp1
{
  internal class Program
  {

    static void Main(string[] args)
    {
//1 уровень

# region3
      double a3 = Convert.ToDouble(Console.ReadLine());
      double b3 = Convert.ToDouble(Console.ReadLine());
      if (a3 > 0)
      {
        Console.WriteLine(Math.Max(a, b));
      }
      else Console.WriteLine(Math.Min(a, b));
#endregion

# region6
      double r6 = Convert.ToDouble(Console.ReadLine());
      double s6 = Convert.ToDouble(Console.ReadLine());
      double rad_cir6 = Math.Pow((r6 / Math.RI), 0.5);
      double rad_sq6 = Math.Pow(s6, 0.5) * Math.Pow(2, 0.5) / 2
      if (rad_cir6 <= rad_sq6)
      {
        Console.WriteLine("Yes");
      }
      else Console.WriteLine("No");
#endregion

# region9
      double x9 = Convert.ToDouble(Console.ReadLine());
      if (x9 <= -1)
      {
        Console.WriteLine(0);
      }
      else if (-1 < x9 && x9 <= 0)
      {
        Console.WriteLine(1 + x9);
      }
      else
      {
        Console.WriteLine(1);
      }
#endregion

//2 уровень
# region2_3
      int n23 = Convert.ToInt32(Console.ReadLine());
      double s23 = 0;
      for (int i = 0; i < n23; i++)
      {
        int weight = Convert.ToInt32(Console.ReadLine());
        if (weight < 30)
        {
          s23 += 0.2;
        }
      }
      Console.WriteLine(s23);
#endregion


# region2_6
      int n26 = Convert.ToInt32(Console.ReadLine());
      int ans26 = 0;
      for (int i = 0; i < n26; i++)
      {
        double x26 = Convert.ToDouble(Console.ReadLine());
        double y26 = Convert.ToDouble(Console.ReadLine());
        if (x26 >= 0 && x26 <= Math.PI)
        {
          if (Math.Sin(x26) >= y26 && y26 >= 0)
          {
            ++ans26;
          }
        }
      }
      Console.WriteLine(ans26);
#endregion

# region2_9
      int n29 = Convert.ToInt32(Console.ReadLine());
      double min29 = Math.Pow(10, 9);
      for (int i = 0; i < n29; i++)
      {
        double x29 = Convert.ToDouble((Console.ReadLine()));
        min29 = Math.Min(min29, x29);
      }
      Console.WriteLine(min29);
#endregion
    }
  }
}
