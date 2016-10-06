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
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        public ZadnjaSoba zadnja;
        public zadnjaKuca kuca;
        string cnnstring = @"Data Source=(local)\SQLEXPRESS;Initial Catalog=koeficijent; User ID=sa;Password=QKH4jL7L;";
        int broj=0;
        int a = 0;
        int c = 0;
        
        
    
        private void Form1_Load(object sender, EventArgs e)
        {
            zadnja = new ZadnjaSoba();
            kuca = new zadnjaKuca();
            SqlConnection conn = new SqlConnection(cnnstring);
            conn.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from tablice", conn);
            adapter.Fill(dt);
            conn.Close();
            
            foreach (DataRow row in dt.Rows)
            {
                comboBox1.Items.Add(row["Opis"]);
            }
            DataTable da = new DataTable();
            SqlDataAdapter adap = new SqlDataAdapter("select * from gradevni_dijelovi", conn);
            adap.Fill(da);
            conn.Close();

            foreach (DataRow red in da.Rows)
            {
                comboBox3.Items.Add(red[1]);
            }
            if (dalje.Tag == "1") { }
            else
            {
                button1.Click -= this.button1_Click;
                button1.Click += this.button1_Click_drugi;
                label35.Text = "1.SOBA - ZID 1";
            }
        }

        public void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(cnnstring);
            String sqlStr = "SELECT Rsi, Rse FROM Gradevni_dijelovi WHERE Opis= '" + comboBox3.SelectedItem.ToString() + "';";
           
            //
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        label5.Text = reader.GetValue(0).ToString();
                        label6.Text = reader.GetValue(1).ToString();
                    }
                }
            }
            comboBox3.Enabled = false;   
        }

        public decimal izracun (decimal top, decimal deb) 
            { 
                decimal r=0;
                r = deb / top;
                return r;
            }
        public decimal izracun2(decimal rsi, decimal rse, decimal r1, decimal r2, decimal r3, decimal r4, decimal r5) 
        {
            decimal rt = 0;
            rt = rsi + r1 + r2 + r3 + r4 + r5 + rse;
            return rt;
        }
        public decimal izracun3(decimal rt)
        {
            decimal u = 0;
            if (rt == 0) { u = 0; }
            else 
            {
                u = 1 / rt;
            }
            return u;
        }

        private void Dodaj_sloj_Click(object sender, EventArgs e)
        {
            broj++;
            string faktor = "";
            if (comboBox1.SelectedItem != null)
            {
                SqlConnection conn = new SqlConnection(cnnstring);
                String Combo2 = comboBox2.SelectedItem.ToString();
                Combo2 = Combo2.Substring(0, Combo2.IndexOf("-"));
                String sqlStr = "SELECT Topl_provodljivost FROM " + this.lbl_tbname.Text.ToString() + " WHERE Vrsta= '" + Combo2 + "';";
                //MessageBox.Show(sqlStr);
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    {

                        if (reader.HasRows)
                        {
                            reader.Read();
                            faktor = reader.GetValue(0).ToString();
                        }
                        else
                        {
                            MessageBox.Show("Nema");
                        }
                    }
                }
            }
            else { MessageBox.Show("Niste unijeli potrebne podatke!!"); }

            
            switch (broj)
            {
                case 1:

                    if (string.IsNullOrEmpty(textBox1.Text.ToString()))
                    {
                        MessageBox.Show("Unesite debljinu materijala");
                        label9.Refresh();
                        broj--;
                    }
                    else
                    {
                        label37.Text = comboBox2.SelectedItem.ToString();
                        label37.Visible = true;
                        label11.Visible = true;
                        label12.Visible = false;
                        label13.Visible = false;
                        label14.Visible = false;
                        label15.Visible = false;

                        label9.Visible = true;
                        label9.Text = faktor;//uspisuje faktor
                        label11.Text = textBox1.Text;//spremi debljinu
                        textBox1.Clear();//ocisti kucicu

                        label16.Visible = false;
                        label17.Visible = false;
                        label18.Visible = false;
                        label19.Visible = false;
                    }
                        break;
                    
                case 2:
                        if (string.IsNullOrEmpty(textBox1.Text.ToString()))
                        {
                            MessageBox.Show("Unesite debljinu materijala");
                            label16.Refresh();
                            broj--;
                        }
                        else
                        {
                            label38.Text = comboBox2.SelectedItem.ToString();
                            label38.Visible = true;
                            label11.Visible = true;
                            label12.Visible = true;
                            label13.Visible = false;
                            label14.Visible = false;
                            label15.Visible = false;

                            label16.Text = faktor; //upisuje faktor
                            label12.Text = textBox1.Text; //spremi debljinu na mjesto label12
                            textBox1.Clear();//ocisti kucicu
                            label16.Visible = true;
                            label17.Visible = false;
                            label18.Visible = false;
                            label19.Visible = false;
                        }
                    break;
                case 3:

                    if (string.IsNullOrEmpty(textBox1.Text.ToString()))
                    {
                        MessageBox.Show("Unesite debljinu materijala");
                        label17.Refresh();
                        broj--;
                    }
                    else
                    {
                        label39.Text = comboBox2.SelectedItem.ToString();
                        label39.Visible = true;
                        label11.Visible = true;
                        label12.Visible = true;
                        label13.Visible = true;
                        label14.Visible = false;
                        label15.Visible = false;

                        label17.Text = faktor; //upisuje faktor
                        label13.Text = textBox1.Text; //spremi debljinu na mjesto label12
                        textBox1.Clear();//o
                        label16.Visible = true;
                        label17.Visible = true;
                        label18.Visible = false;
                        label19.Visible = false;
                    }
                    break;
                case 4:
                    if (string.IsNullOrEmpty(textBox1.Text.ToString()))
                    {
                        MessageBox.Show("Unesite debljinu materijala");
                        label14.Refresh();
                        broj--;
                    }
                    else
                    {
                        label40.Text = comboBox2.SelectedItem.ToString();
                        label40.Visible = true;
                        label11.Visible = true;
                        label12.Visible = true;
                        label13.Visible = true;
                        label14.Visible = true;
                        label15.Visible = false;

                        label14.Text = textBox1.Text; //upisuje faktor
                        label18.Text = faktor; //spremi debljinu na mjesto label12
                        textBox1.Clear();//o
                        label16.Visible = true;
                        label17.Visible = true;
                        label18.Visible = true;
                        label19.Visible = false;
                    }
                    break;
                case 5:
                    if (string.IsNullOrEmpty(textBox1.Text.ToString()))
                    {
                        MessageBox.Show("Unesite debljinu materijala");
                        label19.Refresh();
                        broj--;
                    }
                    else
                    {
                        label41.Text = comboBox2.SelectedItem.ToString();
                        label41.Visible = true;
                        label11.Visible = true;
                        label12.Visible = true;
                        label13.Visible = true;
                        label14.Visible = true;
                        label15.Visible = true;

                        label19.Text = faktor; //upisuje faktor
                        label15.Text = textBox1.Text; //spremi debljinu na mjesto label12
                        textBox1.Clear();//o
                        label16.Visible = true;
                        label17.Visible = true;
                        label18.Visible = true;
                        label19.Visible = true;
                    }
                    break;
                case 6: 
                    MessageBox.Show("Dozvoljen je unos maksimalno 5 materijala");
                    break;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //prvo dohvacamo naziv tablice
            string popis = "";
            comboBox2.Items.Clear();
            SqlConnection conn = new SqlConnection(cnnstring);
            conn.Open();
            string sql = "SELECT Popis FROM tablice WHERE Opis = '" + comboBox1.SelectedItem.ToString() + "';";
            //MessageBox.Show(sql);
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            {

                if (reader.HasRows)
                {
                    reader.Read();
                    popis = reader.GetValue(0).ToString();
                    this.lbl_tbname.Text = popis;

                    conn.Close();
                    conn.Open();

                    DataTable dt = new DataTable();
                    string sql2 = "SELECT Vrsta, Gustoca FROM " + popis + ";";
                    //MessageBox.Show(sql2);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql2, conn);
                    adapter.Fill(dt);

                    conn.Close();

                    foreach (DataRow row in dt.Rows)
                    {
                        comboBox2.Items.Add(row["Vrsta"].ToString() + "-   " + row["Gustoca"].ToString() + "  ρ, kg/m³");
                    }

                }
                else
                {
                    MessageBox.Show("nema");
                }
            }
        }

        private void Proracun_Click(object sender, EventArgs e)
        {
           
            if (label9.Text == "-1") { MessageBox.Show("Niste unijeli podatke za izracun"); }
            else
            {
                if (label9.Visible && label11.Visible)
                {
                    label26.Text = izracun(Convert.ToDecimal(label9.Text), Convert.ToDecimal(label11.Text)).ToString("0.00") + "    (m²K)/W";
                    a++;
                }

                if (label16.Visible && label12.Visible)
                {
                    label29.Text = izracun(Convert.ToDecimal(label16.Text), Convert.ToDecimal(label12.Text)).ToString("0.00") + "    (m²K)/W";
                    a++;
                }

                if (label17.Visible && label13.Visible)
                {
                    label30.Text = izracun(Convert.ToDecimal(label17.Text), Convert.ToDecimal(label13.Text)).ToString("0.00") + "    (m²K)/W";
                    a++;
                }

                if (label18.Visible && label14.Visible)
                {
                    label31.Text = izracun(Convert.ToDecimal(label18.Text), Convert.ToDecimal(label14.Text)).ToString("0.00") + "    (m²K)/W";
                    a++;
                }

                if (label19.Visible && label15.Visible)
                {
                    label32.Text = izracun(Convert.ToDecimal(label19.Text), Convert.ToDecimal(label15.Text)).ToString("0.00") + "    (m²K)/W";
                    a++;
                }

                if(label5.Text!="-1" && label6.Text!="-1")
                {
                    if(label26.Text=="Rezultat"){label26.Text="0.00";}
                    if(label29.Text=="Rezultat"){label29.Text="0.00";}
                    if(label30.Text=="Rezultat"){label30.Text="0.00";}
                    if(label31.Text=="Rezultat"){label31.Text="0.00";}
                    if(label32.Text=="Rezultat"){label32.Text="0.00";}
                    label28.Text = izracun2(
                        Convert.ToDecimal(label5.Text.Substring(0,2)),
                        Convert.ToDecimal(label6.Text.Substring(0,2)),
                        Convert.ToDecimal(label26.Text.Substring(0,2)),
                        Convert.ToDecimal(label29.Text.Substring(0,2)),
                        Convert.ToDecimal(label30.Text.Substring(0,2)),
                        Convert.ToDecimal(label31.Text.Substring(0,2)),
                        Convert.ToDecimal(label32.Text.Substring(0,2))).ToString("0.00") + "    (m²K)/W";
                }

                if (label28.Text != "Rezultat") 
                {
                    label34.Text = izracun3(Convert.ToDecimal(label28.Text.Substring(0, 2))).ToString("0.00") + "  W/(m²K)";
                }
                button1.Enabled = true;
            }
        }

        private void dalje_Click(object sender, EventArgs e)
        {
            if(dalje.Tag.ToString() == "1")
            {
                zadnja.ShowDialog();
            }
            if(dalje.Tag.ToString()=="")
            {
                kuca.ShowDialog();
            }
        }
        
        private void ocisti()
        {
            comboBox3.ResetText();
            comboBox2.ResetText();
            comboBox1.ResetText();
            textBox1.ResetText();
            label9.Text="-1";
            label9.Visible = true;
            label11.Text="Materijal 1";
            label11.Visible = true;
            label26.Text = "Rezultat";
            label16.Text="-1";
            label16.Visible = false;
            label12.Text = "Materijal 2";
            label12.Visible = false;
            label29.Text = "Rezultat";
            label17.Text="-1";
            label17.Visible = false;
            label13.Text = "Materijal 3";
            label13.Visible = false;
            label30.Text = "Rezultat";
            label18.Text="-1";
            label18.Visible = false;
            label14.Text = "Materijal 4";
            label14.Visible = false;
            label31.Text = "Rezultat";
            label19.Text="-1";
            label19.Visible = false;
            label15.Text = "Materijal 5";
            label15.Visible = false;
            label32.Text = "Rezultat";
            label28.Text = "Rezultat";
            label34.Text = "Rezultat";
            label37.Text = "Rezultat";
            label38.Text = "Rezultat";
            label39.Text = "Rezultat";
            label40.Text = "Rezultat";
            label41.Text = "Rezultat";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (dalje.Tag.ToString() == "1")
            {
                broj = 0;
                c++;
                switch (c)
                {
                    case 1:
                        label35.Text = "ZID 2";
                        zadnja.label11.Text = comboBox3.SelectedItem.ToString();
                        zadnja.label11.Visible = true;
                        zadnja.label12.Text = a.ToString();
                        a = 0;
                        zadnja.label12.Visible = true;
                        zadnja.label13.Text = label28.Text;
                        zadnja.label13.Visible = true;
                        zadnja.label14.Text = label34.Text;
                        zadnja.label14.Visible = true;
                        ocisti();
                        comboBox3.Enabled = true;
                        button1.Enabled = false;

                        break;
                    case 2:
                        label35.Text = "ZID 3";
                        zadnja.label15.Text = comboBox3.SelectedItem.ToString();
                        zadnja.label15.Visible = true;
                        zadnja.label16.Text = a.ToString();
                        a = 0;
                        zadnja.label16.Visible = true;
                        zadnja.label17.Text = label28.Text;
                        zadnja.label17.Visible = true;
                        zadnja.label18.Text = label34.Text;
                        zadnja.label18.Visible = true;
                        ocisti();
                        button1.Enabled = false;
                        comboBox3.Enabled = true;

                        break;
                    case 3:
                        label35.Text = "ZID 4";
                        zadnja.label19.Text = comboBox3.SelectedItem.ToString();
                        zadnja.label19.Visible = true;
                        zadnja.label20.Text = a.ToString();
                        a = 0;
                        zadnja.label20.Visible = true;
                        zadnja.label21.Text = label28.Text;
                        zadnja.label21.Visible = true;
                        zadnja.label22.Text = label34.Text;
                        zadnja.label22.Visible = true;
                        ocisti();
                        comboBox3.Enabled = true;

                        break;
                    case 4:
                        label35.Text = "STROP";
                        zadnja.label23.Text = comboBox3.SelectedItem.ToString();
                        zadnja.label23.Visible = true;
                        zadnja.label24.Text = a.ToString();
                        a = 0;
                        zadnja.label24.Visible = true;
                        zadnja.label25.Text = label28.Text;
                        zadnja.label25.Visible = true;
                        zadnja.label26.Text = label34.Text;
                        zadnja.label26.Visible = true;
                        ocisti();
                        comboBox3.Enabled = true;
                        button1.Enabled = false;
                        break;
                    case 5:
                        label35.Text = "POD";
                        zadnja.label27.Text = comboBox3.SelectedItem.ToString();
                        zadnja.label27.Visible = true;
                        zadnja.label28.Text = a.ToString();
                        a = 0;
                        zadnja.label28.Visible = true;
                        zadnja.label29.Text = label28.Text;
                        zadnja.label29.Visible = true;
                        zadnja.label30.Text = label34.Text;
                        zadnja.label30.Visible = true;
                        ocisti();
                        comboBox3.Enabled = true;
                        button1.Enabled = false;
                        break;
                    case 6:
                        zadnja.label31.Text = comboBox3.SelectedItem.ToString();
                        zadnja.label31.Visible = true;
                        zadnja.label32.Text = a.ToString();
                        a = 0;
                        zadnja.label32.Visible = true;
                        zadnja.label33.Text = label28.Text;
                        zadnja.label33.Visible = true;
                        zadnja.label34.Text = label34.Text;
                        zadnja.label34.Visible = true;
                        ocisti();
                        comboBox3.Enabled = true;
                        button1.Enabled = false;
                        break;
                    case 7:
                        MessageBox.Show("Dodali ste sve građevinske dijelove jedne prostorije, pritisnite gumb 'Gotovo'");
                        button1.Enabled = false;
                        break;
                }

            }


        }
        private void button1_Click_drugi(object sender, EventArgs e)
        {
            broj = 0;
            c++;
            
            switch (c) 
            {
                case 1:
                    label35.Text = "1.SOBA - ZID 2";
                    kuca.label2.Text = comboBox3.SelectedItem.ToString();
                    kuca.label79.Text = label34.Text;
                    ocisti();
                    comboBox3.Enabled = true;
                    button1.Enabled = false;
                    break;
                case 2:
                    label35.Text = "1.SOBA - ZID 3";
                    kuca.label80.Text = comboBox3.SelectedItem.ToString();
                    kuca.label81.Text = label34.Text;
                    ocisti();
                    comboBox3.Enabled = true;
                    break;
                case 3:
                    label35.Text = "1.SOBA - ZID 4";
                    kuca.label82.Text = comboBox3.SelectedItem.ToString();
                    kuca.label83.Text = label34.Text;
                    ocisti();
                    comboBox3.Enabled = true;
                    button1.Enabled = false;
                    break;
                case 4:
                    label35.Text = "1.SOBA - STROP";
                    kuca.label84.Text = comboBox3.SelectedItem.ToString();
                    kuca.label85.Text = label34.Text;
                    ocisti();
                    comboBox3.Enabled = true;
                    button1.Enabled = false;
                    break;
                case 5:
                    label35.Text = "1.SOBA - POD";
                    kuca.label86.Text = comboBox3.SelectedItem.ToString();
                    kuca.label87.Text = label34.Text;
                    ocisti();
                    comboBox3.Enabled = true;
                    button1.Enabled = false;
                    break;
                case 6:
                    kuca.groupBox2.Visible = true;
                    label35.Text = "2.SOBA - ZID 1";
                    kuca.label88.Text = comboBox3.SelectedItem.ToString();
                    kuca.label89.Text = label34.Text;
                    ocisti();
                    comboBox3.Enabled = true;
                    button1.Enabled = false;
                    break;
                case 7:
                    label35.Text = "2.SOBA - ZID 2";
                    kuca.label26.Text = comboBox3.SelectedItem.ToString();
                    kuca.label24.Text = label34.Text;
                    ocisti();
                    comboBox3.Enabled = true;
                    button1.Enabled = false;
                    break;
                case 8:
                    label35.Text = "2.SOBA - ZID 3";
                    kuca.label23.Text = comboBox3.SelectedItem.ToString();
                    kuca.label22.Text = label34.Text;
                    ocisti();
                    comboBox3.Enabled = true;
                    button1.Enabled = false;
                    break;
                case 9:
                    label35.Text = "2.SOBA - ZID 4";
                    kuca.label21.Text = comboBox3.SelectedItem.ToString();
                    kuca.label20.Text = label34.Text;
                    ocisti();
                    comboBox3.Enabled = true;
                    button1.Enabled = false;
                    break;
                case 10:
                    label35.Text = "2.SOBA - STROP";
                    kuca.label19.Text = comboBox3.SelectedItem.ToString();
                    kuca.label18.Text = label34.Text;
                    ocisti();
                    comboBox3.Enabled = true;
                    button1.Enabled = false;
                    break;
                case 11:
                    label35.Text = "2.SOBA - POD";
                    kuca.label17.Text = comboBox3.SelectedItem.ToString();
                    kuca.label16.Text = label34.Text;
                    ocisti();
                    comboBox3.Enabled = true;
                    button1.Enabled = false;
                    break;
                case 12:
                    kuca.groupBox3.Visible = true;
                    label35.Text = "3.SOBA - ZID 1";
                    kuca.label15.Text = comboBox3.SelectedItem.ToString();
                    kuca.label14.Text = label34.Text;
                    ocisti();
                    comboBox3.Enabled = true;
                    button1.Enabled = false;
                    break;
                case 13:
                    label35.Text = "3.SOBA - ZID 2";
                    kuca.label50.Text = comboBox3.SelectedItem.ToString();
                    kuca.label48.Text = label34.Text;
                    ocisti();
                    comboBox3.Enabled = true;
                    button1.Enabled = false;
                    break;
                case 14:
                    label35.Text = "3.SOBA - ZID 3";
                    kuca.label47.Text = comboBox3.SelectedItem.ToString();
                    kuca.label46.Text = label34.Text;
                    ocisti();
                    comboBox3.Enabled = true;
                    button1.Enabled = false;
                    break;
                case 15:
                    label35.Text = "3.SOBA - ZID 4";
                    kuca.label45.Text = comboBox3.SelectedItem.ToString();
                    kuca.label44.Text = label34.Text;
                    ocisti();
                    comboBox3.Enabled = true;
                    button1.Enabled = false;
                    break;
                case 16:
                    label35.Text = "3.SOBA - STROP";
                    kuca.label43.Text = comboBox3.SelectedItem.ToString();
                    kuca.label42.Text = label34.Text;
                    ocisti();
                    comboBox3.Enabled = true;
                    button1.Enabled = false;
                    break;
                case 17:
                    label35.Text = "3.SOBA - POD";
                    kuca.label41.Text = comboBox3.SelectedItem.ToString();
                    kuca.label40.Text = label34.Text;
                    ocisti();
                    comboBox3.Enabled = true;
                    button1.Enabled = false;
                    break;
                case 18:
                    kuca.groupBox4.Visible = true;
                    label35.Text = "4.SOBA - ZID 1";
                    kuca.label39.Text = comboBox3.SelectedItem.ToString();
                    kuca.label38.Text = label34.Text;
                    ocisti();
                    comboBox3.Enabled = true;
                    button1.Enabled = false;
                    break;
                case 19:
                    label35.Text = "4.SOBA - ZID 2";
                    kuca.label74.Text = comboBox3.SelectedItem.ToString();
                    kuca.label72.Text = label34.Text;
                    ocisti();
                    comboBox3.Enabled = true;
                    button1.Enabled = false;
                    break;
                case 20:
                    label35.Text = "4.SOBA - ZID 3";
                    kuca.label71.Text = comboBox3.SelectedItem.ToString();
                    kuca.label70.Text = label34.Text;
                    ocisti();
                    comboBox3.Enabled = true;
                    button1.Enabled = false;
                    break;
                case 21:
                    label35.Text = "4.SOBA - ZID 4";
                    kuca.label69.Text = comboBox3.SelectedItem.ToString();
                    kuca.label68.Text = label34.Text;
                    ocisti();
                    comboBox3.Enabled = true;
                    button1.Enabled = false;
                    break;
                case 22:
                    label35.Text = "4.SOBA - STROP";
                    kuca.label67.Text = comboBox3.SelectedItem.ToString();
                    kuca.label66.Text = label34.Text;
                    ocisti();
                    comboBox3.Enabled = true;
                    button1.Enabled = false;
                    break;
                case 23:
                    label35.Text = "4.SOBA - POD";
                    kuca.label65.Text = comboBox3.SelectedItem.ToString();
                    kuca.label64.Text = label34.Text;
                    ocisti();
                    comboBox3.Enabled = true;
                    button1.Enabled = false;
                    break;
                case 24:
                    kuca.groupBox5.Visible = true;
                    label35.Text = "5.SOBA - ZID 1";
                    kuca.label63.Text = comboBox3.SelectedItem.ToString();
                    kuca.label62.Text = label34.Text;
                    ocisti();
                    comboBox3.Enabled = true;
                    button1.Enabled = false;
                    break;
                case 25:
                    label35.Text = "5.SOBA - ZID 2";
                    kuca.label109.Text = comboBox3.SelectedItem.ToString();
                    kuca.label107.Text = label34.Text;
                    ocisti();
                    comboBox3.Enabled = true;
                    button1.Enabled = false;
                    break;
                case 26:
                    label35.Text = "5.SOBA - ZID 3";
                    kuca.label106.Text = comboBox3.SelectedItem.ToString();
                    kuca.label105.Text = label34.Text;
                    ocisti();
                    comboBox3.Enabled = true;
                    button1.Enabled = false;
                    break;
                case 27:
                    label35.Text = "5.SOBA - ZID 4";
                    kuca.label104.Text = comboBox3.SelectedItem.ToString();
                    kuca.label103.Text = label34.Text;
                    ocisti();
                    comboBox3.Enabled = true;
                    button1.Enabled = false;
                    break;
                case 28:
                    label35.Text = "5.SOBA - STROP";
                    kuca.label102.Text = comboBox3.SelectedItem.ToString();
                    kuca.label101.Text = label34.Text;
                    ocisti();
                    comboBox3.Enabled = true;
                    button1.Enabled = false;
                    break;
                case 29:
                    label35.Text = "5.SOBA - POD";
                    kuca.label100.Text = comboBox3.SelectedItem.ToString();
                    kuca.label99.Text = label34.Text;
                    ocisti();
                    comboBox3.Enabled = true;
                    button1.Enabled = false;
                    break;
                case 30:
                    kuca.groupBox6.Visible = true;
                    label35.Text = "6.SOBA - ZID 1";
                    kuca.label98.Text = comboBox3.SelectedItem.ToString();
                    kuca.label97.Text = label34.Text;
                    ocisti();
                    comboBox3.Enabled = true;
                    button1.Enabled = false;
                    break;
                case 31:
                    label35.Text = "6.SOBA - ZID 2";
                    kuca.label133.Text = comboBox3.SelectedItem.ToString();
                    kuca.label131.Text = label34.Text;
                    ocisti();
                    comboBox3.Enabled = true;
                    button1.Enabled = false;
                    break;
                case 32:
                    label35.Text = "6.SOBA - ZID 3";
                    kuca.label130.Text = comboBox3.SelectedItem.ToString();
                    kuca.label129.Text = label34.Text;
                    ocisti();
                    comboBox3.Enabled = true;
                    button1.Enabled = false;
                    break;
                case 33:
                    label35.Text = "6.SOBA - ZID 4";
                    kuca.label128.Text = comboBox3.SelectedItem.ToString();
                    kuca.label127.Text = label34.Text;
                    ocisti();
                    comboBox3.Enabled = true;
                    button1.Enabled = false;
                    break;
                case 34:
                    label35.Text = "6.SOBA - STROP";
                    kuca.label126.Text = comboBox3.SelectedItem.ToString();
                    kuca.label125.Text = label34.Text;
                    ocisti();
                    comboBox3.Enabled = true;
                    button1.Enabled = false;
                    break;
                case 35:
                    label35.Text = "6.SOBA - POD";
                    kuca.label124.Text = comboBox3.SelectedItem.ToString();
                    kuca.label123.Text = label34.Text;
                    ocisti();
                    comboBox3.Enabled = true;
                    button1.Enabled = false;
                    break;
                case 36:
                    
                    kuca.label122.Text = comboBox3.SelectedItem.ToString();
                    kuca.label121.Text = label34.Text;
                    ocisti();
                    comboBox3.Enabled = true;
                    button1.Enabled = false;
                    break;
            
            
            
            }
        }

    }
}


