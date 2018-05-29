using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataScienceAssignment02_KMeans.Utils;

namespace DataScienceAssignment02_KMeans.Algorithms
{
    class KMeans
    {
        int iterations;
        int clusters;
        double SSE;
        List<Vector> vectors;
        List<Vector> centroids;
        Euclidean euclidean = new Euclidean();

        public KMeans(int iterations, int clusters, List<Vector> vectors)
        {
            this.iterations = iterations;
            this.clusters = clusters;
            this.vectors = vectors;
            centroids = new List<Vector>();
        }

        /* Main loop:
        Initialize Centroids -> ((FOR) Assign each point to nearest Centroid -> Recompute Centroids -> Check if Loop should be terminated)  */
        public void MainLoop()
        {
            // Step 1: Generate Centroids
            GenerateCentroids(clusters);

            for (var i = 0; i < iterations; i++)
            {
                var oldCentroids = centroids;

                // Step 2: Assign each point to nearest Centroid
                foreach (var vector in vectors)
                {
                    AssignToCentroid(vector);
                }

                // Step 3: Recompute Centroids
                RecomputeCentroids();

                // Step 4: Check if loop should be terminated
                if (HaveCentroidsStopped(oldCentroids))
                {
                    Console.WriteLine("Computation complete in " + i + " iterations");
                    break;
                }
            }
        }

        // Generate a list of initial clusters
        private void GenerateCentroids(int clusters)
        {
            for (int i = 0; i < clusters; i++)
            {
                centroids.Add(RandomVector());
            }
        }

        // Create Random Vector (for centroid generation)
        private Vector RandomVector()
        {
            var randomVector = new Vector();
            while (true)
            {
                randomVector = vectors[new Random().Next(vectors.Count())];
                if (!centroids.Contains(randomVector))
                {
                    break;
                }
            }
            return randomVector;
        }

        // Assign Point to Centroid
        private void AssignToCentroid(Vector point)
        {
            double distance = int.MaxValue;
            for (int i = 0; i < centroids.Count(); i++)
            {
                double distanceNew = euclidean.getDistance(centroids[i], point);
                if (distanceNew < distance)
                {
                    distance = distanceNew;
                    point.centroid = i;
                }
            }
        }

        // Recompute the centroids
        private void RecomputeCentroids()
        {
            for (int i = 0; i < clusters; i++)
            {
                var clusterSet = vectors.Where(vector => vector.centroid == i).ToList();
                var newCluster = new Vector(vectors.First().Size());
                newCluster = SumCluster(newCluster, clusterSet);
                newCluster = DivideCluster(newCluster, clusterSet.Count());
                centroids[i] = newCluster;
            }
        }

        // Check if centroids have stopped changing
        private bool HaveCentroidsStopped(List<Vector> oldCentroids)
        {
            var haveCentroidsStopped = false;

            //if (ComputeSSE() == SSE)
            //{
            //    haveCentroidsStopped = true;
            //}
            //return haveCentroidsStopped;

            //Compare old centroids list with new centroid list and check if there are changes
            //for (int i = 0; i < centroids.Count(); i++)
            //{
            //    if (centroids[i].points.SequenceEqual(oldCentroids[i].points))
            //    {
            //        haveCentroidsStopped = true;
            //    }
            //}
            if (centroids.Except(oldCentroids).ToList() == centroids)
            {
                haveCentroidsStopped = true;
            }

            return haveCentroidsStopped;
        }

        // Return the SSE
        private double ComputeSSE()
        {
            for (int i = 0; i < clusters; i++)
            {
                var clusterSet = vectors.Where(vector => vector.centroid == i).ToList();

                foreach (var vector in clusterSet)
                {
                    SSE += Math.Pow(euclidean.getDistance(centroids[i], vector), 2);
                }
            }
            return SSE;
        }

        // get a vector containing the sum of all vectors in a cluster
        public Vector SumCluster(Vector cluster, List<Vector> clusterSet)
        {
            for (int i = 0; i < clusterSet.Count(); i++)
                for (int j = 0; j < cluster.points.Count(); j++)
                    cluster.points[j] += clusterSet[i].points[j];

            return cluster;
        }

        // Divide the sum of all points in a cluster by the amount of vectors
        public Vector DivideCluster(Vector cluster, int clusterSize)
        {
            for (int i = 0; i < cluster.points.Count(); i++)
            {
                if (clusterSize <= 0)
                    break;

                cluster.points[i] /= clusterSize;
            }
            return cluster;
        }

        public void PrintResults()
        {
            Console.WriteLine("K-Means Results:");
            Console.WriteLine("Dataset size: " + vectors.Count() + " items, " + vectors.First().Size() + " dimensions");
            Console.WriteLine("Amount of selected iterations: " + iterations);
            Console.WriteLine("Amount of selected clusters: " + clusters);
            Console.WriteLine("SSE: " + ComputeSSE());

            Console.WriteLine("");

            for (int i = 0; i < centroids.Count(); i++)
            {
                var clusterSet = vectors.Where(vector => vector.centroid == i).ToList();
                var newCluster = SumCluster(new Vector(vectors.First().Size()), clusterSet);
                var newClusterDictionary = newCluster.points.Select((value, index) => new { value, index }).ToDictionary(x => x.index, x => x.value);
                var orderedCluster = newClusterDictionary.OrderByDescending(x => x.Value);

                Console.WriteLine("Cluster " + (i + 1) + " contains " + clusterSet.Count() + " customers");
                Console.WriteLine("-------------------------------------------");

                foreach (var vector in orderedCluster)
                {
                    if (vector.Value > 0)
                    {
                        Console.Write("Wine " + (vector.Key + 1) + " was purchased " + vector.Value);
                        if (vector.Value == 1)
                            Console.WriteLine(" time");
                        else
                            Console.WriteLine(" times");
                    }
                }
                Console.WriteLine("");
            }
            Console.SetCursorPosition(0, 0);
            Console.ReadKey(true);

        }
    }
}
