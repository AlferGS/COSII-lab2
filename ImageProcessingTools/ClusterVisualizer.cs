using System;
using ImageMarshalling;
using ImageAnalysis.Snapshot;

namespace ImageProcessingTools
{
    public class ClusterVisualizer : ImageProcessor
    {
        private readonly ConnectedAreasSnapshot snapshot;

        public ClusterVisualizer(ConnectedAreasSnapshot snapshot)
        {
            if (snapshot is null)
            {
                throw new ArgumentNullException(nameof(snapshot));
            }

            this.snapshot = snapshot;
        }

        protected override void ProcessLine(ImageMarshal sourceImage, ImageMarshal resultImage, int row)
        {
            foreach (var column in GetRange(sourceImage.Width))
            {
                var areaNumber = snapshot[row, column];
                if (areaNumber > 0)
                {
                    resultImage[row, column] = GetPixel(resultImage[row, column], areaNumber);
                }
            }   
        }

        private Pixel GetPixel(Pixel pixel, int areaNumber)
        {
            if (areaNumber == 2)
            {
                return new Pixel(30, pixel.Green, pixel.Blue);
            }
            if (areaNumber == 3)
            {
                return new Pixel(pixel.Red, 30, pixel.Blue);
            }
            if (areaNumber == 4)
            {
                return new Pixel(pixel.Red, pixel.Green, 30);
            }
            if (areaNumber == 5)
            {
                return new Pixel(30, 30, pixel.Blue);
            }

            return new Pixel(pixel.Red, 30, 30);
        }
    }
}
