using ASE_Assignment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Action = ASE_Assignment.Action;

namespace UnitTestsProject
{
    /// <summary>
    /// This unit test class if for testing variable setting and to see if it works
    /// </summary>
    [TestClass()]
    public class VariableDeclaration
    {
        Parser parser = new Parser();

        [TestMethod()]
        public void ParseVariableDeclaration()
        {
            string input = "var x = 100\r\ncircle x";
            Dictionary<string, int> store = new Dictionary<string, int>();

            List<Command> commands = parser.Parse(input, store);

            Assert.AreEqual(Action.var, commands[0].CommandName);
            Assert.AreEqual(Action.var, commands[0].CommandName);

            Assert.AreEqual(100, store["x"]);
        }

        [TestMethod()]
        public void ParseVariableDeclarationMultiple()
        {
            string input = "var x = 100\r\nsquare x\r\nvar y = 150\r\nrectangle x y";
            Dictionary<string, int> store = new Dictionary<string, int>();

            List<Command> commands = parser.Parse(input, store);

            Assert.AreEqual(Action.var, commands[0].CommandName);
            Assert.AreEqual(Action.square, commands[1].CommandName);
            
        }

    }

    /// <summary>
    /// This Unit is for Ifconditions to see how they return true or false
    /// </summary>
    [TestClass()]
    public class IfConditionTesting
    {
        Parser parser = new Parser();

        [TestMethod()]
        public void ParseIfConditionTesting()
        {
            string input = "var x = 100\r\nifcondition x > 50\r\nsquare x\r\nendif";

            List<Command> commands = parser.Parse(input, new Dictionary<string, int>());

            // Assertions
            Assert.AreEqual(Action.var, commands[0].CommandName);
            Assert.AreEqual(Action.ifcondition, commands[1].CommandName);
            Assert.AreEqual(Action.square, commands[2].CommandName);
            Assert.AreEqual(Action.end, commands[3].CommandName);

            // does if statement return true or not
            Assert.AreEqual(true, ((IfStatementCommand)commands[1]).IfCondition);
        }

        [TestMethod()]
        public void ParseIfConditionTestingForFalse()
        {
            string input = "var x = 100\r\nifcondition x < 50\r\nsquare x\r\nendif";

            List<Command> commands = parser.Parse(input, new Dictionary<string, int>());

            Assert.AreEqual(Action.var, commands[0].CommandName);
            Assert.AreEqual(Action.ifcondition, commands[1].CommandName);
            Assert.AreEqual(Action.square, commands[2].CommandName);
            Assert.AreEqual(false, ((IfStatementCommand)commands[1]).IfCondition);
        }
    }

    /// <summary>
    /// This unit test is to test the functioning of while loops
    /// </summary>
    [TestClass()]
    public class TestWhileLoops
    {
        Parser parser = new Parser();

        [TestMethod()]
        public void ParseWhileLoops()
        {
            string input = "var x = 100\r\nwhileloop 100\r\nrectangle x\r\nend";

            List<Command> commands = parser.Parse(input, new Dictionary<string, int>());

            Assert.AreEqual(Action.var, commands[0].CommandName);
            Assert.AreEqual(Action.whileloop, commands[1].CommandName);
            Assert.AreEqual(Action.rectangle, commands[2].CommandName);
        }

        [TestMethod()]
        public void ParseWhileLoopsTestingWithVariables()
        {
            string input = "var x = 100\r\nwhileloop x\r\nrectangle x\r\nend";
            List<Command> commands = parser.Parse(input, new Dictionary<string, int>());

            Assert.AreEqual(Action.var, commands[0].CommandName);
            Assert.AreEqual(Action.whileloop, commands[1].CommandName);
            

        }
    }
}
