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

            if (range.isInside(number))
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
            Range crossingInterval = new Range().GetIntersectionInterval(range1, range2);

            if (crossingInterval == null)
            {
                Console.WriteLine($"Пересечений нет.");
            }
            else
            {
                Console.WriteLine($"Пересечение от {crossingInterval.From} до {crossingInterval.To}");
            }

            // Задача 2. Объединение
            Range[] unionsArray = new Range().GetUnionIntervals(range1, range2);

            if (unionsArray.Length > 1)
            {
                Console.WriteLine($"В объединении {unionsArray.Length} интервалов:");

                for (int i = 0; i < unionsArray.Length; i++)
                {
                    Console.WriteLine($"От {unionsArray[i].From} до {unionsArray[i].To}");
                }
            }
            else
            {
                Console.WriteLine($"Объединенный интвервал от {unionsArray[0].From} до {unionsArray[0].To}");
            }

            // Разность
            Range[] differenceArray = new Range().GetIntervalDifference(range1, range2);

            if (differenceArray.Length == 0)
            {
                Console.WriteLine("Разность интервалов равна нулю.");
            }
            else if (differenceArray.Length == 1)
            {
                Console.WriteLine($"Разность интвервалов от {differenceArray[0].From} до {differenceArray[0].To}");
            }
            else
            {
                Console.WriteLine($"Разность представлена двумя интервалами от {differenceArray[0].From} до {differenceArray[0].To} и от {differenceArray[1].From} до {differenceArray[1].To}");
            }
        }
    }
}
