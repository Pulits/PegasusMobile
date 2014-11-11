
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
using Android.Support.V4.Widget;

using PegasusViewerShared;
using System.Threading.Tasks;

namespace PegasusViewerAndroid
{
	[Activity (Label = "Buzón para firma")]			
	public class ParaFirmaActivity : Activity
	{
		ExpandableListView expListView;
		List<ParaFirma> listaCorreos;

		SwipeRefreshLayout swipeLayout;
		LinearLayout layout;
		AlertDialog.Builder alerta;
		AlertDialog alertaMostrar;
		Button botonCerrarAlerta;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			ConfigurarPagina ();
			ConfigurarActionBar ();
			ConfigurarSwipe ();
			PrepararDatos ();

			expListView.SetAdapter (new AdaptadorListaExpandible (this, listaCorreos));
//			expListView.ChildClick += (object sender, ExpandableListView.ChildClickEventArgs e) => {
//			
//			};
		}

		public void ConfigurarPagina ()
		{
			SetContentView (Resource.Layout.ParaFirma);
			expListView = FindViewById<ExpandableListView> (Resource.Id.lvExp);
			swipeLayout = FindViewById<SwipeRefreshLayout> (Resource.Id.swipeContenedor);
		}

		public void ConfigurarActionBar ()
		{
			ActionBar.SetHomeButtonEnabled (false);
			ActionBar.SetDisplayHomeAsUpEnabled (true);
			ActionBar.Show ();
		}

		public override bool OnCreateOptionsMenu (IMenu menu)
		{
			this.MenuInflater.Inflate (Resource.Menu.actividades_menu, menu);
			return true;
		}

		public void ConfigurarSwipe ()
		{
			swipeLayout.SetColorSchemeColors (Android.Graphics.Color.Orange,
				Android.Graphics.Color.DarkGray,
				Android.Graphics.Color.DarkOrange,
				Android.Graphics.Color.LightGray);

			swipeLayout.Refresh += Refrescador;
		}

		async void Refrescador (object sender, EventArgs e)
		{
			await ObtenerDatos ();
			swipeLayout.Refreshing = false;
		}

		public async Task<int> ObtenerDatos ()
		{
			await Task.Delay (1000); //1 secundo delay
			return 1;
		}

		/// <param name="item">The menu item that was selected.</param>
		/// <summary>
		/// Override de la actividad OnOptionsItemSelected, este método marca qué ocurre al hacer click en los botones de la ActionBar
		/// </summary>
		/// <returns>To be added.</returns>
		public override bool OnOptionsItemSelected (IMenuItem item)
		{
			switch (item.ItemId) {
			case Android.Resource.Id.Home:
				StartActivity (typeof(MainActivity));
				return true;

			case Resource.Id.action_warning:
				MuestraPopup ();
				return true;

			default:
				return base.OnOptionsItemSelected (item);
			}
		}

		/// <summary>
		/// Evento que ocurre al hacer click en el botón de regreso
		/// </summary>
		public void botonRegreso_onClick ()
		{
			StartActivity (typeof(MainActivity));
		}

		/// <summary>
		/// Muestra el popup de información
		/// </summary>
		private void MuestraPopup ()
		{
			layout = FindViewById<LinearLayout> (Resource.Id.layoutParaFirma);
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

		public void PrepararDatos ()
		{
			listaCorreos = new List<ParaFirma> ();
			ParaFirma correoDummy = new ParaFirma ("GDI14-64", "Rodrigo Zarza, Dirección de Informática", "Rodrigo Zarza, Dirección de Informática", "A externo \nCon Vo.Bo\nFolio: GDI14-61-0", DateTime.Now, string.Empty, DateTime.Now, "Público", "Administración de Pegasus Pegaso TEC", string.Empty);
			ParaFirma correoDummy2 = new ParaFirma ("GDI14-65", "Rodrigo Zarza, Dirección de Informática2", "Rodrigo Zarza, Dirección de Informática", "Este es el asunto \nPodemos poner\nMuchas líneas\nOtra línea", DateTime.Now, string.Empty, DateTime.Now, "Público", "Administración de Pegasus Pegaso TEC", string.Empty);
			ParaFirma correoDummy3 = new ParaFirma ("GDI14-66", "Rodrigo Zarza, Dirección de Informática3", "Rodrigo Zarza, Dirección de Informática", "A externo \nCon Vo.Bo\nFolio: GDI14-61-0", DateTime.Now, string.Empty, DateTime.Now, "Público", "Administración de Pegasus Pegaso TEC", string.Empty);

			listaCorreos.Add (correoDummy);
			listaCorreos.Add (correoDummy2);
			listaCorreos.Add (correoDummy3);
			listaCorreos.Add (correoDummy);
		}
	}

	/// <summary>
	/// Cambia el color de la línea divisora del mensaje de alerta
	/// </summary>
	public class ShowListener : Java.Lang.Object, IDialogInterfaceOnShowListener
	{
		public void OnShow (IDialogInterface dialog)
		{
			Dialog dialogo = (Dialog)dialog;

			int divisorTituloId = dialogo.Context.Resources.GetIdentifier ("android:id/titleDivider", null, null);

			View tituloAlerta = dialogo.FindViewById (divisorTituloId);
			if (tituloAlerta != null) {
				tituloAlerta.SetBackgroundColor (Android.Graphics.Color.Orange);
			}
		}
	}
}

