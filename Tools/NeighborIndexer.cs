using System.Collections.Generic;

namespace Tools
{
    public static class NeighborIndexer
    {
        public static IEnumerable<(int row, int column)> GetDirectNeighbors(int column, int row, int width, int height)
        {
            if (row > 0)
            {
                yield return (row - 1, column);
            }

            if (row < height - 1)
            {
                yield return (row + 1, column);
            }

            if (column > 0)
            {
                yield return (row, column - 1);
            }

            if (column < width - 1)
            {
                yield return (row, column + 1);
            }
        }

        public static IEnumerable<(int row, int column)> GetAllNeighbors(int column, int row, int width, int height)
        {
            int startX = -1, startY = -1, maxX = 2, maxY = 2;
            if (row == 0)
            {
                startY = 0;
            }

            if (row == height - 1)
            {
                maxY = 1;
            }

            if (column == 0)
            {
                startX = 0;
            }

            if (column == width - 1)
            {
                maxX = 1;
            }

            for (int y = startY; y < maxY; ++y)
            {
                for (int x = startX; x < maxX; ++x)
                {
                    yield return (row + y, column + x);
                }
            }
        }
    }
}
