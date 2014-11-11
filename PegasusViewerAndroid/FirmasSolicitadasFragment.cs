using System;
using Android.App;
using Android.Views;
using Android.OS;
using Android.Content;
using Android.Widget;
using System.Collections.Generic;
using Android.Text.Method;

namespace PegasusViewerAndroid
{
	public class FirmasSolicitadasFragment : Fragment
	{
		TextView txtAntefirmasFragment;
		TextView txtRespuestaVoboFragment;
		Spinner ddlFirmasSolicitadas;
		List<string> datosFirmasSolicitadas;

		public FirmasSolicitadasFragment ()
		{

		}

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			base.OnCreateView (inflater, container, savedInstanceState);

			Context contextThemeWrapper = new ContextThemeWrapper (Activity, Resource.Style.AppTheme);
			LayoutInflater localInflater = inflater.CloneInContext (contextThemeWrapper);

			var view = localInflater.Inflate (Resource.Layout.FirmasSolicitadasFragment, container, false);
			ddlFirmasSolicitadas = view.FindViewById<Spinner> (Resource.Id.ddlFirmasSolicitadas);

			ConfiguraTextBoxes (view);
			LlenaDropDownList (view);
			return view;
		}

		public void ConfiguraTextBoxes (View view)
		{
			txtAntefirmasFragment = view.FindViewById<TextView> (Resource.Id.txtAntefirmasFragment);
			txtRespuestaVoboFragment = view.FindViewById<TextView> (Resource.Id.txtRespuestaVoboFragment);

			txtAntefirmasFragment.MovementMethod = new ScrollingMovementMethod ();
			txtRespuestaVoboFragment.MovementMethod = new ScrollingMovementMethod ();
		}

		public void LlenaDropDownList (View view)
		{
			datosFirmasSolicitadas = new List<string> ();
			datosFirmasSolicitadas.Add ("Ordinario");

			ArrayAdapter<string> adaptador = new ArrayAdapter<string> (view.Context, Resource.Layout.TextViewAdaptadorDropDown, datosFirmasSolicitadas);
			ddlFirmasSolicitadas.Adapter = adaptador;
		}
	}
}

