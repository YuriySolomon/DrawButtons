using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawButtons
{
    public partial class Form1 : Form
    {
        private int MouseDownX;
        private int MouseDownY;
        private int NumButton = 1;              

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDownX = e.X;
            MouseDownY = e.Y;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs MouseUp)
        {
            if (Math.Abs(MouseUp.X - MouseDownX) >= 30 && Math.Abs(MouseUp.Y - MouseDownY) >= 20)
            {
                var button1 = new Button();
                button1.Parent = this;
                button1.Text = "Buttot" + NumButton++;
                button1.Width = Math.Abs(MouseUp.X - MouseDownX);
                button1.Height = Math.Abs(MouseUp.Y - MouseDownY);
                if (MouseUp.X - MouseDownX > 0)
                {           
                    if (MouseUp.Y - MouseDownY < 0)
                    {
                        MouseDownY = MouseUp.Y;
                    }                    
                }
                else
                {
                    MouseDownX = MouseUp.X;
                    if ((MouseUp.Y - MouseDownY) < 0)
                    {
                        MouseDownY = MouseUp.Y;
                    }
                }                
                button1.Location = new Point(MouseDownX, MouseDownY);                
            }
            else
            {
                MessageBox.Show("Button size too small", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
          
        }
    }
}
