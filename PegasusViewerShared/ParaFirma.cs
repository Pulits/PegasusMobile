using System;

namespace PegasusViewerShared
{
	public class ParaFirma
	{
		public ParaFirma ()
		{

		}

		public ParaFirma(string folio, string promotorOficial, string remitente, string asunto, DateTime fechaRegistro, string tipoAtencion, DateTime fechadeCompromiso, string caracter, string destino, string expediente)
		{
			_folio = folio;
			_promotorOficial = promotorOficial;
			_remitente = remitente;
			_asunto = asunto;
			_fechaRegistro = fechaRegistro;
			_tipoAtencion = tipoAtencion;
			_fechadeCompromiso = fechadeCompromiso;
			_caracter = caracter;
			_destino = destino;
			_expediente = expediente;
		}

		private string _folio;
		public string Folio
		{
			get { return _folio; }
			set { _folio = value; }
		}

		private string _promotorOficial;
		public string PromotorOficial
		{
			get { return _promotorOficial; }
			set { _promotorOficial = value; }
		}

		private string _remitente;
		public string Remitente
		{
			get { return _remitente; }
			set { _remitente = value; }
		}

		private string _asunto;
		public string Asunto
		{
			get { return _asunto; }
			set { _asunto = value; }
		}

		private DateTime _fechaRegistro;
		public DateTime FechaRegistro
		{
			get { return _fechaRegistro; }
			set { _fechaRegistro = value; }
		}

		private string _tipoAtencion;
		public string TipoAtencion
		{
			get { return _tipoAtencion; }
			set { _tipoAtencion = value; }
		}

		private DateTime _fechadeCompromiso;
		public DateTime FechaDeCompromiso
		{
			get { return _fechadeCompromiso; }
			set { _fechadeCompromiso = value;}
		}

		private string _caracter;
		public string Caracter
		{
			get { return _caracter; }
			set { _caracter = value; }
		}

		private string _destino;
		public string Destino
		{
			get { return _destino; }
			set { _destino = value; }
		}

		private string _expediente;
		public string Expediente
		{
			get { return _expediente; }
			set { _expediente = value; }
		}
	}
}

