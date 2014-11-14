using System;

namespace PegasusViewerShared
{
	public class Anexo
	{
		public Anexo ()
		{
		}

		private	string _archivo;
		public string Archivo
		{
			get { return _archivo; }
			set { _archivo = value; }
		}

		private string _descripcion;
		public string Descripcion
		{
			get { return _archivo; }
			set { _descripcion = value; }
		}

		private string _tipoAnexo;
		public string TipoAnexo
		{
			get { return _tipoAnexo; }
			set { _tipoAnexo = value; }
		}

		private string _confidencialidad;
		public string Confidencialidad
		{
			get { return _confidencialidad; }
			set { _confidencialidad = value; }
		}

		private string _unidadDocumental;
		public string UnidadDocumental
		{
			get { return _unidadDocumental; }
			set { _unidadDocumental = value; }
		}

		private string _tipo;
		public string Tipo
		{
			get { return _tipo; }
			set { _tipo = value; }
		}
	}
}

