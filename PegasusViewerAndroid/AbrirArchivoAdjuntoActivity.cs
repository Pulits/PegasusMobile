using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace pegasusviewerandroid
{
	[Activity (Label = "AbrirArchivoAdjuntoActivity", MainLauncher = false, Icon = "@drawable/icon")]
	public class AbrirArchivoAdjuntoActivity : Activity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			Android.Net.Uri firma = Intent.Data;

			if ((firma != null) && (firma.Scheme.Contains ("content"))) {
				//procesar firma
			}
		}

		protected override void OnActivityResult (int requestCode, Result resultCode, Intent data)
		{
			Intent archivoAdjunto = data;
			Android.Net.Uri uriRegresado = archivoAdjunto.Data;
			if (uriRegresado != null) {

			}
		}
		public AbrirArchivoAdjuntoActivity ()
		{

		}
	}
}