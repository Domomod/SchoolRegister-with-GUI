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
		AppKit.NSPopUpButton AAddStClass { get; set; }

		[Outlet]
		AppKit.NSTextField AAddStHome { get; set; }

		[Outlet]
		AppKit.NSTextField AAddStLast { get; set; }

		[Outlet]
		AppKit.NSTextField AAddStMail { get; set; }

		[Outlet]
		AppKit.NSTextField AAddStName { get; set; }

		[Outlet]
		AppKit.NSTextField AAddStNum { get; set; }

		[Outlet]
		AppKit.NSTextField AAddStPesel { get; set; }

		[Outlet]
		AppKit.NSTextField AAddStRegNum { get; set; }

		[Outlet]
		AppKit.NSTextFieldCell PeselInput { get; set; }

		[Outlet]
		AppKit.NSButton PLegitimizeApply { get; set; }

		[Outlet]
		AppKit.NSComboBox PLegitimizeData { get; set; }

		[Outlet]
		AppKit.NSComboBox PLegitimizeName { get; set; }

		[Outlet]
		AppKit.NSButton PLegitimizeSearch { get; set; }

		[Outlet]
		AppKit.NSScrollView PMyChildrenNotes { get; set; }

		[Outlet]
		AppKit.NSScrollView PMyChildrenPresance { get; set; }

		[Outlet]
		AppKit.NSScrollView PMyChildrenWarnings { get; set; }

		[Outlet]
		AppKit.NSTextField PMyInfo { get; set; }

		[Outlet]
		AppKit.NSScrollView StudentShowMyNotes { get; set; }

		[Outlet]
		AppKit.NSScrollView StudentShowMyPresance { get; set; }

		[Outlet]
		AppKit.NSTextField StudentShowMyWarningsPoints { get; set; }

		[Outlet]
		AppKit.NSScrollView StudentShowMyWarningsTab { get; set; }

		[Outlet]
		AppKit.NSButton TAddNoteApply { get; set; }

		[Outlet]
		AppKit.NSComboBox TAddNoteCat { get; set; }

		[Outlet]
		AppKit.NSComboBox TAddNoteClass { get; set; }

		[Outlet]
		AppKit.NSTextField TAddNoteDesc { get; set; }

		[Outlet]
		AppKit.NSButton TAddNoteSearch { get; set; }

		[Outlet]
		AppKit.NSComboBox TAddNoteStudent { get; set; }

		[Outlet]
		AppKit.NSView TAddNoteSub { get; set; }

		[Outlet]
		AppKit.NSComboBox TAddNotevalue { get; set; }

		[Outlet]
		AppKit.NSButton TAddWarningApply { get; set; }

		[Outlet]
		AppKit.NSComboBox TAddWarningClass { get; set; }

		[Outlet]
		AppKit.NSTextField TAddWarningDesc { get; set; }

		[Outlet]
		AppKit.NSButton TAddWarningFindStudent { get; set; }

		[Outlet]
		AppKit.NSTextField TAddWarningPoints { get; set; }

		[Outlet]
		AppKit.NSComboBox TAddWarningStudent { get; set; }

		[Outlet]
		AppKit.NSButton TCheckPresanceApply { get; set; }

		[Outlet]
		AppKit.NSButton TeacherCheckPresanceClasses { get; set; }

		[Outlet]
		AppKit.NSComboBox TeacherCheckPresanceClassLetter { get; set; }

		[Outlet]
		AppKit.NSComboBox TeacherCheckPresanceClassNum { get; set; }

		[Outlet]
		AppKit.NSComboBox TeacherCheckPresanceLessonDay { get; set; }

		[Outlet]
		AppKit.NSView TeacherCheckPresanceLessonUnit { get; set; }

		[Outlet]
		AppKit.NSScrollView TeacherCheckPresanceStudentList { get; set; }

		[Outlet]
		AppKit.NSSearchField TeacherMyData { get; set; }

		[Outlet]
		AppKit.NSButton TEditPresanceApply { get; set; }

		[Outlet]
		AppKit.NSComboBox TEditPresanceClass { get; set; }

		[Outlet]
		AppKit.NSButton TEditPresanceFindStudent { get; set; }

		[Outlet]
		AppKit.NSScrollView TEditPresanceList { get; set; }

		[Outlet]
		AppKit.NSComboBox TEditPresanceStudent { get; set; }

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
			if (StudentShowMyNotes != null) {
				StudentShowMyNotes.Dispose ();
				StudentShowMyNotes = null;
			}

			if (StudentShowMyPresance != null) {
				StudentShowMyPresance.Dispose ();
				StudentShowMyPresance = null;
			}

			if (StudentShowMyWarningsTab != null) {
				StudentShowMyWarningsTab.Dispose ();
				StudentShowMyWarningsTab = null;
			}

			if (StudentShowMyWarningsPoints != null) {
				StudentShowMyWarningsPoints.Dispose ();
				StudentShowMyWarningsPoints = null;
			}

			if (TeacherMyData != null) {
				TeacherMyData.Dispose ();
				TeacherMyData = null;
			}

			if (TeacherCheckPresanceClassNum != null) {
				TeacherCheckPresanceClassNum.Dispose ();
				TeacherCheckPresanceClassNum = null;
			}

			if (TeacherCheckPresanceClassLetter != null) {
				TeacherCheckPresanceClassLetter.Dispose ();
				TeacherCheckPresanceClassLetter = null;
			}

			if (TeacherCheckPresanceLessonDay != null) {
				TeacherCheckPresanceLessonDay.Dispose ();
				TeacherCheckPresanceLessonDay = null;
			}

			if (TeacherCheckPresanceLessonUnit != null) {
				TeacherCheckPresanceLessonUnit.Dispose ();
				TeacherCheckPresanceLessonUnit = null;
			}

			if (TeacherCheckPresanceStudentList != null) {
				TeacherCheckPresanceStudentList.Dispose ();
				TeacherCheckPresanceStudentList = null;
			}

			if (TAddNoteClass != null) {
				TAddNoteClass.Dispose ();
				TAddNoteClass = null;
			}

			if (TAddNoteStudent != null) {
				TAddNoteStudent.Dispose ();
				TAddNoteStudent = null;
			}

			if (TAddNoteDesc != null) {
				TAddNoteDesc.Dispose ();
				TAddNoteDesc = null;
			}

			if (TAddNoteSub != null) {
				TAddNoteSub.Dispose ();
				TAddNoteSub = null;
			}

			if (TAddNoteCat != null) {
				TAddNoteCat.Dispose ();
				TAddNoteCat = null;
			}

			if (TAddNotevalue != null) {
				TAddNotevalue.Dispose ();
				TAddNotevalue = null;
			}

			if (TEditPresanceClass != null) {
				TEditPresanceClass.Dispose ();
				TEditPresanceClass = null;
			}

			if (TEditPresanceStudent != null) {
				TEditPresanceStudent.Dispose ();
				TEditPresanceStudent = null;
			}

			if (TEditPresanceList != null) {
				TEditPresanceList.Dispose ();
				TEditPresanceList = null;
			}

			if (TAddWarningClass != null) {
				TAddWarningClass.Dispose ();
				TAddWarningClass = null;
			}

			if (TAddWarningStudent != null) {
				TAddWarningStudent.Dispose ();
				TAddWarningStudent = null;
			}

			if (TAddWarningPoints != null) {
				TAddWarningPoints.Dispose ();
				TAddWarningPoints = null;
			}

			if (TAddWarningDesc != null) {
				TAddWarningDesc.Dispose ();
				TAddWarningDesc = null;
			}

			if (PMyInfo != null) {
				PMyInfo.Dispose ();
				PMyInfo = null;
			}

			if (PMyChildrenNotes != null) {
				PMyChildrenNotes.Dispose ();
				PMyChildrenNotes = null;
			}

			if (PMyChildrenWarnings != null) {
				PMyChildrenWarnings.Dispose ();
				PMyChildrenWarnings = null;
			}

			if (PMyChildrenPresance != null) {
				PMyChildrenPresance.Dispose ();
				PMyChildrenPresance = null;
			}

			if (PLegitimizeName != null) {
				PLegitimizeName.Dispose ();
				PLegitimizeName = null;
			}

			if (PLegitimizeData != null) {
				PLegitimizeData.Dispose ();
				PLegitimizeData = null;
			}

			if (AAddStPesel != null) {
				AAddStPesel.Dispose ();
				AAddStPesel = null;
			}

			if (AAddStName != null) {
				AAddStName.Dispose ();
				AAddStName = null;
			}

			if (AAddStRegNum != null) {
				AAddStRegNum.Dispose ();
				AAddStRegNum = null;
			}

			if (AAddStClass != null) {
				AAddStClass.Dispose ();
				AAddStClass = null;
			}

			if (AAddStMail != null) {
				AAddStMail.Dispose ();
				AAddStMail = null;
			}

			if (AAddStLast != null) {
				AAddStLast.Dispose ();
				AAddStLast = null;
			}

			if (AAddStHome != null) {
				AAddStHome.Dispose ();
				AAddStHome = null;
			}

			if (AAddStNum != null) {
				AAddStNum.Dispose ();
				AAddStNum = null;
			}

			if (PLegitimizeApply != null) {
				PLegitimizeApply.Dispose ();
				PLegitimizeApply = null;
			}

			if (PLegitimizeSearch != null) {
				PLegitimizeSearch.Dispose ();
				PLegitimizeSearch = null;
			}

			if (TAddNoteApply != null) {
				TAddNoteApply.Dispose ();
				TAddNoteApply = null;
			}

			if (TEditPresanceFindStudent != null) {
				TEditPresanceFindStudent.Dispose ();
				TEditPresanceFindStudent = null;
			}

			if (TEditPresanceApply != null) {
				TEditPresanceApply.Dispose ();
				TEditPresanceApply = null;
			}

			if (TAddWarningFindStudent != null) {
				TAddWarningFindStudent.Dispose ();
				TAddWarningFindStudent = null;
			}

			if (TAddWarningApply != null) {
				TAddWarningApply.Dispose ();
				TAddWarningApply = null;
			}

			if (TAddNoteSearch != null) {
				TAddNoteSearch.Dispose ();
				TAddNoteSearch = null;
			}

			if (TCheckPresanceApply != null) {
				TCheckPresanceApply.Dispose ();
				TCheckPresanceApply = null;
			}

			if (TeacherCheckPresanceClasses != null) {
				TeacherCheckPresanceClasses.Dispose ();
				TeacherCheckPresanceClasses = null;
			}

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
