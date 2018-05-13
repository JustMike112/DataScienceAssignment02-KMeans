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
                var oldCentroids = new List<Vector>(centroids);

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

        }

        // Recompute the centroids
        private void RecomputeCentroids()
        {

        }

        // Check if centroids have stopped changing
        private bool HaveCentroidsStopped(List<Vector> oldCentroids)
        {
            var hasCentroidsStopped = false;

            // Compare old centroids list with new centroid list and check if there are changes

            return hasCentroidsStopped;
        }

        // Return the SSE
        private double ComputeSSE()
        {
            return SSE;
        }

    }
}
