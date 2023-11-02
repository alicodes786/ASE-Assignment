using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASE_Assignment
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private readonly Cursor cursor = new Cursor();

        private void picDrawingArea_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Point position = new Point(120, 100);
            Shape rectangle = new Rectangle(position, Color.Blue, 10, 20);
            rectangle.Draw(graphics);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            cursor.Draw(g);
            if (textCommandLine.Text != string.Empty)
            {

                
                //Shape rectangle = new Rectangle(Color.Blue);
                //rectangle.Draw(g);




            }

        }

        private void textCommandLine_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode != Keys.Enter)
            {
                return;
            }
            button1.PerformClick();

            Console.WriteLine("Enter Key was pressed");
            e.Handled = true;
            e.SuppressKeyPress = true;
        }


        private void textCommandLine_TextChanged(object sender, EventArgs e)
        {


        }

        private void multiLineCommandLine_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void picDrawingArea_Click(object sender, EventArgs e)
        {
           


        }

    }
}
