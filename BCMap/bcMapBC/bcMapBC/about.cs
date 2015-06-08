
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace bcMapBC
{
	[Activity (Label = "about")]			
	public class about : Activity
	{
		Database sqldb;
	
		TextView shMsg;

		ListView listItem;

			protected override void OnCreate(Bundle bundle)
			{
				base.OnCreate(bundle);

			SetContentView(Resource.Layout.about);

			sqldb = new Database("person_db");
		

				
			shMsg = FindViewById<TextView> (Resource.Id.shMsg);
			listItem = FindViewById<ListView> (Resource.Id.listItems);
			shMsg.Text = sqldb.Message;
			GetCursorView ();
			//GetCursorView ("Type","Qrcode");

			//shMsg.Text = sqldb.Message;
			
//
//				var gridview = FindViewById<GridView>(Resource.Id.gridview);
//				gridview.Adapter = new ImageAdapter(this);
//
//				gridview.ItemClick += (sender, args) => Toast.MakeText(this, args.Position.ToString(), ToastLength.Short).Show();
			}

		void GetCursorView()
		{
			Android.Database.ICursor sqldb_cursor = sqldb.GetRecordCursor ();
			if (sqldb_cursor != null) 
			{
				
				sqldb_cursor.MoveToFirst ();
				string[] from = new string[] {"_id","Type","Location"};
				int[] to = new int[] {
					Resource.Id.Id_row,
					Resource.Id.Name_row,
					Resource.Id.LastName_row,
				
				};
				//Creates a SimplecursorAdapter for ListView object
				SimpleCursorAdapter sqldb_adapter = new SimpleCursorAdapter (this, Resource.Layout.record_view, sqldb_cursor, from, to);
				listItem.Adapter = sqldb_adapter;
			} 
			else 
			{
				shMsg.Text = sqldb.Message;
			}
		}

		void GetCursorView (string sqldb_column, string sqldb_value)
		{
			Android.Database.ICursor sqldb_cursor = sqldb.GetRecordCursor (sqldb_column, sqldb_value);

			if (sqldb_cursor != null) 
			{
				sqldb_cursor.MoveToFirst ();
				string[] from = new string[] {"_id","Type","Location"};
				int[] to = new int[] 
				{
					Resource.Id.Id_row,
					Resource.Id.Name_row,
					Resource.Id.LastName_row,

				};
				Console.WriteLine (to.ToString());
				SimpleCursorAdapter sqldb_adapter = new SimpleCursorAdapter (this, Resource.Layout.record_view, sqldb_cursor, from, to);
				listItem.Adapter = sqldb_adapter;
			} 
			else 
			{
				shMsg.Text = sqldb.Message;
			}
		}
	}
}



