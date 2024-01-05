using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    public class VariableCommand : Command
    {
        public string VariableName { get; set; }
        public int ValueOfVariable { get; set; }


        public VariableCommand(Action commandName, string variableName, int variableValue) 
        {
            CommandName = commandName;
            VariableName = variableName;
            ValueOfVariable = variableValue;
        }
    }
}
