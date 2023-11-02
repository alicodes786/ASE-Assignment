using System;
using System.Collections.Generic;
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

        public override void Draw(Graphics g)
        {
            var brush = new SolidBrush(PenColor);
            g.FillRectangle(brush, Position.X, Position.Y, 4, 4);
        }



    }
}
