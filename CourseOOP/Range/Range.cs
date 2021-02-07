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
        public Range[] GetDifference(Range range1, Range range2)
        {
            Range[] rangesArray = new Range[2];

            if (range1.To <= range2.From)
            {
                rangesArray[0] = range1;
                rangesArray[1] = range2;
            }

            if (range1.From - range2.From == 0 && range1.To - range2.To == 0)
            {
                Array.Resize(ref rangesArray, 0);

                return rangesArray;
            }

            if (range1.From == range2.From)
            {
                Array.Resize(ref rangesArray, 1);

                double from = range2.To;
                double to = range1.To;

                if (range1.To < range2.To)
                {
                    from = range1.To;
                    to = range2.To;
                }

                rangesArray[0] = new Range(from, to);

                return rangesArray;
            }

            if (range1.To == range2.To)
            {
                Array.Resize(ref rangesArray, 1);

                double from = range1.From;
                double to = range2.From;

                rangesArray[0] = new Range(from, to);

                return rangesArray;
            }

            rangesArray[0] = new Range(range1.From, range2.From);
            rangesArray[1] = new Range(range1.To, range2.To);

            return rangesArray;
        }
    }
}
