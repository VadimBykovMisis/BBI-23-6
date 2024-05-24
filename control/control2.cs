using System;
using System.Collections.Generic;
class Number
{
    public double realPart;
    public Number(double real)
    {
        realPart = real;
    }

    public static Number Plus(Number x1, Number x2)
    {
        Number buf = new Number(0);
        buf.realPart = x1.realPart + x2.realPart;
        return buf;
    }
    public static Number Minus(Number x1, Number x2)
    {
        Number buf = new Number(0);
        buf.realPart = x1.realPart - x2.realPart;
        return buf;
    }
    public static Number Product(Number x1, Number x2)
    {
        Number buf = new Number(0);
        buf.realPart = x1.realPart * x2.realPart;
        return buf;
    }
    public static Number Divide(Number x1, Number x2)
    {
        Number buf = new Number(0);
        buf.realPart = x1.realPart / x2.realPart;
        return buf;
    }

    public virtual void output()
    {
        Console.WriteLine(String.Format("number = {0}", realPart));
    }

}
class ComplexNumber : Number
{
    double imaginaryPart;
    public ComplexNumber(int realPart, int imaginaryPart) : base(realPart)
    {
        this.imaginaryPart = imaginaryPart;
    }
    public static ComplexNumber Plus(ComplexNumber x1, ComplexNumber x2)
    {
        ComplexNumber buf = new ComplexNumber(0, 0);
        buf.realPart = x1.realPart + x2.realPart;
        buf.imaginaryPart = x1.imaginaryPart + x2.imaginaryPart;
        return buf;
    }
    public static ComplexNumber Minus(ComplexNumber x1, ComplexNumber x2)
    {
        ComplexNumber buf = new ComplexNumber(0, 0);
        buf.realPart = x1.realPart - x2.realPart;
        buf.imaginaryPart = x1.imaginaryPart - x2.imaginaryPart;
        return buf;
    }
    public static ComplexNumber Product(ComplexNumber x1, ComplexNumber x2)
    {
        ComplexNumber buf = new ComplexNumber(0, 0);
        buf.realPart = x1.realPart * x2.realPart + x1.imaginaryPart * x2.imaginaryPart;
        buf.imaginaryPart = x1.realPart * x2.imaginaryPart + x2.realPart * x1.imaginaryPart;
        return buf;
    }
    public static ComplexNumber Divide(ComplexNumber x1, ComplexNumber x2)
    {
        ComplexNumber buf = new ComplexNumber(0, 0);
        buf.realPart = (x1.realPart * x1.imaginaryPart + x2.realPart * x2.imaginaryPart) /
                    (x2.realPart * x2.realPart + x2.imaginaryPart * x2.imaginaryPart);
        buf.imaginaryPart = (x1.imaginaryPart * x2.realPart - x1.realPart * x2.imaginaryPart) /
                            (x2.realPart * x2.realPart + x2.imaginaryPart * x2.imaginaryPart);
        return buf;
    }

    public override void output()
    {
        string plusOrNot = "";
        if (imaginaryPart >= 0) {
            plusOrNot = "+";
        }
        Console.WriteLine(String.Format("number = {0}{1}{2}i", realPart, plusOrNot, imaginaryPart));
    }
}
class Program
{
    static void Main()
    {
        ComplexNumber x1 = new ComplexNumber(3, 1);
        ComplexNumber x2 = new ComplexNumber(6, 2);


        ComplexNumber sum = ComplexNumber.Plus(x1, x2);

        ComplexNumber minus = ComplexNumber.Minus(x1, x2);
        ComplexNumber product = ComplexNumber.Product(x1, x2);
        ComplexNumber division = ComplexNumber.Divide(x1, x2);

        x1.output();
        x2.output();
        sum.output();
        minus.output();
        product.output();
        division.output();
    }
}
