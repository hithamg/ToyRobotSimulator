using System;

namespace ToyRobot
{
    public class Robot : IRobot
    {
        private int x;
        private int y;
        private string direction="South";
        private bool isPlaced;

        string IRobot.Current { get => this.direction; }

        public void Place(int x, int y, string direction)
        {
            if (x >= 0 && x <= 5 && y >= 0 && y <= 5)
            {
                this.x = x;
                this.y = y;
                this.direction = direction;
                isPlaced = true;
            }
        }

        public void Move()
        {
            if (!isPlaced) return;

            switch (direction)
            {
                case "NORTH":
                    if (y < 5) y++;
                    break;
                case "SOUTH":
                    if (y > 0) y--;
                    break;
                case "EAST":
                    if (x < 5) x++;
                    break;
                case "WEST":
                    if (x > 0) x--;
                    break;
            }
        }

        public void Left()
        {
            if (!isPlaced) return;

            switch (direction)
            {
                case "NORTH":
                    direction = "WEST";
                    break;
                case "SOUTH":
                    direction = "EAST";
                    break;
                case "EAST":
                    direction = "NORTH";
                    break;
                case "WEST":
                    direction = "SOUTH";
                    break;
            }
        }

        public void Right()
        {
            if (!isPlaced) return;

            switch (direction)
            {
                case "NORTH":
                    direction = "EAST";
                    break;
                case "SOUTH":
                    direction = "WEST";
                    break;
                case "EAST":
                    direction = "SOUTH";
                    break;
                case "WEST":
                    direction = "NORTH";
                    break;
            }
        }

        public string Report()
        {
            if (!isPlaced) return "Robot is not placed on the table.";
            return $"{x},{y},{direction}";
        }
    }
}
