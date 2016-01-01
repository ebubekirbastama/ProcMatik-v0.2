using Kütüphane_Otomasyonu;
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
    public partial class enity : MetroForm
    {
        public enity()
        {
            InitializeComponent();
        }
        baglanti bgl = new baglanti();
        string tablo_ismi;
        string  kosul_kolonu;
        string kosulkolon;
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                tablo_ismi = dataGridView1.CurrentRow.Cells[0].Value.ToString();
          
               
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
                SqlDataAdapter adtr = new SqlDataAdapter("SELECT name FROM sys.tables", con);
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
            try
            {
                SqlConnection con = bgl.baglantim();
                SqlDataAdapter adtr = new SqlDataAdapter("SELECT * FROM   syscolumns WHERE  id = (SELECT id FROM sysobjects WHERE name='" + tablo_ismi  + "')", con);
                DataTable dt = new DataTable();
                adtr.Fill(dt);
                dataGridView2.DataSource = dt;
                con.Close();
                
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ebubekir Bastama");
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            string sorgu = "select COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, IS_NULLABLE from INFORMATION_SCHEMA.COLUMNS IC where TABLE_NAME ='"+tablo_ismi +"'";
            try
            {
                SqlConnection con = bgl.baglantim();
                SqlDataAdapter adtr = new SqlDataAdapter(sorgu, con);
                DataTable dt = new DataTable();
                adtr.Fill(dt);
                dataGridView3.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ebubekir Bastama");
            }
           
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            try
            {
                richTextBox1.AppendText("public class " + tablo_ismi + "" + "\n");
                richTextBox1.AppendText("{" + "\n");
                for (int i = 0; i < dataGridView3.Rows.Count - 1; i++)
                {
                    richTextBox1.AppendText("public " + dataGridView3.Rows[i].Cells[1].Value.ToString() + " " + dataGridView3.Rows[i].Cells[0].Value.ToString() + "{ get; set; }" + "\n");
                }
                richTextBox1.AppendText("}");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ebubekir Bastama");
            }
           
        }
        int sayac=0;
        int sayacı = 0;
        
        private void button6_Click(object sender, EventArgs e)
        {
          try
            {
                richTextBox2.AppendText("create proc "+"sp_"+ tablo_ismi + "_"+"insert"+ "\n");
                richTextBox2.AppendText("("+"\n");
                for (int i = 0; i < dataGridView3.Rows.Count - 1; i++)
                {
                    if (dataGridView3.Rows[i].Cells[1].Value.ToString() == "int" || dataGridView3.Rows[i].Cells[1].Value.ToString() == "bigint" || dataGridView3.Rows[i].Cells[1].Value.ToString() == "datetime" || dataGridView3.Rows[i].Cells[1].Value.ToString() == "bit" || dataGridView3.Rows[i].Cells[1].Value.ToString() == "date" || dataGridView3.Rows[i].Cells[1].Value.ToString() == "float")//1sn
                    {
                        richTextBox2.AppendText("@" + dataGridView3.Rows[i].Cells[0].Value.ToString() + " " + dataGridView3.Rows[i].Cells[1].Value.ToString() + "" + dataGridView3.Rows[i].Cells[2].Value.ToString() + "" + "" + "," + "\n");    
                    }
                    else
                    {
                      richTextBox2.AppendText("@" + dataGridView3.Rows[i].Cells[0].Value.ToString() + " " + dataGridView3.Rows[i].Cells[1].Value.ToString() +"("+ dataGridView3.Rows[i].Cells[2].Value.ToString() +")"+ "" + "," + "\n");
                    }   
                }
                richTextBox2.AppendText(")"+"\n");
                richTextBox2.AppendText("as"+"\n");
                richTextBox2.AppendText("begin" + "\n");
   
                for (int i = 0; i < dataGridView3.Rows.Count - 1; i++)
                {

                    if (sayac == 0)
                    {
                        richTextBox2.AppendText("insert into " + tablo_ismi + "(" + dataGridView3.Rows[i].Cells[0].Value.ToString() + ",");
                        sayac++;
                    }
                    else
                    {
                        if ( i== dataGridView3.Rows.Count - 2)
                        {
                            richTextBox2.AppendText(dataGridView3.Rows[i].Cells[0].Value.ToString() + ""); 
                        }
                        else
                        {
                            richTextBox2.AppendText(dataGridView3.Rows[i].Cells[0].Value.ToString() + ","); 
                        }
                                            
                    }
                   
                }
                for (int i = 0; i < dataGridView3.Rows.Count - 1; i++)
                {
                    if (sayacı == 0)
                    {
                        richTextBox2.AppendText(")values (" + dataGridView3.Rows[i].Cells[0].Value.ToString());
                        sayacı++;
                    }
                    else
                    {
                        if (i == dataGridView3.Rows.Count - 2)
                        {
                            richTextBox2.AppendText("@" + dataGridView3.Rows[i].Cells[0].Value.ToString() + "");  
                        }
                        else
                        {
                            richTextBox2.AppendText("@" + dataGridView3.Rows[i].Cells[0].Value.ToString() + ",");
                        }
                       
                    }
                }
                richTextBox2.AppendText(")"+"\n");
                richTextBox2.AppendText("end" + "\n");
   

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ebubekir Bastama");
            }
        }

        private void enity_Load(object sender, EventArgs e)
        {
            webBrowser2.Hide();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            richTextBox3.AppendText("create proc " + "sp_" + tablo_ismi + "_"+"update"+"\n" );
            richTextBox3.AppendText("(" + "\n");
            for (int i = 0; i < dataGridView3.Rows.Count - 1; i++)
            {
                if (dataGridView3.Rows[i].Cells[1].Value.ToString() == "int" || dataGridView3.Rows[i].Cells[1].Value.ToString() == "bigint" || dataGridView3.Rows[i].Cells[1].Value.ToString() == "datetime" || dataGridView3.Rows[i].Cells[1].Value.ToString() == "bit" || dataGridView3.Rows[i].Cells[1].Value.ToString() == "date" || dataGridView3.Rows[i].Cells[1].Value.ToString() == "float")//1sn
                {
                    richTextBox3.AppendText("@" + dataGridView3.Rows[i].Cells[0].Value.ToString() + " " + dataGridView3.Rows[i].Cells[1].Value.ToString() + "" + dataGridView3.Rows[i].Cells[2].Value.ToString() + "" + "" + "," + "\n");
                }
                else
                {
                    richTextBox3.AppendText("@" + dataGridView3.Rows[i].Cells[0].Value.ToString() + " " + dataGridView3.Rows[i].Cells[1].Value.ToString() + "(" + dataGridView3.Rows[i].Cells[2].Value.ToString() + ")" + "" + "," + "\n");
                }
            }
            richTextBox3.AppendText(")" + "\n");
            richTextBox3.AppendText("as" + "\n");
            richTextBox3.AppendText("begin" + "\n");
            for (int i = 0; i < dataGridView3.Rows.Count - 1; i++)
            {
               richTextBox2.AppendText("update" + tablo_ismi + ""+"set");
               if (metroGrid1.Rows[i].Cells[0].Value.ToString () != kosul_kolonu)
               {
                   richTextBox3.AppendText(metroGrid1.Rows[i].Cells[0].Value.ToString() + "=" + "@" + metroGrid1.Rows[i].Cells[0].Value.ToString()+ "," +"\n");
               }
               else
               {
                    kosulkolon = metroGrid1.Rows[i].Cells[0].Value.ToString();
               }
            }
            richTextBox3.AppendText("where"+"@"+kosulkolon+"="+kosulkolon+"\n" );

            richTextBox3.AppendText("end" + "\n");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            gtr();
        }
        private void button9_Click(object sender, EventArgs e)
        {
            kosul_kolonu = metroGrid1.CurrentRow.Cells[0].Value.ToString(); 
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string sorgu = "select COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, IS_NULLABLE from INFORMATION_SCHEMA.COLUMNS IC where TABLE_NAME ='" + tablo_ismi + "'";
            try
            {
                SqlConnection con = bgl.baglantim();
                SqlDataAdapter adtr = new SqlDataAdapter(sorgu, con);
                DataTable dt = new DataTable();
                adtr.Fill(dt);
                metroGrid2.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ebubekir Bastama");
            } 
        }
        public void  gtr()
        {
           string sorgu = "select COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, IS_NULLABLE from INFORMATION_SCHEMA.COLUMNS IC where TABLE_NAME ='" + tablo_ismi + "'";
            try
            {
                SqlConnection con = bgl.baglantim();
                SqlDataAdapter adtr = new SqlDataAdapter(sorgu, con);
                DataTable dt = new DataTable();
                adtr.Fill(dt);
                metroGrid1.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ebubekir Bastama");
            }        
        }

        private void button10_Click(object sender, EventArgs e)
        {
            kosul_kolonu = metroGrid2.CurrentRow.Cells[0].Value.ToString(); 
        }

        private void button12_Click(object sender, EventArgs e)
        {
            richTextBox4.AppendText("create proc " + "sp_" + tablo_ismi + "_" + "Delete" + "\n");
            richTextBox4.AppendText("(" + "\n");
            richTextBox4.AppendText("@" + metroGrid2.CurrentRow.Cells[0].Value.ToString() +" "+ metroGrid2.CurrentRow.Cells[1].Value.ToString() + ",\n");
            richTextBox4.AppendText(")" + "\n");
            richTextBox4.AppendText("as" + "\n");
            richTextBox4.AppendText("begin" + "\n");
            richTextBox4.AppendText("delete" + " from " + tablo_ismi + "" + " where" + "" + kosul_kolonu + "=" + "@" + kosul_kolonu + "\n");
            richTextBox4.AppendText("end" + "\n");
        }

    }
}
