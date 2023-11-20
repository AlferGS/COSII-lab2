using System;
using System.Collections.Generic;
using System.Linq;

namespace ImageAnalysis.Сlustering
{
    public static class Сlusterer
    {
        public static List<PropertyVector> MakeClusters(IEnumerable<PropertyVector> vectors, int clustersNumber)
        {
            var clusteredVectors = vectors.ToList();
            var previousVectors = clusteredVectors;
            var centroids = GetCentroidsPlus(vectors, clustersNumber);

            while (true)
            {
                clusteredVectors = СlassifyVectors(clusteredVectors, centroids);

                for (int i = 0; i < clustersNumber; ++i)
                {
                    var classifiedVector = clusteredVectors.Where(v => v.ClassNumber == i + 1);
                    var compactnessMax = centroids[i].Compactness;
                    var compactnessMin = centroids[i].Compactness;
                    if (classifiedVector.Select(v => v.Compactness).Any())
                    {
                        compactnessMax = classifiedVector.Select(v => v.Compactness).Max();
                        compactnessMin = classifiedVector.Select(v => v.Compactness).Min();
                    }

                    var elongationMax = centroids[i].Elongation;
                    var elongationMin = centroids[i].Elongation;
                    if (classifiedVector.Select(v => v.Compactness).Any())
                    {
                        elongationMax = classifiedVector.Select(v => v.Elongation).Max();
                        elongationMin = classifiedVector.Select(v => v.Elongation).Min();
                    }

                    centroids[i] = new PropertyVector((compactnessMax + compactnessMin) / 2, (elongationMax + elongationMin) / 2, 0, i + 1);
                }

                if (CompareLists(previousVectors, clusteredVectors))
                {
                    return clusteredVectors;
                }

                previousVectors = clusteredVectors;
            }
        }

        private static List<PropertyVector> СlassifyVectors(IEnumerable<PropertyVector> vectors, IEnumerable<PropertyVector> centroids)
        {
            var clusteredVectors = new List<PropertyVector>();
            foreach (var vector in vectors)
            {
                var classNumber = centroids.OrderBy(c => c.GetRange(vector)).First().ClassNumber;
                clusteredVectors.Add(new PropertyVector(vector, classNumber));
            }
            
            return clusteredVectors;
        }

        private static List<PropertyVector> GetCentroidsPlus(IEnumerable<PropertyVector> vectors, int clustersNumber)
        {
            var random = new Random();
            var firstCentroid = vectors.Skip(random.Next(vectors.Count() - 2)).First();
            var centroids = new List<PropertyVector>
            {
                new PropertyVector(firstCentroid, 1)
            };

            for (int clusterNumber = 2; clusterNumber <= clustersNumber; ++clusterNumber)
            {
                double sum = 0;
                foreach (var vector in vectors)
                {
                    var maxRange = centroids.Select(c => vector.GetRange(c)).Max();
                    sum += maxRange * maxRange;
                }

                var limit = random.NextDouble() * sum;
                sum = 0;
                foreach (var vector in vectors)
                {
                    var maxRange = centroids.Select(c => vector.GetRange(c)).Max();
                    sum += maxRange * maxRange;
                    if (sum > limit)
                    {
                        centroids.Add(new PropertyVector(vector, clusterNumber));
                        break;
                    }
                }

            }

            return centroids;
        }

        private static List<PropertyVector> GetCentroids(IEnumerable<PropertyVector> vectors, int clustersNumber)
        {
            var centroids = new List<PropertyVector>();
            var maxCompactness = vectors.Select(v => v.Compactness).Max();
            var maxElongation = vectors.Select(v => v.Elongation).Max();

            var random = new Random();
            for (int i = 0; i < clustersNumber; ++i)
            {
                centroids.Add(new PropertyVector(maxCompactness * random.NextDouble(), maxElongation * random.NextDouble(), 0, i + 1));
            }

            return centroids;
        }

        private static bool CompareLists(List<PropertyVector> left, List<PropertyVector> right)
        {
            for (int i = 0; i < left.Count; ++i)
            {
                if (left[i] != right[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
