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
		AppKit.NSComboBox AAClassForm { get; set; }

		[Outlet]
		AppKit.NSTextField AAClassLetter { get; set; }

		[Outlet]
		AppKit.NSComboBox AAClassProfile { get; set; }

		[Outlet]
		AppKit.NSTextField AAClassYear { get; set; }

		[Outlet]
		AppKit.NSComboBox AAddStClass { get; set; }

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
		AppKit.NSComboBox AALessClL { get; set; }

		[Outlet]
		AppKit.NSComboBox AALessClY { get; set; }

		[Outlet]
		AppKit.NSComboBox AALessDay { get; set; }

		[Outlet]
		AppKit.NSComboBox AALessRF { get; set; }

		[Outlet]
		AppKit.NSComboBox AALessRR { get; set; }

		[Outlet]
		AppKit.NSComboBox AALessSub { get; set; }

		[Outlet]
		AppKit.NSComboBox AALessUH { get; set; }

		[Outlet]
		AppKit.NSComboBox AALessUM { get; set; }

		[Outlet]
		AppKit.NSTextField AAParHome { get; set; }

		[Outlet]
		AppKit.NSTextField AAParLast { get; set; }

		[Outlet]
		AppKit.NSTextField AAParMail { get; set; }

		[Outlet]
		AppKit.NSTextField AAParMoney { get; set; }

		[Outlet]
		AppKit.NSTextField AAParNa { get; set; }

		[Outlet]
		AppKit.NSTextField AAParNum { get; set; }

		[Outlet]
		AppKit.NSTextField AAParPe { get; set; }

		[Outlet]
		AppKit.NSTextField AARoomChairs { get; set; }

		[Outlet]
		AppKit.NSTextField AARoomFloor { get; set; }

		[Outlet]
		AppKit.NSTextField AARoomRoom { get; set; }

		[Outlet]
		AppKit.NSTextField AASub { get; set; }

		[Outlet]
		AppKit.NSTextField AATaNa { get; set; }

		[Outlet]
		AppKit.NSTextField AATeaHome { get; set; }

		[Outlet]
		AppKit.NSTextField AATeaLast { get; set; }

		[Outlet]
		AppKit.NSTextField AATeaMail { get; set; }

		[Outlet]
		AppKit.NSTextField AATeaName { get; set; }

		[Outlet]
		AppKit.NSTextField AATeaPe { get; set; }

		[Outlet]
		AppKit.NSTextField AATeaPhone { get; set; }

		[Outlet]
		AppKit.NSTextField AATeaWork { get; set; }

		[Outlet]
		AppKit.NSComboBox AAUnitH { get; set; }

		[Outlet]
		AppKit.NSTextField AAUnitM { get; set; }

		[Outlet]
		AppKit.NSComboBox ACClass { get; set; }

		[Outlet]
		AppKit.NSComboBox ACForm { get; set; }

		[Outlet]
		AppKit.NSComboBox AGrillParent { get; set; }

		[Outlet]
		AppKit.NSComboBox AGrillStudent { get; set; }

		[Outlet]
		AppKit.NSTextFieldCell PeselInput { get; set; }

		[Outlet]
		AppKit.NSComboBox PLegitimizeData { get; set; }

		[Outlet]
		AppKit.NSComboBox PLegitimizeName { get; set; }

		[Outlet]
		AppKit.NSScrollView PMyChildrenNotes { get; set; }

		[Outlet]
		AppKit.NSScrollView PMyChildrenPresance { get; set; }

		[Outlet]
		AppKit.NSScrollView PMyChildrenWarnings { get; set; }

		[Outlet]
		AppKit.NSTableColumn PNoteAvg { get; set; }

		[Outlet]
		AppKit.NSTableColumn PNoteChildrenNames { get; set; }

		[Outlet]
		AppKit.NSTableColumn PNoteChildrenSubject { get; set; }

		[Outlet]
		AppKit.NSTableColumn PNoteNotes { get; set; }

		[Outlet]
		AppKit.NSTableColumn PPreData { get; set; }

		[Outlet]
		AppKit.NSTableColumn PPreName { get; set; }

		[Outlet]
		AppKit.NSTableColumn PPreStatus { get; set; }

		[Outlet]
		AppKit.NSTableColumn PPreUnit { get; set; }

		[Outlet]
		AppKit.NSTableColumn PWarDesc { get; set; }

		[Outlet]
		AppKit.NSTableColumn PWarName { get; set; }

		[Outlet]
		AppKit.NSTableColumn PWarPoints { get; set; }

		[Outlet]
		AppKit.NSScrollView StudentShowMyNotes { get; set; }

		[Outlet]
		AppKit.NSScrollView StudentShowMyPresance { get; set; }

		[Outlet]
		AppKit.NSTextField StudentShowMyWarningsPoints { get; set; }

		[Outlet]
		AppKit.NSScrollView StudentShowMyWarningsTab { get; set; }

		[Outlet]
		AppKit.NSComboBox TChePrCl { get; set; }

		[Outlet]
		AppKit.NSScrollView TChePrst { get; set; }

		[Outlet]
		AppKit.NSScrollView TChePrSt { get; set; }

		[Outlet]
		AppKit.NSComboBox TChePrU { get; set; }

		[Outlet]
		AppKit.NSTextField TextOnFirstPage { get; set; }

		[Action ("AAClassApply:")]
		partial void AAClassApply (Foundation.NSObject sender);

		[Action ("AAddParApply:")]
		partial void AAddParApply (Foundation.NSObject sender);

		[Action ("AAFOrmApply:")]
		partial void AAFOrmApply (Foundation.NSObject sender);

		[Action ("AAGrilApply:")]
		partial void AAGrilApply (Foundation.NSObject sender);

		[Action ("AAGrillApply:")]
		partial void AAGrillApply (Foundation.NSObject sender);

		[Action ("AALessonApply:")]
		partial void AALessonApply (Foundation.NSObject sender);

		[Action ("AARoomAPply:")]
		partial void AARoomAPply (Foundation.NSObject sender);

		[Action ("AAStudentApply:")]
		partial void AAStudentApply (Foundation.NSObject sender);

		[Action ("AASubApply:")]
		partial void AASubApply (Foundation.NSObject sender);

		[Action ("AATeacher:")]
		partial void AATeacher (Foundation.NSObject sender);

		[Action ("AAUnitApply:")]
		partial void AAUnitApply (Foundation.NSObject sender);

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

		[Action ("PLegitimizeApply:")]
		partial void PLegitimizeApply (Foundation.NSObject sender);

		[Action ("PLegitimizeSearch:")]
		partial void PLegitimizeSearch (Foundation.NSObject sender);

		[Action ("TChePrApply:")]
		partial void TChePrApply (Foundation.NSObject sender);

		[Action ("TChePrFins:")]
		partial void TChePrFins (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (TChePrCl != null) {
				TChePrCl.Dispose ();
				TChePrCl = null;
			}

			if (TChePrU != null) {
				TChePrU.Dispose ();
				TChePrU = null;
			}

			if (TChePrst != null) {
				TChePrst.Dispose ();
				TChePrst = null;
			}

			if (TChePrSt != null) {
				TChePrSt.Dispose ();
				TChePrSt = null;
			}

			if (AAClassForm != null) {
				AAClassForm.Dispose ();
				AAClassForm = null;
			}

			if (AAClassLetter != null) {
				AAClassLetter.Dispose ();
				AAClassLetter = null;
			}

			if (AAClassProfile != null) {
				AAClassProfile.Dispose ();
				AAClassProfile = null;
			}

			if (AAClassYear != null) {
				AAClassYear.Dispose ();
				AAClassYear = null;
			}

			if (AAddStClass != null) {
				AAddStClass.Dispose ();
				AAddStClass = null;
			}

			if (AAddStHome != null) {
				AAddStHome.Dispose ();
				AAddStHome = null;
			}

			if (AAddStLast != null) {
				AAddStLast.Dispose ();
				AAddStLast = null;
			}

			if (AAddStMail != null) {
				AAddStMail.Dispose ();
				AAddStMail = null;
			}

			if (AAddStName != null) {
				AAddStName.Dispose ();
				AAddStName = null;
			}

			if (AAddStNum != null) {
				AAddStNum.Dispose ();
				AAddStNum = null;
			}

			if (AAddStPesel != null) {
				AAddStPesel.Dispose ();
				AAddStPesel = null;
			}

			if (AAddStRegNum != null) {
				AAddStRegNum.Dispose ();
				AAddStRegNum = null;
			}

			if (AALessClL != null) {
				AALessClL.Dispose ();
				AALessClL = null;
			}

			if (AALessClY != null) {
				AALessClY.Dispose ();
				AALessClY = null;
			}

			if (AALessDay != null) {
				AALessDay.Dispose ();
				AALessDay = null;
			}

			if (AALessRF != null) {
				AALessRF.Dispose ();
				AALessRF = null;
			}

			if (AALessRR != null) {
				AALessRR.Dispose ();
				AALessRR = null;
			}

			if (AALessSub != null) {
				AALessSub.Dispose ();
				AALessSub = null;
			}

			if (AALessUH != null) {
				AALessUH.Dispose ();
				AALessUH = null;
			}

			if (AALessUM != null) {
				AALessUM.Dispose ();
				AALessUM = null;
			}

			if (AAParHome != null) {
				AAParHome.Dispose ();
				AAParHome = null;
			}

			if (AAParLast != null) {
				AAParLast.Dispose ();
				AAParLast = null;
			}

			if (AAParMail != null) {
				AAParMail.Dispose ();
				AAParMail = null;
			}

			if (AAParMoney != null) {
				AAParMoney.Dispose ();
				AAParMoney = null;
			}

			if (AAParNa != null) {
				AAParNa.Dispose ();
				AAParNa = null;
			}

			if (AAParNum != null) {
				AAParNum.Dispose ();
				AAParNum = null;
			}

			if (AAParPe != null) {
				AAParPe.Dispose ();
				AAParPe = null;
			}

			if (AARoomChairs != null) {
				AARoomChairs.Dispose ();
				AARoomChairs = null;
			}

			if (AARoomFloor != null) {
				AARoomFloor.Dispose ();
				AARoomFloor = null;
			}

			if (AARoomRoom != null) {
				AARoomRoom.Dispose ();
				AARoomRoom = null;
			}

			if (AASub != null) {
				AASub.Dispose ();
				AASub = null;
			}

			if (AATaNa != null) {
				AATaNa.Dispose ();
				AATaNa = null;
			}

			if (AATeaHome != null) {
				AATeaHome.Dispose ();
				AATeaHome = null;
			}

			if (AATeaLast != null) {
				AATeaLast.Dispose ();
				AATeaLast = null;
			}

			if (AATeaMail != null) {
				AATeaMail.Dispose ();
				AATeaMail = null;
			}

			if (AATeaName != null) {
				AATeaName.Dispose ();
				AATeaName = null;
			}

			if (AATeaPe != null) {
				AATeaPe.Dispose ();
				AATeaPe = null;
			}

			if (AATeaPhone != null) {
				AATeaPhone.Dispose ();
				AATeaPhone = null;
			}

			if (AATeaWork != null) {
				AATeaWork.Dispose ();
				AATeaWork = null;
			}

			if (AAUnitH != null) {
				AAUnitH.Dispose ();
				AAUnitH = null;
			}

			if (AAUnitM != null) {
				AAUnitM.Dispose ();
				AAUnitM = null;
			}

			if (ACClass != null) {
				ACClass.Dispose ();
				ACClass = null;
			}

			if (ACForm != null) {
				ACForm.Dispose ();
				ACForm = null;
			}

			if (AGrillParent != null) {
				AGrillParent.Dispose ();
				AGrillParent = null;
			}

			if (AGrillStudent != null) {
				AGrillStudent.Dispose ();
				AGrillStudent = null;
			}

			if (PeselInput != null) {
				PeselInput.Dispose ();
				PeselInput = null;
			}

			if (PLegitimizeData != null) {
				PLegitimizeData.Dispose ();
				PLegitimizeData = null;
			}

			if (PLegitimizeName != null) {
				PLegitimizeName.Dispose ();
				PLegitimizeName = null;
			}

			if (PMyChildrenNotes != null) {
				PMyChildrenNotes.Dispose ();
				PMyChildrenNotes = null;
			}

			if (PMyChildrenPresance != null) {
				PMyChildrenPresance.Dispose ();
				PMyChildrenPresance = null;
			}

			if (PMyChildrenWarnings != null) {
				PMyChildrenWarnings.Dispose ();
				PMyChildrenWarnings = null;
			}

			if (PNoteAvg != null) {
				PNoteAvg.Dispose ();
				PNoteAvg = null;
			}

			if (PNoteChildrenNames != null) {
				PNoteChildrenNames.Dispose ();
				PNoteChildrenNames = null;
			}

			if (PNoteChildrenSubject != null) {
				PNoteChildrenSubject.Dispose ();
				PNoteChildrenSubject = null;
			}

			if (PNoteNotes != null) {
				PNoteNotes.Dispose ();
				PNoteNotes = null;
			}

			if (PPreData != null) {
				PPreData.Dispose ();
				PPreData = null;
			}

			if (PPreName != null) {
				PPreName.Dispose ();
				PPreName = null;
			}

			if (PPreStatus != null) {
				PPreStatus.Dispose ();
				PPreStatus = null;
			}

			if (PPreUnit != null) {
				PPreUnit.Dispose ();
				PPreUnit = null;
			}

			if (PWarDesc != null) {
				PWarDesc.Dispose ();
				PWarDesc = null;
			}

			if (PWarName != null) {
				PWarName.Dispose ();
				PWarName = null;
			}

			if (PWarPoints != null) {
				PWarPoints.Dispose ();
				PWarPoints = null;
			}

			if (StudentShowMyNotes != null) {
				StudentShowMyNotes.Dispose ();
				StudentShowMyNotes = null;
			}

			if (StudentShowMyPresance != null) {
				StudentShowMyPresance.Dispose ();
				StudentShowMyPresance = null;
			}

			if (StudentShowMyWarningsPoints != null) {
				StudentShowMyWarningsPoints.Dispose ();
				StudentShowMyWarningsPoints = null;
			}

			if (StudentShowMyWarningsTab != null) {
				StudentShowMyWarningsTab.Dispose ();
				StudentShowMyWarningsTab = null;
			}

			if (TextOnFirstPage != null) {
				TextOnFirstPage.Dispose ();
				TextOnFirstPage = null;
			}
		}
	}
}
