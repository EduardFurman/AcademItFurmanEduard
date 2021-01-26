using System;

namespace RangeTask
{
    class MyProgram
    {
        static void Main(string[] args)
        {
            double from = 5;
            double to = 12;
            double number = 7;

            Range range = new Range(from, to);

            Console.WriteLine($"Длина диапазона = {range.GetLength()}");

            if(range.isInside(number))
            {
                Console.WriteLine($"Число {number} принадлежит диапазону от {from} до {to}");
            }
            else
            {
                Console.WriteLine($"Число {number} не принадлежит диапазону от {from} до {to}");
            }
        }
    }
}
