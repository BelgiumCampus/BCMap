using Android.App;
using Android.Views;
using Android.Widget;
using Android.OS;
using ZXing;
using ZXing.Mobile;





namespace bcMapBC
{
	[Activity (Label = "andro", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Android.Support.V4.App.FragmentActivity
	{
		string msg;
		Button buttonScanDefaultView;
		Database sqldb;
		ImageView 	ypsilon,gama,leuven,genk,caffeteria,parking,antwerp,hasselt,admin,
		alpha,theta,brussels,delta,cottage,zeta,reception,beta,library,omega,sigma;
		MobileBarcodeScanner scanner;
		TextView shMsg;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Main);
			sqldb = new Database("person_db");

			//
			shMsg = FindViewById<TextView> (Resource.Id.Shmg);
			shMsg.Text = sqldb.Message;

			//Toast.MakeText(this,   dada, ToastLength.Short).Show();
			//sqldb.GetRecordCursor ();


			//			//
			//			ImageView image = FindViewById<ImageView> (Resource.Id.imageView1);
			//			Bitmap bMap = BitmapFactory.DecodeResource(Resources, Resource.Id.imageView1);
			//			var drawable = image.Drawable;
			//			using (var bitmap = Bitmap.CreateBitmap(drawable.IntrinsicWidth, drawable.IntrinsicHeight, Bitmap.Config.Argb8888))
			//			using(var canvas = new Canvas(bitmap))
			//			{
			//				drawable.SetBounds(0, 0, canvas.Width, canvas.Height);
			//				drawable.Draw(canvas);
			//
			//				var mat = new Matrix();
			//				mat.PostRotate(45);	`
			//				using(var bMapRotate = Bitmap.CreateBitmap(bitmap, 0, 0, bitmap.Width, bitmap.Height, mat, true))
			//					image.SetImageBitmap(bMapRotate);
			//			}
			//			//
			scanner = new MobileBarcodeScanner(this);
			//image1 = this.FindViewById<ImageView>(Resource.Id.imageView1);
			//image2 = this.FindViewById<ImageView>(Resource.Id.imageView2);
			//this section is for the hiding and apearing stars a simpole test
			ypsilon = FindViewById<ImageView>(Resource.Id.ypsilon);
			gama = FindViewById<ImageView>(Resource.Id.gama);
			leuven = FindViewById<ImageView>(Resource.Id.leuven);
			genk = FindViewById<ImageView>(Resource.Id.genk);
			caffeteria = FindViewById<ImageView>(Resource.Id.caffeteria);
			parking = FindViewById<ImageView>(Resource.Id.parking);
			antwerp = FindViewById<ImageView>(Resource.Id.antwerp);
			hasselt = FindViewById<ImageView>(Resource.Id.hasselt);
			admin = FindViewById<ImageView>(Resource.Id.adminOffice);
			alpha = FindViewById<ImageView>(Resource.Id.alpha);
			theta = FindViewById<ImageView>(Resource.Id.theta);
			brussels = FindViewById<ImageView>(Resource.Id.brussels);
			delta = FindViewById<ImageView>(Resource.Id.delta);
			cottage = FindViewById<ImageView>(Resource.Id.COTTAGE);
			reception = FindViewById<ImageView>(Resource.Id.rep);
			beta = FindViewById<ImageView>(Resource.Id.Beta);
			zeta = FindViewById<ImageView>(Resource.Id.zetandthem);
			library = FindViewById<ImageView>(Resource.Id.library);
			omega = FindViewById<ImageView>(Resource.Id.omega);
			sigma = FindViewById<ImageView> (Resource.Id.sigma);
			shMsg.Text = sqldb.Message;


			//
			buttonScanDefaultView = FindViewById<Button>(Resource.Id.button1);
			buttonScanDefaultView.Click += async delegate {
				scanner.UseCustomOverlay = false;
				scanner.TopText = "Hold the camera up to the barcode\nAbout 6 inches away";
				scanner.BottomText = "Wait for the Qrcode to automatically scan!";
				var result = await scanner.Scan();

				HandleScanResult(result);
			};

		}
		//menu poplualtion 
		//menu poplualtion 
		public override bool OnCreateOptionsMenu(IMenu menu)
		{
			menu.Add (0, 0, 0, "databse test");
			menu.Add (0, 1, 2, "grid view test");

			return true;
		}

		public override bool OnOptionsItemSelected(IMenuItem item)
		{
			switch (item.ItemId)
			{
			case 0:
				//Toast.MakeText (this, "welcome nja", ToastLength.Short).Show ();
				StartActivity (typeof(about) );
				return true;
			case 1: StartActivity (typeof(Activity1) );
				return true;
			default:
				return base.OnOptionsItemSelected(item);
			}
		}
		//menu poplualtion 
		//menu poplualtion 

		void HandleScanResult (ZXing.Result result)
		{
			msg = "";

			if (result != null && !string.IsNullOrEmpty(result.Text))
				msg = result.Text;
			else
				msg = "Scanning Canceled!";

			RunOnUiThread(() => Toast.MakeText(this, msg, ToastLength.Short).Show());
			if (msg =="boss") {

				//Toast.MakeText(this, "the boss is here dooood", ToastLength.Short).Show();
				//image1.SetImageResource (Resource.Drawable.testcolour);

			}
			else if (msg =="boss2") {

				//Toast.MakeText(this, "the boss is here dooood", ToastLength.Short).Show();
				//image2.SetImageResource (Resource.Drawable.pic2);


			}


			// togggle the visibility to change based on diffent inputs
			if (msg == "ypsilon") {
				ypsilon.Visibility = ViewStates.Visible;


				sqldb.AddRecord("QRcode",result.Text);
				//Toast.MakeText(this, sqldb.Message, ToastLength.Short).Show();
				shMsg.Text = sqldb.Message;
				//
				sigma.Visibility = ViewStates.Invisible;
				omega.Visibility = ViewStates.Invisible;
				library.Visibility = ViewStates.Invisible;
				zeta.Visibility = ViewStates.Invisible;
				cottage.Visibility = ViewStates.Invisible;
				delta.Visibility = ViewStates.Invisible;
				brussels.Visibility = ViewStates.Invisible;
				theta.Visibility = ViewStates.Invisible;
				alpha.Visibility = ViewStates.Invisible;
				hasselt.Visibility= ViewStates.Invisible;
				antwerp.Visibility = ViewStates.Invisible;
				parking.Visibility= ViewStates.Invisible;
				caffeteria.Visibility= ViewStates.Invisible;
				genk.Visibility = ViewStates.Invisible;
				leuven.Visibility = ViewStates.Invisible;
				gama.Visibility = ViewStates.Invisible;
				beta.Visibility = ViewStates.Invisible;
				reception.Visibility = ViewStates.Invisible;
				admin.Visibility = ViewStates.Invisible;


			} else if (msg == "gama") {
				gama.Visibility = ViewStates.Visible;
				Toast.MakeText(this,  result.Text, ToastLength.Short).Show();
				//
				sigma.Visibility = ViewStates.Invisible;
				omega.Visibility = ViewStates.Invisible;
				library.Visibility = ViewStates.Invisible;
				zeta.Visibility = ViewStates.Invisible;
				cottage.Visibility = ViewStates.Invisible;
				delta.Visibility = ViewStates.Invisible;
				brussels.Visibility = ViewStates.Invisible;
				theta.Visibility = ViewStates.Invisible;
				alpha.Visibility = ViewStates.Invisible;
				hasselt.Visibility= ViewStates.Invisible;
				antwerp.Visibility = ViewStates.Invisible;
				parking.Visibility= ViewStates.Invisible;
				caffeteria.Visibility= ViewStates.Invisible;
				genk.Visibility = ViewStates.Invisible;
				leuven.Visibility = ViewStates.Invisible;
				beta.Visibility = ViewStates.Invisible;
				reception.Visibility = ViewStates.Invisible;
				admin.Visibility = ViewStates.Invisible;
				ypsilon.Visibility = ViewStates.Invisible;

			} else if (msg == "leuven") {
				leuven.Visibility = ViewStates.Visible;
				Toast.MakeText(this,  result.Text, ToastLength.Short).Show();
				//
				sigma.Visibility = ViewStates.Invisible;
				omega.Visibility = ViewStates.Invisible;
				library.Visibility = ViewStates.Invisible;
				zeta.Visibility = ViewStates.Invisible;
				cottage.Visibility = ViewStates.Invisible;
				delta.Visibility = ViewStates.Invisible;
				brussels.Visibility = ViewStates.Invisible;
				theta.Visibility = ViewStates.Invisible;
				alpha.Visibility = ViewStates.Invisible;
				hasselt.Visibility= ViewStates.Invisible;
				antwerp.Visibility = ViewStates.Invisible;
				parking.Visibility= ViewStates.Invisible;
				caffeteria.Visibility= ViewStates.Invisible;
				genk.Visibility = ViewStates.Invisible;
				gama.Visibility = ViewStates.Invisible;
				beta.Visibility = ViewStates.Invisible;
				reception.Visibility = ViewStates.Invisible;
				admin.Visibility = ViewStates.Invisible;
				ypsilon.Visibility = ViewStates.Invisible;
			} 
			else if (msg == "genk") {
				genk.Visibility = ViewStates.Visible;
				Toast.MakeText(this,  result.Text, ToastLength.Short).Show();
				//
				sigma.Visibility = ViewStates.Invisible;
				omega.Visibility = ViewStates.Invisible;
				library.Visibility = ViewStates.Invisible;
				zeta.Visibility = ViewStates.Invisible;
				cottage.Visibility = ViewStates.Invisible;
				delta.Visibility = ViewStates.Invisible;
				brussels.Visibility = ViewStates.Invisible;
				theta.Visibility = ViewStates.Invisible;
				alpha.Visibility = ViewStates.Invisible;
				hasselt.Visibility= ViewStates.Invisible;
				antwerp.Visibility = ViewStates.Invisible;
				parking.Visibility= ViewStates.Invisible;
				caffeteria.Visibility= ViewStates.Invisible;
				leuven.Visibility = ViewStates.Invisible;
				gama.Visibility = ViewStates.Invisible;
				beta.Visibility = ViewStates.Invisible;
				reception.Visibility = ViewStates.Invisible;
				admin.Visibility = ViewStates.Invisible;
				ypsilon.Visibility = ViewStates.Invisible;

			}
			else if (msg == "caffeteria") {
				caffeteria.Visibility = ViewStates.Visible;
				Toast.MakeText(this,  result.Text, ToastLength.Short).Show();
				//
				sigma.Visibility = ViewStates.Invisible;
				omega.Visibility = ViewStates.Invisible;
				library.Visibility = ViewStates.Invisible;
				zeta.Visibility = ViewStates.Invisible;
				cottage.Visibility = ViewStates.Invisible;
				delta.Visibility = ViewStates.Invisible;
				brussels.Visibility = ViewStates.Invisible;
				theta.Visibility = ViewStates.Invisible;
				alpha.Visibility = ViewStates.Invisible;
				hasselt.Visibility= ViewStates.Invisible;
				antwerp.Visibility = ViewStates.Invisible;
				parking.Visibility= ViewStates.Invisible;
				genk.Visibility = ViewStates.Invisible;
				leuven.Visibility = ViewStates.Invisible;
				gama.Visibility = ViewStates.Invisible;
				beta.Visibility = ViewStates.Invisible;
				reception.Visibility = ViewStates.Invisible;
				admin.Visibility = ViewStates.Invisible;
				ypsilon.Visibility = ViewStates.Invisible;

			} else if (msg == "parking") {
				parking.Visibility = ViewStates.Visible;
				Toast.MakeText(this,  result.Text, ToastLength.Short).Show();
				//
				sigma.Visibility = ViewStates.Invisible;
				omega.Visibility = ViewStates.Invisible;
				library.Visibility = ViewStates.Invisible;
				zeta.Visibility = ViewStates.Invisible;
				cottage.Visibility = ViewStates.Invisible;
				delta.Visibility = ViewStates.Invisible;
				brussels.Visibility = ViewStates.Invisible;
				theta.Visibility = ViewStates.Invisible;
				alpha.Visibility = ViewStates.Invisible;
				hasselt.Visibility= ViewStates.Invisible;
				antwerp.Visibility = ViewStates.Invisible;
				caffeteria.Visibility= ViewStates.Invisible;
				genk.Visibility = ViewStates.Invisible;
				leuven.Visibility = ViewStates.Invisible;
				gama.Visibility = ViewStates.Invisible;
				beta.Visibility = ViewStates.Invisible;
				reception.Visibility = ViewStates.Invisible;
				admin.Visibility = ViewStates.Invisible;
				ypsilon.Visibility = ViewStates.Invisible;
			} else if (msg == "antwerp") {
				antwerp.Visibility = ViewStates.Visible;
				Toast.MakeText(this,  result.Text, ToastLength.Short).Show();
				//
				sigma.Visibility = ViewStates.Invisible;
				omega.Visibility = ViewStates.Invisible;
				library.Visibility = ViewStates.Invisible;
				zeta.Visibility = ViewStates.Invisible;
				cottage.Visibility = ViewStates.Invisible;
				delta.Visibility = ViewStates.Invisible;
				brussels.Visibility = ViewStates.Invisible;
				theta.Visibility = ViewStates.Invisible;
				alpha.Visibility = ViewStates.Invisible;
				hasselt.Visibility= ViewStates.Invisible;
				parking.Visibility= ViewStates.Invisible;
				caffeteria.Visibility= ViewStates.Invisible;
				genk.Visibility = ViewStates.Invisible;
				leuven.Visibility = ViewStates.Invisible;
				gama.Visibility = ViewStates.Invisible;
				beta.Visibility = ViewStates.Invisible;
				reception.Visibility = ViewStates.Invisible;
				admin.Visibility = ViewStates.Invisible;
				ypsilon.Visibility = ViewStates.Invisible;
			} else if (msg == "hasselt") {
				hasselt.Visibility = ViewStates.Visible;
				Toast.MakeText(this,  result.Text, ToastLength.Short).Show();

				//
				sigma.Visibility = ViewStates.Invisible;
				omega.Visibility = ViewStates.Invisible;
				library.Visibility = ViewStates.Invisible;
				zeta.Visibility = ViewStates.Invisible;
				cottage.Visibility = ViewStates.Invisible;
				delta.Visibility = ViewStates.Invisible;
				brussels.Visibility = ViewStates.Invisible;
				theta.Visibility = ViewStates.Invisible;
				alpha.Visibility = ViewStates.Invisible;
				antwerp.Visibility = ViewStates.Invisible;
				parking.Visibility= ViewStates.Invisible;
				caffeteria.Visibility= ViewStates.Invisible;
				genk.Visibility = ViewStates.Invisible;
				leuven.Visibility = ViewStates.Invisible;
				gama.Visibility = ViewStates.Invisible;
				beta.Visibility = ViewStates.Invisible;
				reception.Visibility = ViewStates.Invisible;
				admin.Visibility = ViewStates.Invisible;
				ypsilon.Visibility = ViewStates.Invisible;

			} else if (msg == "alpha") {
				alpha.Visibility = ViewStates.Visible;
				sqldb.AddRecord("QRcode",result.Text);
				//Toast.MakeText(this, sqldb.Message, ToastLength.Short).Show();
				shMsg.Text = sqldb.Message;
				//
				sigma.Visibility = ViewStates.Invisible;
				omega.Visibility = ViewStates.Invisible;
				library.Visibility = ViewStates.Invisible;
				zeta.Visibility = ViewStates.Invisible;
				cottage.Visibility = ViewStates.Invisible;
				delta.Visibility = ViewStates.Invisible;
				brussels.Visibility = ViewStates.Invisible;
				theta.Visibility = ViewStates.Invisible;
				hasselt.Visibility= ViewStates.Invisible;
				antwerp.Visibility = ViewStates.Invisible;
				parking.Visibility= ViewStates.Invisible;
				caffeteria.Visibility= ViewStates.Invisible;
				genk.Visibility = ViewStates.Invisible;
				leuven.Visibility = ViewStates.Invisible;
				gama.Visibility = ViewStates.Invisible;
				beta.Visibility = ViewStates.Invisible;
				reception.Visibility = ViewStates.Invisible;
				admin.Visibility = ViewStates.Invisible;
				ypsilon.Visibility = ViewStates.Invisible;
			} else if (msg == "theta") {
				theta.Visibility = ViewStates.Visible;
				Toast.MakeText(this,  result.Text, ToastLength.Short).Show();
				//
				sigma.Visibility = ViewStates.Invisible;
				omega.Visibility = ViewStates.Invisible;
				library.Visibility = ViewStates.Invisible;
				zeta.Visibility = ViewStates.Invisible;
				cottage.Visibility = ViewStates.Invisible;
				delta.Visibility = ViewStates.Invisible;
				brussels.Visibility = ViewStates.Invisible;
				alpha.Visibility = ViewStates.Invisible;
				hasselt.Visibility= ViewStates.Invisible;
				antwerp.Visibility = ViewStates.Invisible;
				parking.Visibility= ViewStates.Invisible;
				caffeteria.Visibility= ViewStates.Invisible;
				genk.Visibility = ViewStates.Invisible;
				leuven.Visibility = ViewStates.Invisible;
				gama.Visibility = ViewStates.Invisible;
				beta.Visibility = ViewStates.Invisible;
				reception.Visibility = ViewStates.Invisible;
				admin.Visibility = ViewStates.Invisible;
				ypsilon.Visibility = ViewStates.Invisible;
			} else if (msg == "brussels") {
				brussels.Visibility = ViewStates.Visible;
				Toast.MakeText(this,  result.Text, ToastLength.Short).Show();

				//
				sigma.Visibility = ViewStates.Invisible;
				omega.Visibility = ViewStates.Invisible;
				library.Visibility = ViewStates.Invisible;
				zeta.Visibility = ViewStates.Invisible;
				cottage.Visibility = ViewStates.Invisible;
				delta.Visibility = ViewStates.Invisible;
				theta.Visibility = ViewStates.Invisible;
				alpha.Visibility = ViewStates.Invisible;
				hasselt.Visibility= ViewStates.Invisible;
				antwerp.Visibility = ViewStates.Invisible;
				parking.Visibility= ViewStates.Invisible;
				caffeteria.Visibility= ViewStates.Invisible;
				genk.Visibility = ViewStates.Invisible;
				leuven.Visibility = ViewStates.Invisible;
				gama.Visibility = ViewStates.Invisible;
				beta.Visibility = ViewStates.Invisible;
				reception.Visibility = ViewStates.Invisible;
				admin.Visibility = ViewStates.Invisible;
				ypsilon.Visibility = ViewStates.Invisible;
			}else if (msg == "delta") {
				delta.Visibility = ViewStates.Visible;
				Toast.MakeText(this,  result.Text, ToastLength.Short).Show();

				//
				sigma.Visibility = ViewStates.Invisible;
				omega.Visibility = ViewStates.Invisible;
				library.Visibility = ViewStates.Invisible;
				zeta.Visibility = ViewStates.Invisible;
				cottage.Visibility = ViewStates.Invisible;
				brussels.Visibility = ViewStates.Invisible;
				theta.Visibility = ViewStates.Invisible;
				alpha.Visibility = ViewStates.Invisible;
				hasselt.Visibility= ViewStates.Invisible;
				antwerp.Visibility = ViewStates.Invisible;
				parking.Visibility= ViewStates.Invisible;
				caffeteria.Visibility= ViewStates.Invisible;
				genk.Visibility = ViewStates.Invisible;
				leuven.Visibility = ViewStates.Invisible;
				gama.Visibility = ViewStates.Invisible;
				beta.Visibility = ViewStates.Invisible;
				reception.Visibility = ViewStates.Invisible;
				admin.Visibility = ViewStates.Invisible;
				ypsilon.Visibility = ViewStates.Invisible;
			}
			else if (msg == "cottage") {
				cottage.Visibility = ViewStates.Visible;
				Toast.MakeText(this,  result.Text, ToastLength.Short).Show();

				//
				sigma.Visibility = ViewStates.Invisible;
				omega.Visibility = ViewStates.Invisible;
				library.Visibility = ViewStates.Invisible;
				zeta.Visibility = ViewStates.Invisible;
				delta.Visibility = ViewStates.Invisible;
				brussels.Visibility = ViewStates.Invisible;
				theta.Visibility = ViewStates.Invisible;
				alpha.Visibility = ViewStates.Invisible;
				hasselt.Visibility= ViewStates.Invisible;
				antwerp.Visibility = ViewStates.Invisible;
				parking.Visibility= ViewStates.Invisible;
				caffeteria.Visibility= ViewStates.Invisible;
				genk.Visibility = ViewStates.Invisible;
				leuven.Visibility = ViewStates.Invisible;
				gama.Visibility = ViewStates.Invisible;
				beta.Visibility = ViewStates.Invisible;
				reception.Visibility = ViewStates.Invisible;
				admin.Visibility = ViewStates.Invisible;
				ypsilon.Visibility = ViewStates.Invisible;
			}else if (msg == "zeta") {
				zeta.Visibility = ViewStates.Visible;
				Toast.MakeText(this,  result.Text, ToastLength.Short).Show();

				//
				sigma.Visibility = ViewStates.Invisible;
				omega.Visibility = ViewStates.Invisible;
				library.Visibility = ViewStates.Invisible;
				cottage.Visibility = ViewStates.Invisible;
				delta.Visibility = ViewStates.Invisible;
				brussels.Visibility = ViewStates.Invisible;
				theta.Visibility = ViewStates.Invisible;
				alpha.Visibility = ViewStates.Invisible;
				hasselt.Visibility= ViewStates.Invisible;
				antwerp.Visibility = ViewStates.Invisible;
				parking.Visibility= ViewStates.Invisible;
				caffeteria.Visibility= ViewStates.Invisible;
				genk.Visibility = ViewStates.Invisible;
				leuven.Visibility = ViewStates.Invisible;
				gama.Visibility = ViewStates.Invisible;
				beta.Visibility = ViewStates.Invisible;
				reception.Visibility = ViewStates.Invisible;
				admin.Visibility = ViewStates.Invisible;
				ypsilon.Visibility = ViewStates.Invisible;
				gama.Visibility = ViewStates.Invisible;
			}else if (msg == "library") {
				library.Visibility = ViewStates.Visible;
				Toast.MakeText(this,  result.Text, ToastLength.Short).Show();

				//
				sigma.Visibility = ViewStates.Invisible;
				omega.Visibility = ViewStates.Invisible;
				zeta.Visibility = ViewStates.Invisible;
				cottage.Visibility = ViewStates.Invisible;
				delta.Visibility = ViewStates.Invisible;
				brussels.Visibility = ViewStates.Invisible;
				theta.Visibility = ViewStates.Invisible;
				alpha.Visibility = ViewStates.Invisible;
				hasselt.Visibility= ViewStates.Invisible;
				antwerp.Visibility = ViewStates.Invisible;
				parking.Visibility= ViewStates.Invisible;
				caffeteria.Visibility= ViewStates.Invisible;
				genk.Visibility = ViewStates.Invisible;
				leuven.Visibility = ViewStates.Invisible;
				gama.Visibility = ViewStates.Invisible;
				beta.Visibility = ViewStates.Invisible;
				reception.Visibility = ViewStates.Invisible;
				admin.Visibility = ViewStates.Invisible;
				ypsilon.Visibility = ViewStates.Invisible;
			}else if (msg == "omega") {
				omega.Visibility = ViewStates.Visible;
				Toast.MakeText(this,  result.Text, ToastLength.Short).Show();

				//
				sigma.Visibility = ViewStates.Invisible;
				library.Visibility = ViewStates.Invisible;
				zeta.Visibility = ViewStates.Invisible;
				cottage.Visibility = ViewStates.Invisible;
				delta.Visibility = ViewStates.Invisible;
				brussels.Visibility = ViewStates.Invisible;
				theta.Visibility = ViewStates.Invisible;
				alpha.Visibility = ViewStates.Invisible;
				hasselt.Visibility= ViewStates.Invisible;
				antwerp.Visibility = ViewStates.Invisible;
				parking.Visibility= ViewStates.Invisible;
				caffeteria.Visibility= ViewStates.Invisible;
				genk.Visibility = ViewStates.Invisible;
				leuven.Visibility = ViewStates.Invisible;
				gama.Visibility = ViewStates.Invisible;
				beta.Visibility = ViewStates.Invisible;
				reception.Visibility = ViewStates.Invisible;
				admin.Visibility = ViewStates.Invisible;
				ypsilon.Visibility = ViewStates.Invisible;
			}else if (msg == "sigma") {
				sigma.Visibility = ViewStates.Visible;
				Toast.MakeText(this,  result.Text, ToastLength.Short).Show();

				//
				omega.Visibility = ViewStates.Invisible;
				library.Visibility = ViewStates.Invisible;
				zeta.Visibility = ViewStates.Invisible;
				cottage.Visibility = ViewStates.Invisible;
				delta.Visibility = ViewStates.Invisible;
				brussels.Visibility = ViewStates.Invisible;
				theta.Visibility = ViewStates.Invisible;
				alpha.Visibility = ViewStates.Invisible;
				hasselt.Visibility= ViewStates.Invisible;
				antwerp.Visibility = ViewStates.Invisible;
				parking.Visibility= ViewStates.Invisible;
				caffeteria.Visibility= ViewStates.Invisible;
				genk.Visibility = ViewStates.Invisible;
				leuven.Visibility = ViewStates.Invisible;
				gama.Visibility = ViewStates.Invisible;
				beta.Visibility = ViewStates.Invisible;
				reception.Visibility = ViewStates.Invisible;
				admin.Visibility = ViewStates.Invisible;
				ypsilon.Visibility = ViewStates.Invisible;
			}
			else if (msg == "beta") {
				beta.Visibility = ViewStates.Visible;
				Toast.MakeText(this,  result.Text, ToastLength.Short).Show();
				//
				sigma.Visibility = ViewStates.Invisible;
				omega.Visibility = ViewStates.Invisible;
				library.Visibility = ViewStates.Invisible;
				zeta.Visibility = ViewStates.Invisible;
				cottage.Visibility = ViewStates.Invisible;
				delta.Visibility = ViewStates.Invisible;
				brussels.Visibility = ViewStates.Invisible;
				theta.Visibility = ViewStates.Invisible;
				alpha.Visibility = ViewStates.Invisible;
				hasselt.Visibility= ViewStates.Invisible;
				antwerp.Visibility = ViewStates.Invisible;
				parking.Visibility= ViewStates.Invisible;
				caffeteria.Visibility= ViewStates.Invisible;
				genk.Visibility = ViewStates.Invisible;
				leuven.Visibility = ViewStates.Invisible;
				gama.Visibility = ViewStates.Invisible;
				reception.Visibility = ViewStates.Invisible;
				admin.Visibility = ViewStates.Invisible;
				ypsilon.Visibility = ViewStates.Invisible;
			}
			else if (msg == "reception") {
				reception.Visibility = ViewStates.Visible;
				Toast.MakeText(this,  result.Text, ToastLength.Short).Show();
				//
				sigma.Visibility = ViewStates.Invisible;
				omega.Visibility = ViewStates.Invisible;
				library.Visibility = ViewStates.Invisible;
				zeta.Visibility = ViewStates.Invisible;
				cottage.Visibility = ViewStates.Invisible;
				delta.Visibility = ViewStates.Invisible;
				brussels.Visibility = ViewStates.Invisible;
				theta.Visibility = ViewStates.Invisible;
				alpha.Visibility = ViewStates.Invisible;
				hasselt.Visibility= ViewStates.Invisible;
				antwerp.Visibility = ViewStates.Invisible;
				parking.Visibility= ViewStates.Invisible;
				caffeteria.Visibility= ViewStates.Invisible;
				genk.Visibility = ViewStates.Invisible;
				leuven.Visibility = ViewStates.Invisible;
				gama.Visibility = ViewStates.Invisible;
				beta.Visibility = ViewStates.Invisible;
				admin.Visibility = ViewStates.Invisible;
				ypsilon.Visibility = ViewStates.Invisible;
			}
			else if (msg == "admin") {
				admin.Visibility = ViewStates.Visible;
				Toast.MakeText(this,  result.Text, ToastLength.Short).Show();
				//
				sigma.Visibility = ViewStates.Invisible;
				omega.Visibility = ViewStates.Invisible;
				library.Visibility = ViewStates.Invisible;
				zeta.Visibility = ViewStates.Invisible;
				cottage.Visibility = ViewStates.Invisible;
				delta.Visibility = ViewStates.Invisible;
				brussels.Visibility = ViewStates.Invisible;
				theta.Visibility = ViewStates.Invisible;
				alpha.Visibility = ViewStates.Invisible;
				hasselt.Visibility= ViewStates.Invisible;
				antwerp.Visibility = ViewStates.Invisible;
				parking.Visibility= ViewStates.Invisible;
				caffeteria.Visibility= ViewStates.Invisible;
				genk.Visibility = ViewStates.Invisible;
				leuven.Visibility = ViewStates.Invisible;
				gama.Visibility = ViewStates.Invisible;
				beta.Visibility = ViewStates.Invisible;
				reception.Visibility = ViewStates.Invisible;
				ypsilon.Visibility = ViewStates.Invisible;
			}
			else {
				sigma.Visibility = ViewStates.Invisible;
				omega.Visibility = ViewStates.Invisible;
				library.Visibility = ViewStates.Invisible;
				zeta.Visibility = ViewStates.Invisible;
				cottage.Visibility = ViewStates.Invisible;
				delta.Visibility = ViewStates.Invisible;
				brussels.Visibility = ViewStates.Invisible;
				theta.Visibility = ViewStates.Invisible;
				alpha.Visibility = ViewStates.Invisible;
				hasselt.Visibility= ViewStates.Invisible;
				antwerp.Visibility = ViewStates.Invisible;
				parking.Visibility= ViewStates.Invisible;
				caffeteria.Visibility= ViewStates.Invisible;
				genk.Visibility = ViewStates.Invisible;
				leuven.Visibility = ViewStates.Invisible;
				gama.Visibility = ViewStates.Invisible;
				beta.Visibility = ViewStates.Invisible;
				reception.Visibility = ViewStates.Invisible;
				admin.Visibility = ViewStates.Invisible;
				ypsilon.Visibility = ViewStates.Invisible;
			}

		}

	}
}


