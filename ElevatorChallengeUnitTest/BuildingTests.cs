using ElevatorChallenge.Models;
using System.Collections.Generic;
using System;
using Xunit;

namespace ElevatorChallengeUnitTest
{
    public class BuildingTests 
    {
        [Fact]
        public void Building_Initializes_Correctly_With_Elevators()
        {
            Building building = new Building(3, 10, 15);
            var output = new List<string>();
            var consoleOutput = new System.IO.StringWriter();
            Console.SetOut(consoleOutput);

            building.ShowElevatorStatus();

            var result = consoleOutput.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.Equal(3, result.Length);
            Assert.Contains("Elevator 1 is on floor 1", result[0]);
            Assert.Contains("Elevator 2 is on floor 1", result[1]);
            Assert.Contains("Elevator 3 is on floor 1", result[2]);
        }

        [Fact]
        public void CallElevator_MovesNearestElevator_To_CorrectFloor()
        {
            Building building = new Building(3, 10, 15);
            var consoleInput = new System.IO.StringReader("2");
            Console.SetIn(consoleInput);

            var consoleOutput = new System.IO.StringWriter();
            Console.SetOut(consoleOutput);

            building.CallElevator(5, 3);

            var output = consoleOutput.ToString();
            Assert.Contains("Elevator 1 has arrived at floor 5", output);
        }

        [Fact]
        public void CallElevator_AddsPeople_ToElevator()
        {
            Building building = new Building(3, 10, 15);
            var consoleInput = new System.IO.StringReader("0");
            Console.SetIn(consoleInput);

            building.CallElevator(3, 4);

            var consoleOutput = new System.IO.StringWriter();
            Console.SetOut(consoleOutput);

            building.ShowElevatorStatus();
            var output = consoleOutput.ToString();

            Assert.Contains("people: 4", output);
        }
    }
}
