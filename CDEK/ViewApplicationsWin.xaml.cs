using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data.Entity.SqlServer;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.Entity;

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
			string tableName = "Table_Application";
			DBConnect.DataBaseConn(sqlConn);
			DataTable dt;
			DBConnect.LoadedDB(tableName, out dt);
			
			dgApplication.ItemsSource = dt.DefaultView;
			//this.Width = dgApplication.Width;
		}

		private void btnReport_Click(object sender, RoutedEventArgs e)
		{
			DataSenderRecipient.id_Application = ((DataRowView)dgApplication.SelectedItem).Row.ItemArray[0].ToString();
			DataSenderRecipient.Firstname_sender = ((DataRowView)dgApplication.SelectedItem).Row.ItemArray[1].ToString();
			DataSenderRecipient.Secondname_sender = ((DataRowView)dgApplication.SelectedItem).Row.ItemArray[2].ToString();
			DataSenderRecipient.Number_phone_sender = ((DataRowView)dgApplication.SelectedItem).Row.ItemArray[3].ToString();
			DataSenderRecipient.Type_package = ((DataRowView)dgApplication.SelectedItem).Row.ItemArray[4].ToString();
			DataSenderRecipient.Adress_sender = ((DataRowView)dgApplication.SelectedItem).Row.ItemArray[5].ToString();
			DataSenderRecipient.Firstname_recipient = ((DataRowView)dgApplication.SelectedItem).Row.ItemArray[6].ToString();
			DataSenderRecipient.Secondname_recipient = ((DataRowView)dgApplication.SelectedItem).Row.ItemArray[7].ToString();
			DataSenderRecipient.Number_phone_recipient = ((DataRowView)dgApplication.SelectedItem).Row.ItemArray[8].ToString();
			DataSenderRecipient.Adress_recipient = ((DataRowView)dgApplication.SelectedItem).Row.ItemArray[9].ToString();
			DataSenderRecipient.Mail = ((DataRowView)dgApplication.SelectedItem).Row.ItemArray[10].ToString();

			ReportWin win = new ReportWin();
			win.Show();
			this.Close();
		}
	}
}
