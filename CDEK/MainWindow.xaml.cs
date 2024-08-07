﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data.SqlClient;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CDEK
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		/// <summary>
		/// Событие MainWindow предназначен для инициализации компонентов.
		/// </summary>
		int countTab = 0;
		public MainWindow()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Событие btnSetApplication_Click предназначен для открытия окна подачи заявок пользователя
		/// </summary>
		/// <param name="sender">Переменная относящаяся к классу Object</param>
		/// <param name="e">Содержит информацию о состоянии и данные события</param>
		private void btnSetApplication_Click(object sender, RoutedEventArgs e)
		{
			ApplicationWin win = new ApplicationWin();
			win.Show();
			this.Close();
		}

		/// <summary>
		/// Событие Autorization_Loaded предназначен для того, чтобы при загрузке окна происходило подключение к базе данных.
		/// </summary>
		/// <param name="sender">Переменная относящаяся к классу Object</param>
		/// <param name="e">Содержит информацию о состоянии и данные события</param>
		private void Autorization_Loaded(object sender, RoutedEventArgs e)
		{
			try
			{
				string sqlConn = @"Data Source = DESKTOP-R2UPGH3\DR; Initial Catalog = CDEK; Integrated Security = True";
				DBConnect.DataBaseConn(sqlConn);
			}
			catch
			{
				MessageBox.Show("No connection");
			}
		}

		/// <summary>
		/// Событие btnSignIn_Click предназначен для того, чтобы менеджер мог зайти на окно заявок
		/// </summary>
		/// <param name="sender">Переменная относящаяся к классу Object</param>
		/// <param name="e">Содержит информацию о состоянии и данные события</param>
		private void btnSignIn_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				bool Autorization;
				DBConnect.SQLQueryAutorization(tbLogin.Text, pbManager.Password, "ManagerTable", "Login", "Password", out Autorization);
				if(Autorization)
				{
					ViewApplicationsWin applicationsWin = new ViewApplicationsWin();
					applicationsWin.Show();
					this.Close();
				}
				else
				{
					MessageBox.Show("Login or password entered incorrectly");
				}
			}
			catch
			{
				MessageBox.Show("No connection or incorrect data entered");
			}
		}

		/// <summary>
		/// Событие pbManager_KeyDown предназначена для отслеживания события нажатия кнопки enter и запуска события btnSetApplication_Click
		/// </summary>
		/// <param name="sender">Переменная относящаяся к классу Object</param>
		/// <param name="e">Содержит информацию о состоянии и данные события</param>
		private void pbManager_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.Key == Key.Enter)
			{
				btnSignIn_Click(sender, e);
			}
		}
	}
}
