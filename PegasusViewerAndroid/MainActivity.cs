using System;


using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using PegasusViewerShared;
using Android.Preferences;

namespace PegasusViewerAndroid
{
	[Activity (Label = Helper.Etiqueta, MainLauncher = true, Icon = "@drawable/pegasus_icon")]
	public class MainActivity : Activity
	{
		TextView footer;
		TextView avisoPrivacidad;
		EditText txtUsuario;
		EditText txtPassword;
		Button buttonLogin;

		PreferenciasAndroid preferencias;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			ConfiguraActionBar ();
			SetContentView (Resource.Layout.Main);

			ConfiguraFooter ();
			ConfiguraBotonAviso ();
			ConfiguraBotonLogin ();
			ConfiguraPreferencias ();
			ConfiguraLogin ();
		}

		public void ConfiguraActionBar ()
		{
			ActionBar.Hide ();
		}

		public void ConfiguraFooter ()
		{
			footer = FindViewById<TextView> (Resource.Id.textViewFooter);
			footer.Text += Helper.FooterAplicacion;
		}

		public void ConfiguraBotonAviso ()
		{
			avisoPrivacidad = FindViewById<TextView> (Resource.Id.textViewAviso);
			avisoPrivacidad.Click += delegate {
				botonAviso_onClick ();
			};
		}

		public void ConfiguraBotonLogin ()
		{
			buttonLogin = FindViewById<Button> (Resource.Id.buttonLogin);
			buttonLogin.Touch += delegate {
				botonLogin_onTouch ();
			};
		}

		public void ConfiguraPreferencias ()
		{
			if (preferencias == null) {
				preferencias = new PreferenciasAndroid (ApplicationContext);
			}
			preferencias.Usuario = "Mi Usuario";
			preferencias.Password = "Passw0rd";

			preferencias.BorrarInformacion ();
		}

		public void ConfiguraLogin ()
		{
			txtUsuario = FindViewById<EditText> (Resource.Id.editTextCorreo);
			txtPassword = FindViewById<EditText> (Resource.Id.editTextPassword);
		}

		public void botonAviso_onClick ()
		{
			StartActivity (typeof(AvisoPrivacidadActivity));
		}

		public void botonLogin_onTouch ()
		{
			StartActivity (typeof(ParaFirmaActivity));
		}

		public void ValidaUsuario ()
		{

		}
	}
}

