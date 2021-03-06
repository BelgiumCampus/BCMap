﻿using System;
using Android.Database.Sqlite;
using System.IO;



namespace bcMapBC
{
	class Database
	{

		private SQLiteDatabase sqldb;
		private string sqldb_query;
		private string sqldb_message;
		private bool sqldb_available;
		public Database()
		{
			sqldb_message = "";
			sqldb_available = false;
		}

		public Database(string sqldb_name)
		{
			try
			{
				sqldb_message = "";
				sqldb_available = false;
				CreateDatabase(sqldb_name);
			}
			catch (SQLiteException ex) 
			{
				sqldb_message = ex.Message;
			}
		}

		public bool DatabaseAvailable
		{
			get{ return sqldb_available; }
			set{ sqldb_available = value; }
		}

		public string Message
		{
			get{ return sqldb_message; }
			set{ sqldb_message = value; }
		}

		public void CreateDatabase(string sqldb_name)
		{
			try
			{
				sqldb_message = "";
				string sqldb_location = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
				string sqldb_path = Path.Combine(sqldb_location, sqldb_name);
				bool sqldb_exists = File.Exists(sqldb_path);
				if(!sqldb_exists)
				{
					sqldb = SQLiteDatabase.OpenOrCreateDatabase(sqldb_path,null);
					sqldb_query = "CREATE TABLE IF NOT EXISTS MyTable (_id INTEGER PRIMARY KEY AUTOINCREMENT, Type VARCHAR, Location VARCHAR);";
					sqldb.ExecSQL(sqldb_query);
					sqldb_message = "Database: " + sqldb_name + " created";
				}
				else
				{
					sqldb = SQLiteDatabase.OpenDatabase(sqldb_path, null, DatabaseOpenFlags.OpenReadwrite);
					sqldb_message = "Database: " + sqldb_name + " opened";
				}
				sqldb_available=true;
			}
			catch(SQLiteException ex) 
			{
				sqldb_message = ex.Message;
			}
		}

		public void AddRecord(string sName, string sLastName)
		{
			try
			{
				sqldb_query = "INSERT INTO MyTable (Type, Location) VALUES ('" + sName + "','" + sLastName + "');";
				sqldb.ExecSQL(sqldb_query);
				sqldb_message = "Record saved";
			}
			catch(SQLiteException ex) 
			{
				sqldb_message = ex.Message;
			}
		}





		public Android.Database.ICursor GetRecordCursor()
		{
			Android.Database.ICursor sqldb_cursor = null;
			try
			{
				sqldb_query = "SELECT*FROM MyTable;";
				sqldb_cursor = sqldb.RawQuery(sqldb_query, null);
				if(sqldb_cursor == null)
				{
					sqldb_message = "Record not found";

				}
			}
			catch(SQLiteException ex) 
			{
				sqldb_message = ex.Message;
			}
			return sqldb_cursor;
		}

		public Android.Database.ICursor GetRecordCursor(string sColumn, string sValue)
		{
			Android.Database.ICursor sqldb_cursor = null;
			try
			{
				sqldb_query = "SELECT*FROM MyTable WHERE " + sColumn + " LIKE '" + sValue + "%';";
				sqldb_cursor = sqldb.RawQuery(sqldb_query, null);
				if(sqldb_cursor == null)
				{
					sqldb_message = "Record not found";
				}
			}
			catch(SQLiteException ex) 
			{
				sqldb_message = ex.Message;
			}
			return sqldb_cursor;
		}
	}
}