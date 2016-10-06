using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class ZadnjaSoba : Form
    {

        public ZadnjaSoba()
        {
            InitializeComponent();
        }


        private void ZadnjaSoba_Load(object sender, EventArgs e)
        {


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label38.Text = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label39.Text = textBox2.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            label40.Text = textBox3.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dir = @"c:\Energetski certifikat\Prostorije";  // folder location

            if (!Directory.Exists(dir))  // if it doesn't exist, create
                Directory.CreateDirectory(dir);
            string fname = dir + "\\" + label39.Text + ".txt";
            System.IO.StreamWriter fs = new StreamWriter(fname);
            //use Path.Combine to combine 2 strings to a path
            String line = String.Format("{0,-15}{1,-80}{2,-20}{3,-30}{4,-30}", "", "GRAĐEVINSKI DIO:", "BROJ MATERIJALA:", "UKUPAN TOPLINSKI OTPOR Rt:", "KOEFICIJENT PROLASKA TOPLINE U:");
            fs.WriteLine(line);
            string naziv = "";
            fs.WriteLine("");

            if (label11.Text.Length > 77)
            {
                naziv = label11.Text.ToString().Substring(0, 77) + "*";
            }
            else
            {
                naziv = label11.Text;
            }
            line = String.Format("{0,-15}{1,-80}{2,-20}{3,-30}{4,-30}", "ZID 1:", naziv, label12.Text, label13.Text, label14.Text);
            fs.WriteLine(line);
            


            if (label15.Text.Length > 77)
            {
                naziv = label15.Text.ToString().Substring(0, 77) + "*";
            }
            else
            {
                naziv = label15.Text;
                line = String.Format("{0,-15}{1,-80}{2,-20}{3,-30}{4,-30}", "ZID 2:", naziv, label16.Text, label17.Text, label18.Text);
                fs.WriteLine(line);
                
            }

                if (label19.Text.Length > 77)
                {
                    naziv = label19.Text.ToString().Substring(0, 77) + "*";
                }
                else
                {
                    naziv = label19.Text;
                    line = String.Format("{0,-15}{1,-80}{2,-20}{3,-30}{4,-30}", "ZID 3:", naziv, label20.Text, label21.Text, label22.Text);
                    fs.WriteLine(line);
                }

                if (label23.Text.Length > 77)
                {
                    naziv = label23.Text.ToString().Substring(0, 77) + "*";
                }
                else
                {
                    naziv = label23.Text;
                    line = String.Format("{0,-15}{1,-80}{2,-20}{3,-30}{4,-30}", "ZID 4:", naziv, label24.Text, label25.Text, label26.Text);
                    fs.WriteLine(line);
                }
                        if (label27.Text.Length > 77)
                        {
                            naziv = label27.Text.ToString().Substring(0, 77) + "*";
                        }
                        else
                        {
                            naziv = label27.Text;
                            line = String.Format("{0,-15}{1,-80}{2,-20}{3,-30}{4,-30}", "STROP:", naziv, label28.Text, label29.Text, label30.Text);
                            fs.WriteLine(line);
                        }
                            if (label31.Text.Length > 77)
                            {
                                naziv = label31.Text.ToString().Substring(0, 77) + "*";
                            }
                            else
                            {
                                naziv = label31.Text;
                                line = String.Format("{0,-15}{1,-80}{2,-20}{3,-30}{4,-30}", "ZID 4:", naziv, label32.Text, label33.Text, label34.Text);
                                fs.WriteLine(line);
                                fs.WriteLine("");

                                fs.WriteLine("NAZIV SOBE:    " + label38.Text);
                                fs.WriteLine("IME I PREZIME VLASNIKA:     " + label39.Text);
                                fs.WriteLine("ADRESA:     " + label40.Text);
                            }
                                fs.Close();

                                System.Diagnostics.Process.Start(fname);
                            }
        
    }
}
