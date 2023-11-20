using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using ImageMarshalling;

namespace ImageProcessingTools
{
    public abstract class ImageProcessor
    {
        protected abstract void ProcessLine(ImageMarshal sourceImage, ImageMarshal resultImage, int row);

        public virtual async Task<Image> ProcessAsync(Image image)
        {
            using var sourceImage = new ImageMarshal(image);
            using var resultImage = new ImageMarshal(image);

            await ProcessImageAsync(sourceImage, resultImage);
            return resultImage.GetImage();
        }

        protected virtual async Task ProcessImageAsync(ImageMarshal sourceImage, ImageMarshal resultImage)
        {
            var tasks = new List<Task>();
            foreach (var row in this.GetRange(sourceImage.Height))
            {
                tasks.Add(ProcessLineAsync(sourceImage, resultImage, row));
            }

            await Task.WhenAll(tasks.ToArray());
        }

        protected async Task ProcessLineAsync(ImageMarshal sourceImage, ImageMarshal resultImage, int row)
        {
            await Task.Run(() =>
            {
                ProcessLine(sourceImage, resultImage, row);
            });
        }

        protected IEnumerable<int> GetRange(int count)
            => Enumerable.Range(0, count);        
    }
}
