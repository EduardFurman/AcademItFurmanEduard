using System;

namespace RangeTask
{
    class Range
    {
        public double From { get; set; }

        public double To { get; set; }

        public Range(double from, double to)
        {
            From = from;
            To = to;
        }

        public double GetLength()
        {
            return To - From;
        }

        public bool IsInside(double number)
        {
            return number >= From && number <= To;
        }

        // Пересечение

        public Range GetCrossing(Range range)
        {
            if (To <= range.From || range.To <= From)
            {
                return null;
            }

            double from = Math.Max(From, range.From);
            double to = Math.Min(To, range.To);

            return new Range(from, to);
        }

        // Объединение
        public Range[] GetUnion(Range range)
        {
            if (To < range.From || range.To < From)
            {
                return new Range[]
                {
                    new Range(From, To),
                    new Range(range.From, range.To)
                };
            }

            double from = Math.Min(From, range.From);
            double to = Math.Max(To, range.To);

            return new Range[] { new Range(from, to) };
        }

        // Разность
        public Range[] GetDifference(Range range)
        {
            if (From == range.From)
            {
                double from = Math.Min(To, range.To);
                double to = Math.Max(To, range.To);

                return new Range[] { new Range(from, to) };
            }

            if (To == range.To)
            {
                return new Range[] { new Range(From, range.From) };
            }

            double from1 = From;
            double to1 = range.From;
            double from2 = Math.Min(To, range.To);
            double to2 = Math.Max(To, range.To);

            return new Range[]
            {
                new Range(from1, to1),
                new Range(from2, to2)
            };
        }

        // Печать
        public static void Print(Range[] range)
        {
            if (range.Length == 2)
            {
                Console.WriteLine($"({range[0].From}, {range[0].To}), ({range[1].From}, {range[1].To})");
                return;
            }

            Console.WriteLine($"({range[0].From}, {range[0].To})");
        }

        public static void Print(Range range)
        {
            if (range == null)
            {
                Console.WriteLine("Пересечений нет.");
                return;
            }

            Console.WriteLine($"({range.From}, {range.To})");
        }
    }
}
