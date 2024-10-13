using ElevatorChallenge.Models;
using System;

namespace ElevatorChallenge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of elevators in the building");
            int numberOfElevators = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the total number of floors for the buiding");
            int totalFloors = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the weight limit of each elevator");
            int weightLimit = int.Parse(Console.ReadLine()); // weight limit defined by the number of individuals.

            Building building = new Building(numberOfElevators, totalFloors, weightLimit);

            while (true)
            {
                Console.WriteLine("Elevator Challenge");
                Console.WriteLine("1. Show elevator status");
                Console.WriteLine("2. Call elevator to a floor");
                Console.WriteLine("3. Exit");
                Console.Write("Choose an option: ");
                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        building.ShowElevatorStatus();
                        break;
                    case 2:
                        Console.Write("Enter floor number:");
                        int floor = int.Parse(Console.ReadLine());
                        Console.Write("Enter number of people waiting:");
                        int peopleCount = int.Parse(Console.ReadLine());
                        building.CallElevator(floor, peopleCount);
                        break;
                    case 3:
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}
