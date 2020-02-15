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
		AppKit.NSTextField StatusTextField { get; set; }

		[Outlet]
		AppKit.NSTextField TelefonTextField { get; set; }

		[Action ("DodajButton:")]
		partial void DodajButton (Foundation.NSObject sender);

		[Action ("OnSearchTextCellChange:")]
		partial void OnSearchTextCellChange (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (NazwiskoTextField != null) {
				NazwiskoTextField.Dispose ();
				NazwiskoTextField = null;
			}

			if (AdresTextField != null) {
				AdresTextField.Dispose ();
				AdresTextField = null;
			}

			if (DodajTextField != null) {
				DodajTextField.Dispose ();
				DodajTextField = null;
			}

			if (EmailTextField != null) {
				EmailTextField.Dispose ();
				EmailTextField = null;
			}

			if (EtatTextField != null) {
				EtatTextField.Dispose ();
				EtatTextField = null;
			}

			if (ImieTableColumn != null) {
				ImieTableColumn.Dispose ();
				ImieTableColumn = null;
			}

			if (ImieTextField != null) {
				ImieTextField.Dispose ();
				ImieTextField = null;
			}

			if (NauczycieleTableView != null) {
				NauczycieleTableView.Dispose ();
				NauczycieleTableView = null;
			}

			if (NazwiskoTableColumn != null) {
				NazwiskoTableColumn.Dispose ();
				NazwiskoTableColumn = null;
			}

			if (PeselTextField != null) {
				PeselTextField.Dispose ();
				PeselTextField = null;
			}

			if (SearchTextCell != null) {
				SearchTextCell.Dispose ();
				SearchTextCell = null;
			}

			if (StatusTextField != null) {
				StatusTextField.Dispose ();
				StatusTextField = null;
			}

			if (TelefonTextField != null) {
				TelefonTextField.Dispose ();
				TelefonTextField = null;
			}
		}
	}
}
