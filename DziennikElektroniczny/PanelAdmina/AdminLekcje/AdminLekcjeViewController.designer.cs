// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace DziennikElektroniczny.AdminLekcje
{
	[Register ("AdminLekcjeViewController")]
	partial class AdminLekcjeViewController
	{
		[Outlet]
		AppKit.NSComboBox DzienTygodniaCombobox { get; set; }

		[Outlet]
		AppKit.NSComboBox JednostkaCombobox { get; set; }

		[Outlet]
		AppKit.NSComboBox KlasaCombobox { get; set; }

		[Outlet]
		AppKit.NSTableView LekcjeTableView { get; set; }

		[Outlet]
		AppKit.NSTextField OnWyszukajTextFieldEdited { get; set; }

		[Outlet]
		AppKit.NSComboBox PrzedmiotCombobox { get; set; }

		[Outlet]
		AppKit.NSComboBox SalaCombobox { get; set; }

		[Outlet]
		AppKit.NSTextField StatusTextField { get; set; }

		[Outlet]
		AppKit.NSTextField WyszukajTextField { get; set; }

		[Action ("OnDodajLekcjeButtonPressed:")]
		partial void OnDodajLekcjeButtonPressed (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (LekcjeTableView != null) {
				LekcjeTableView.Dispose ();
				LekcjeTableView = null;
			}

			if (KlasaCombobox != null) {
				KlasaCombobox.Dispose ();
				KlasaCombobox = null;
			}

			if (JednostkaCombobox != null) {
				JednostkaCombobox.Dispose ();
				JednostkaCombobox = null;
			}

			if (DzienTygodniaCombobox != null) {
				DzienTygodniaCombobox.Dispose ();
				DzienTygodniaCombobox = null;
			}

			if (PrzedmiotCombobox != null) {
				PrzedmiotCombobox.Dispose ();
				PrzedmiotCombobox = null;
			}

			if (SalaCombobox != null) {
				SalaCombobox.Dispose ();
				SalaCombobox = null;
			}

			if (WyszukajTextField != null) {
				WyszukajTextField.Dispose ();
				WyszukajTextField = null;
			}

			if (StatusTextField != null) {
				StatusTextField.Dispose ();
				StatusTextField = null;
			}

			if (OnWyszukajTextFieldEdited != null) {
				OnWyszukajTextFieldEdited.Dispose ();
				OnWyszukajTextFieldEdited = null;
			}
		}
	}
}
