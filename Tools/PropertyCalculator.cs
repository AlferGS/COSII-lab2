using System;

namespace Tools
{
    public static class PropertyCalculator
    {
        public static double GetElongation(long centralMoment20, long centralMoment02, long centralMoment11)
        {
            double m202 = centralMoment20 - centralMoment02;
            double subRoot = m202 * m202 + 4 * centralMoment11 * centralMoment11;
            var root = Math.Sqrt(subRoot);
            var up = centralMoment20 + centralMoment02 + root;
            var down = centralMoment20 + centralMoment02 - root;
            return up / down;
        }

        public static double GetCompactness(long area, long perimeter)
            => perimeter * perimeter / area;
    }
}
