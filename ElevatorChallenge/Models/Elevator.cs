using ElevatorChallenge.Models.Enums;
using System;

namespace ElevatorChallenge.Models
{
    public class Elevator
    {
        public int Id { get; }
        public int CurrentFloor { get; private set; }
        public Direction CurrentDirection { get; private set; }
        public int PeopleCount { get; private set; }
        public int WeightLimit { get; }

        public Elevator(int id, int initialFloor, int weightLimit)
        {
            Id = id;
            CurrentFloor = initialFloor;
            CurrentDirection = Direction.Idle;
            PeopleCount = 0;
            WeightLimit = weightLimit;
        }

        public void MoveToFloor(int floor)
        {
            if (CurrentFloor < floor)
            {
                CurrentDirection = Direction.Up;
            }
            else if (CurrentFloor > floor)
            {
                CurrentDirection = Direction.Down;
            }
            else
            {
                CurrentDirection = Direction.Idle;
            }

            CurrentFloor = floor;
            CurrentDirection = Direction.Idle;
        }

        public void AddPeople(int count)
        {
            if (PeopleCount + count <= WeightLimit)
            {
                PeopleCount += count;
            }
            else
            {
                Console.WriteLine("Cannot add people. Weight limit exceeded.");
            }
        }

        public void RemovePeople(int count)
        {
            if (PeopleCount - count >= 0)
            {
                PeopleCount -= count;
            }
            else
            {
                Console.WriteLine("Cannot remove more people than present.");
            }
        }

        public override string ToString()
        {
            return $"Elevator {Id} is on floor {CurrentFloor}, direction: {CurrentDirection}, people: {PeopleCount}";
        }
    }
}
