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

       
        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
            
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Point position = new Point(100, 150);
            Shape rectangle = new Rectangle(position, Color.Blue, 10, 20);
            rectangle.Draw(graphics);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
