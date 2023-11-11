using System;
using System.Collections.Generic;
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

        /// <summary>
        /// Parses command from Single Line Command Line - dividing the command into Command's Name and the parameters
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public Command ParseShapeFromSingleLineCommand(string input)
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

            return new Command(commandName, paramsArrayInNumForm);

        }

        public Command ParseShapeFromMultiLineCommand(string input)
        {
            input = input.ToLower();
            string[] inputSplit = input.ToLower().Split(' ');

            string stringCommandName = inputSplit[0];

            Action commandName = ParseCommandName(stringCommandName);

            List<string> paramsList = new List<string>();
            for (int i = 1; i < inputSplit.Length; i++)
            {
                paramsList.Add(inputSplit[i]);
            }

            string[] paramsListArray = paramsList.ToArray();

            int[] paramsArrayInNumForm = Array.ConvertAll(paramsListArray, int.Parse);

            return new Command(commandName, paramsArrayInNumForm);
        }

        /// <summary>
        /// This checks which command name was entered from the Enum
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

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
                case "move":
                    return Action.move;
                case "drawto":
                    return Action.drawto;
                case "fill":
                    return Action.fill;
                default:
                    return Action.none;

            }
        }
        
    }
}
