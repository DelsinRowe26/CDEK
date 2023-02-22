using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CDEK
{
	/// <summary>
	/// Логика взаимодействия для ViewApplicationsWin.xaml
	/// </summary>
	public partial class ViewApplicationsWin : Window
	{
		public ViewApplicationsWin()
		{
			InitializeComponent();
		}

		private void ViewApplicationWin_Loaded(object sender, RoutedEventArgs e)
		{
			string sqlConn = @"Data Source = DESKTOP-R2UPGH3\DR; Initial Catalog = CDEK; Integrated Security = True";
			string tableName = "Application_Table";
			DataTable dt;
			DBConnect.LoadedDB(sqlConn, tableName, out dt);


			//int count = dt.Columns.Count;
			
			dgApplication.ItemsSource = dt.DefaultView;
			//dgApplication.Width = dt.Columns.Count;
			//this.Width = dgApplication.Width;
		}
    }
}
