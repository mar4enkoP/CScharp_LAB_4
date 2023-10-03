using System;

namespace CScharp_LAB_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ComplexNumber a = new ComplexNumber(2, 3, false);
            ComplexNumber b = new ComplexNumber(1, 4, false); 
            ComplexNumber c = new ComplexNumber(5, 45, true); 
            ComplexNumber d = new ComplexNumber(3, 60, true); 

            ComplexNumber numerator = (a + b) * (c * c);
            ComplexNumber denominator = b - a;

            ComplexNumber x = numerator / denominator;

            Console.WriteLine("calculation results:");
            Console.WriteLine(x.ToAlgebraicString()); // Вывод в алгебраической форме
            Console.WriteLine(x.ToTrigonometricString()); // Вывод в тригонометрической форме
        }
    }
}