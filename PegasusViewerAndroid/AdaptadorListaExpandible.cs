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
	public class AdaptadorListaExpandible : BaseExpandableListAdapter
	{
		readonly Activity _contexto;
		public List<ParaFirma> _listaCorreos;

		public AdaptadorListaExpandible (Activity contexto, List<ParaFirma> listaCorreos)
		{
			_contexto = contexto;
			_listaCorreos = listaCorreos;
		}

		public override Java.Lang.Object GetChild (int groupPosition, int childPosition)
		{
			return string.Empty;
		}

		public override long GetChildId (int groupPosition, int childPosition)
		{
			return childPosition;
		}

		public override int GetChildrenCount (int groupPosition)
		{
			return 1;
		}

		public override View GetChildView (int groupPosition, int childPosition, bool isLastChild, View convertView, ViewGroup parent)
		{
			if (convertView == null) {
				var inflater = _contexto.GetSystemService (Context.LayoutInflaterService) as LayoutInflater;
				convertView = inflater.Inflate (Resource.Layout.item_lista, null);
			}

			Button btnVer = (Button)convertView.FindViewById<Button> (Resource.Id.btnVer);
			Button btnFirmar = (Button)convertView.FindViewById<Button> (Resource.Id.btnFirmar);
			btnVer.Focusable = false;
			btnFirmar.Focusable = false;

			btnVer.Click += delegate {
				_contexto.StartActivity (typeof(RespuestaVoBo));
			};

			btnFirmar.Click += delegate {
				//ToDo: Qué ocurre al firmar
			};

			TextView lblAsunto = (TextView)convertView.FindViewById<TextView> (Resource.Id.lblAsunto);
			TextView lblFechaCompromiso = (TextView)convertView.FindViewById<TextView> (Resource.Id.lblFechaCompromiso);
			TextView lblDestino = (TextView)convertView.FindViewById<TextView> (Resource.Id.lblDestino);

			lblAsunto.Text = _listaCorreos [groupPosition].Asunto;
			lblFechaCompromiso.Text = "Fecha de Compromiso: " + string.Format ("{0:d}", _listaCorreos [groupPosition].FechaDeCompromiso);
			lblDestino.Text = "Destino: " + _listaCorreos [groupPosition].Destino;

			return convertView;
		}

		public override Java.Lang.Object GetGroup (int groupPosition)
		{
			return string.Empty;
		}

		public override long GetGroupId (int groupPosition)
		{
			return groupPosition;
		}

		public override View GetGroupView (int groupPosition, bool isExpanded, View convertView, ViewGroup parent)
		{
			if (convertView == null) {
				var inflater = _contexto.GetSystemService (Context.LayoutInflaterService) as LayoutInflater;
				convertView = inflater.Inflate (Resource.Layout.lista_firma, null);
			}

			TextView lblFolio = (TextView)convertView.FindViewById<TextView> (Resource.Id.lblFolio);
			TextView lblFechaRegistro = (TextView)convertView.FindViewById<TextView> (Resource.Id.lblFechaRegistro);
			TextView lblPromotor = (TextView)convertView.FindViewById<TextView> (Resource.Id.lblPromotor);
			TextView lblRemitente = (TextView)convertView.FindViewById<TextView> (Resource.Id.lblRemitente);

			lblFolio.Text = "Folio: " + _listaCorreos [groupPosition].Folio;
			lblFechaRegistro.Text = "Fecha de Registro: " + string.Format ("{0:d}", _listaCorreos [groupPosition].FechaRegistro);
			lblPromotor.Text = "Promotor: " + _listaCorreos [groupPosition].PromotorOficial;
			lblRemitente.Text = "Remitente: " + _listaCorreos [groupPosition].Remitente;

			return convertView;
		}

		public override bool IsChildSelectable (int groupPosition, int childPosition)
		{
			return true;
		}

		public override int GroupCount {
			get { return this._listaCorreos.Count; }
		}

		public override bool HasStableIds {
			get { return true; }
		}
	}
}

