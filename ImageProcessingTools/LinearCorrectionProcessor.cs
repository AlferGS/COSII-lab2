using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageMarshalling;

namespace ImageProcessingTools
{
    public class LinearCorrectionProcessor : ImageProcessor
    {
        private readonly byte maxBoundaryBrightness;                
        private readonly byte minBoundaryBrightness;                
        private (byte min, byte max)[] channelBrightnessLimits;     

        public LinearCorrectionProcessor(byte minBoundaryBrightness, byte maxBoundaryBrightness)    
        {
            this.maxBoundaryBrightness = maxBoundaryBrightness;
            this.minBoundaryBrightness = minBoundaryBrightness;
        }

        protected override async Task ProcessImageAsync(ImageMarshal sourceImage, ImageMarshal resultImage)
        {
            await FindBrightnessLimitsAsync(sourceImage);

            var tasks = new List<Task>();
            foreach (var row in GetRange(sourceImage.Height))
            {
                tasks.Add(ProcessLineAsync(sourceImage, resultImage, row));
            }

            await Task.WhenAll(tasks.ToArray());
        }

        protected override void ProcessLine(ImageMarshal sourceImage, ImageMarshal resultImage, int row)
        {
            foreach (var channelNumber in GetRange(sourceImage.ColorChannelsNumber))
            {
                foreach (var column in GetRange(sourceImage.Width))
                {
                    var minChannelBrightness = channelBrightnessLimits[channelNumber].min;
                    var maxChannelBrightness = channelBrightnessLimits[channelNumber].max;
                    var currentChannelBrightness = sourceImage[row, column, channelNumber];
                    resultImage[row, column, channelNumber] = CalculateLinearCorrection(currentChannelBrightness, minChannelBrightness, maxChannelBrightness);
                }
            }

        }

        private byte CalculateLinearCorrection(byte currentLightness, byte minChannelBrightness, byte maxChannelBrightness)
        {
            if (maxChannelBrightness == minChannelBrightness)
            {
                return currentLightness;
            }

            return (byte)((currentLightness - minChannelBrightness) *
                (maxBoundaryBrightness - minBoundaryBrightness) /
                (maxChannelBrightness - minChannelBrightness) + minBoundaryBrightness);
        }

        private async Task FindBrightnessLimitsAsync(ImageMarshal sourceImage)
        {
            channelBrightnessLimits = new (byte min, byte max)[sourceImage.ColorChannelsNumber];
            foreach (var channelNumber in GetRange(sourceImage.ColorChannelsNumber))
            {
                var tasks = new List<Task<(byte min, byte max)>>();
                foreach (var row in GetRange(sourceImage.Height))
                {
                    tasks.Add(FindBrightnessLimitsAsyncInLineAsync(sourceImage, row, channelNumber));
                }

                var results = await Task.WhenAll(tasks.ToArray());
                channelBrightnessLimits[channelNumber] = (results.Select(r => r.min).Min(), results.Select(t => t.max).Max());
            }
        }

        private async Task<(byte min, byte max)> FindBrightnessLimitsAsyncInLineAsync(ImageMarshal sourceImage, int row, int channelNumber)
        {
            return await Task.Run(() =>
            {
                byte min = byte.MaxValue, max = byte.MinValue;
                foreach (var column in GetRange(sourceImage.Width))
                {
                    var current = sourceImage[row, column, channelNumber];
                    min = current < min ? current : min;
                    max = current > max ? current : max;
                }

                return (min, max);
            });
        }
    }
}