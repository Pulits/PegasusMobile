using System;
using Android.Content;
using Android.Preferences;

namespace PegasusViewerShared
{
	public class PreferenciasAndroid
	{
		const string _usuario = "usuario";
		const string _password = "password";

		private Context _contexto;

		public PreferenciasAndroid ()
		{

		}

		public PreferenciasAndroid (Context contexto)
		{
			_contexto = contexto;
		}

		public ISharedPreferences Preferencias
		{
			get {
				return PreferenceManager.GetDefaultSharedPreferences(this.Contexto); 
			}
		}

		public string Usuario
		{
			get
			{
				return this.Preferencias.GetString(_usuario, string.Empty);
			}
			set
			{
				ISharedPreferencesEditor editor = this.Preferencias.Edit();
				editor.PutString(_usuario, value);
				editor.Commit();
			}
		}

		public string Password
		{
			get
			{
				return this.Preferencias.GetString(_password, string.Empty);
			}
			set
			{
				ISharedPreferencesEditor editor = this.Preferencias.Edit();
				editor.PutString(_password, value);
				editor.Commit();
			}
		}

		public Context Contexto
		{
			get{
				return _contexto;
			}

			set {
				_contexto = value;
			}
		}

		public void BorrarInformacion()
		{
			ISharedPreferencesEditor editor = Preferencias.Edit();
			editor.Clear ();
			editor.Commit ();
		}
	}
}

