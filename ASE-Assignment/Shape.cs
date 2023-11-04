using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASE_Assignment
{    
    /// <summary>
    /// 
    /// </summary>
    internal abstract class Shape
    {
      public readonly Color defaultPenColor = Color.Green;
      public readonly Point defaultPosition = new Point(0, 0);


        public Color PenColor { get; set; }
      public Point Position { get; set; }

        protected Shape() {
            PenColor = defaultPenColor;  
            Position = defaultPosition;

      }
      protected Shape(Color penColor, Point position) 
      {
            PenColor = penColor;
            Position = position;
      }

      public Shape NewShape(Command shapeInCommand, Point position, Color penColor)
        {
            if(shapeInCommand.Equals("rectangle"))
            {
                return new Rectangle(position, penColor, shapeInCommand.CommandValues[0], shapeInCommand.CommandValues[1]);
            }
            else
            {
                throw new ArgumentException(null, nameof(shapeInCommand));
            }
        }

        public abstract void Draw(Graphics g);
    }
}
