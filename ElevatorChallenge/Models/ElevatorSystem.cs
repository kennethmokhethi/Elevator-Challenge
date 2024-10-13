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
            nearestElevator?.MoveToFloor(floor);
            nearestElevator?.AddPeople(peopleWaiting);
        }

        public void SetPeopleWaiting(int floor, int peopleCount)
        {
            // In this simple implementation, we just call the nearest elevator
            CallElevator(floor, peopleCount);
        }
    }
}
