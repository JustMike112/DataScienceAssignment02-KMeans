using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataScienceAssignment02_KMeans.Utils
{
    class Vector
    {
        private List<int> points = new List<int>();

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

        public Vector(List<int> points)
        {
            this.points = points;
        }

        public void AddPoint(int point)
        {
            points.Add(point);
        }

        public int Size()
        {
            return points.Count();
        }

        public List<int> getPoints()
        {
            return points;
        }

    }
}
