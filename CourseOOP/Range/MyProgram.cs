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

            if (range.IsInside(number))
            {
                Console.WriteLine($"Число {number} принадлежит диапазону от {from} до {to}");
            }
            else
            {
                Console.WriteLine($"Число {number} не принадлежит диапазону от {from} до {to}");
            }

            // *Range
            Console.WriteLine();

            Console.WriteLine("*Range");

            double from1 = 1;
            double to1 = 6;
            double from2 = 5;
            double to2 = 10;

            Range range1 = new Range(from1, to1);
            Range range2 = new Range(from2, to2);

            // Задача 1. Пересечение
            Range crossingRange = range1.GetCrossing(range2);

            Console.Write("Диапазоны пересекаются: ");
            Range.Print(crossingRange);

            // Задача 2. Объединение
            Range[] union = range1.GetUnion(range2);

            Console.Write("Диапазон объединения: ");
            Range.Print(union);

            // Разность
            Range[] difference = range1.GetDifference(range2);

            Console.Write("Диапазон разности: ");
            Range.Print(difference);
        }
    }
}
