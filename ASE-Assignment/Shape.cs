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
    public abstract class Shape
    {
      public readonly Color defaultPenColor = Color.Green;
      public readonly Point defaultPosition = new Point(0, 0);
      public readonly bool defaultFill = false;


      public Color PenColor { get; set; }
      public Point Position { get; set; }
      public bool Fill { get; set; }

      /// <summary>
      /// 
      /// </summary>
      protected Shape() 
      {
            PenColor = defaultPenColor;  
            Position = defaultPosition;
            Fill = defaultFill;

      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="penColor"></param>
      /// <param name="position"></param>
      /// <param name="fill"></param>
      protected Shape(Color penColor, Point position, bool fill) 
      {
            PenColor = penColor;
            Position = position;
            Fill = fill;
      }

        public abstract void Draw(Graphics g);
    }
}
