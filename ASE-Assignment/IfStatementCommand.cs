using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    public class IfStatementCommand : Command
    {
        public int IndexStart {  get; set; }
        public int IndexEnd { get; set; } 
        public bool IfCondition { get; set; }

        public IfStatementCommand(Action commandName, bool ifCondition, int indexStart, int indexEnd)
        {
            CommandName = commandName;
            IfCondition = ifCondition;
            IndexStart = indexStart;
            IndexEnd = indexEnd;
        }
    }
}
