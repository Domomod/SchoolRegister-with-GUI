// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace DziennikElektroniczny.AdminJednostki
{
	[Register ("AdminJednostkiViewController")]
	partial class AdminJednostkiViewController
	{
		[Outlet]
		AppKit.NSComboBox GodzinaCombobox { get; set; }

		[Outlet]
		AppKit.NSTableView JednostkiTableView { get; set; }

		[Outlet]
		AppKit.NSComboBox MinutaCombobox { get; set; }

		[Outlet]
		AppKit.NSTextField StatusTextField { get; set; }

		[Action ("OnDodajJednostkeButtonPressed:")]
		partial void OnDodajJednostkeButtonPressed (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (JednostkiTableView != null) {
				JednostkiTableView.Dispose ();
				JednostkiTableView = null;
			}

			if (GodzinaCombobox != null) {
				GodzinaCombobox.Dispose ();
				GodzinaCombobox = null;
			}

			if (MinutaCombobox != null) {
				MinutaCombobox.Dispose ();
				MinutaCombobox = null;
			}

			if (StatusTextField != null) {
				StatusTextField.Dispose ();
				StatusTextField = null;
			}
		}
	}
}
