using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace buttonProject
{
    public partial class Form1 : Form
    {
        
        Point firstPos;
        float sizeX, sizeY;
        

        public Form1()
        {
            InitializeComponent();

          
            
            
            
        }

        public void CreateMyForm(string msg)
        {
            // Create a new instance of the form.
            Form form1 = new Form();
            form1.Size = new Size(300, 150);
            // Create two buttons to use as the accept and cancel buttons.
            Button button1 = new Button();
            Label lb = new Label();
            lb.Location = new Point(10, 20);
            lb.Size = new Size(280, 50);
            lb.Text = msg;
            // Set the text of button1 to "OK".
            button1.Text = "OK";
            // Set the position of the button on the form.
            button1.Location = new Point(100, 70);
            button1.Click += (sender, args) => ((Form)((Button)sender).Parent).Close();
            // Set the caption bar text of the form.
            form1.Text = "Рисуй и страдай";
            // Display a help button on the form.
            form1.HelpButton = true;

            // Define the border style of the form to a dialog box.
            form1.FormBorderStyle = FormBorderStyle.FixedDialog;
            // Set the accept button of the form to button1.
            form1.AcceptButton = button1;
            // Set the start position of the form to the center of the screen.
            form1.StartPosition = FormStartPosition.CenterParent;

            // Add button1 to the form.
            form1.Controls.Add(button1);
            form1.Controls.Add(lb);

            // Display the form as a modal dialog box.
            form1.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           CreateMyForm("Ух, вы смогли попасть по кнопке!");
            
        }

       

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Point pos = new Point(e.X+button1.Size.Width/2, e.Y + button1.Size.Height / 2);
            Point pos2 = new Point(button1.Location.X + button1.Size.Width / 2,
                button1.Location.Y + button1.Size.Height / 2);
            int disX = pos.X - firstPos.X;
            int disY = pos.Y - firstPos.Y;
            int dixOX = pos.X - pos2.X;
            int dixOY = pos.Y - pos2.Y;
            if (Math.Abs(dixOX) <= button1.Size.Width*1.5f
                && Math.Abs(dixOY) <= button1.Size.Height*1.5f
                
                 )
            {

                
                
                    button1.Location = new Point
                    (
                    button1.Location.X - dixOX/10,
                    button1.Location.Y - dixOY/10
                    );
                    if (button1.Location.X < 0)
                        button1.Location = new Point(0, button1.Location.Y);
                    if (button1.Location.X >= Size.Width - button1.Size.Width)
                        button1.Location = new Point(Size.Width - button1.Size.Width, 0);
                    if (button1.Location.Y < 0)
                        button1.Location = new Point(button1.Location.X, 0);
                    if (button1.Location.Y >= Size.Height - button1.Size.Height)
                        button1.Location = new Point(button1.Location.X, Size.Height - button1.Size.Height);
                

            }
            
            firstPos = pos;
            sizeX = (float)(button1.Location.X) / (float)(Size.Width);
            sizeY = (float)(button1.Location.Y) / (float)(Size.Height);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Location = new Point(Size.Width / 2 - button1.Size.Width/2, 
                Size.Height / 2 - button1.Size.Height / 2);
            sizeX = (float)(button1.Location.X) / (float)(Size.Width);
            sizeY = (float)(button1.Location.Y) / (float)(Size.Height);
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            button1.Location = new Point
                (
               (int)( Size.Width * sizeX),
                (int)(Size.Height* sizeY)
                );
            if (button1.Location.X < 0)
                button1.Location = new Point(0, button1.Location.Y);
            if (button1.Location.X >= Size.Width - button1.Size.Width)
                button1.Location = new Point(Size.Width - button1.Size.Width, button1.Location.Y);
            if (button1.Location.Y < 0)
                button1.Location = new Point(button1.Location.X, 0);
            if (button1.Location.Y >= Size.Height - button1.Size.Height)
                button1.Location = new Point(button1.Location.X, Size.Height - button1.Size.Height);
        }

       
    }
}
