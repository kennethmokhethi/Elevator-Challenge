using ElevatorChallenge.Models;
using ElevatorChallenge.Models.Enums;
using Xunit;

namespace ElevatorChallengeUnitTest
{

    public class ElevatorTests 
    {
       
        [Fact]
        public void Elevator_Initializes_Correctly()
        {
            Elevator elevator = new Elevator(1, 1, 10);
            Assert.Equal(1, elevator.Id);
            Assert.Equal(1, elevator.CurrentFloor);
            Assert.Equal(Direction.Idle, elevator.CurrentDirection);
            Assert.Equal(0, elevator.PeopleCount);
            Assert.Equal(10, elevator.WeightLimit);
        }


        [Fact]
        public void MoveToFloor_ChangesDirectionAndFloor()
        {
            Elevator elevator = new Elevator(1, 1, 10);
            elevator.MoveToFloor(10);

            Assert.Equal(10, elevator.CurrentFloor);
            Assert.Equal(Direction.Idle, elevator.CurrentDirection); 
        }

        [Fact]
        public void AddPeople_IncreasesPeopleCount()
        {
            Elevator elevator = new Elevator(1, 1, 10);
            elevator.AddPeople(5);

            Assert.Equal(5, elevator.PeopleCount);
        }

        [Fact]
        public void RemovePeople_DecreasesPeopleCount()
        {
            Elevator elevator = new Elevator(1, 1, 10);
            elevator.AddPeople(5);
            elevator.RemovePeople(3);

            Assert.Equal(2, elevator.PeopleCount);
        }

        [Fact]
        public void AddPeople_ExceedsWeightLimit_DoesNotIncreaseCount()
        {
            Elevator elevator = new Elevator(1, 1, 10);
            elevator.AddPeople(11);

            Assert.Equal(0, elevator.PeopleCount);
        }

        [Fact]
        public void RemovePeople_NegativePeopleCount_NotAllowed()
        {
            Elevator elevator = new Elevator(1, 1, 10);
            elevator.AddPeople(5);

            elevator.RemovePeople(6);

            Assert.Equal(5, elevator.PeopleCount);
        }

        [Fact]
        public void ToString_ReturnsExpectedString()
        {
            Elevator elevator = new Elevator(1, 1, 10);
            elevator.AddPeople(5);

            var result = elevator.ToString();

            Assert.Equal("Elevator 1 is on floor 1, direction: Idle, people: 5", result);
        }
    }
}
