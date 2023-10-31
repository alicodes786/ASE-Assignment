using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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

        private int length { get; set; }
        private int height { get; set; }
        public Rectangle()
        {
            length = defaultLengthValue;
            height = defaultWidthValue;
        }

        




    }
}
