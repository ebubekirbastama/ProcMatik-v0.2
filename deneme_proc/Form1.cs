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
    public partial class Form1 : MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }
        Kütüphane_Otomasyonu.baglanti bgl = new Kütüphane_Otomasyonu.baglanti();
         string isim;
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
            button4.Enabled = true;
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

         private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                isim = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                 button2.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message ,"Ebubekir Bastama");
            }
        }
         string b;
         int sayac = 3;
         int sayacı = 0;
         private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                button5.Enabled = true;
                connection();
                for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
                {
                    b = Convert.ToString("kmt1.Parameters.AddWithValue(" + "@" + dataGridView2.Rows[sayacı].Cells[0].Value.ToString() + "" + "),competent);");
                    dataGridView3.Rows.Add();
                    dataGridView3.Rows[sayac].Cells[0].Value = b;
                    b = string.Empty;
                    sayac++;
                    sayacı++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ebubekir Bastama");
            }
           
        }
         void connection()
        {
            dataGridView3.Rows.Add();
            dataGridView3.Rows[0].Cells[0].Value = "SqlConnection con = bgl.baglantim();";
            dataGridView3.Rows.Add();
            dataGridView3.Rows[1].Cells[0].Value = "SqlCommand kmt = new SqlCommand(param[0].ToString(), con);";
            dataGridView3.Rows.Add();
            dataGridView3.Rows[2].Cells[0].Value = "kmt.CommandType = CommandType.StoredProcedure;";  
        }
         private void button5_Click(object sender, EventArgs e)
         {
             try
             {
                 for (int i = 0; i < dataGridView3 .Rows .Count -1; i++)
                 {

                    richTextBox1.AppendText(dataGridView3.Rows[i].Cells[0].Value.ToString()+"\n");  
                 }
                 richTextBox1.AppendText("kmt.ExecuteNonQuery();" + "\n");
                 richTextBox1.AppendText("con.close();" + "\n"); 
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message ,"Ebubekir Bastama");
             }
         }

         private void Form1_Load(object sender, EventArgs e)
         {
             button4.Enabled = false;
             button2.Enabled = false;
             button5.Enabled = false; 
         }
         
    }
}
