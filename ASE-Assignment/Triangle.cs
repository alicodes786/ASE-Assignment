using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Xml.Schema;

namespace ASE_Assignment
{
    public class Triangle : Shape
    {
        private readonly int defaultLength = 150;

        public int Length { get; set; }

        public Point pointA { get; set; }
        public Point pointB { get; set; }
        public Point pointC { get; set; }

        private void triangleSides(int sideLength)
        {
            pointA = new Point(Position.X, Position.Y);
            pointB = new Point(Position.X, Position.Y + sideLength);
            pointC = new Point(Position.X + sideLength, Position.Y + sideLength);
        }


        public Triangle(Point position, bool fill, Color penColor, int length) : base(penColor, position, fill)
        {
            Length = length;
            triangleSides(length);
        }


        public override void Draw(Graphics g)
        {
            Point[] points = new Point[3];
            points[0] = pointA;
            points[1] = pointB;
            points[2] = pointC;
            var pen = new Pen(PenColor, 3);
            g.DrawPolygon(pen, points);
        }
    }
}
