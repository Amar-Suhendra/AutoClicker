using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoClicker
{
    public partial class Form1 : Form
    {
        String text1 = "Start";
        String text2 = "Stop";
        int interval;
        public Form1()
        {
            InitializeComponent();
        }
        [DllImport("user32.dll")]

        static extern void mouse_event(int dwflags, int dx, int dy, int dwdata, int dwextrainfo);

        public void Leftclick(Point P)
        {
            mouse_event(0x0002, P.X, P.Y, 0, 0);
            mouse_event(0x0004, P.X, P.Y, 0, 0);
        }

        public void Rightclick(Point P)
        {
            mouse_event(0x0008, P.X, P.Y, 0, 0);
            mouse_event(0x0010, P.X, P.Y, 0, 0);
        }

        bool stop = true;
        private void Button1_Click(object sender, EventArgs e)
        {
            
            if(rightClickRbt.Checked == false && leftClickRbt.Checked == false)
            {
                error2.Text = "Choose left click or right click";
            }
            else
            {
                error2.Text = "click true";
            }

             if ( numericUpDown1.Value == 0 )
            {
                error.Text = "Min 1 CPS";
            }
            else
            {
                error.Text = "";
                if (button1.Text == text1)
                {
                    button1.Text = text2;
                }
                else
                {
                    button1.Text = text1;
                }
                interval = (int)numericUpDown1.Value;
                interval *= 1000;
                stop = (stop) ? false : true;
                timer1.Interval = interval;
                timer1.Enabled = true;
                if (!stop)
                {
                    timer1.Start();
                    numericUpDown1.Enabled = false;
                }
                if (stop)
                {
                    timer1.Stop();
                    numericUpDown1.Enabled = true;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Text = text1;
            error.Text = "";
            error2.Text = "";
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Rightclick(new Point(MousePosition.X, MousePosition.Y));
        }
    }
}
