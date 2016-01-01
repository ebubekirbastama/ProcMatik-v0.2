using MetroFramework.Forms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace deneme_proc
{
    public partial class OtoGetset : MetroForm
    {
        public OtoGetset()
        {
            InitializeComponent();
        }
        ArrayList al = new ArrayList();
        mesajlar m = new mesajlar();
        private void metroButton1_Click(object sender, EventArgs e)
        {
            try
            {
                datagriggtr();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message ,m.gnmsg_1.ToString ());
            }
        }
        public void datagriggtr()
        {
            for (int i = 0; i < richTextBox1.Lines.Length; i++)//richTextBox1 satırı kadar döndürüyoruz.
            {
                richTextBox2.AppendText("public YE_"+richTextBox1.Lines [i].ToString () + "\r");//
                richTextBox2.AppendText("{" + "\r");
                richTextBox2.AppendText("get" + "\r");
                richTextBox2.AppendText("{" + "\r");
                richTextBox2.AppendText("return" + richTextBox1.Lines[i].ToString() + "" + ";" + "\r");
                richTextBox2.AppendText("}" + "\r");
                richTextBox2.AppendText("set" + "\r");
                richTextBox2.AppendText("{" + "\r");
                richTextBox2.AppendText(richTextBox1.Lines[i].ToString() + " =value;" + "\r");
                richTextBox2.AppendText("{" + "\r");
            }
        }
        private void metroButton2_Click(object sender, EventArgs e)//bu butonun görevi copy paste yaptığımızverileri temiz hale getirmekmek boşlukları felen atmaktır.
        {
            try
            {
                for (int i = 0; i < richTextBox1.Lines.Length; i++)//richTextBox1dekisatır sayısı kadarverileri döndürüyoruz.
                {
                    al.Add (richTextBox1.Lines[i].ToString ().TrimStart ());//bütün verileri arayliste ekliyoruz.
                }
                richTextBox1.Clear();//temizliyoruz.
                for (int i = 0; i < al.Count ; i++)
                {
                    richTextBox1.AppendText(al[i].ToString ()+"\n");//Temizlediğimiz kodları geri yazıyoruz.
                }
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message ,m.gnmsg_1.ToString ());
            }
        }
    }
}
