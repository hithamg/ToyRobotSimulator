using System;
using System.Collections.Generic;
using ToyRobot;

namespace CommandParser
{
    public class Parser : IParser
    {
        private readonly IRobot _robot;

        public Parser(IRobot robot)
        {
            _robot = robot;
        }

        public void ParseCommand(string command)
        {
            if (string.IsNullOrWhiteSpace(command))
                return;

            var commandParts = command.Split(' ');
            var action = commandParts[0];
            switch (action)
            {
                case "PLACE":
                    PlaceCommand(commandParts[1]);
                    break;
                case "MOVE":
                    _robot.Move();
                    break;
                case "LEFT":
                    _robot.Left();
                    break;
                case "RIGHT":
                    _robot.Right();
                    break;
                case "REPORT":
                    Console.WriteLine(_robot.Report());
                    break;
                default:
                    break;
            }
        }

        private void PlaceCommand(string placeCommand)
        {
           var placeCommandParts = placeCommand.Split(',');
            var x = 0;
            var y = 0;
            var direction = _robot.Current;
            if (placeCommandParts.Length >= 1)
            {
                int.TryParse(placeCommandParts[0],out x);
            }
            if (placeCommandParts.Length >= 2)
            {
                int.TryParse(placeCommandParts[1],out y);
            }
            if (placeCommandParts.Length >= 3)
            {
                direction = placeCommandParts[2];
            }
            
            _robot.Place(x, y, direction);
        }
    }
}
