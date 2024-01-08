using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

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
        private const string RegexVariables = @"^([a-zA-Z]+)\s*([a-zA-Z]+)? ?([a-zA-Z]+)?$";
        private const string RegexLoops = @"while.+";
        public List<Command> Parse(string userInput, Dictionary<string, int> store)
        {
            // List which will have all commands
            List<Command> commands = new List<Command>();

            // Splitting input into individual lines
            string[] userInputSplitLines = userInput.Split(new char[] { '\r','\n'}, StringSplitOptions.RemoveEmptyEntries);

            foreach (string line in userInputSplitLines)
            {

                string inputLine = line.ToLower();

                // Check for While loops
                if (Regex.IsMatch(inputLine.TrimEnd().ToLower(), RegexLoops))
                {
                    if (!Regex.IsMatch(inputLine.TrimEnd().ToLower(), RegexVariables))
                    {
                        Command command = ParseWhile(inputLine);
                        commands.Add(command);
                    }

                    else
                    {
                        Command command = ParseWhileWithVariables(inputLine, store);
                        commands.Add(command);
                    }



                }

                // End Commands
                else if (inputLine.Trim().ToLower().Contains("end"))
                {
                    Command command = new CommandEnd(Action.end);
                    commands.Add(command);
                }

                // Draw Shapes with Variables rectangle x or square x
                else if (Regex.IsMatch(inputLine.Trim().ToLower(), RegexVariables))
                {
                    Command command = ParseDrawShapeWithVariable(inputLine, store);
                    commands.Add(command);
                }

                // Variable Commands
                else if (inputLine.Trim().ToLower().Contains("var"))
                {
                    VariableCommand command = ParseVariable(inputLine, store);

                    if (store.ContainsKey(command.VariableName))
                    {
                        store[command.VariableName] = command.ValueOfVariable;
                    }
                    else
                    {
                        store.Add(command.VariableName, command.ValueOfVariable);
                    }
                    commands.Add(command);
                }

                // if condition commands
                else if (inputLine.Trim().ToLower().Contains("ifcondition"))
                {
                    //Search the line where if condtion ends
                    int indexStart = Array.IndexOf(userInputSplitLines, inputLine);
                    int endIndex = Array.IndexOf(userInputSplitLines, "endif");

                    bool outcome = ParseIfCondition(inputLine, store);

                    Command command = new IfStatementCommand(Action.ifcondition, outcome, indexStart, endIndex);
                    commands.Add(command);
                }

                else if (!Regex.IsMatch(inputLine.TrimEnd().ToLower(), RegexVariables))
                {
                    Command command = ParseShapeFromSingleLineCommand(inputLine);
                    commands.Add(command);
                }


                else
                {
                    throw new ArgumentException("Invalid command");
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

        private Command ParseWhileWithVariables(string input, Dictionary<string, int> store)
        {
            string[] inputSplitLines = input.Split(' ');

            Console.WriteLine(inputSplitLines);

            if (store.ContainsKey(inputSplitLines[1]))
            {
                int valueOfCount = store[inputSplitLines[1]];
                CommandWhileLoop command= new CommandWhileLoop(Action.whileloop, valueOfCount);
               
                return command;
            }

            else
            {
                throw new ArgumentException("Invalid command");
            }

            // Loop count with commmandWhile
            
        }

        private bool ParseIfCondition(string userInput, Dictionary<string, int> store)
        {
            string[] userInputArray = userInput.Split(' ');

            if (!store.ContainsKey(userInputArray[1]))
            {
                throw new ArgumentException("Invalid input");
            }

            // Check if the input is valid

            if (!int.TryParse(userInputArray[3], out int valueOfVariable))
            {
                throw new ArgumentException("Invalid Input");
            }

            if (userInputArray[2] == ">")
            {
                if (store[userInputArray[1]] > valueOfVariable)
                {
                    return true;
                }
            }
            else if (userInputArray[2] == "<")
            {
                if (store[userInputArray[1]] < valueOfVariable)
                {
                    return true;
                }
            }
            else if (userInputArray[2] == "==")
            {
                if (store[userInputArray[1]] == valueOfVariable)
                {
                    return true;
                }
            }
            else
            {
                throw new ArgumentException("Invalid Command");
            }

            return false;

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

        private CommandGenerator ParseDrawShapeWithVariable(string input, Dictionary<string, int> store)
        {
            // Split the user input into strings
            string[] userInputArray = input.Split(' ');

            if (!Enum.TryParse(userInputArray[0], true, out Action commandName))
            {
                throw new ArgumentException("Invalid input");
            }

            if (!store.ContainsKey(userInputArray[1]))
            {
                throw new ArgumentException("Invalid command");
            }

            CommandGenerator commandShape = new CommandGenerator(commandName, new int[] { store[userInputArray[1]] });
            
            if(userInputArray.Length == 3)
            {
                if (!store.ContainsKey(userInputArray[2]))
                {
                    throw new ArgumentException("Invalid command");
                }
                commandShape.CommandValues = commandShape.CommandValues.Concat(new int[] { store[userInputArray[2]] }).ToArray();
            }
            return commandShape;
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
