using ImageMarshalling;
using Tools;

namespace ImageProcessingTools
{
    public class MaxFilter : ImageProcessor
    {
        protected override void ProcessLine(ImageMarshal sourceImage, ImageMarshal resultImage, int row)
        {
            foreach (var channelNumber in GetRange(sourceImage.ColorChannelsNumber))
            {
                foreach (var column in GetRange(sourceImage.Width))
                {
                    var max = sourceImage[row, column, channelNumber];
                    foreach (var neighborPoint in NeighborIndexer.GetAllNeighbors(column, row, sourceImage.Width, sourceImage.Height))
                    {
                        var neighbor = sourceImage[neighborPoint.row, neighborPoint.column, channelNumber];
                        max = neighbor > max ? neighbor : max;
                    }

                    resultImage[row, column, channelNumber] = max;
                }
            }
        }
    }
}
