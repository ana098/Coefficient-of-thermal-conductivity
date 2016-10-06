using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        private Form1 prva = null;

        public Form2(Form pozovi)
        {
            prva = pozovi as Form1;
            InitializeComponent();
        }

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form= new Form1();
            form.ShowDialog();
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form = new Form1();
            form.dalje.Visible = true;
            form.dalje.Tag = "1";
            form.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var form = new Form1();
            form.dalje.Visible = true;
            form.dalje.Tag = "";
            form.ShowDialog();

        }

      
        
        
    }
}
