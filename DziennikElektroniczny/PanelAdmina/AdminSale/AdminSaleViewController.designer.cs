// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace DziennikElektroniczny.AdminSale
{
	[Register ("AdminSaleViewController")]
	partial class AdminSaleViewController
	{
		[Outlet]
		AppKit.NSTextField LiczbaMiejscTextField { get; set; }

		[Outlet]
		AppKit.NSTextField PietroTextField { get; set; }

		[Outlet]
		AppKit.NSTextField SalaTextField { get; set; }

		[Outlet]
		AppKit.NSTextField StatusTextField { get; set; }

		[Outlet]
		AppKit.NSTextFieldCell WyszukajTextField { get; set; }

		[Action ("OnDodajSaleButtonPressed:")]
		partial void OnDodajSaleButtonPressed (Foundation.NSObject sender);

		[Action ("OnWyszukajTextFieldEdited:")]
		partial void OnWyszukajTextFieldEdited (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (WyszukajTextField != null) {
				WyszukajTextField.Dispose ();
				WyszukajTextField = null;
			}

			if (StatusTextField != null) {
				StatusTextField.Dispose ();
				StatusTextField = null;
			}

			if (PietroTextField != null) {
				PietroTextField.Dispose ();
				PietroTextField = null;
			}

			if (SalaTextField != null) {
				SalaTextField.Dispose ();
				SalaTextField = null;
			}

			if (LiczbaMiejscTextField != null) {
				LiczbaMiejscTextField.Dispose ();
				LiczbaMiejscTextField = null;
			}
		}
	}
}
