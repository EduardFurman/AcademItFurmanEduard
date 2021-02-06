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
        public Range GetCrossingRange(Range range1, Range range2)
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
            Range[] rangesArray = new Range[1];

            if (range1.To < range2.From || range2.To < range1.From)
            {
                Array.Resize(ref rangesArray, 2);

                rangesArray[0] = range1;
                rangesArray[1] = range2;

                return rangesArray;
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

            rangesArray[0] = new Range(from, to);

            return rangesArray;
        }

        // Разность
        public Range[] GetRangesDifference(Range range1, Range range2)
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
