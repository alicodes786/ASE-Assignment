using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    public class Parser
    {
        public Parser() 
        {
        
        } 

        public Parser(string input)
        {
            
        }


        public List<Command> Parse(string userInput, Dictionary<string, int> store)
        {
            // List which will have all commands
            List<Command> commands = new List<Command>();

            string[] userInputSplitLines = userInput.Split('\n');

            foreach (string line in userInputSplitLines)
            {
                string inputLine = line.ToLower();

                // Check for While loops
                if (inputLine.Trim().ToLower().Contains("while"))
                {
                    Command command = ParseWhile(inputLine);
                    commands.Add(command);

                }
            }

            return commands;
        }


        /// <summary>
        /// Parses command from Single Line Command Line - dividing the command into Command's Name and the parameters
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public CommandGenerator ParseShapeFromSingleLineCommand(string input)
        {
            input = input.ToLower();
            //Splitting the input into array of strings
            string[] inputSplit = input.ToLower().Split(' ');

            if(inputSplit.Length >= 4)
            {
                throw new ArgumentException("Parameters limit exceeded");
            }

            string stringCommandName = inputSplit[0];

            Action commandName = ParseCommandName(stringCommandName);

            if (commandName == Action.none)
            {
                throw new ArgumentException("INVALID");
            }

            if (inputSplit.Length == 1 && commandName != Action.run && commandName != Action.clear && commandName != Action.reset)
            {
                throw new ArgumentException("Error - Parameter(s) missing here");
            }


            List<string> paramsList = new List<string>();
            for(int i = 1; i < inputSplit.Length; i++)
            {
                paramsList.Add(inputSplit[i]);
            }

            string[] paramsListArray = paramsList.ToArray();

            int[] paramsArrayInNumForm = Array.ConvertAll(paramsListArray, int.Parse);

            return new CommandGenerator(commandName, paramsArrayInNumForm);

        }

        public List<CommandGenerator> ParseShapeFromMultiLineCommand(string input)
        {

            var result = input.Split("\n\r".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            List<CommandGenerator> commands = new List<CommandGenerator>();

            foreach (string s in result)
            {
                string line = s.Trim().ToLower();
                CommandGenerator command = ParseShapeFromSingleLineCommand(line);
                commands.Add(command);
            }

            return commands;

        }

        private Command ParseWhile(string input)
        {
            string[] inputSplitLines = input.Split(' ');


            // Loop count with commmandWhile
            Command command = new CommandWhileLoop(Action.whileloop, int.Parse(inputSplitLines[1]));
            return command;
        }

        private VariableCommand ParseVariable(string userInput, Dictionary<string, int> variableStore)
        {
            string[] splitVariable = userInput.Split('=');
            string expression = splitVariable[1].Trim();

            string nameOfVariable = splitVariable[0].Substring(3).Trim();

            int outcome = EvaluateExpression(variableStore, expression);


            VariableCommand commandVariable = new VariableCommand(Action.var, nameOfVariable, outcome);

            return commandVariable;
   
        }

        private int EvaluateExpression(Dictionary<string, int> variableStore, string expression)
        {
            //
            foreach(KeyValuePair<string, int> kvp in variableStore)
            {
                if (expression.Contains(kvp.Key))
                {
                    expression = expression.Replace(kvp.Key, kvp.Value.ToString());
                }
            }

            int outcome = Convert.ToInt32(new DataTable().Compute(expression, null));

            return outcome;
        }

        public Action ParseCommandName(string input)
        {
            input = input.Trim().ToLower();

            switch (input)
            {
                case "rectangle":
                    return Action.rectangle;
                case "circle":
                    return Action.circle;
                case "square":
                    return Action.square;
                case "triangle":
                    return Action.triangle;
                case "move":
                    return Action.move;
                case "drawto":
                    return Action.drawto;
                case "fill":
                    return Action.fill;
                case "reset":
                    return Action.reset;
                case "pen":
                    return Action.pen;
                case "clear":
                    return Action.clear;
                case "run":
                    return Action.run;
                default:
                    return Action.none;

            }
        }
        
    }
}
