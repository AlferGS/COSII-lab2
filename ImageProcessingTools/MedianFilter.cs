using System.Linq;
using System.Collections.Generic;
using ImageMarshalling;
using Tools;

namespace ImageProcessingTools
{
    public class MedianFilter : ImageProcessor
    {
        protected override void ProcessLine(ImageMarshal sourceImage, ImageMarshal resultImage, int row)
        {
            foreach (var channelNumber in GetRange(sourceImage.ColorChannelsNumber))
            {
                foreach (var column in GetRange(sourceImage.Width))
                {
                    var neighborValues = new List<byte>();
                    foreach (var neighborPoint in NeighborIndexer.GetAllNeighbors(column, row, sourceImage.Width, sourceImage.Height))
                    {
                        neighborValues.Add(sourceImage[neighborPoint.row, neighborPoint.column, channelNumber]);
                    }

                    resultImage[row, column, channelNumber] = neighborValues.OrderBy(n => n).Skip(neighborValues.Count / 2).First();
                }
            }
        }
    }
}
