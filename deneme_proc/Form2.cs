using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace deneme_proc
{
    public partial class Form2 : MetroForm
    {
        public Form2()
        {
            InitializeComponent();
            
        }
        private string ozel_karekter="\"";
        Kütüphane_Otomasyonu.baglanti bgl = new Kütüphane_Otomasyonu.baglanti();
        string isim;
        string b;
        int sayacı = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                isim = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                button2.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ebubekir Bastama");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = bgl.baglantim();
                SqlDataAdapter adtr = new SqlDataAdapter("SELECT * FROM sys.tables", con);
                DataTable dt = new DataTable();
                adtr.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ebubekir Bastama");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            button5.Enabled = true;
            try
            {
                SqlConnection con = bgl.baglantim();
                SqlDataAdapter adtr = new SqlDataAdapter("SELECT name FROM   syscolumns WHERE  id = (SELECT id FROM sysobjects WHERE name='" + isim + "')", con);
                DataTable dt = new DataTable();
                adtr.Fill(dt);
                dataGridView2.DataSource = dt;
                con.Close();
                String[] a = new string[dataGridView2.Rows.Count - 1];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ebubekir Bastama");
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                button5.Enabled = true;
                for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
                {
                    b = Convert.ToString("kmt1.Parameters.AddWithValue(" + "@" + dataGridView2.Rows[sayacı].Cells[0].Value.ToString() + "" + "),competent);");
                 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ebubekir Bastama");
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {

            try
            {
                richTextBox1.AppendText("Normal Ayırıcı" + "\n");
                for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
                {
                    if (dataGridView2 .RowCount-2 ==i)
                    {
                        richTextBox1.AppendText(dataGridView2.Rows[i].Cells[0].Value.ToString() );  
                    }
                    else
                    {
                        richTextBox1.AppendText(dataGridView2.Rows[i].Cells[0].Value.ToString() + ",");
                    }
                 
                }
                richTextBox1.AppendText(" " + "\n");
                richTextBox1.AppendText(" " + "\n");
                richTextBox1.AppendText(" " + "\n");
                richTextBox1.AppendText("Class'için olan ayırıcı" + "\n");
                for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
                {
                    if (dataGridView2.RowCount - 2 == i)
                    {
                        richTextBox1.AppendText(ozel_karekter + " " + dataGridView2.Rows[i].Cells[0].Value.ToString() + "" + ozel_karekter + "");
                    }
                    else
                    {
                        richTextBox1.AppendText(ozel_karekter + " " + dataGridView2.Rows[i].Cells[0].Value.ToString() + "" + ozel_karekter + ",");
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ebubekir Bastama");
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button5.Enabled = false; 
        }
        
    }
}
