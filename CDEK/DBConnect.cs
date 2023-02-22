using System;
using System.Collections.Generic;
using System.Linq;
//using System.Data.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.Remoting.Contexts;

namespace CDEK
{
	public class DBConnect
	{
		public static SqlConnection sqlConn;

		/// <summary>
		/// Метод DataBaseConn пердназначен для подключения к бд
		/// </summary>
		/// <param name="sql">Переменная в которую нужна присваивать путь подключения к бд</param>
		public static void DataBaseConn(string sql)
		{
			sqlConn = new SqlConnection(sql);
		}

		/// <summary>
		/// Метод был создан для unittest
		/// </summary>
		/// <param name="sql">Переменная в которую нужна присваивать путь подключения к бд</param>
		/// <returns>Возвращает True если подключение к бд произошло, и возвращает False если не было подключения</returns>
		public static bool DBC(string sql)
		{
			sqlConn = new SqlConnection(sql);
			try
			{
				sqlConn.Open();
				sqlConn.Close();
				return true;
			}
			catch
			{
				return false;
			}
		}

		/// <summary>
		/// Метод LoadedDB предназначен для вывода таблицы из бд в DataGrid
		/// </summary>
		/// <param name="sql">Переменная в которую нужна присваивать путь подключения к бд</param>
		/// <param name="nameTable">Название таблицы которую будем выводит в DataGrid</param>
		/// <param name="dt">Переменная для записи в неё таблицы с бд</param>
		public static void LoadedDB(string sql,string nameTable, out DataTable dt)//предназначен при загрузке и выводе определенной таблицы
		{
			
			sqlConn = new SqlConnection(sql);

			sqlConn.Open();

			string Get_Data = "SELECT * FROM [" + nameTable + "]";

			SqlCommand cmd = sqlConn.CreateCommand();
			cmd.CommandText = Get_Data;

			SqlDataAdapter adapter = new SqlDataAdapter(cmd);
			dt = new DataTable("[" + nameTable + "]");

			adapter.Fill(dt);
		}

		/// <summary>
		/// Метод DateFilter предназначен для фильтрации данных в таблице из бд по датам
		/// </summary>
		/// <param name="sql">Переменная в которую нужна присваивать путь подключения к бд</param>
		/// <param name="nameTable">Название таблицы в которой мы будем делать фильтрацию</param>
		/// <param name="Date">Переменная даты по которой происходит фильтрация</param>
		/// <param name="dt">Переменная для записи отфильтрованной таблицы</param>
		public static void DateFilter(string sql, string nameTable , string Date, out DataTable dt)//фильтр по дате
		{
			sqlConn = new SqlConnection(sql);

			sqlConn.Open();

			string Get_Data = "SELECT * FROM [" + nameTable + "] WHERE DATE = " + "'" + Date + "'";
			SqlCommand cmd = sqlConn.CreateCommand();
			cmd.CommandText = Get_Data;

			SqlDataAdapter adapter = new SqlDataAdapter(cmd);
			dt = new DataTable("[" + nameTable + "]");

			adapter.Fill(dt);
		}

		/// <summary>
		/// Метод EventFilter предназначен для фильтрации данных в таблице из бд по событиям
		/// </summary>
		/// <param name="sql">Переменная в которую нужна присваивать путь подключения к бд</param>
		/// <param name="nameTable">Название таблицы в которой мы будем делать фильтрацию</param>
		/// <param name="nameEvent">Переменная для фильтрации таблицы по событиям</param>
		/// <param name="dt">Переменная для записи отфильтрованной таблицы и вывода её</param>
		public static void EventFilter(string sql, string nameTable, string nameEvent, out DataTable dt)//фильтр по событиям
		{
			sqlConn = new SqlConnection(sql);

			sqlConn.Open();

			string Get_Data = "SELECT * FROM [" + nameTable + "] WHERE [Событие] = " + "'" + nameEvent + "'";
			SqlCommand cmd = sqlConn.CreateCommand();
			cmd.CommandText = Get_Data;

			SqlDataAdapter adapter = new SqlDataAdapter(cmd);
			dt = new DataTable("[" + nameTable + "]");

			adapter.Fill(dt);
		}

		/// <summary>
		/// Метод Add_to_table предназначен для добавления данных в таблицу 
		/// </summary>
		/// <param name="sql">Переменная в которую нужна присваивать путь подключения к бд</param>
		/// <param name="command">Пременная в которую мы вносим команду для добавления данных в таблицу бд</param>
		public static void Add_to_table(string sql, string command)
		{
			sqlConn = new SqlConnection(sql);

			sqlConn.Open();
			SqlCommand sqlCommand = new SqlCommand();
			sqlCommand.CommandType = System.Data.CommandType.Text;
			sqlCommand.CommandText = command;
			//"INSERT MAC_Table (MAC) VALUES ('" + macAddresses + "');"
			sqlCommand.Connection = sqlConn;

			//sqlConn.Open();
			sqlCommand.ExecuteNonQuery();
			sqlConn.Close();

		}

		/// <summary>
		/// Метод SQLQueryAutorization предназначен для проверки пароля и логина пользователя 
		/// </summary>
		/// <param name="id">Логин пользователя</param>
		/// <param name="password">Парооль пользователя</param>
		/// <param name="nameTable">Название таблицы где хранятся логин и пароль пользователя</param>
		/// <param name="nameColumnMail">Название столбца Логина</param>
		/// <param name="nameColumnPassword">Название столбца пароля</param>
		/// <param name="Autorization">Логическая переменная в которой записывается True когда пароль и логин совали, и false когда не совпали</param>
		public static void SQLQueryAutorization(string id, string password, string nameTable, string nameColumnMail, string nameColumnPassword, out bool Autorization)//отправление sql-запросов на авторизацию
		{
			string sqlQuery = "SELECT * FROM [dbo].[" + nameTable + "] WHERE [" + nameColumnMail + "]= '" + id + "' and [" + nameColumnPassword + "]='" + password + "'";
			
			using (SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlQuery, sqlConn))
			{
				DataTable table = new DataTable();

				dataAdapter.Fill(table);

				if (table.Rows.Count == 0)
				{
					Autorization = false;
				}
				else
				{
					Autorization = true;
				}
			}
		}
	}
}
