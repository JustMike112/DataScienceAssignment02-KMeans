using DataScienceAssignment02_KMeans.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataScienceAssignment02_KMeans.Algorithms
{
    class Euclidean
    {
        /* Euclidian formula : d(p,q) = sqrt(pow(p1-q1)+pow(pn-qn)) */

        public double getDistance(Vector user1, Vector user2)
        {
            var length = user1.Size();
            var total = 0.0;

            for (var i = 0; i < length; i++)
                total += Math.Pow(user1.points[i] - user2.points[i], 2);

            return Math.Sqrt(total);
        }


    }
}
