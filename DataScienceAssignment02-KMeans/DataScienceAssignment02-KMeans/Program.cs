using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataScienceAssignment02_KMeans.Utils;
using DataScienceAssignment02_KMeans.Algorithms;

namespace DataScienceAssignment02_KMeans
{
    class Program
    {
        static void Main(string[] args)
        {
            // Winedata contains 32 rows and 100 columns
            List<Vector> vectors = Parser.Parse(',', "Winedata.csv");
            
            Console.ReadLine();

        }
    }
}
