using System;
using Android.App;
using Android.Views;
using Android.OS;
using Android.Content;
using Android.Widget;

namespace PegasusViewerAndroid
{
	public class RespuestaFirmaFragment : Fragment
	{
		TableLayout tablaFirmasDocumento;
		TableRow filaFirmasDocumento;
		RadioGroup radioGroupAutorizado;
		RadioButton radioGroupAutorizadoSi;
		RadioButton radioGroupAutorizadoNo;
		CheckBox checkFirmar;

		public RespuestaFirmaFragment ()
		{
			
		}

		/// <param name="inflater">The LayoutInflater object that can be used to inflate
		///  any views in the fragment,</param>
		/// <param name="container">If non-null, this is the parent view that the fragment's
		///  UI should be attached to. The fragment should not add the view itself,
		///  but this can be used to generate the LayoutParams of the view.</param>
		/// <param name="savedInstanceState">If non-null, this fragment is being re-constructed
		///  from a previous saved state as given here.</param>
		/// <summary>
		/// Called to have the fragment instantiate its user interface view.
		/// Este evento se llama al crear la vista del fragmento, equivalente al OnCrate de una actividad
		/// </summary>
		/// <returns>To be added.</returns>
		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			base.OnCreateView (inflater, container, savedInstanceState);

			Context contextThemeWrapper = new ContextThemeWrapper (Activity, Resource.Style.AppTheme);
			LayoutInflater localInflater = inflater.CloneInContext (contextThemeWrapper);

			var view = localInflater.Inflate (Resource.Layout.RespuestaFirmaFragment, container, false);

			checkFirmar = view.FindViewById<CheckBox> (Resource.Id.checkFirmar);

			ConfigurarRadioGroup (view);
			ConfiguraTablaFirmasDocumento (view, inflater);
			return view;
		}

		/// <summary>
		/// Configura el RadioGroup para hacer selección automática del checkbox Firmar
		/// </summary>
		/// <param name="view">View.</param>
		public void ConfigurarRadioGroup (View view)
		{
			radioGroupAutorizadoSi = view.FindViewById<RadioButton> (Resource.Id.radioGroupAutorizadoSi);
			radioGroupAutorizadoSi.CheckedChange += ActivarFirmaConSeleccion;
		}

		public void ActivarFirmaConSeleccion (object sender, EventArgs e)
		{
			if (radioGroupAutorizadoSi.Checked) {
				checkFirmar.Checked = true;
			}
		}

		/// <summary>
		/// Configura la tabla Firmas de documento del fragmento RespuestaFirmaFragment
		/// </summary>
		/// <param name="view">View.</param>
		/// <param name="inflater">Inflater.</param>
		public void ConfiguraTablaFirmasDocumento (View view, LayoutInflater inflater)
		{
			tablaFirmasDocumento = view.FindViewById<TableLayout> (Resource.Id.tblFirmasDocumentos);

			string[] firmas = { "AnteFirma", "AnteFirma", "Firma", "Vobo/Autorización", "Firma" };
			string[] nombres = { "Administrador de Pegasus, Adm. de Sistema PEGASO TEC",
				"Carlos Osorio, Director PEGASO TEC", "Jose Eduardo Contreras Pedraza, Adminsitrador PEGASO TEC", "Omar Jair Montoya Bautista, 1.1.3 Titular DDTEC Dirección de Desarrollo Tecnologic",
				"Dora Luz Cruz Mar, 1.1.3 Supervisor Dirección de Desarrollo Tecnologico"
			};
			string[] fechas = { "04/11/2014", "04/11/2014", "04/11/2014", string.Empty, string.Empty };

			for (int i = 0; i < 5; i++) {
				InsertarFila (inflater, firmas [i], nombres [i], fechas [i]);
			}
		}

		/// <summary>
		/// Inserta una fila en la tabla de firmas del documento
		/// </summary>
		/// <param name="inflater">Inflater.</param>
		/// <param name="firma">Firma.</param>
		/// <param name="nombre">Nombre.</param>
		/// <param name="fecha">Fecha.</param>
		public void InsertarFila (LayoutInflater inflater, string firma, string nombre, string fecha)
		{
			TableRow.LayoutParams parametrosFila = new TableRow.LayoutParams (0, TableRow.LayoutParams.WrapContent, 1f);

			TextView txtFirma = (TextView)inflater.Inflate (Resource.Layout.TextViewTablaRow, null);
			TextView txtNombre = (TextView)inflater.Inflate (Resource.Layout.TextViewTablaRow, null);
			TextView txtFechaFirma = (TextView)inflater.Inflate (Resource.Layout.TextViewTablaRow, null);

			filaFirmasDocumento = new TableRow (Activity);

			txtFirma.Text = firma;
			txtNombre.Text = nombre;
			txtFechaFirma.Text = fecha;

			///Los TableRow.LayoutParams es para hacer las columnas uniformes
			filaFirmasDocumento.AddView (txtFirma, parametrosFila);
			filaFirmasDocumento.AddView (txtNombre, parametrosFila);
			filaFirmasDocumento.AddView (txtFechaFirma, parametrosFila);
			tablaFirmasDocumento.AddView (filaFirmasDocumento);
		}
	}
}
	