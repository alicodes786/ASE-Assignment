﻿using System;
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
        private readonly Parser parser = new Parser();

        /// <summary>
        /// Testing code to see if program is working
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picDrawingArea_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Point position = new Point(120, 100);
            Shape rectangle = new Rectangle(position, Color.Blue, 10, 20);
            rectangle.Draw(graphics);


        }

        /// <summary>
        /// Run button command code
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
           
            if(textCommandLine.Text != string.Empty) 
            {
                try
                {
                    cursor.Draw(g);
                    Command command = parser.ParseShapeFromSingleLineCommand(textCommandLine.Text);
                    RunCommand(g, command);
                }
                catch (ArgumentException ex)
                {

                }
            }

          

            

        }

        /// <summary>
        /// Function which will be executed when run button or run command is initiated
        /// </summary>
        /// <param name="g"></param>
        /// <param name="command"></param>

        public void RunCommand(Graphics g, Command command)
        {
            switch (command.CommandName)
            {
                case Action.rectangle:
                    Rectangle rect = new Rectangle(cursor.Position, cursor.defaultPenColor, command.CommandValues[0], command.CommandValues[1]);
                    rect.Draw(g);
                break;
                case Action.circle:
                    Circle circle = new Circle(cursor.Position, cursor.defaultPenColor, command.CommandValues[0]);
                    circle.Draw(g);
                break;
                case Action.square:
                    Square square = new Square(cursor.Position, cursor.defaultPenColor, command.CommandValues[0]);
                    square.Draw(g);
                    break;
                case Action.move:
                    cursor.MoveTo(new Point(command.CommandValues[0], command.CommandValues[1]));
                    cursor.Draw(g);
                    break;
                case Action.drawto:
                    Line line = new Line(cursor.Position, cursor.defaultPenColor, new Point(command.CommandValues[0], command.CommandValues[1]));
                    line.Draw(g);
                    break;

            }
            
            
        }
       
        /// <summary>
        /// Function which checks anything was entered into the command line and checks if "Enter" was pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Function to be executed when clear button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearBtn_Click(object sender, EventArgs e)
        {
            var g = pictureBox1.CreateGraphics();
            g.Clear(Color.White);

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
