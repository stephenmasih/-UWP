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

namespace ADAPTIVE_UI
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class MainPage : Page
	{
		System.Threading.Timer _timer;

		MySqlConnection cn;
		MySqlCommand cmd;
		MySqlDataReader dr;

		public MainPage()
		{
			this.InitializeComponent();
			_timer = new System.Threading.Timer(new System.Threading.TimerCallback((obj) => Refresh()), null, 0, 5000);

		}
		private async void Refresh()
		{
			//call your database here...
			System.Text.EncodingProvider ppp;
			ppp = System.Text.CodePagesEncodingProvider.Instance;
			Encoding.RegisterProvider(ppp);

			string sql = "select * from airPollution";
			cn = new MySqlConnection("server=127.0.0.1; user id=root; database=airPollution; port=3306; charset = utf8");
			cn.Open();

			//and update the UI afterwards:
			await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
			() =>
			{
				// Your UI update code goes here!
				cmd = new MySqlCommand(sql, cn);
				dr = cmd.ExecuteReader();
				if (dr.HasRows)
				{
					while (dr.Read())
					{
						RPB1.Value = (int)dr["MQ1"];
						

						RPB2.Value = (int)dr["MQ2"];

						RPB3.Value = (int)dr["MQ3"];

						RPB4.Value = (int)dr["MQ4"];

						RPB5.Value = (int)dr["MQ5"];

						RPB6.Value = (int)dr["MQ6"];

						RPB7.Value = (int)dr["MQ7"];

						RPB8.Value = (int)dr["MQ8"];

						RPB9.Value = (int)dr["MQ9"];

						RPB10.Value = (int)dr["TGS2600"];
					}
				}
			});
		}

	}
}
