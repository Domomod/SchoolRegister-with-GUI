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
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		AppKit.NSTextFieldCell PeselInput { get; set; }

		[Outlet]
		AppKit.NSTextField TextOnFirstPage { get; set; }

		[Action ("FirstUseButton:")]
		partial void FirstUseButton (AppKit.NSButton sender);

		[Action ("LogInAdminMode:")]
		partial void LogInAdminMode (AppKit.NSButton sender);

		[Action ("LogInAsParent:")]
		partial void LogInAsParent (AppKit.NSButton sender);

		[Action ("LogInAsStudent:")]
		partial void LogInAsStudent (AppKit.NSButton sender);

		[Action ("LogInAsTeacher:")]
		partial void LogInAsTeacher (AppKit.NSButton sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (PeselInput != null) {
				PeselInput.Dispose ();
				PeselInput = null;
			}

			if (TextOnFirstPage != null) {
				TextOnFirstPage.Dispose ();
				TextOnFirstPage = null;
			}
		}
	}
}
