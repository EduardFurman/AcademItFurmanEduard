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
        public Range GetIntersectionRange(Range range1, Range range2)
        {
            if (range1.To <= range2.From || range2.To <= range1.From)
            {
                return null;
            }

            double from = range1.From;
            double to = range1.To;

            if (range1.From <= range2.From)
            {
                from = range2.From;
            }

            if (range1.To > range2.To)
            {
                to = range2.To;
            }

            Range crossingRange = new Range(from, to);

            return crossingRange;
        }

        // Объединение
        public Range[] GetRangesUnion(Range range1, Range range2)
        {
            Range[] arrayRanges = new Range[1];

            if (range1.To < range2.From || range2.To < range1.From)
            {
                Array.Resize(ref arrayRanges, 2);

                arrayRanges[0] = range1;
                arrayRanges[1] = range2;

                return arrayRanges;
            }

            double from = range1.From;
            double to = range2.To;

            if (range1.From > range2.From)
            {
                from = range2.From;
            }

            if (range1.To > range2.To)
            {
                to = range1.To;
            }

            arrayRanges[0] = new Range(from, to);

            return arrayRanges;
        }

        // Разность
        public Range[] GetRangesDifference(Range range1, Range range2)
        {
            Range[] arrayRanges = new Range[2];

            if (range1.To <= range2.From)
            {
                arrayRanges[0] = range1;
                arrayRanges[1] = range2;
            }

            if (range1.From - range2.From == 0 && range1.To - range2.To == 0)
            {
                Array.Resize(ref arrayRanges, 0);

                return arrayRanges;
            }

            if (range1.From == range2.From)
            {
                Array.Resize(ref arrayRanges, 1);

                double from = range2.To;
                double to = range1.To;

                if (range1.To < range2.To)
                {
                    from = range1.To;
                    to = range2.To;
                }

                arrayRanges[0] = new Range(from, to);

                return arrayRanges;
            }

            if (range1.To == range2.To)
            {
                Array.Resize(ref arrayRanges, 1);

                double from = range1.From;
                double to = range2.From;

                arrayRanges[0] = new Range(from, to);

                return arrayRanges;
            }

            arrayRanges[0] = new Range(range1.From, range2.From);
            arrayRanges[1] = new Range(range1.To, range2.To);

            return arrayRanges;
        }
    }
}
