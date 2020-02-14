// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace DziennikElektroniczny.AdminKlasyProfile
{
	[Register ("AdminKlasyProfileViewController")]
	partial class AdminKlasyProfileViewController
	{
		[Outlet]
		AppKit.NSTableView KlasyTableView { get; set; }

		[Outlet]
		AppKit.NSComboBox ProfilCombobox { get; set; }

		[Outlet]
		AppKit.NSTextField ProfilTextField { get; set; }

		[Outlet]
		AppKit.NSTextField RocznikTextField { get; set; }

		[Outlet]
		AppKit.NSTextField StatusTextField { get; set; }

		[Outlet]
		AppKit.NSTextField SymbolTextField { get; set; }

		[Outlet]
		AppKit.NSTextField WyszukajTextField { get; set; }

		[Action ("OnDodajKlaseButtonPressed:")]
		partial void OnDodajKlaseButtonPressed (Foundation.NSObject sender);

		[Action ("OnDodajProfilButtonPressed:")]
		partial void OnDodajProfilButtonPressed (Foundation.NSObject sender);

		[Action ("OnWyszukajTextFieldEdited:")]
		partial void OnWyszukajTextFieldEdited (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (KlasyTableView != null) {
				KlasyTableView.Dispose ();
				KlasyTableView = null;
			}

			if (WyszukajTextField != null) {
				WyszukajTextField.Dispose ();
				WyszukajTextField = null;
			}

			if (RocznikTextField != null) {
				RocznikTextField.Dispose ();
				RocznikTextField = null;
			}

			if (SymbolTextField != null) {
				SymbolTextField.Dispose ();
				SymbolTextField = null;
			}

			if (ProfilCombobox != null) {
				ProfilCombobox.Dispose ();
				ProfilCombobox = null;
			}

			if (ProfilTextField != null) {
				ProfilTextField.Dispose ();
				ProfilTextField = null;
			}

			if (StatusTextField != null) {
				StatusTextField.Dispose ();
				StatusTextField = null;
			}
		}
	}
}
