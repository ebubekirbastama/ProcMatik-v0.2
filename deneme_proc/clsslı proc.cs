using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace deneme_proc
{
    public partial class clsslı_proc : MetroForm
    {
        public clsslı_proc()
        {
            InitializeComponent();
        }
        int a;
        int toplam;
        int asil_sayi;
        int sayac = 1;
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (richTextBox1 .Text !=string .Empty )
                {
                    MessageBox.Show("Please Clearing to Texbox ", "Yazılım Eğitim v0.1(c.)");
                }
                else
                {
            a = int.Parse(metroTextBox1.Text);
            toplam=a * 2;
            asil_sayi = toplam / 2;
            asil_sayi++;
            richTextBox1.AppendText("con = bgl.Baglanti();" + "\n");
            richTextBox1.AppendText("SqlCommand kmt" + metroTextBox1 .Text + " = new SqlCommand(param[0].ToString(), con);" + "\n");
            richTextBox1.AppendText("kmt"+metroTextBox1 .Text +".CommandType = CommandType.StoredProcedure;" + "\n");          
            for (int i = 0; i < a; i++)
            {
                richTextBox1.AppendText("kmt"+metroTextBox1 .Text +".Parameters.AddWithValue(param[" + sayac + "].ToString(), param[" + asil_sayi + "].ToString());" + "\n");
                sayac++;
                asil_sayi++;
            }
            richTextBox1.AppendText("kmt"+metroTextBox1 .Text +".ExecuteNonQuery();" + "\n");
            }
             }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Yazılım Eğitim v0.1(c.)");
            }               
        }
        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            sayac = 1;
        }    
               
    }
}
