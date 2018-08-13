using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Position(string posStr)
        {
            string[] aPos = posStr.Split(' ');

            X = Convert.ToInt32(aPos[0]);
            Y = Convert.ToInt32(aPos[1]);
        }
    }
}
