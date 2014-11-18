using System;
using Android.App;
using Android.Views;
using Android.OS;
using Android.Content;
using Android.Widget;
using System.Collections.Generic;
using PegasusViewerShared;

namespace PegasusViewerAndroid
{
	public class AnexosFragment : Fragment
	{
		List<Anexo> listadoAnexos;
		ListView listaAnexos;
		public AnexosFragment ()
		{
		}

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			base.OnCreateView (inflater, container, savedInstanceState);

			Context contextThemeWrapper = new ContextThemeWrapper (Activity, Resource.Style.AppTheme);
			LayoutInflater localInflater = inflater.CloneInContext (contextThemeWrapper);

			var view = localInflater.Inflate (Resource.Layout.AnexosFragment, container, false);

			PrepararDatos ();
			listaAnexos = view.FindViewById<ListView> (Resource.Id.listaAnexos);
			listaAnexos.SetAdapter (new AdaptadorAnexos (Activity, listadoAnexos));
			return view;
		}

		public void PrepararDatos()
		{
			listadoAnexos = new List<Anexo> ();
			Anexo dummy = new Anexo ("Arquitectura.pdf", string.Empty, "Anexo de Respuesta", "Pública", "Otro", "Anexo");

			listadoAnexos.Add (dummy);
			listadoAnexos.Add (dummy);
			listadoAnexos.Add (dummy);
		}
	}
}

