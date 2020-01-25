// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace gui
{
	[Register ("ParentViewControllerController")]
	partial class ParentViewControllerController
	{
		[Outlet]
		AppKit.NSComboBox Absent { get; set; }

		[Outlet]
		AppKit.NSButton FindAbsence { get; set; }

		[Outlet]
		AppKit.NSButton LegitimizeApply { get; set; }

		[Outlet]
		AppKit.NSTextField MyData { get; set; }

		[Outlet]
		AppKit.NSComboBox Name { get; set; }

		[Outlet]
		AppKit.NSScrollView NotesTab { get; set; }

		[Outlet]
		AppKit.NSScrollView PresanceTab { get; set; }

		[Outlet]
		AppKit.NSScrollView WarningsTab { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (MyData != null) {
				MyData.Dispose ();
				MyData = null;
			}

			if (NotesTab != null) {
				NotesTab.Dispose ();
				NotesTab = null;
			}

			if (WarningsTab != null) {
				WarningsTab.Dispose ();
				WarningsTab = null;
			}

			if (PresanceTab != null) {
				PresanceTab.Dispose ();
				PresanceTab = null;
			}

			if (Name != null) {
				Name.Dispose ();
				Name = null;
			}

			if (Absent != null) {
				Absent.Dispose ();
				Absent = null;
			}

			if (FindAbsence != null) {
				FindAbsence.Dispose ();
				FindAbsence = null;
			}

			if (LegitimizeApply != null) {
				LegitimizeApply.Dispose ();
				LegitimizeApply = null;
			}
		}
	}
}
