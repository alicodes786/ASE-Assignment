using ASE_Assignment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace UnitTestsProject
{
    [TestClass()]
    public class TestShapes
    {
        private readonly Parser parser = new Parser();

        [TestMethod]
        public void CommandsWorkingOnSingleCommandLine()
        {
            // test data
            string input = "rectangle 100 150";

            // command
            Command command = parser.ParseShapeFromSingleLineCommand(input);

            //assertion
            Assert.AreEqual(Action.rectangle, command.CommandName);
            Assert.IsNotNull(command);
            
        }

        [TestMethod]

        public void ParseInputDrawShapeWithCapitalCase() 
        {   
            // test data
            string inputRect = "RECTANGLE 100 100";

            Command command = parser.ParseShapeFromSingleLineCommand(inputRect);
            
            // Assert
            Assert.AreEqual(Action.rectangle, command.CommandName);
            Assert.IsNotNull(command);
            Assert.AreNotEqual(Action.circle, command.CommandName);
        }

        [TestMethod]

        public void ParseInputDrawShapeWithDifferentCases()
        {
            string inputRect = "ReCTaNgle 50 100";

            Command command = parser.ParseShapeFromSingleLineCommand(inputRect);

            Assert.AreEqual(Action.rectangle, command.CommandName);
            Assert.IsNotNull(command);
            Assert.AreNotEqual(Action.circle, command.CommandName);
        }

        [TestMethod]
        public void checkParametersOfRectangle()
        {
            string inputRect = "rectangle 100 200";

            Command command = parser.ParseShapeFromSingleLineCommand(inputRect);

            Assert.AreEqual (Action.rectangle, command.CommandName);
            Assert.IsNotNull(command);
            Assert.AreEqual(100, command.CommandValues[0]);
            Assert.AreEqual(200, command.CommandValues[1]);
            Assert.AreNotEqual(120, command.CommandValues[0]);
        }


    }

    [TestClass()]

    public class TestShape_Circle
    {
        private readonly Parser parser = new Parser();
        [TestMethod]

        public void ParseInputCheckCommandWorkingForCircle()
        {
            string inputCircle = "circle 50";

            Command command = parser.ParseShapeFromSingleLineCommand(inputCircle);

            // Assertions
            Assert.IsTrue(command != null);
            Assert.AreEqual(Action.circle, command.CommandName);
            
        }

        [TestMethod]
        public void ParseInputCheckCommandParametersForCircle()
        {
            string inputCircle = "circle 50 100";

            Command command = parser.ParseShapeFromSingleLineCommand(inputCircle);
            
            Assert.IsTrue(command != null);
            Assert.AreEqual(Action.circle, command.CommandName);
            Assert.AreEqual(50, command.CommandValues[0]);
            Assert.AreEqual(100, command.CommandValues[1]);
        }

        [TestMethod]

        public void ParseInputCheckCommandWithCapitalCase()
        {
            string inputCircle = "CIRCLE 50 100";

            Command command = parser.ParseShapeFromSingleLineCommand(inputCircle);

            Assert.IsTrue(command != null);
            Assert.AreEqual(Action.circle, command.CommandName);
        }

        [TestMethod]
        public void ParseInputCheckCommandWithDifferentCases()
        {
            string inputCircle = "cIRcLe 50 100";

            Command command = parser.ParseShapeFromSingleLineCommand(inputCircle);

            Assert.IsTrue(command != null);
            Assert.AreEqual(Action.circle, command.CommandName);
        }
    }

    [TestClass()]
    public class TestSquares
    {
        private readonly Parser parser = new Parser();
        [TestMethod]
        public void ParseSquares() 
        {
            string inputSquare = "square";

            Action command = parser.ParseCommandName(inputSquare);

            Assert.AreEqual(Action.square, command);
            

        }

        [TestMethod]
        public void ParseSquaresWithCapitalCase()
        {
            string inputSquare = "SQUARE 50";

            Command command = parser.ParseShapeFromSingleLineCommand(inputSquare);
            Assert.IsTrue(command != null);
            Assert.AreEqual(Action.square, command.CommandName);
        }

        [TestMethod]
        public void ParseSquaresWithDifferentCases()
        {
            string inputSquare = "sQUaRe 50";

            Command command = parser.ParseShapeFromSingleLineCommand(inputSquare);
            Assert.IsTrue(command != null);
            Assert.AreEqual(Action.square, command.CommandName);
        }


        [TestMethod]
        public void ParseSquaresCheckParameter()
        {
            string inputSquare = "square 50";

            Command command = parser.ParseShapeFromSingleLineCommand(inputSquare);
            Assert.IsTrue(command != null);
            Assert.AreEqual(Action.square, command.CommandName);
            Assert.AreEqual(50, command.CommandValues[0]);
        }

    }

    [TestClass]
    public class TestTriangles 
    {
        private readonly Parser parser = new Parser();

        [TestMethod]
        public void ParseTrianglesWorkingCommand()
        {
            string input = "triangle 150";

            Command command = parser.ParseShapeFromSingleLineCommand(input);

            //assert

            Assert.IsTrue(command != null);
            Assert.AreEqual(Action.triangle, command.CommandName);
        }


        [TestMethod]
        public void ParseTrianglesCommandWithDifferentCases()
        {
            string input = "TriANgLe 150";

            Command command = parser.ParseShapeFromSingleLineCommand(input);

            //assert

            Assert.IsTrue(command != null);
            Assert.AreEqual(Action.triangle, command.CommandName);
            Assert.AreNotEqual(Action.circle, command.CommandName);

        }

        [TestMethod]
        public void ParseTrianglesCheckParameters()
        {
            string input = "triangle 100";

            Command command = parser.ParseShapeFromSingleLineCommand(input);

            //assert

            Assert.IsTrue(command != null);
            Assert.AreEqual(Action.triangle, command.CommandName);
            Assert.AreEqual(100, command.CommandValues[0]);
            Assert.AreNotEqual(120, command.CommandValues[0]);
        }
    }

    [TestClass()]

    public class TestLines
    {
        private readonly Parser parser = new Parser();

        [TestMethod]
        public void ParseLinesCommand()
        {
            string inputLinePoints = "drawto 100 140";

            Command command = parser.ParseShapeFromSingleLineCommand(inputLinePoints);
            Assert.IsTrue(command != null);
            Assert.AreEqual(Action.drawto, command.CommandName);
            Assert.AreNotEqual(Action.circle, command.CommandName);
        }

        [TestMethod]
        public void ParseLinesCommandWithDifferentCases()
        {
            string inputLinePoints = "dRaWTo 100 140";

            Command command = parser.ParseShapeFromSingleLineCommand(inputLinePoints);
            Assert.IsTrue(command != null);
            Assert.AreEqual(Action.drawto, command.CommandName);
            Assert.AreNotEqual(Action.circle, command.CommandName);
        }

        [TestMethod]
        public void ParseLinesCommandCheckParameters()
        {
            string inputLinePoints = "drawto 100 140";

            Command command = parser.ParseShapeFromSingleLineCommand(inputLinePoints);
            Assert.IsTrue(command != null);
            Assert.AreEqual(Action.drawto, command.CommandName);
            Assert.AreEqual(100, command.CommandValues[0]);
            Assert.AreEqual(140, command.CommandValues[1]);
            Assert.AreNotEqual(Action.circle, command.CommandName);
        }
    }

    [TestClass()]
    public class TestMoveToFunction
    {
        private readonly Parser parser = new Parser();

        [TestMethod]
        public void ParseMoveToFunction()
        {
            string inputMove = "move 100 120";

            Command command = parser.ParseShapeFromSingleLineCommand(inputMove);
            Assert.IsTrue(command != null);
            Assert.AreEqual(Action.move, command.CommandName);
        }

        [TestMethod]
        public void ParseMoveToCheckParameters()
        {
            string inputMove = "move 100 120";

            Command command = parser.ParseShapeFromSingleLineCommand(inputMove);
            Assert.IsTrue(command != null);
            Assert.AreEqual(Action.move, command.CommandName);
            Assert.AreEqual(100, command.CommandValues[0]);
        }
    }

    [TestClass()]
    public class ColorOfPen
    {
        private readonly Parser parser = new Parser();

        [TestMethod]
        public void ParseColorOfPen()
        {
            string input = "pen 2";

            Command command = parser.ParseShapeFromSingleLineCommand(input);

            Assert.IsTrue(command != null);
            
        }
    }

    [TestClass()]
    public class Clear
    {
        private readonly Parser parser = new Parser();

        [TestMethod]
        public void ParseClear()
        {
            string input = "clear";

            Command command = parser.ParseShapeFromSingleLineCommand(input);

            Assert.IsTrue(command != null);
            
        }
    }

    [TestClass()]
    public class Reset
    {
        private readonly Parser parser = new Parser();

        [TestMethod]
        public void ParseReset()
        {
            string input = "reset";

            Command command = parser.ParseShapeFromSingleLineCommand(input);

            Assert.IsTrue(command != null);

        }
    }

    [TestClass()]
    public class FillCommand
    {
        private readonly Parser parser = new Parser();

        [TestMethod]
        public void ParseFillCommand()
        {
            string input = "fill 1";

            Command command = parser.ParseShapeFromSingleLineCommand(input);

            Assert.IsTrue(command != null);
            Assert.AreEqual(Action.fill, command.CommandName);
            Assert.AreEqual(1, command.CommandValues[0]);

        }
    }





}
