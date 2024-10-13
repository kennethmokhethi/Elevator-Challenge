using System;
using System.Collections.Generic;
using System.Linq;

namespace ElevatorChallenge.Models
{
    public class Building
    {
        private List<Elevator> Elevators;
        private int TotalFloors;

        public Building(int numberOfElevators, int totalFloors, int weightLimit)
        {
            Elevators = new List<Elevator>();
            TotalFloors = totalFloors;
            for (int i = 0; i < numberOfElevators; i++)
            {
                Elevators.Add(new Elevator(i + 1, 1, weightLimit));
            }
        }

        public void ShowElevatorStatus()
        {
            foreach (var elevator in Elevators)
            {
                Console.WriteLine(elevator);
            }
        }

        public void CallElevator(int floor, int peopleWaiting)
        {
            var nearestElevator = Elevators.OrderBy(e => Math.Abs(e.CurrentFloor - floor)).FirstOrDefault();

            if (nearestElevator != null)
            {
                nearestElevator.MoveToFloor(floor);

                Console.Write($"Elevator {nearestElevator.Id} has arrived at floor {floor}. How many people are getting off? ");
                int peopleGettingOff = int.Parse(Console.ReadLine());
                nearestElevator.RemovePeople(peopleGettingOff);

                nearestElevator.AddPeople(peopleWaiting);
            }
        }
    }
}
