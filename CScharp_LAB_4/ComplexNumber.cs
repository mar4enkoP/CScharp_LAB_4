using System;

namespace CScharp_LAB_4
{
    internal class ComplexNumber
    {
        public const double DEGREES_TO_RADIANS = Math.PI / 180.0;

        private double _realPart;
        private double _imaginaryPart;
        private bool _isTrigonometric;

        public ComplexNumber(double realPart, double imaginaryPart, bool isTrigonometric = false)
        {
            _realPart = realPart;
            _imaginaryPart = imaginaryPart;
            _isTrigonometric = isTrigonometric;

            if (_isTrigonometric)
            {
                ConvertTrigonometricToAlgebraic();
            }
        }

        public static ComplexNumber operator +(ComplexNumber num1, ComplexNumber num2)
        {
            return new ComplexNumber(num1._realPart + num2._realPart, num1._imaginaryPart + num2._imaginaryPart);
        }

        public static ComplexNumber operator -(ComplexNumber num1, ComplexNumber num2)
        {
            return new ComplexNumber(num1._realPart - num2._realPart, num1._imaginaryPart - num2._imaginaryPart);
        }

        public static ComplexNumber operator *(ComplexNumber num1, ComplexNumber num2)
        {
            double realPart = num1._realPart * num2._realPart - num1._imaginaryPart * num2._imaginaryPart;
            double imaginaryPart = num1._realPart * num2._imaginaryPart + num1._imaginaryPart * num2._realPart;
            return new ComplexNumber(realPart, imaginaryPart);
        }

        public static ComplexNumber operator /(ComplexNumber num1, ComplexNumber num2)
        {
            double denominator = num2._realPart * num2._realPart + num2._imaginaryPart * num2._imaginaryPart;
            if (denominator == 0)
            {
                throw new DivideByZeroException("Division by zero is not allowed.");
            }

            double realPart = (num1._realPart * num2._realPart + num1._imaginaryPart * num2._imaginaryPart) /
                              denominator;
            double imaginaryPart = (num1._imaginaryPart * num2._realPart - num1._realPart * num2._imaginaryPart) /
                                   denominator;
            return new ComplexNumber(realPart, imaginaryPart);
        }

        // Вывод в алгебраической форме
        public string ToAlgebraicString()
        {
            return $"Algebraic form: {_realPart} + {_imaginaryPart}i";
        }

        // Вывод в тригонометрической форме
        public string ToTrigonometricString()
        {
            double magnitude = Math.Sqrt(_realPart * _realPart + _imaginaryPart * _imaginaryPart);
            double angleInDegrees = Math.Atan2(_imaginaryPart, _realPart) / DEGREES_TO_RADIANS;
            return $"Trigonometric form: {magnitude} * cos({angleInDegrees}°) + {magnitude} * sin({angleInDegrees}°)";
        }

        //преобразование числа из тригонометрической формы в алгебраическую (все операции (сложение, вычитание, умножение, деление) будут выполняться в одной и той же форме)
        private void ConvertTrigonometricToAlgebraic()
        {
            double radians = _imaginaryPart * DEGREES_TO_RADIANS;
            double magnitude = Math.Sqrt(_realPart * _realPart + _imaginaryPart * _imaginaryPart);
            _realPart = magnitude * Math.Cos(radians);
            _imaginaryPart = magnitude * Math.Sin(radians);
            _isTrigonometric = false;
        }
    }
}