using System;
using Android.Widget;
using Android.Content;
using Android.Views;
using System.Collections.Generic;
using Java.Util;
using Android.App;
using PegasusViewerShared;

namespace PegasusViewerAndroid
{
	public class AdaptadorAnexos : BaseAdapter
	{
		readonly Activity _contexto;
		public List<Anexo> _listaAnexos;

		public AdaptadorAnexos (Activity contexto, List<Anexo> listaAnexos) : base()
		{
			_contexto = contexto;
			_listaAnexos = listaAnexos;
		}

		public override int Count
		{
			get { return _listaAnexos.Count; }
		}

		public override Java.Lang.Object GetItem (int position)
		{
			throw new NotImplementedException ();
		}

		public override long GetItemId (int position)
		{
			return position;
		}

		public override View GetView (int position, View convertView, ViewGroup parent)
		{
			if (convertView == null) {
				var inflater = _contexto.GetSystemService (Context.LayoutInflaterService) as LayoutInflater;
				convertView = inflater.Inflate (Resource.Layout.item_lista_anexos, null);
			}

			return convertView;
		}
	}
}
	