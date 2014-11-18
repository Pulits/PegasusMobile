using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Org.BouncyCastle.Pkcs;
using System.IO;
using System.Collections.Generic;
using Org.BouncyCastle.X509;
using Org.BouncyCastle.Crypto.Parameters;

namespace pegasusviewerandroid
{
	[Activity (Label = "AbrirArchivoAdjuntoActivity", MainLauncher = false, Icon = "@drawable/icon")]
	public class AbrirArchivoAdjuntoActivity : Activity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			if (Intent.Data != null) {
				Android.Net.Uri firma = Intent.Data;

				if ((firma != null) && (firma.Scheme.Contains ("content"))) {
					CrearParametrosLlave (firma);
				}
			}
		}

		void CrearParametrosLlave (Android.Net.Uri firma)
		{
			Pkcs12Store store = new Pkcs12Store (ContentResolver.OpenInputStream (firma), "Passw0rd".ToCharArray ());
			String alias = "";
			ICollection<X509Certificate> chain = new List<X509Certificate> ();

			// searching for private key
			foreach (string al in store.Aliases)
				if (store.IsKeyEntry (al) && store.GetKey (al).Key.IsPrivate) {
					alias = al;
					break;
				}
			AsymmetricKeyEntry pk = store.GetKey (alias);
			foreach (X509CertificateEntry c in store.GetCertificateChain (alias))
				chain.Add (c.Certificate);
			RsaPrivateCrtKeyParameters parameters = pk.Key as RsaPrivateCrtKeyParameters;
		}

		protected override void OnActivityResult (int requestCode, Result resultCode, Intent data)
		{
			Intent archivoAdjunto = data;
			Android.Net.Uri uriRegresado = archivoAdjunto.Data;
			if (uriRegresado != null) {
				//Pkcs12Store store = new Pkcs12Store(new FileStream(uriRegresado, FileMode.Open), "Passw0rd".ToCharArray());
			}
		}
		public AbrirArchivoAdjuntoActivity ()
		{

		}
	}
}