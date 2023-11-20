using Tools;
using ImageMarshalling;

namespace ImageProcessingTools
{
    public class MinFilter : ImageProcessor
    {
        protected override void ProcessLine(ImageMarshal sourceImage, ImageMarshal resultImage, int row)
        {
            foreach (var channelNumber in GetRange(sourceImage.ColorChannelsNumber))
            {
                foreach (var column in GetRange(sourceImage.Width))
                {
                    var min = sourceImage[row, column, channelNumber];
                    foreach (var neighborPoint in NeighborIndexer.GetAllNeighbors(column, row, sourceImage.Width, sourceImage.Height))
                    {
                        var neighbor = sourceImage[neighborPoint.row, neighborPoint.column, channelNumber];
                        min = neighbor < min ? neighbor : min;
                    }

                    resultImage[row, column, channelNumber] = min;
                }
            }
        }
    }
}
