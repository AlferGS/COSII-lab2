using System;
using System.Collections.Generic;
using System.Linq;
using Tools;
using ImageAnalysis.Analyzers;

namespace ImageAnalysis.Snapshot
{
    public class ConnectedAreasSnapshot
    {
        private readonly int[] data;

        private ConnectedAreasSnapshot(int width, int height)
        {
            if (width <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(width));
            }

            if (height <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(height));
            }

            Width = width;
            Height = height;
            data = new int[width * height];
        }

        public int FirstAreaNumber { get; } = 2;

        public int Width { get; }

        public int Height { get; }

        public int LastAreaNumber { get; private set; } = 1;

        public int this[int row, int column]
        {
            get
            {
                CheckParameters(row, column);
                return data[row * Width + column];
            }
            set
            {
                CheckParameters(row, column);
                data[row * Width + column] = value;
            }
        }

        public long GetCentralMoment11(int areaNumber)
            => GetCentralMoment11(areaNumber, GetMassCenterX(areaNumber), GetMassCenterY(areaNumber));

        public long GetCentralMoment11(int areaNumber, long massCenterX, long massCenterY)
        {
            var analyzer = new DiscreteCentralMomentAnalyzer(this)
            {
                MassCenterX = massCenterX,
                MassCenterY = massCenterY,
                PowerX = 1,
                PowerY = 1
            };

            return GetAreaParameter(analyzer, areaNumber);
        }

        public long GetCentralMoment02(int areaNumber)
            => GetCentralMoment02(areaNumber, GetMassCenterX(areaNumber), GetMassCenterY(areaNumber));

        public long GetCentralMoment02(int areaNumber, long massCenterX, long massCenterY)
        {
            var analyzer = new DiscreteCentralMomentAnalyzer(this)
            {
                MassCenterX = massCenterX,
                MassCenterY = massCenterY,
                PowerX = 0,
                PowerY = 2
            };

            return GetAreaParameter(analyzer, areaNumber);
        }

        public long GetCentralMoment20(int areaNumber)
            => GetCentralMoment20(areaNumber, GetMassCenterX(areaNumber), GetMassCenterY(areaNumber));

        public long GetCentralMoment20(int areaNumber, long massCenterX, long massCenterY)
        {
            var analyzer = new DiscreteCentralMomentAnalyzer(this)
            {
                MassCenterX = massCenterX,
                MassCenterY = massCenterY,
                PowerX = 2,
                PowerY = 0
            };

            return GetAreaParameter(analyzer, areaNumber);
        }

        public long GetMassCenterY(int areaNumber)
            => GetMassCenterY(areaNumber, GetArea(areaNumber));

        public long GetMassCenterY(int areaNumber, long area)
        {
            var analyzer = new MassCenterAnalyzer(this)
            {
                Axis = Axis.Y
            };

            return GetAreaParameter(analyzer, areaNumber) / area;
        }

        public long GetMassCenterX(int areaNumber)
            => GetMassCenterX(areaNumber, GetArea(areaNumber));

        public long GetMassCenterX(int areaNumber, long area)
        {
            var analyzer = new MassCenterAnalyzer(this)
            {
                Axis = Axis.X
            };

            return GetAreaParameter(analyzer, areaNumber) / area;
        }

        public long GetPerimeter(int areaNumber)
            => GetAreaParameter(new PerimeterAnalyzer(this), areaNumber);

        public long GetArea(int areaNumber)
            => GetAreaParameter(new AreaAnalyzer(this), areaNumber);

        private long GetAreaParameter(Analyzer analyzer, int areaNumber)
        {
            CheckAreaNumber(areaNumber);
            return analyzer.Analyze(areaNumber);
        }

        public static ConnectedAreasSnapshot Create(BinaryImageSnapshot binarySnapshot)
        {
            if (binarySnapshot is null)
            {
                throw new ArgumentNullException(nameof(binarySnapshot));
            }

            var snapshot = new ConnectedAreasSnapshot(binarySnapshot.Width, binarySnapshot.Height);
            Initialization(binarySnapshot, snapshot);
            ExtractAreas(snapshot);
            return snapshot;
        }

        private static void Initialization(BinaryImageSnapshot binarySnapshot, ConnectedAreasSnapshot connectedSnapshot)
        {
            for (int row = 0; row < binarySnapshot.Height; ++row)
            {
                for (int column = 0; column < binarySnapshot.Width; ++column)
                {
                    connectedSnapshot[row, column] = binarySnapshot[row, column] == BinaryPixel.White ? 1 : 0;
                }
            }
        }

        private static void ExtractAreas(ConnectedAreasSnapshot snapshot)
        {
            var stack = new Stack<(int row, int column)>();
            for (int row = 0; row < snapshot.Height; ++row)
            {
                for (int column = 0; column < snapshot.Width; ++column)
                {
                    if (snapshot[row, column] == 1)
                    {
                        ++snapshot.LastAreaNumber;
                        snapshot[row, column] = snapshot.LastAreaNumber;
                        stack.Push((row, column));
                        while (stack.Any())
                        {
                            var point = stack.Pop();
                            foreach (var neighborPoint in NeighborIndexer.GetDirectNeighbors(point.column, point.row, snapshot.Width, snapshot.Height))
                            {
                                if (snapshot[neighborPoint.row, neighborPoint.column] == 1)
                                {
                                    snapshot[neighborPoint.row, neighborPoint.column] = snapshot.LastAreaNumber;
                                    stack.Push((neighborPoint.row, neighborPoint.column));
                                }
                            }
                        }
                    }
                }
            }
        }

        private void CheckAreaNumber(int areaNumber)
        {
            if (areaNumber > LastAreaNumber || areaNumber < FirstAreaNumber)
            {
                throw new ArgumentOutOfRangeException(nameof(areaNumber));
            }
        }

        private void CheckParameters(int row, int column)
        {
            if (row >= Height || row < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(row));
            }

            if (column >= Width || column < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(column));
            }
        }
    }
}

