using System;
using Android.App;
using Android.Views;
using Android.OS;
using Android.Content;
using Android.Widget;

namespace PegasusViewerAndroid
{
	public class AnexosFragment : Fragment
	{
		public AnexosFragment ()
		{
		}

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			base.OnCreateView (inflater, container, savedInstanceState);

			Context contextThemeWrapper = new ContextThemeWrapper (Activity, Resource.Style.AppTheme);
			LayoutInflater localInflater = inflater.CloneInContext (contextThemeWrapper);

			var view = localInflater.Inflate (Resource.Layout.AnexosFragment, container, false);

			return view;
		}
	}
}

