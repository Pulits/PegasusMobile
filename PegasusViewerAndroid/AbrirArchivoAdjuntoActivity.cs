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
	[IntentFilter (new[] { Intent.ActionMain }, Categories = new[] {
		Intent.CategoryLauncher,
		"pegasusviewerandroid.AbrirArchivoAdjuntoActivity"
	})]
	public class AbrirArchivoAdjuntoActivity : Activity
	{
		public AbrirArchivoAdjuntoActivity ()
		{
			Intent archivoAdjunto = new Intent (this, typeof(AbrirArchivoAdjuntoActivity));
			Android.Net.Uri uriRegresado = archivoAdjunto.Data;

			if ((uriRegresado != null) && (uriRegresado.Scheme.Contains ("content"))) {
				//obtener attachment
			}
		}
	}
}

