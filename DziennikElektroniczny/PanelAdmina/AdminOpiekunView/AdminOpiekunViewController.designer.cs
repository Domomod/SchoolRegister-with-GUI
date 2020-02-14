// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace DziennikElektroniczny.AdminOpiekunView
{
	[Register ("AdminOpiekunViewController")]
	partial class AdminOpiekunViewController
	{
		[Outlet]
		AppKit.NSTextField AdresTextCell { get; set; }

		[Outlet]
		AppKit.NSTextField DochodTextCell { get; set; }

		[Outlet]
		AppKit.NSComboBox DzieciCombobox { get; set; }

		[Outlet]
		AppKit.NSTableView DzieciTableView { get; set; }

		[Outlet]
		AppKit.NSTextField EmailTextCell { get; set; }

		[Outlet]
		AppKit.NSTextField ImieTextCell { get; set; }

		[Outlet]
		AppKit.NSComboBox NauczycieleCombobox { get; set; }

		[Outlet]
		AppKit.NSTextField NazwiskoTextCell { get; set; }

		[Outlet]
		AppKit.NSTableView OpiekunowieTableView { get; set; }

		[Outlet]
		AppKit.NSTextField PeselTextCell { get; set; }

		[Outlet]
		AppKit.NSTextField SearchTextCell { get; set; }

		[Outlet]
		AppKit.NSTextField TelefonTextCell { get; set; }

		[Action ("OnDodajNauczycielaOpiekubaButtonPressed:")]
		partial void OnDodajNauczycielaOpiekubaButtonPressed (Foundation.NSObject sender);

		[Action ("OnDodajOpiekunaButtonPressed:")]
		partial void OnDodajOpiekunaButtonPressed (Foundation.NSObject sender);

		[Action ("OnPrzypiszDzieckoButtonPressed:")]
		partial void OnPrzypiszDzieckoButtonPressed (Foundation.NSObject sender);

		[Action ("OnWyszukajTextCellEdited:")]
		partial void OnWyszukajTextCellEdited (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (ImieTextCell != null) {
				ImieTextCell.Dispose ();
				ImieTextCell = null;
			}

			if (NazwiskoTextCell != null) {
				NazwiskoTextCell.Dispose ();
				NazwiskoTextCell = null;
			}

			if (PeselTextCell != null) {
				PeselTextCell.Dispose ();
				PeselTextCell = null;
			}

			if (DochodTextCell != null) {
				DochodTextCell.Dispose ();
				DochodTextCell = null;
			}

			if (EmailTextCell != null) {
				EmailTextCell.Dispose ();
				EmailTextCell = null;
			}

			if (AdresTextCell != null) {
				AdresTextCell.Dispose ();
				AdresTextCell = null;
			}

			if (TelefonTextCell != null) {
				TelefonTextCell.Dispose ();
				TelefonTextCell = null;
			}

			if (SearchTextCell != null) {
				SearchTextCell.Dispose ();
				SearchTextCell = null;
			}

			if (OpiekunowieTableView != null) {
				OpiekunowieTableView.Dispose ();
				OpiekunowieTableView = null;
			}

			if (DzieciTableView != null) {
				DzieciTableView.Dispose ();
				DzieciTableView = null;
			}

			if (DzieciCombobox != null) {
				DzieciCombobox.Dispose ();
				DzieciCombobox = null;
			}

			if (NauczycieleCombobox != null) {
				NauczycieleCombobox.Dispose ();
				NauczycieleCombobox = null;
			}
		}
	}
}
