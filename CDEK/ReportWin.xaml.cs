using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Net.Mail;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.Entity.Core.Objects;
using Microsoft.Win32;
using System.IO;
using System.Data;
using System.ComponentModel.DataAnnotations;
using Path = System.IO.Path;
using System.Net;

namespace CDEK
{
	/// <summary>
	/// Логика взаимодействия для ReportWin.xaml
	/// </summary>
	public partial class ReportWin : Window
	{

		int sum;
		SaveFileDialog saveFileDialog = new SaveFileDialog();

		/// <summary>
		/// Событие tbLengthPack_KeyDown предназначено для добавления к сумме, дополнительную плату за длину посылки
		/// </summary>
		/// <param name="sender">Переменная относящаяся к классу Object</param>
		/// <param name="e">Содержит информацию о состоянии и данные события</param>
		private void tbLengthPack_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.Key == Key.Enter)
			{
				sum = (int)(sum + (Convert.ToInt32(tbLengthPack.Text) * 0.25));
				lbSum.Content = sum + "$";
			}
		}

		/// <summary>
		/// Событие tbWidthPack_KeyDown предназначено для добавления к сумме, дополнительную плату за ширину посылки
		/// </summary>
		/// <param name="sender">Переменная относящаяся к классу Object</param>
		/// <param name="e">Содержит информацию о состоянии и данные события</param>
		private void tbWidthPack_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.Key == Key.Enter)
			{
				sum = (int)(sum + (Convert.ToInt32(tbWidthPack.Text) * 0.25));
				lbSum.Content = sum + "$";
			}
		}

		/// <summary>
		/// Событие tbHeightPack_KeyDown предназначено для добавления к сумме, дополнительную плату за высоту посылки
		/// </summary>
		/// <param name="sender">Переменная относящаяся к классу Object</param>
		/// <param name="e">Содержит информацию о состоянии и данные события</param>
		private void tbHeightPack_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Enter)
			{
				sum = (int)(sum + (Convert.ToInt32(tbHeightPack.Text) * 0.25));
				lbSum.Content = sum + "$";
			}
		}

		/// <summary>
		/// Событие btnSaveSend_Click предназначен для сохранения договора в текстовый файл, отправки файла на почту
		/// </summary>
		/// <param name="sender">Переменная относящаяся к классу Object</param>
		/// <param name="e">Содержит информацию о состоянии и данные события</param>
		private async void btnSaveSend_Click(object sender, RoutedEventArgs e)
		{
			/*if (saveFileDialog.ShowDialog() == DialogResult.)
				return;*/
			saveFileDialog.ShowDialog();
			DateTime date = DateTime.Today;
			string fileName = saveFileDialog.FileName;
			string doc = lbNumberApplic.Content + " " + tblNumberApplic.Text + "\n\n" + lbSenderData.Content + "\n\n"
				+ lbFirstname_sender.Content + ": " + tbFirstname_sender.Text + "\n"
				+ lbSecondname.Content + ": " + tbSecondname_sender.Text + "\n"
				+ lbNumber_phone.Content + ": " + tbNumber_phone_sender.Text + "\n"
				+ lbTypePackage.Content + ": " + tbTypePackage.Text + "\n"
				+ lbAdress_sender.Content + ": " + tbAdress_sender.Text + "\n\n"
				+ lbRecipientData.Content + "\n\n"
				+ lbFirstname_recipient.Content + ": " + tbFirstname_recipient.Text + "\n"
				+ lbSecondname_recipient.Content + ": " + tbSecondname_recipient.Text + "\n"
				+ lbNumber_Phone_recipient.Content + ": " + tbNumber_phone_recipient.Text + "\n"
				+ lbAdress_recipient.Content + ": " + tbAdress_recipient.Text + "\n"
				+ lbDeliveryType.Content + ": " + cmbDeliveryCompany.Text + "\n"
				+ lbLengthPack.Content + ": " + tbLengthPack.Text + "\n"
				+ lbWidthPack.Content + ": " + tbWidthPack.Text + "\n"
				+ lbHeightPack.Content + ": " + tbHeightPack.Text + "\n"
				+ "Date: " + date.ToString() + "\n"
				+ lbPrice.Content + ": " + lbSum.Content + "    " + lbSignature.Content + " " + lbSignatureSpace.Content;
			File.WriteAllText(fileName, doc);
			MessageBox.Show("File saved.");

			string path = Path.GetFullPath(fileName);

			MailAddress from = new MailAddress("npl1u1pc@mail.ru", "Company");
			MailAddress to = new MailAddress(DataSenderRecipient.Mail);
			MailMessage message = new MailMessage(from, to);
			message.Subject = "Treaty";
			message.Attachments.Add(new Attachment(path));
			message.Body = "Delivery contract";
			message.IsBodyHtml = true;
			SmtpClient smtpClient = new SmtpClient("smtp.mail.ru", 465);
			smtpClient.Credentials = new NetworkCredential("npl1u1pc@mail.ru", "NPL_npl");
			smtpClient.EnableSsl = true;
			await smtpClient.SendMailAsync(message);

			this.Close();
		}

		public ReportWin()
		{
			InitializeComponent();

			saveFileDialog.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
		}

		/// <summary>
		/// Событие RepWin_Loaded предназначен для автоматического заполнения полей окна при загрузке 
		/// </summary>
		/// <param name="sender">Переменная относящаяся к классу Object</param>
		/// <param name="e">Содержит информацию о состоянии и данные события</param>
		private void RepWin_Loaded(object sender, RoutedEventArgs e)
		{
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

		/// <summary>
		/// Событие cmbDeliveryCompany_SelectionChanged предназначен для вывода цены за доставку, когда происходит выбор в комбобоксе
		/// </summary>
		/// <param name="sender">Переменная относящаяся к классу Object</param>
		/// <param name="e">Содержит информацию о состоянии и данные события</param>
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
