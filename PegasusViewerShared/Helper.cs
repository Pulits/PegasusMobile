using System;

namespace PegasusViewerShared
{
	public class Helper
	{
		public const string Etiqueta = "Peg@sus Viewer";
		public static string FooterAplicacion = "Copyright © " + DateTime.Now.Year.ToString() + " Pegaso Tecnología";

		public bool EsCorreoValido(string email)
		{
			try {
				var addr = new System.Net.Mail.MailAddress(email);
				return true;
			}
			catch {
				return false;
			}
		}
	}
}

