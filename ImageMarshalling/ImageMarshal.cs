using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace ImageMarshalling
{
    public sealed class ImageMarshal : IDisposable
    {
        private readonly int сolumnSize;

        private readonly Bitmap bitmap;

        private readonly BitmapData bitmapData;

        public ImageMarshal(Image image)
        {
            if (image is null)
            {
                throw new ArgumentNullException(nameof(image));
            }

            bitmap = new Bitmap(image);
            bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, bitmap.PixelFormat);
            Height = bitmapData.Height;
            Width = bitmapData.Width;
            сolumnSize = bitmapData.Stride / bitmapData.Width;

            var pixelSizeInBits = Image.GetPixelFormatSize(bitmap.PixelFormat);
            var channelSizeInBits = GetChannelSizeInBits(bitmap.PixelFormat);
            var channelNumber = pixelSizeInBits / channelSizeInBits;
            ColorChannelsNumber = Image.IsAlphaPixelFormat(bitmap.PixelFormat) ? channelNumber - 1 : channelNumber;
        }

        public int Width { get; }

        public int Height { get; }

        public byte this[int row, int column, int channel]
        {
            get
            {
                CheckParameters(row, column);
                unsafe
                {
                    var pointer = (byte*)(bitmapData.Scan0 + (row * bitmapData.Stride) + column * сolumnSize + channel);
                    return pointer[0];
                }
            }
            set
            {
                CheckParameters(row, column);
                unsafe
                {
                    var pointer = (byte*)(bitmapData.Scan0 + (row * bitmapData.Stride) + column * сolumnSize + channel);
                    pointer[0] = value;
                }
            }
        }

        public Pixel this[int row, int column]
        {
            get
            {
                CheckParameters(row, column);
                unsafe
                {
                    var pointer = (byte*)bitmapData.Scan0 + (row * bitmapData.Stride) + column * сolumnSize;
                    return new Pixel(pointer[0], pointer[1], pointer[2]);
                }
            }
            set
            {
                CheckParameters(row, column);
                unsafe
                {
                    var pointer = (byte*)bitmapData.Scan0 + (row * bitmapData.Stride) + column * сolumnSize;
                    pointer[0] = value.Red;
                    pointer[1] = value.Green;
                    pointer[2] = value.Blue;
                }
            }
        }

        public Image GetImage()
            => Image.FromHbitmap(bitmap.GetHbitmap());

        public void Dispose()
        {
            bitmap.UnlockBits(bitmapData);
            bitmap.Dispose();
        }

        public int ColorChannelsNumber { get; }

        private int GetChannelSizeInBits(PixelFormat format)
            => Image.IsExtendedPixelFormat(format) ? 16 : 8;

        private void CheckParameters(int row, int column)
        {
            if (row >= Height || row < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(row));
            }

            if (column >= Width || row < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(column));
            }
        }
    }
}
