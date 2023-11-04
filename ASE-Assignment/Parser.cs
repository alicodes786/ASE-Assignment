﻿using System;
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

        public Command ParseShapeFromSingleLineCommand(string input)
        {

            input = input.ToLower();
            string[] inputSplit = input.ToLower().Split(' ');

            string stringCommandName = inputSplit[0];

            Action commandName = ParseCommandName(stringCommandName);

            List<string> paramsList = new List<string>();
            for(int i = 1; i < inputSplit.Length; i++)
            {
                paramsList.Add(inputSplit[i]);
            }

            string[] paramsListArray = paramsList.ToArray();

            int[] paramsArrayInNumForm = Array.ConvertAll(paramsListArray, int.Parse);

            return new Command(commandName, paramsArrayInNumForm);

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
                case "move":
                    return Action.move;
                case "drawto":
                    return Action.drawto;
                default:
                    return Action.none;

            }
        }
        
    }
}
