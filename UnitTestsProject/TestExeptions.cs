using ASE_Assignment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTestsProject
{
    [TestClass]
    public class TestExeptions
    {
        private readonly Parser parser = new Parser();

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InvalidCommandPassed()
        {
            string input = "INVALID";

            parser.ParseShapeFromSingleLineCommand(input);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Too many parameters")]
        public void TooManyParametersPassed()
        {
            string input = "rectangle 100 120 150";

            parser.ParseShapeFromSingleLineCommand(input);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MissingParametersTest()
        {
            string input = "circle";

            parser.ParseShapeFromSingleLineCommand(input);

        }
    }
}
