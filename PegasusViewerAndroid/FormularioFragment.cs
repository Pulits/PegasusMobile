using System;
using Android.App;
using Android.Views;
using Android.OS;
using Android.Content;
using Android.Widget;
using Android.Text.Method;

namespace PegasusViewerAndroid
{
	public class FormularioFragment : Fragment
	{
		TextView txtContenidoFormularioFragment;

		public FormularioFragment ()
		{
		}

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			base.OnCreateView (inflater, container, savedInstanceState);

			Context contextThemeWrapper = new ContextThemeWrapper (Activity, Resource.Style.AppTheme);
			LayoutInflater localInflater = inflater.CloneInContext (contextThemeWrapper);

			var view = localInflater.Inflate (Resource.Layout.FormularioFragment, container, false);

			ConfiguraTextboxes (view);
			return view;
		}

		public void ConfiguraTextboxes (View view)
		{
			txtContenidoFormularioFragment = view.FindViewById<TextView> (Resource.Id.txtContenidoFormularioFragment);
			txtContenidoFormularioFragment.MovementMethod = new ScrollingMovementMethod ();
		}
	}
}

