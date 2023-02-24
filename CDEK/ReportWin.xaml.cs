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
		public ReportWin()
		{
			InitializeComponent();
		}

		private void RepWin_Loaded(object sender, RoutedEventArgs e)
		{
			tbReport.Text = DataSenderRecipient.id_Application + "\n" + DataSenderRecipient.Firstname_sender + "\n"
							+ DataSenderRecipient.Secondname_sender + "\n" + DataSenderRecipient.Number_phone_sender + "\n"
							+ DataSenderRecipient.Type_package + "\n" + DataSenderRecipient.Adress_sender + "\n"
							+ DataSenderRecipient.Firstname_recipient + "\n" + DataSenderRecipient.Secondname_recipient + "\n"
							+ DataSenderRecipient.Number_phone_recipient + "\n" + DataSenderRecipient.Adress_recipient;
        }
    }
}
