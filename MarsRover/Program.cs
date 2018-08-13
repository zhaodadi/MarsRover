using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            string boundry;
            string roverPos;
            Orientation roverO;
            string roverInstruction;

            // assuming all data entered are valid

            Console.WriteLine("Please enter upper right coordinates");
            boundry = Console.ReadLine();
            Plateau plateau = new Plateau(new Position(boundry));

            Console.WriteLine("Please enter first Rover's position");
            roverPos = Console.ReadLine();
            roverO = (Orientation)Enum.Parse(typeof(Orientation), roverPos.Split(' ')[2]);
            Rover roverA = new Rover(new Position(roverPos), roverO, plateau.MaxPosition);
            plateau.PlaceRover(roverA);

            Console.WriteLine("Please enter first Rover's instructions");
            roverInstruction = Console.ReadLine();
            roverA.SetInstruction(roverInstruction);

            Console.WriteLine("Please enter second Rover's position");
            roverPos = Console.ReadLine();
            roverO = (Orientation)Enum.Parse(typeof(Orientation), roverPos.Split(' ')[2]);
            Rover roverB = new Rover(new Position(roverPos), roverO, plateau.MaxPosition);
            plateau.PlaceRover(roverB);

            Console.WriteLine("Please enter second Rover's instructions");
            roverInstruction = Console.ReadLine();
            roverB.SetInstruction(roverInstruction);

            plateau.ExecuteInstructions(); // start exploring

            Console.WriteLine("Final positions of rovers are:");
            plateau.DisplayPositions();

            Console.ReadLine();
        }
    }
}
