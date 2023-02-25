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
	/// Логика взаимодействия для ReportWin.xaml
	/// </summary>
	public partial class ReportWin : Window
	{

		int lengt, width, height, sum;

		private void tbLengthPack_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.Key == Key.Enter)
			{
				sum = (int)(sum + (Convert.ToInt32(tbLengthPack.Text) * 0.25));
				lbSum.Content = sum + "$";
			}
		}

		private void tbWidthPack_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.Key == Key.Enter)
			{
				sum = (int)(sum + (Convert.ToInt32(tbLengthPack.Text) * 0.25));
				lbSum.Content = sum + "$";
			}
		}

		private void tbHeightPack_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Enter)
			{
				sum = (int)(sum + (Convert.ToInt32(tbLengthPack.Text) * 0.25));
				lbSum.Content = sum + "$";
			}
		}

		public ReportWin()
		{
			InitializeComponent();
		}

		private void RepWin_Loaded(object sender, RoutedEventArgs e)
		{
			/*tbReport.Text = DataSenderRecipient.id_Application + "\n" + DataSenderRecipient.Firstname_sender + "\n"
							+ DataSenderRecipient.Secondname_sender + "\n" + DataSenderRecipient.Number_phone_sender + "\n"
							+ DataSenderRecipient.Type_package + "\n" + DataSenderRecipient.Adress_sender + "\n"
							+ DataSenderRecipient.Firstname_recipient + "\n" + DataSenderRecipient.Secondname_recipient + "\n"
							+ DataSenderRecipient.Number_phone_recipient + "\n" + DataSenderRecipient.Adress_recipient;*/
			tblNumberApplic.Text = DataSenderRecipient.id_Application;
			tbFirstname_sender.Text = DataSenderRecipient.Firstname_sender;
			tbSecondname_sender.Text = DataSenderRecipient.Secondname_sender;
			tbNumber_phone_sender.Text = DataSenderRecipient.Number_phone_sender;
			tbTypePackage.Text = DataSenderRecipient.Type_package;
			tbAdress_sender.Text = DataSenderRecipient.Adress_sender;
			tbFirstname_recipient.Text = DataSenderRecipient.Firstname_recipient;
			tbSecondname_recipient.Text = DataSenderRecipient.Secondname_recipient;
			tbNumber_phone_recipient.Text = DataSenderRecipient.Number_phone_recipient;
			tbAdress_recipient.Text = DataSenderRecipient.Adress_recipient;

			if(DataSenderRecipient.Type_package == "Message")
			{
				tcDeliveryType.SelectedItem = tbiMessage;
			}
			else if(DataSenderRecipient.Type_package == "Package")
			{
				tcDeliveryType.SelectedItem = tbiPackage;
			}
			else if(DataSenderRecipient.Type_package == "Fragile package")
			{
				tcDeliveryType.SelectedItem = tbiPackage;
			}

		}

		private void cmbDeliveryCompany_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (DataSenderRecipient.Type_package == "Message")
			{
				if(cmbDeliveryCompany.SelectedIndex == 0)
				{
					lbSum.Content = "1$";
				}
				else if(cmbDeliveryCompany.SelectedIndex == 1)
				{
					lbSum.Content = "5$";
				}
				else if(cmbDeliveryCompany.SelectedIndex == 2)
				{
					lbSum.Content = "10$";
				}
			}
			else if (DataSenderRecipient.Type_package == "Package")
			{
				if (cmbDeliveryCompany.SelectedIndex == 0)
				{
					sum = 15;
					lbSum.Content = "15$";
				}
				else if (cmbDeliveryCompany.SelectedIndex == 1)
				{
					sum = 25;
					lbSum.Content = "25$";
				}
				else if (cmbDeliveryCompany.SelectedIndex == 2)
				{
					sum = 35;
					lbSum.Content = "35$";
				}
			}
			else if (DataSenderRecipient.Type_package == "Fragile package")
			{
				if (cmbDeliveryCompany.SelectedIndex == 0)
				{
					sum = 20;
					lbSum.Content = "20$";
				}
				else if (cmbDeliveryCompany.SelectedIndex == 1)
				{
					sum = 40;
					lbSum.Content = "40$";
				}
				else if (cmbDeliveryCompany.SelectedIndex == 2)
				{
					sum = 60;
					lbSum.Content = "60$";
				}
			}
		}
	}
}
