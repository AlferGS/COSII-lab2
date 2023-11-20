using System;
using ImageAnalysis.Snapshot;

namespace ImageAnalysis.Analyzers
{
    public class DiscreteCentralMomentAnalyzer : Analyzer
    {
        private int powerX;
        private int powerY;
        private long massCenterX;
        private long massCenterY;

        public DiscreteCentralMomentAnalyzer(ConnectedAreasSnapshot snapshot) : base(snapshot)
        {
        }

        public int PowerX 
        {
            get => powerX;
            set
            {
                if (value > 2 || value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "out of range [0..2]");
                }

                powerX = value;
            }
        }

        public int PowerY
        {
            get => powerY;
            set
            {
                if (value > 2 || value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "out of range [0..2]");
                }

                powerY = value;
            }
        }

        public long MassCenterX
        {
            get => massCenterX;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Less than zero", nameof(value));
                }

                massCenterX = value;
            }
        }

        public long MassCenterY
        {
            get => massCenterY;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Less than zero", nameof(value));
                }

                massCenterY = value;
            }
        }

        protected override long AnalyzeElement(int row, int column, int areaNumber)
        {
            return (long)(Math.Pow(column - massCenterX, powerX) * Math.Pow(row - massCenterY, powerY));
        }
    }
}
