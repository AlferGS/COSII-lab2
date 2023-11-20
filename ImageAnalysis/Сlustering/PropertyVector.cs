using System;

namespace ImageAnalysis.Сlustering
{
    public class PropertyVector
    {
        public PropertyVector(PropertyVector vector, int classNumber)
            : this(vector.Compactness, vector.Elongation, vector.AreaNumber, classNumber)
        {
        }

        public PropertyVector(double compactness, double elongation, int areaNumber, int classNumber = 0)
        {
            Compactness = compactness;
            Elongation = elongation;
            AreaNumber = areaNumber;
            ClassNumber = classNumber;
        }

        public static bool operator ==(PropertyVector left, PropertyVector right)
            => left.ClassNumber == right.ClassNumber && left.AreaNumber == right.AreaNumber;

        public static bool operator !=(PropertyVector left, PropertyVector right)
            => !(left == right);

        public double GetRange(PropertyVector vector)
        {
            var x = vector.Compactness - this.Compactness;
            var y = vector.Elongation - this.Elongation;
            var subroot = Math.Sqrt(x * x + y * y);
            return Math.Sqrt(subroot);
        }

        public override bool Equals(object obj)
        {
            if (obj is PropertyVector vector)
            {
                return this == vector;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public int AreaNumber { get; }

        public int ClassNumber { get; set; }

        public double Compactness { get; }

        public double Elongation { get; }
    }
}
