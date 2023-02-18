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
		public static void DataBaseConn(string sql)
		{
			sqlConn = new SqlConnection(sql);
		}

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
