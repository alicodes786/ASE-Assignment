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

      public abstract void Draw(Graphics g);
    }
}
