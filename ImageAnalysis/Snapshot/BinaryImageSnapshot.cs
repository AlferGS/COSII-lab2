using System;
using System.Drawing;
using ImageMarshalling;

namespace ImageAnalysis.Snapshot
{
    public class BinaryImageSnapshot
    {
        private readonly byte brightnessGap;

        private readonly BinaryPixel[] data;

        private BinaryImageSnapshot(int width, int height, byte brightnessGap)
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
            this.brightnessGap = brightnessGap;
            data = new BinaryPixel[width * height];
        }

        public int Width { get; }

        public int Height { get; }

        public BinaryPixel this[int row, int column]
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

        public static BinaryImageSnapshot CreateFromImage(Image image, byte brightnessGap)
        {
            if (image is null)
            {
                throw new ArgumentNullException(nameof(image));
            }

            using var imageMarshal = new ImageMarshal(image);
            var snapshot = new BinaryImageSnapshot(image.Width, image.Height, brightnessGap);
            for (int row = 0; row < imageMarshal.Height; ++row)
            {
                for (int column = 0; column < imageMarshal.Width; ++column)
                {
                    var brightness = imageMarshal[row, column].GetGrayColor();
                    snapshot[row, column] = brightness > snapshot.brightnessGap ? BinaryPixel.White : BinaryPixel.Black;
                }
            }

            return snapshot;
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
