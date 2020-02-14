// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace DziennikElektroniczny.AdminPrzedmioty
{
	[Register ("AdminPrzedmiotyViewController")]
	partial class AdminPrzedmiotyViewController
	{
		[Outlet]
		AppKit.NSTextField NazwaTextField { get; set; }

		[Outlet]
		AppKit.NSTableView PrzedmiotyTableView { get; set; }

		[Outlet]
		AppKit.NSScrollView StatusTextField { get; set; }

		[Outlet]
		AppKit.NSTextField WyszukajTextField { get; set; }

		[Action ("OnDodajPrzedmiotPressed:")]
		partial void OnDodajPrzedmiotPressed (Foundation.NSObject sender);

		[Action ("OnWyszukajTextFieldEdited:")]
		partial void OnWyszukajTextFieldEdited (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (WyszukajTextField != null) {
				WyszukajTextField.Dispose ();
				WyszukajTextField = null;
			}

			if (NazwaTextField != null) {
				NazwaTextField.Dispose ();
				NazwaTextField = null;
			}

			if (StatusTextField != null) {
				StatusTextField.Dispose ();
				StatusTextField = null;
			}

			if (PrzedmiotyTableView != null) {
				PrzedmiotyTableView.Dispose ();
				PrzedmiotyTableView = null;
			}
		}
	}
}
