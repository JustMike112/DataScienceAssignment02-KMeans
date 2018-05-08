using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataScienceAssignment02_KMeans.Utils
{
    static class Parser
    {
        public static List<Vector> Parse(char delimiter, string path)
        {
            List<Vector> vectors = new List<Vector>();
            var result = File.ReadAllLines(path).Select(
                    line => line.Split(delimiter)
                            .Select(int.Parse).ToList())
                    .ToList();

            // Loop through all rows and columns
            for (var i = 0; i < result.Count; i++)
            {
                for (var j = 0; j < result[i].Count; j++)
                {
                    if (vectors.ElementAtOrDefault(j) == null)
                        vectors.Add(new Vector());

                    vectors[j].AddPoint(result[i][j]);
                }
            }

            return vectors;
        }
        
    }
}
