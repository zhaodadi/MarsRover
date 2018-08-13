using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class Rover
    {
        public Position CurrentPosition { get; set; }
        public Position MaxPosition { get; set; }
        public Orientation O { get; set; }
        public char[] Instructions { get; set; }

        public Rover(Position startPos, Orientation o, Position maxPosition)
        {
            CurrentPosition = startPos;
            O = o;
            MaxPosition = maxPosition;
        }

        /// <summary>
        /// Set rover's instructions
        /// </summary>
        /// <param name="instructions"></param>
        public void SetInstruction(string instructions)
        {
            Instructions = instructions.ToCharArray();
        }

        /// <summary>
        /// Explore as per instructions
        /// </summary>
        public void Explore()
        {
            foreach(var instruction in Instructions)
            {
                switch(instruction)
                {
                    case RoverInstructions.TurnLeft:
                        TurnLeft();
                        break;

                    case RoverInstructions.TurnRight:
                        TurnRight();
                        break;

                    case RoverInstructions.Move:
                        Move();
                        break;
                }
            }
        }

        /// <summary>
        /// Move One point towards current facing direction
        /// </summary>
        public void Move()
        { 
            // before move, check if rover is still inside boundry
            // ?? and also can check if rover is on top of another rover??
            switch(O)
            {
                case Orientation.N:
                    CurrentPosition.Y++;
                    break;

                case Orientation.E:
                    CurrentPosition.X++;
                    break;

                case Orientation.S:
                    CurrentPosition.Y--;
                    break;

                case Orientation.W:
                    CurrentPosition.X--;
                    break;
            }

            // dont move if outside boundry
            if (CurrentPosition.X > MaxPosition.X)
            {
                CurrentPosition.X = MaxPosition.X;
            }
            else if (CurrentPosition.X < 0)
            {
                CurrentPosition.X = 0;
            }

            if (CurrentPosition.Y > MaxPosition.Y)
            {
                CurrentPosition.Y = MaxPosition.Y;
            }
            else if (CurrentPosition.Y < 0)
            {
                CurrentPosition.Y = 0;
            }
        }

        public void TurnLeft()
        {
            O--; // turn left minus one
            O = CalculateOrientation((int)O);
        }

        public void TurnRight()
        {
            O++; // turn right plus one;
            O = CalculateOrientation((int)O);
        }

        /// <summary>
        /// Calculate rover's current orientation
        /// </summary>
        /// <param name="orientation"></param>
        /// <returns></returns>
        private Orientation CalculateOrientation(int orientation)
        {
            // if equals 0, means turn left from N, which is West, set to 4
            // see Orientation enum
            if(orientation == 0)
            {
                orientation = 4;
            }

            // if equals 5, means turn right from W, which is north, set to 1
            // see Orientation enum
            if (orientation == 5)
            {
                orientation = 1;
            }

            return (Orientation)orientation;
        }
    }
}
