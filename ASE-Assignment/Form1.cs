using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASE_Assignment
{
    public partial class Form1 : Form
    {
       
        private readonly Cursor cursor = new Cursor();
        private readonly Parser parser = new Parser();
        //private readonly ShapeGenerator _shapeGenerator = ShapeGenerator.Instance;
        Dictionary<string, int> storageOfVariables = new Dictionary<string, int>();
        private const string TextFile = "Text File| *.txt";
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Testing code to see if program is working
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picDrawingArea_Paint(object sender, PaintEventArgs e)
        {
           

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
                    //Single line commands parsing
                    cursor.Draw(g);
                    CommandGenerator command = parser.ParseShapeFromSingleLineCommand(textCommandLine.Text);
                    RunCommand(g, command);
                }
                catch (ArgumentException ex)
                {
                    label1.Text = ex.Message;
                }
            }

            // MultiLine Command parsing and Executing
            if (multiLineCommandLine.Text != string.Empty)
            {
                cursor.Draw(g);
                try
                {   //Multi line commands parsing

                    List<Command> commands = parser.Parse(multiLineCommandLine.Text, storageOfVariables); 
                    for(int i = 0; i < commands.Count; i++)
                    {
                        if (commands[i] is CommandWhileLoop)
                        {
                            CommandWhileLoop currentCommand = (CommandWhileLoop)commands[i];
                            int loopStartIndex= i + 1;
                            int loopEndIndex = commands.FindIndex(loopStartIndex, x => x is CommandEnd) - 1; // Looks for end keyword after the loopstart

                            string[] inputLines = multiLineCommandLine.Text.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                            string inputLoop = "";

                            for (int counterLoop = loopStartIndex; counterLoop <= loopEndIndex; counterLoop++)
                            {
                                inputLoop+= inputLines[counterLoop];
                            }

                            for(int loopIndex = 1; loopIndex < currentCommand.LoopCount; loopIndex++)
                            {
                                List<Command> loopCommands = parser.Parse(inputLoop, storageOfVariables);

                                for (int k = 0; k < loopCommands.Count; k++)
                                {
                                    RunCommand(g, (CommandGenerator)loopCommands[k]);
                                }
                            }
                        }

                        else if (commands[i] is IfStatementCommand)
                        {
                            IfStatementCommand command = (IfStatementCommand)commands[i];
                            if (command.IfCondition)
                            {
                                continue;
                            }
                            else
                            {
                                i = command.IndexEnd;
                            }
                        }

                        else if (commands[i] is CommandGenerator)
                        {
                            RunCommand(g, (CommandGenerator)commands[i]);
                        }
                    }
                }
                catch (ArgumentException ex)
                {
                    label1.Text = ex.Message;
                }
            }

        }

        /// <summary>
        /// Function which will be executed when run button or run command is initiated
        /// </summary>
        /// <param name="g"></param>
        /// <param name="command"></param>

        public void RunCommand(Graphics g, CommandGenerator command)
        {
            switch (command.CommandName)
            {
                case Action.rectangle:
                    Rectangle rect = new Rectangle(cursor.Position, cursor.PenColor, command.CommandValues[0], command.CommandValues[1], cursor.Fill);
                    rect.Draw(g);
                    break;
                case Action.circle:
                    Circle circle = new Circle(cursor.Position, cursor.PenColor, command.CommandValues[0], cursor.Fill);
                    circle.Draw(g);
                    break;
                case Action.square:
                    Square square = new Square(cursor.Position, cursor.PenColor, command.CommandValues[0], cursor.Fill);
                    square.Draw(g);
                    break;
                case Action.triangle:
                    Triangle triangle = new Triangle(cursor.Position, cursor.Fill, cursor.PenColor, command.CommandValues[0]);
                    triangle.Draw(g);
                    break;
                case Action.move:
                    cursor.MoveTo(new Point(command.CommandValues[0], command.CommandValues[1]));
                    cursor.Draw(g);
                    break;
                case Action.drawto:
                    Line line = new Line(cursor.Position, cursor.PenColor, new Point(command.CommandValues[0], command.CommandValues[1]), cursor.Fill);
                    line.Draw(g);
                    break;

                case Action.run:
                    RunCommand(g, command);
                    break;
                case Action.fill:
                    if (command.CommandValues[0] == 1)
                    {
                        cursor.Fill = true;
                    }

                    if (command.CommandValues[0] == 0)
                    {
                        cursor.Fill = false;
                    }
                    break;

                case Action.reset:
                    {
                        cursor.MoveTo(cursor.defaultPosition);
                        cursor.Draw(g);
                        textCommandLine.Text = "";
                        multiLineCommandLine.Text = "";
                        cursor.FillChange(cursor.defaultFill);
                    }
                    break;
                case Action.pen:
                    {
                        if (command.CommandValues[0].Equals(1))
                        {
                            cursor.PenColor = Color.Blue;
                        }
                        if (command.CommandValues[0].Equals(2))
                        {
                            cursor.PenColor = Color.Red;
                        }
                        if (command.CommandValues[0].Equals(3))
                        {
                            cursor.PenColor = Color.Green;
                        }
                        cursor.Draw(g);
                        break;
                    }
                case Action.clear:
                    {
                        g.Clear(Color.White);
                        cursor.Draw(g);
                    }
                    break;
                //default:
                   // {
                     //   Shape shape = _shapeGenerator.GenerateShape(command, cursor.Position, cursor.Fill, cursor.PenColor);
                       // shape.Draw(g);
                       // cursor.MoveTo(shape.Position);
                        //cursor.Draw(g);
                        //break;
                    //}
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
            label1.Text = "";
            textCommandLine.Text = label1.Text;
            multiLineCommandLine.Text = label1.Text;

        }

        /// <summary>
        /// Save button - saves any list of commands
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.FileName = "AllCommands.txt";
            save.Filter = TextFile;
            save.RestoreDirectory = true;

            if(save.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(save.FileName, multiLineCommandLine.Text);
            }
        }

        /// <summary>
        /// Loads any saved files
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = TextFile;
            open.RestoreDirectory = true;

            if(open.ShowDialog() == DialogResult.OK)
            {
                multiLineCommandLine.Text = File.ReadAllText(open.FileName);
            }

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

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        
    }
}
