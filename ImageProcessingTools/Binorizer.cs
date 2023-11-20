using ImageMarshalling;

namespace ImageProcessingTools
{
    public class Binorizer : ImageProcessor
    {
        private readonly byte limit;

        public Binorizer(byte limit)
        {
            this.limit = limit;
        }

        protected override void ProcessLine(ImageMarshal sourceImage, ImageMarshal resultImage, int row)
        {
            foreach (var column in this.GetRange(sourceImage.Width))
            {
                var color = sourceImage[row, column].GetGrayColor();
                color = color > limit ? byte.MaxValue : byte.MinValue;
                resultImage[row, column] = new Pixel(color);
            }
        }
    }
}
