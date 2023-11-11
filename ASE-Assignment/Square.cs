using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    public class Square : Rectangle
    {
        private readonly int defaultLength = 120;
        public int Length { get; set; }

        public Square() 
        {
            Length = defaultLength;
        }

        public Square(Point position, Color penColor, int length, bool fill) : base(position, penColor, length, length, fill)
        {
            Length = length;
        }

        /// <summary>
        /// Overriden draw function to draw Square with Length as the side of the square
        /// </summary>
        /// <param name="g"></param>
        public override void Draw(Graphics g)
        {
            var pen = new Pen(PenColor, 1);
            g.DrawRectangle(pen, Position.X, Position.Y, Length, Length);
            return;
        }
    }
}
