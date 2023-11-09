using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    public class Circle : Shape
    {
        private readonly int defaultRadius = 50;
        private int Radius { get; set; }


        public Circle() 
        { 
           Radius = defaultRadius;
        }

        public Circle(Point position, Color penColor, int radius) : base(penColor, position)
        {
            Radius = radius;
        }


        /// <summary>
        /// Overriden draw function to draw circle
        /// </summary>
        /// <param name="g"></param>
        public override void Draw(Graphics g)
        {
            var pen = new Pen(PenColor, 3);
            g.DrawEllipse(pen, Position.X - Radius, Position.Y - Radius, Radius * 2, Radius * 2);
            return;

        }
    }
}
