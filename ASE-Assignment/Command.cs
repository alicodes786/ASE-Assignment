using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    public class Command
    {
        public int[] CommandValues { get; set; }
        public Action CommandName { get; set; }
        public Command(Action commandName, int[] commandValues) 
        {
           CommandName = commandName;
           CommandValues = commandValues;
        }
    }
}
