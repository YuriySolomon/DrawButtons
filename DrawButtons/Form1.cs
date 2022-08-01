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
        Button button1;
        bool drawing = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDownX = e.X;
            MouseDownY = e.Y;
            button1 = new Button();
            button1.Parent = this;
            button1.Text = "Buttot" + NumButton++;
            drawing = true;            
        }

        private void Form1_MouseUp(object sender, MouseEventArgs MouseUp)
        {
            drawing = false;
            if (Math.Abs(MouseUp.X - MouseDownX) < 30 || Math.Abs(MouseUp.Y - MouseDownY) < 20)
            {
                NumButton--;
                this.Controls.Remove(button1);
                MessageBox.Show("Button size too small", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!drawing) return;                   

            button1.Width = Math.Abs(e.X - MouseDownX);
            button1.Height = Math.Abs(e.Y - MouseDownY);

            int TempX = MouseDownX;
            int TempY = MouseDownY;

            if (e.X - MouseDownX > 0)
            {
                if (e.Y - MouseDownY < 0)
                {
                    TempY = e.Y;
                }                
            }
            else
            {
                TempX = e.X;
                if ((e.Y - MouseDownY) < 0)
                {
                    TempY = e.Y;
                }                
            }
            button1.Location = new Point(TempX, TempY);
        }
    }
}
