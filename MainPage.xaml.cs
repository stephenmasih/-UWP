using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using MySql.Data.MySqlClient;
using System.Text;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App8
{
    public sealed partial class MainPage : Page
    {
        MySqlConnection cn;
        MySqlCommand cmd;
        MySqlDataReader dr;
        
        public MainPage()
        {
            this.InitializeComponent();

        }
        private void btnConn_Click(object sender, RoutedEventArgs e)
        {
            System.Text.EncodingProvider ppp;
            ppp = System.Text.CodePagesEncodingProvider.Instance;
            Encoding.RegisterProvider(ppp);

            string sql = "select * from streetlight";
            cn = new MySqlConnection("server=127.0.0.1;user id=root;database=streetlight; port=3306;charset = utf8");
            cn.Open();
            textBlock1.Text = "Connection established";
            
            cmd = new MySqlCommand(sql, cn);
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    textBlock2.Text = dr["id"].ToString();
                    textBlock3.Text = dr["mode"].ToString();
                    textBlock4.Text = dr["status"].ToString();
                }
            }
            cn.Close();
            
        }
    
    }   
}