//Bu Yapı By Ebubekir Bastama tarından dizayn edilmiş'dir.
//Soru ve görüşleriniz için online 05554128854
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;

//desing by Ebubekir bastama(c.)
namespace Kütüphane_Otomasyonu
{
    class baglanti
    {
        private string server_name;
       
        StreamReader sr;
        private string s;
        public void ayr()
        {
            sr = File.OpenText(@"C:\ayar.txt");
            si = sr.ReadLine();
            svr = si;
            sr.Close();
        }
        public string svr
        {
            get
            {

                return server_name;
            }
            set
            {
                server_name = value;
            }
        }
        public string si
        {
            get
            {

                return s;
            }
            set
            {
                s = value;
            }
        }
        public SqlConnection baglantim()
        {
            //ebubekirbastama
            SqlConnection con = new SqlConnection(@"Server=" + svr + "; Integrated Security=true; Database=StokTakipOtomasyonu");//Bağlantı cümlemiz

            if (con.State == ConnectionState.Closed) // System.Data.SqlClient.ConnectionState using System.Data; kütüphanesinden gelir
            {
                con.Open();//Bağlantıyı Aç
            }
            return con;//con döndür
        }
        
    }
}
