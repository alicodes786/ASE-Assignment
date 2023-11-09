using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    public class Line : Shape
    {
        private readonly Point defaultPositionOfLine = new Point(200, 200);

        public Point ToPositionOfLine { get; set; }
        public Line() : base()
        {
            ToPositionOfLine = defaultPositionOfLine;
        }

        public Line(Point positionOfLine, Color penColor, Point toPosition) : base(penColor, positionOfLine)
        {
            ToPositionOfLine = toPosition;
        }
    
        /// <summary>
        /// Drawto command uses this function to draw a line between two points
        /// </summary>
        /// <param name="g"></param>
        public override void Draw(Graphics g)
        {
            var pen = new Pen(PenColor, 1);
            g.DrawLine(pen, Position.X, Position.Y, ToPositionOfLine.X, ToPositionOfLine.Y);
        }
    }
}
