using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Сlustering
{
    public class Point_data
    {
        public PointF Location;
        public int ClusterNum;
        public Point_data(PointF location, int cluster_num)
        {
            Location = location;
            ClusterNum = cluster_num;
        }
        public Point_data(float x, float y, int set)
            : this(new PointF(x, y), set)
        {
        }
    }
}