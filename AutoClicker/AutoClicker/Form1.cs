using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoClicker
{
    public partial class Form1 : Form
    {
        String text1 = "Start";
        String text2 = "Stop";
        public Form1()
        {
            InitializeComponent();
        }

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
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Text = "Start";
        }
    }
}
