using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigatorNaumen
{
    public class Point
    {
        public int x { get; private set; }
        public int y { get; private set; }
        public int weight { get; private set; }
        public bool isFinish { get; private set; }
        public bool isStart { get; private set; }

        public Point(int x, int y, int weight)
        {
            this.x = x;
            this.y = y;
            this.weight = weight;
        }
        public void IsFinish()
        {
            this.isFinish = true;
        }
        public void IsStart()
        {
            this.isStart = true;
        }
    }
}
