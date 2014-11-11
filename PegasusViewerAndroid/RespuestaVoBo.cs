
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

namespace PegasusViewerAndroid
{
	[Activity (Label = "Respuesta VoBo")]			
	public class RespuestaVoBo : Activity
	{
		LinearLayout layout;
		AlertDialog.Builder alerta;
		AlertDialog alertaMostrar;
		Button botonCerrarAlerta;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.RespuestaVoBo);
			ConfiguraActionBar ();
		}

		public void ConfiguraActionBar ()
		{
			ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;

			AgregaTab ("Respuesta-Firma", 0, new RespuestaFirmaFragment ());
			AgregaTab ("Formulario", 0, new FormularioFragment ());
			AgregaTab ("Firmas Solicitadas", 0, new FirmasSolicitadasFragment ());
			AgregaTab ("Anexos", 0, new AnexosFragment ());

			ActionBar.SetHomeButtonEnabled (false);
			ActionBar.SetDisplayHomeAsUpEnabled (true);
			ActionBar.Show ();
		}

		public override bool OnCreateOptionsMenu (IMenu menu)
		{
			this.MenuInflater.Inflate (Resource.Menu.actividades_enviar_menu, menu);
			return true;
		}

		public override bool OnOptionsItemSelected (IMenuItem item)
		{
			switch (item.ItemId) {
			case Android.Resource.Id.Home:
				StartActivity (typeof(ParaFirmaActivity));
				return true;

			case Resource.Id.action_warning:
				MuestraPopup ();
				return true;

			case Resource.Id.action_send:
				//Enviar
				return true;

			default:
				return base.OnOptionsItemSelected (item);
			}
		}

		/// <summary>
		/// Muestra el popup de información
		/// </summary>
		private void MuestraPopup ()
		{
			layout = FindViewById<LinearLayout> (Resource.Id.layoutParaFirmaVoBo);
			alerta = new AlertDialog.Builder (layout.Context, Resource.Style.DialogAppTheme);

			alerta.SetTitle ("Alertas");
			alerta.SetMessage ("Usted tiene 1 recordatorio\n\nUsted tiene 1 documento con Autorización VoBo sin revisar\n\nUsted tiene 29 pendientes");
			alerta.SetNeutralButton ("Cerrar", BotonNeutralAviso);

			alertaMostrar = alerta.Create ();
			alertaMostrar.SetOnShowListener (new ShowListener ());
			alertaMostrar.Show ();
			ConfiguraBotonCancelar ();
		}

		/// <summary>
		/// Evento que ocurre al hacer click en el botón de cerrar aviso en la pantalla de listado
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		private void BotonNeutralAviso (object sender, EventArgs e)
		{
			alertaMostrar.Dismiss ();
		}

		/// <summary>
		/// Configura el botón de cerrar aviso
		/// </summary>
		private void ConfiguraBotonCancelar ()
		{
			botonCerrarAlerta = alertaMostrar.GetButton ((int)Android.Content.DialogButtonType.Neutral);
			botonCerrarAlerta.Touch += delegate {
				botonCerrarAlerta.SetBackgroundColor (Android.Graphics.Color.Orange);
				botonCerrarAlerta.SetBackgroundDrawable (Resources.GetDrawable (Resource.Drawable.apptheme_btn_default_pressed_holo_light));
				alertaMostrar.Dismiss ();
			};
			if (botonCerrarAlerta != null) {
				botonCerrarAlerta.Click += delegate {
					botonCerrarAlerta.SetBackgroundColor (Android.Graphics.Color.Orange);
					botonCerrarAlerta.SetBackgroundDrawable (Resources.GetDrawable (Resource.Drawable.apptheme_btn_default_pressed_holo_light));
					alertaMostrar.Dismiss ();
				};
			}
		}

		/// <summary>
		/// Agrega una tab al menú de Respuesta VoBo
		/// </summary>
		/// <param name="tabText">Texto que lleva la tab.</param>
		/// <param name="iconResourceId">Identificador de imagen que lleva la tab.</param>
		/// <param name="fragment">Vista parcial (fragment) que carga cada tab.</param>
		public void AgregaTab (string tabText, int iconResourceId, Fragment fragment)
		{
			var tab = this.ActionBar.NewTab ();            
			tab.SetText (tabText);
			//tab.SetIcon (iconResourceId);

			tab.TabSelected += delegate(object sender, ActionBar.TabEventArgs e) {
				e.FragmentTransaction.Replace (Resource.Id.contenedorFragmento, fragment);
			};

			this.ActionBar.AddTab (tab);
		}
	}
}

