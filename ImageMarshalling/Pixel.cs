namespace ImageMarshalling
{
    public struct Pixel
    {
        public Pixel(byte brightness)
            : this(brightness, brightness, brightness)
        {
        }

        public Pixel(byte red, byte green, byte blue)
        {
            Red = red;
            Green = green;
            Blue = blue;
        }

        public byte Red { get; }

        public byte Green { get; }

        public byte Blue { get; }

        public static bool operator ==(Pixel left, int right)
            => left.Red == right && left.Green == right && left.Blue == right;

        public static bool operator !=(Pixel left, int right)
            => !(left == right);

        public static bool operator ==(Pixel left, Pixel right)
            => left.Red == right.Red && left.Green == right.Green && left.Blue == right.Blue;

        public static bool operator !=(Pixel left, Pixel right)
            => !(left == right);

        public override bool Equals(object obj)
        {
            if (obj is Pixel pixel)
            {
                return this == pixel;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return $"{Red}; {Green}; {Blue}";
        }

        public byte GetGrayColor()
            => (byte)(0.3 * Red + 0.59 * Green + 0.11 * Blue);
    }
}
