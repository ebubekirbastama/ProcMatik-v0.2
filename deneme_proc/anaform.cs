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
    public partial class anaform : MetroForm
    {
        public anaform()
        {
            InitializeComponent();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.ShowDialog();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            clsslı_proc k = new clsslı_proc();
            k.ShowDialog();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            enity enit = new enity();
            enit.ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/user/Yazilimegitim");
        }

        private void anaform_Load(object sender, EventArgs e)
        {

        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            OtoGetset o=new OtoGetset ();
            o.ShowDialog();
        }
    }
}
