using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class zadnjaKuca : Form
    {
        Form1 prva;
        public zadnjaKuca()
        {
            InitializeComponent();
        }
       
        public zadnjaKuca(Form1 pozovi)
        {
            InitializeComponent();
            prva = pozovi;
        }
        private void zadnjaKuca_Load(object sender, EventArgs e)
        {
            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label147.Text = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label146.Text = textBox2.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            label145.Text = textBox3.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == null) { MessageBox.Show("Niste unijeli naziv"); }
            else
            {
                if (textBox2.Text == null) { MessageBox.Show("Niste unijeli ime i prezime vlasnika"); }
                else
                {
                    if (textBox3.Text == null) { MessageBox.Show("Niste unijeli adresu vlasnika"); }
                    else
                    {
                        var dir = @"c:\Energetski certifikat\Kuca-stan";  // folder location

                        if (!Directory.Exists(dir))  // if it doesn't exist, create
                            Directory.CreateDirectory(dir);
                        string fname = dir + "\\" + label146.Text + ".txt";
                        System.IO.StreamWriter fs = new StreamWriter(fname);
                        String line = String.Format("{0,-15}{1,-85}{2,-80}", "", "GRAĐEVINSKI DIO:", "KOEFICIJENT PROLASKA TOPLINE U:");
                        fs.WriteLine(line);
                        fs.WriteLine("");
                        fs.WriteLine("SOBA 1");
                        fs.WriteLine("");

                        if (label2.Text == "građevinski dio" && label79.Text == "građevinski dio") { label79.Text = ""; label2.Text = ""; }
                        else
                        {
                            line = String.Format("{0,-15}{1,-85}{2,-80}", "ZID 1:", label2.Text, label79.Text);
                            fs.WriteLine(line);
                        }
                        if (label80.Text == "građevinski dio" && label81.Text == "građevinski dio") { label80.Text = ""; label81.Text = ""; }
                        else
                        {
                            line = String.Format("{0,-15}{1,-85}{2,-80}", "ZID 2:", label80.Text, label81.Text);
                            fs.WriteLine(line);
                        }
                        if (label82.Text == "građevinski dio" && label83.Text == "građevinski dio") { label82.Text = ""; label83.Text = ""; }
                        else
                        {
                            line = String.Format("{0,-15}{1,-85}{2,-80}", "ZID 3:", label82.Text, label83.Text);
                            fs.WriteLine(line);
                        }
                        if (label84.Text == "građevinski dio" && label85.Text == "građevinski dio") { label84.Text = ""; label85.Text = ""; }
                        else
                        {
                            line = String.Format("{0,-15}{1,-85}{2,-80}", "ZID 4:", label84.Text, label85.Text);
                            fs.WriteLine(line);
                        } if (label86.Text == "građevinski dio" && label87.Text == "građevinski dio") { label86.Text = ""; label87.Text = ""; }
                        else
                        {

                            line = String.Format("{0,-15}{1,-85}{2,-80}", "STROP:", label86.Text, label87.Text);
                            fs.WriteLine(line);
                        }
                        if (label88.Text == "građevinski dio" && label89.Text == "građevinski dio") { label80.Text = ""; label81.Text = ""; }
                        else
                        {
                            line = String.Format("{0,-15}{1,-85}{2,-80}", "POD:  ", label88.Text, label89.Text);
                            fs.WriteLine(line);
                            fs.WriteLine("");
                            fs.WriteLine("SOBA 2");
                            fs.WriteLine("");
                        }

                        if (label26.Text == "građevinski dio" && label24.Text == "građevinski dio") { label26.Text = ""; label24.Text = ""; }
                        else
                        {
                            line = String.Format("{0,-15}{1,-85}{2,-80}", "ZID 1:", label26.Text, label24.Text);
                            fs.WriteLine(line);
                        }
                        if (label23.Text == "građevinski dio" && label12.Text == "građevinski dio") { label23.Text = ""; label22.Text = ""; }
                        else
                        {
                            line = String.Format("{0,-15}{1,-85}{2,-80}", "ZID 2:", label23.Text, label22.Text);
                            fs.WriteLine(line);
                        }
                        if (label21.Text == "građevinski dio" && label20.Text == "građevinski dio") { label21.Text = ""; label20.Text = ""; }
                        else
                        {
                            line = String.Format("{0,-15}{1,-85}{2,-80}", "ZID 3:", label21.Text, label20.Text);
                            fs.WriteLine(line);
                        }
                        if (label19.Text == "građevinski dio" && label18.Text == "građevinski dio") { label19.Text = ""; label18.Text = ""; }
                        else
                        {
                            line = String.Format("{0,-15}{1,-85}{2,-80}", "ZID 4:", label19.Text, label18.Text);
                            fs.WriteLine(line);
                        }
                        if (label17.Text == "građevinski dio" && label16.Text == "građevinski dio") { label17.Text = ""; label16.Text = ""; }
                        else
                        {
                            line = String.Format("{0,-15}{1,-85}{2,-80}", "STROP:", label17.Text, label16.Text);
                            fs.WriteLine(line);
                        }
                        if (label15.Text == "građevinski dio" && label14.Text == "građevinski dio") { label15.Text = ""; label14.Text = ""; }
                        else
                        {
                            line = String.Format("{0,-15}{1,-85}{2,-80}", "POD:  ", label15.Text, label14.Text);
                            fs.WriteLine(line);
                            fs.WriteLine("");
                            fs.WriteLine("SOBA 3");
                            fs.WriteLine("");
                        }

                        if (label50.Text == "građevinski dio" && label48.Text == "građevinski dio") { label50.Text = ""; label48.Text = ""; }
                        else
                        {
                            line = String.Format("{0,-15}{1,-85}{2,-80}", "ZID 1:", label50.Text, label48.Text);
                            fs.WriteLine(line);
                        }
                        if (label47.Text == "građevinski dio" && label46.Text == "građevinski dio") { label47.Text = ""; label46.Text = ""; }
                        else
                        {
                            line = String.Format("{0,-15}{1,-85}{2,-80}", "ZID 2:", label47.Text, label46.Text);
                            fs.WriteLine(line);
                        }
                        if (label45.Text == "građevinski dio" && label44.Text == "građevinski dio") { label45.Text = ""; label44.Text = ""; }
                        else
                        {
                            line = String.Format("{0,-15}{1,-120}{2,-80}", "ZID 3:", label45.Text, label44.Text);
                            fs.WriteLine(line);
                        }
                        if (label43.Text == "građevinski dio" && label42.Text == "građevinski dio") { label43.Text = ""; label42.Text = ""; }
                        else
                        {
                            line = String.Format("{0,-15}{1,-85}{2,-80}", "ZID 4:", label43.Text, label42.Text);
                            fs.WriteLine(line);
                        }
                        if (label41.Text == "građevinski dio" && label40.Text == "građevinski dio") { label41.Text = ""; label40.Text = ""; }
                        else
                        {
                            line = String.Format("{0,-15}{1,-85}{2,-80}", "STROP:", label41.Text, label40.Text);
                            fs.WriteLine(line);
                        }
                        if (label39.Text == "građevinski dio" && label38.Text == "građevinski dio") { label39.Text = ""; label38.Text = ""; }
                        else
                        {
                            line = String.Format("{0,-15}{1,-85}{2,-80}", "POD:  ", label39.Text, label38.Text);
                            fs.WriteLine(line);
                            fs.WriteLine("");
                            fs.WriteLine("SOBA 4");
                            fs.WriteLine("");
                        }

                        if (label74.Text == "građevinski dio" && label72.Text == "građevinski dio") { label74.Text = ""; label72.Text = ""; }
                        else
                        {
                            line = String.Format("{0,-15}{1,-85}{2,-80}", "ZID 1:", label74.Text, label72.Text);
                            fs.WriteLine(line);
                        }
                        if (label71.Text == "građevinski dio" && label70.Text == "građevinski dio") { label71.Text = ""; label70.Text = ""; }
                        else
                        {
                            line = String.Format("{0,-15}{1,-85}{2,-80}", "ZID 2:", label71.Text, label70.Text);
                            fs.WriteLine(line);
                        }
                        if (label69.Text == "građevinski dio" && label68.Text == "građevinski dio") { label69.Text = ""; label68.Text = ""; }
                        else
                        {
                            line = String.Format("{0,-15}{1,-85}{2,-80}", "ZID 3:", label69.Text, label68.Text);
                            fs.WriteLine(line);
                        }
                        if (label67.Text == "građevinski dio" && label66.Text == "građevinski dio") { label67.Text = ""; label66.Text = ""; }
                        else
                        {
                            line = String.Format("{0,-15}{1,-85}{2,-80}", "ZID 4:", label67.Text, label66.Text);
                            fs.WriteLine(line);
                        }
                        if (label65.Text == "građevinski dio" && label64.Text == "građevinski dio") { label65.Text = ""; label64.Text = ""; }
                        else
                        {
                            line = String.Format("{0,-15}{1,-85}{2,-80}", "STROP:", label65.Text, label64.Text);
                            fs.WriteLine(line);
                        }
                        if (label63.Text == "građevinski dio" && label62.Text == "građevinski dio") { label63.Text = ""; label62.Text = ""; }
                        else
                        {
                            line = String.Format("{0,-15}{1,-85}{2,-80}", "POD:  ", label63.Text, label62.Text);
                            fs.WriteLine(line);
                            fs.WriteLine("");
                            fs.WriteLine("SOBA 5");
                            fs.WriteLine("");
                        }

                        if (label109.Text == "građevinski dio" && label107.Text == "građevinski dio") { label109.Text = ""; label107.Text = ""; }
                        else
                        {
                            line = String.Format("{0,-15}{1,-85}{2,-80}", "ZID 1:", label109.Text, label107.Text);
                            fs.WriteLine(line);
                        }
                        if (label106.Text == "građevinski dio" && label105.Text == "građevinski dio") { label106.Text = ""; label105.Text = ""; }
                        else
                        {
                            line = String.Format("{0,-15}{1,-85}{2,-80}", "ZID 2:", label106.Text, label105.Text);
                            fs.WriteLine(line);
                        }
                        if (label104.Text == "građevinski dio" && label103.Text == "građevinski dio") { label104.Text = ""; label103.Text = ""; }
                        else
                        {
                            line = String.Format("{0,-15}{1,-85}{2,-80}", "ZID 3:", label104.Text, label103.Text);
                            fs.WriteLine(line);
                        }
                        if (label102.Text == "građevinski dio" && label101.Text == "građevinski dio") { label102.Text = ""; label101.Text = ""; }
                        else
                        {
                            line = String.Format("{0,-15}{1,-85}{2,-80}", "ZID 4:", label102.Text, label101.Text);
                            fs.WriteLine(line);
                        }
                        if (label100.Text == "građevinski dio" && label99.Text == "građevinski dio") { label100.Text = ""; label99.Text = ""; }
                        else
                        {
                            line = String.Format("{0,-15}{1,-85}{2,-80}", "STROP:", label100.Text, label99.Text);
                            fs.WriteLine(line);
                        }
                        if (label98.Text == "građevinski dio" && label97.Text == "građevinski dio") { label98.Text = ""; label97.Text = ""; }
                        else
                        {
                            line = String.Format("{0,-15}{1,-85}{2,-80}", "POD:  ", label98.Text, label97.Text);
                            fs.WriteLine(line);
                            fs.WriteLine("");
                            fs.WriteLine("SOBA 6");
                            fs.WriteLine("");
                        }

                        if (label133.Text == "građevinski dio" && label131.Text == "građevinski dio") { label133.Text = ""; label131.Text = ""; }
                        else
                        {
                            line = String.Format("{0,-15}{1,-85}{2,-80}", "ZID 1:", label133.Text, label131.Text);
                            fs.WriteLine(line);
                        }
                        if (label130.Text == "građevinski dio" && label129.Text == "građevinski dio") { label130.Text = ""; label129.Text = ""; }
                        else
                        {
                            line = String.Format("{0,-15}{1,-85}{2,-80}", "ZID 2:", label130.Text, label129.Text);
                            fs.WriteLine(line);
                        }
                        if (label128.Text == "građevinski dio" && label127.Text == "građevinski dio") { label128.Text = ""; label127.Text = ""; }
                        else
                        {
                            line = String.Format("{0,-15}{1,-85}{2,-80}", "ZID 3:", label128.Text, label127.Text);
                            fs.WriteLine(line);
                        }
                        if (label126.Text == "građevinski dio" && label125.Text == "građevinski dio") { label126.Text = ""; label125.Text = ""; }
                        else
                        {
                            line = String.Format("{0,-15}{1,-85}{2,-80}", "ZID 4:", label126.Text, label125.Text);
                            fs.WriteLine(line);
                        }
                        if (label124.Text == "građevinski dio" && label123.Text == "građevinski dio") { label124.Text = ""; label123.Text = ""; }
                        else
                        {
                            line = String.Format("{0,-15}{1,-85}{2,-80}", "STROP:", label124.Text, label123.Text);
                            fs.WriteLine(line);
                        }
                        if (label109.Text == "građevinski dio" && label107.Text == "građevinski dio") { label109.Text = ""; label107.Text = ""; }
                        else
                        {
                            line = String.Format("{0,-15}{1,-85}{2,-80}", "POD:  ", label122.Text, label121.Text);
                            fs.WriteLine(line);
                        }

                        fs.WriteLine("");
                        fs.WriteLine("");
                        fs.WriteLine("");
                        fs.WriteLine("NAZIV OBJEKTA:        " + label147.Text);
                        fs.WriteLine("IME I PREZIME VLASNIKA:       " + label146.Text);
                        fs.WriteLine("ADRESA:       " + label145.Text);

                        fs.Close();

                        System.Diagnostics.Process.Start(fname);
                    }
                }
            }
        }
    }
}
