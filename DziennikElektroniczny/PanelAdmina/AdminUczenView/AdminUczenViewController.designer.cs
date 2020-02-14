// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace DziennikElektroniczny.AdminUczenView
{
	[Register ("AdminUczenViewController")]
	partial class AdminUczenViewController
	{
		[Outlet]
		AppKit.NSTextField AdresTextField { get; set; }

		[Outlet]
		AppKit.NSTextField EmailTextField { get; set; }

		[Outlet]
		AppKit.NSTextField ImieTextField { get; set; }

		[Outlet]
		AppKit.NSComboBox KlasaCombobox { get; set; }

		[Outlet]
		AppKit.NSTextField NazwiskoTextField { get; set; }

		[Outlet]
		AppKit.NSTableView ObecnościTableView { get; set; }

		[Outlet]
		AppKit.NSTableView OcenyTableView { get; set; }

		[Outlet]
		AppKit.NSTableView OpiekunowieTableView { get; set; }

		[Outlet]
		AppKit.NSTextField PeselTextField { get; set; }

		[Outlet]
		AppKit.NSTextView StatusTextView { get; set; }

		[Outlet]
		AppKit.NSTextField TextField { get; set; }

		[Outlet]
		AppKit.NSTableView UczniowieTableView { get; set; }

		[Outlet]
		AppKit.NSTableView UwagiTableView { get; set; }

		[Action ("OnDodajUczniaButtonPressed:")]
		partial void OnDodajUczniaButtonPressed (Foundation.NSObject sender);

		[Action ("OnWyszukajTextCellEdited:")]
		partial void OnWyszukajTextCellEdited (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (ImieTextField != null) {
				ImieTextField.Dispose ();
				ImieTextField = null;
			}

			if (NazwiskoTextField != null) {
				NazwiskoTextField.Dispose ();
				NazwiskoTextField = null;
			}

			if (PeselTextField != null) {
				PeselTextField.Dispose ();
				PeselTextField = null;
			}

			if (KlasaCombobox != null) {
				KlasaCombobox.Dispose ();
				KlasaCombobox = null;
			}

			if (EmailTextField != null) {
				EmailTextField.Dispose ();
				EmailTextField = null;
			}

			if (AdresTextField != null) {
				AdresTextField.Dispose ();
				AdresTextField = null;
			}

			if (TextField != null) {
				TextField.Dispose ();
				TextField = null;
			}

			if (StatusTextView != null) {
				StatusTextView.Dispose ();
				StatusTextView = null;
			}

			if (UczniowieTableView != null) {
				UczniowieTableView.Dispose ();
				UczniowieTableView = null;
			}

			if (OpiekunowieTableView != null) {
				OpiekunowieTableView.Dispose ();
				OpiekunowieTableView = null;
			}

			if (OcenyTableView != null) {
				OcenyTableView.Dispose ();
				OcenyTableView = null;
			}

			if (UwagiTableView != null) {
				UwagiTableView.Dispose ();
				UwagiTableView = null;
			}

			if (ObecnościTableView != null) {
				ObecnościTableView.Dispose ();
				ObecnościTableView = null;
			}
		}
	}
}
