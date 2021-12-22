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

        public enum mouseeventflags
        {
            LeftDown = 2,
            LeftUp = 4,
        }

        public void leftclick(Point P)
        {
            mouse_event((int)(mouseeventflags.LeftDown), P.X, P.Y, 0, 0);
            mouse_event((int)(mouseeventflags.LeftUp), P.X, P.Y, 0, 0);
        }
        bool stop = true;
        private void Button1_Click(object sender, EventArgs e)
        {

            if (button1.Text == text1)
            {
                button1.Text = text2;
            }
            else
            {
                button1.Text = text1;
            }
            interval = (int)numericUpDown1.Value;
            interval = interval * 1000;
            stop = (stop) ? false : true;
            timer1.Interval = interval;
            timer1.Enabled = true;
            if (!stop) timer1.Start();
            if (stop) timer1.Stop();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Text = "Start";
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            leftclick(new Point(MousePosition.X, MousePosition.Y));
        }
    }
}
