using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    internal class Cursor : Shape
    {
        public Cursor() : base()
        {
        
        }
        public bool cursorChecker = false;

        /// <summary>
        /// MoveTo function to change the cursor position and draw from there
        /// </summary>
        /// <param name="position"></param>
        public void MoveTo(Point position)
        {
            Position = position;
            
        }

        public void FillChange(bool fillState)
        {
            Fill = fillState;
        }

        public override void Draw(Graphics g)
        {
            var brush = new SolidBrush(PenColor);
            g.FillRectangle(brush, Position.X, Position.Y, 4, 4);
        }



    }
}
