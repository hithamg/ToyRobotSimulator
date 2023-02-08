using System;

namespace ToyRobot
{
    public interface IRobot
    {
        void Place(int x, int y, string direction);
        void Move();
        void Left();
        void Right();
        string Report();
        public string Current { get; }
    }
}
