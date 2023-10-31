﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASE_Assignment

  /// <summary>
  /// A class that implements the <see cref="Shape" /> parent class and is used to create <see cref="Rectangle" /> objects and draw them on a WinForms control.
  /// </summary>
  /// <seealso cref="Shape" />
{
    internal class Rectangle : Shape
    {
        private readonly int defaultLengthValue = 100;
        private readonly int defaultWidthValue = 100;

        private int Length { get; set; }
        private int Height { get; set; }
        public Rectangle()
        {
            Length = defaultLengthValue;
            Height = defaultWidthValue;
        }

        public Rectangle(Point position,Color penColor, int length, int height) : base(penColor, position)
        {
            Length = length;
            Height = height;   
        }
        public override void Draw(Graphics g)
        {
            var pen = new Pen(PenColor, 2);
            g.DrawRectangle(pen, Position.X, Position.Y, Length, Height);
            return;
        }
    }
}
