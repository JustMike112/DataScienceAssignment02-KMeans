using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataScienceAssignment02_KMeans.Utils
{
    class Vector
    {
        public List<float> points = new List<float>();
        public int centroid;

        public Vector()
        {
        }

        public Vector(int size)
        {
            for (int i = 0; i < size; i++)
            {
                points.Add(0);
            }
        }

        public Vector(List<float> points)
        {
            this.points = points;
        }

        public void AddPoint(float point)
        {
            points.Add(point);
        }

        public int Size()
        {
            return points.Count();
        }
    }
}
