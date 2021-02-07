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

            if (crossingRange == null)
            {
                Console.WriteLine($"Пересечений нет.");
            }
            else
            {
                Console.WriteLine($"Пересечение от {crossingRange.From} до {crossingRange.To}");
            }

            // Задача 2. Объединение
            Range[] union = range1.GetUnion(range2);

            if (union.Length > 1)
            {
                Console.WriteLine($"В объединении {union.Length} интервала:");

                for (int i = 0; i < union.Length; i++)
                {
                    Console.WriteLine($"От {union[i].From} до {union[i].To}");
                }
            }
            else
            {
                Console.WriteLine($"Объединенный интвервал от {union[0].From} до {union[0].To}");
            }

            // Разность
            Range[] difference = new Range(0, 0).GetDifference(range1, range2);

            if (difference.Length == 0)
            {
                Console.WriteLine("Разность интервалов равна нулю.");
            }
            else if (difference.Length == 1)
            {
                Console.WriteLine($"Разность интвервалов от {difference[0].From} до {difference[0].To}");
            }
            else
            {
                Console.WriteLine($"Разность представлена двумя интервалами от {difference[0].From} до {difference[0].To} и от {difference[1].From} до {difference[1].To}");
            }
        }
    }
}
