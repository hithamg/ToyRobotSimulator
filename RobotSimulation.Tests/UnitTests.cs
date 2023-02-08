using System;
using CommandParser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobot;

namespace RobotSimulation.Tests
{
    [TestClass]
    public class CommandParserTests
    {
        private IParser _commandParser;
        private IRobot _robot;

        [TestInitialize]
        public void TestInitialize()
        {
            _robot = new Robot();
            _commandParser = new Parser(_robot);
        }

        [TestMethod]
        public void TestCaseA()
        {
            var commands = new string[] { "PLACE 0,0,NORTH", "MOVE", "REPORT" };

            foreach (var command in commands)
            {
                _commandParser.ParseCommand(command);
            }

            Assert.AreEqual("0,1,NORTH", _robot.Report());
        }

        [TestMethod]
        public void TestCaseB()
        {
            var commands = new string[] { "PLACE 0,0,NORTH", "LEFT", "REPORT" };

            foreach (var command in commands)
            {
                _commandParser.ParseCommand(command);
            }

            Assert.AreEqual("0,0,WEST", _robot.Report());
        }

        [TestMethod]
        public void TestCaseC()
        {
            var commands = new string[] { "PLACE 1,2,EAST", "MOVE", "MOVE", "LEFT", "MOVE", "REPORT" };

            foreach (var command in commands)
            {
                _commandParser.ParseCommand(command);
            }

            Assert.AreEqual("3,3,NORTH", _robot.Report());
        }

        [TestMethod]
        public void TestCaseD()
        {
            var commands = new string[] { "PLACE 1,2,EAST", "MOVE", "LEFT", "MOVE", "PLACE 3,1", "MOVE", "REPORT" };

            foreach (var command in commands)
            {
                _commandParser.ParseCommand(command);
            }

            Assert.AreEqual("3,2,NORTH", _robot.Report());
        }
    }
}
