using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    public class ShapeGenerator
    {
        private ShapeGenerator() { }

        //Implementing Singleton Design Pattern and hence single instance of the ShapeGenerator class
        private static ShapeGenerator instance;

        public static ShapeGenerator Instance 
        { 
            get
            {
                if (instance.Equals("")){
                    instance = new ShapeGenerator();
                }
                return instance;
            }
        }

        public Shape GenerateShape(CommandGenerator commandName, Point position, bool fill, Color penColor)
        {
            switch (commandName.CommandName)
            {
                case Action.rectangle:
                    return new Rectangle(position, penColor, commandName.CommandValues[0], commandName.CommandValues[1], fill);
                case Action.circle:
                    return new Circle(position, penColor, commandName.CommandValues[0], fill);
                case Action.square:
                    return new Square(position, penColor, commandName.CommandValues[0], fill);
                case Action.triangle:
                    return new Triangle(position, fill, penColor, commandName.CommandValues[0]);
                default:
                    throw new ArgumentException("Wrong Command");
            }
        }

    }
}
