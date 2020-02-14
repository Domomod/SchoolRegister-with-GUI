// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace DziennikElektroniczny
{
	[Register ("AdminNauczycieleViewController")]
	partial class AdminNauczycieleViewController
	{
		[Outlet]
		AppKit.NSTextField AdresTextField { get; set; }

		[Outlet]
		AppKit.NSButton DodajTextField { get; set; }

		[Outlet]
		AppKit.NSTextField EmailTextField { get; set; }

		[Outlet]
		AppKit.NSTextField EtatTextField { get; set; }

		[Outlet]
		AppKit.NSTableColumn ImieTableColumn { get; set; }

		[Outlet]
		AppKit.NSTextField ImieTextField { get; set; }

		[Outlet]
		AppKit.NSTableView NauczycieleTableView { get; set; }

		[Outlet]
		AppKit.NSTableColumn NazwiskoTableColumn { get; set; }

		[Outlet]
		AppKit.NSTextField NazwiskoTextField { get; set; }

		[Outlet]
		AppKit.NSTextField PeselTextField { get; set; }

		[Outlet]
		AppKit.NSTextField SearchTextCell { get; set; }

		[Outlet]
		AppKit.NSScrollView StatusTextField { get; set; }

		[Outlet]
		AppKit.NSTextField TelefonTextField { get; set; }

		[Action ("OnSearchTextCellChange:")]
		partial void OnSearchTextCellChange (Foundation.NSObject sender);
		
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

			if (EtatTextField != null) {
				EtatTextField.Dispose ();
				EtatTextField = null;
			}

			if (EmailTextField != null) {
				EmailTextField.Dispose ();
				EmailTextField = null;
			}

			if (AdresTextField != null) {
				AdresTextField.Dispose ();
				AdresTextField = null;
			}

			if (TelefonTextField != null) {
				TelefonTextField.Dispose ();
				TelefonTextField = null;
			}

			if (StatusTextField != null) {
				StatusTextField.Dispose ();
				StatusTextField = null;
			}

			if (DodajTextField != null) {
				DodajTextField.Dispose ();
				DodajTextField = null;
			}

			if (ImieTableColumn != null) {
				ImieTableColumn.Dispose ();
				ImieTableColumn = null;
			}

			if (NauczycieleTableView != null) {
				NauczycieleTableView.Dispose ();
				NauczycieleTableView = null;
			}

			if (NazwiskoTableColumn != null) {
				NazwiskoTableColumn.Dispose ();
				NazwiskoTableColumn = null;
			}

			if (SearchTextCell != null) {
				SearchTextCell.Dispose ();
				SearchTextCell = null;
			}
		}
	}
}
