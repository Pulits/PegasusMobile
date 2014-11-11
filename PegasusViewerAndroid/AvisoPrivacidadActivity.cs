
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
using Android.Text.Method;

using PegasusViewerShared;

namespace PegasusViewerAndroid
{
	[Activity (Label = "Aviso de Privacidad")]			
	public class AvisoPrivacidadActivity : Activity
	{
		TextView avisoPrivacidad;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.AvisoDePrivacidad);

			ConfiguraActionBar ();
			ConfiguraTextoPrivacidad ();			
		}

		public void ConfiguraActionBar ()
		{
			ActionBar.SetHomeButtonEnabled (false);
			ActionBar.SetDisplayHomeAsUpEnabled (true);
			ActionBar.Show ();
		}

		public override bool OnOptionsItemSelected (IMenuItem item)
		{
			switch (item.ItemId) {
			case Android.Resource.Id.Home:
				StartActivity (typeof(MainActivity));
				return true;

			default:
				return base.OnOptionsItemSelected (item);
			}
		}

		public void ConfiguraTextoPrivacidad ()
		{
			avisoPrivacidad = FindViewById<TextView> (Resource.Id.textViewAvisoCompleto);
			avisoPrivacidad.MovementMethod = new ScrollingMovementMethod ();
		}

		public void botonRegreso_onClick ()
		{
			StartActivity (typeof(MainActivity));
		}
	}
}

