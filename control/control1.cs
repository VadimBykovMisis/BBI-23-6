using System;
using System.Collections.Generic;
struct Number
{ 
    public double realPart;
    public Number(double real)
    {
        realPart = real;
    }
    public static Number Plus(Number x1, Number x2)
    {
        x1.realPart = x1.realPart + x2.realPart;
        return x1;
    }
    public static Number Minus(Number x1, Number x2)
    {
        x1.realPart = x1.realPart - x2.realPart;
        return x1;
    }
    public static Number Product(Number x1, Number x2)
    {
        x1.realPart = x1.realPart * x2.realPart;
        return x1;
    }
    public static Number Divide(Number x1, Number x2)
    {
        x1.realPart = x1.realPart / x2.realPart;
        return x1;
    }
    public void output()
    {
        Console.WriteLine(String.Format("Number равен = {0}", realPart));
    }
}
class Program
{
    static void Main()
    {
        Number x1 = new Number(3);
        Number x2 = new Number(6);

        Number sum = Number.Plus(x1, x2);
        Number minus = Number.Minus(x1, x2);
        Number product = Number.Product(x1, x2);
        Number division = Number.Divide(x1, x2);

        sum.output();
        minus.output();
        product.output();
        division.output();
    }
}
