using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class Plateau
    {
        public Position MaxPosition { get; set; }
        public List<Rover> Rovers { get; set; }

        public Plateau(Position boundryPos)
        {
            MaxPosition = boundryPos;
            Rovers = new List<Rover>();
        }

        /// <summary>
        /// Place rover on board
        /// </summary>
        /// <param name="rover"></param>
        public void PlaceRover(Rover rover)
        {
            // maybe check if rover is inside plateau boundry before placing??
            Rovers.Add(rover);
        }

        /// <summary>
        /// Start all Rovers to explore Mars as per instructions
        /// </summary>
        public void ExecuteInstructions()
        {
            foreach(var rover in Rovers)
            {
                rover.Explore();
            }
        }

        /// <summary>
        /// Display all rovers current position
        /// </summary>
        public void DisplayPositions()
        {
            foreach (var rover in Rovers)
            {
                Console.WriteLine(rover.CurrentPosition.X + " " + rover.CurrentPosition.Y + " " + rover.O);
            }
        }
    }
}
