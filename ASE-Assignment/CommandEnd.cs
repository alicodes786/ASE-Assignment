using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    public class CommandEnd : Command
    {
        public CommandEnd(Action commandName) 
        {
           CommandName = commandName;
        }
    }
}
