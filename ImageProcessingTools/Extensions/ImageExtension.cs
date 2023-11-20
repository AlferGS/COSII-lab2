using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using ImageMarshalling;
using ImageAnalysis.Snapshot;

namespace ImageProcessingTools.Extensions
{
    public static class ImageExtension
    {
        public static List<int> GetBrightnessLevels(this Image image, int channelNumber)
        {
            using var sourceImage = new ImageMarshal(image);
            var result = new int[256];
            for (int row = 0; row < sourceImage.Height; ++row)
            {
                for (int column = 0; column < sourceImage.Width; ++column)
                {
                    var brightness = sourceImage[row, column, channelNumber];
                    ++result[brightness];
                }
            }

            return result.ToList();
        }

        public static List<int> GetBrightnessLevels(this Image image)
        {
            using var sourceImage = new ImageMarshal(image);
            var result = new int[256];
            for (int row = 0; row < sourceImage.Height; ++row)
            {
                for (int column = 0; column < sourceImage.Width; ++column)
                {
                    var brightness = sourceImage[row, column].GetGrayColor();
                    ++result[brightness];
                }
            }

            return result.ToList();
        }

        public static byte GetBinaryThreshold(this Image image)
        {
            var brightnessLevels = image.GetBrightnessLevels();

            int m = 0;
            int n = 0;
            for (int i = 0; i < brightnessLevels.Count; ++i)
            {
                m += i * brightnessLevels[i];
                n += brightnessLevels[i];
            }

            var threshold = 0;
            double maxSigma = -1;
            int alpha1 = 0;
            int beta1 = 0;

            for (int i = 0; i < brightnessLevels.Count; ++i)
            {
                alpha1 += i * brightnessLevels[i];
                beta1 += brightnessLevels[i];

                var w1 = (double)beta1 / n;
                var a = (double)alpha1 / beta1 - (double)(m - alpha1) / (n - beta1);
                var sigma = w1 * (1 - w1) * a * a;

                if (sigma > maxSigma)
                {
                    maxSigma = sigma;
                    threshold = i;
                }
            }

            return (byte)threshold;
        }

        public async static Task<Image> MinFilterAsync(this Image image)
            => await new MinFilter().ProcessAsync(image);

        public async static Task<Image> MaxFilterAsync(this Image image)
            => await new MaxFilter().ProcessAsync(image);

        public async static Task<Image> LinearContrasting(this Image image, byte min, byte max)
           => await new LinearCorrectionProcessor(min, max).ProcessAsync(image);

        public async static Task<Image> MinMaxFilterAsync(this Image image)
        {
            var result = image;
            result = await result.MinFilterAsync();
            result = await result.MaxFilterAsync();
            return result;
        }

        public async static Task<Image> VisualizeClusterAsync(this Image image, ConnectedAreasSnapshot snapshot)
            => await new ClusterVisualizer(snapshot).ProcessAsync(image);

        public async static Task<Image> BinorizeAsync(this Image image)
            => await new Binorizer(image.GetBinaryThreshold()).ProcessAsync(image);
    }
}
