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
	[Register ("StudentViewControllerController")]
	partial class StudentViewControllerController
	{
		[Outlet]
		AppKit.NSScrollView NotesTab { get; set; }

		[Outlet]
		AppKit.NSTextField Points { get; set; }

		[Outlet]
		AppKit.NSScrollView PresanceTab { get; set; }

		[Outlet]
		AppKit.NSScrollView WarningsTab { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (Points != null) {
				Points.Dispose ();
				Points = null;
			}

			if (WarningsTab != null) {
				WarningsTab.Dispose ();
				WarningsTab = null;
			}

			if (NotesTab != null) {
				NotesTab.Dispose ();
				NotesTab = null;
			}

			if (PresanceTab != null) {
				PresanceTab.Dispose ();
				PresanceTab = null;
			}
		}
	}
}
