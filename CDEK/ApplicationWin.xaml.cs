using System;
using System.Collections.Generic;
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
	/// Логика взаимодействия для ApplicationWin.xaml
	/// </summary>
	public partial class ApplicationWin : Window
	{
		public ApplicationWin()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Метод btnSend_Click предназначен для отправки заявки в базу данных
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e">Содержит информацию о состоянии и данные события</param>
		private void btnSend_Click(object sender, RoutedEventArgs e)
		{
			if (tbFirstnameSender.Text != "" && tbSecondnameSender.Text != "" && tbNumberPhoneSender.Text != "" && cmbTypePackage.Text != "" && tbAdressSender.Text != "" && tbFirstnameRecipient.Text != "" && tbSecondnameRecipient.Text != "" && tbNumberPhoneRecipient.Text != "" && tbAdressRecipient.Text != "" && tbMailSender.Text != "") {
				string command = "INSERT Table_Application (Firstname_sender, Secondname_sender, Number_phone_sender, Type_package, Adress_sender, Firstname_recipient, Secondname_recipient, Number_phone_recipient, Adress_recipient, Email) VALUES ('" + tbFirstnameSender.Text + "','" + tbSecondnameSender.Text + "','" + tbNumberPhoneSender.Text + "','" + cmbTypePackage.Text + "','" + tbAdressSender.Text + "','" + tbFirstnameRecipient.Text + "','" + tbSecondnameRecipient.Text + "','" + tbNumberPhoneRecipient.Text + "','" + tbAdressRecipient.Text + "','" + tbMailSender.Text + "');";
				DBConnect.Add_to_table(command);
				this.Close();
			}
			else
			{
				MessageBox.Show("Fill in all the fields.");
			}
		}

		private void AppWin_Loaded(object sender, RoutedEventArgs e)
		{
			string sqlConn = @"Data Source = DESKTOP-R2UPGH3\DR; Initial Catalog = CDEK; Integrated Security = True";
			DBConnect.DataBaseConn(sqlConn);
		}
	}
}
