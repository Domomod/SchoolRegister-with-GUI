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
	[Register ("AdminViewControllerController")]
	partial class AdminViewControllerController
	{
		[Outlet]
		AppKit.NSButton AddParentApply { get; set; }

		[Outlet]
		AppKit.NSTextField AddParentEMail { get; set; }

		[Outlet]
		AppKit.NSTextField AddParentHome { get; set; }

		[Outlet]
		AppKit.NSView AddParentIncome { get; set; }

		[Outlet]
		AppKit.NSTextField AddParentLastName { get; set; }

		[Outlet]
		AppKit.NSTextField AddParentName { get; set; }

		[Outlet]
		AppKit.NSTextField AddParentPesel { get; set; }

		[Outlet]
		AppKit.NSTextField AddParentPhone { get; set; }

		[Outlet]
		AppKit.NSButton AddStudentApply { get; set; }

		[Outlet]
		AppKit.NSPopUpButton AddStudentClass { get; set; }

		[Outlet]
		AppKit.NSTextField AddStudentEMail { get; set; }

		[Outlet]
		AppKit.NSTextField AddStudentHome { get; set; }

		[Outlet]
		AppKit.NSTextField AddStudentLastName { get; set; }

		[Outlet]
		AppKit.NSTextField AddStudentName { get; set; }

		[Outlet]
		AppKit.NSTextField AddStudentNum { get; set; }

		[Outlet]
		AppKit.NSTextField AddStudentPesel { get; set; }

		[Outlet]
		AppKit.NSTextField AddStudentPhone { get; set; }

		[Outlet]
		AppKit.NSButton AddSubjectApply { get; set; }

		[Outlet]
		AppKit.NSTextField AddSubjectName { get; set; }

		[Outlet]
		AppKit.NSButton AddteacherApply { get; set; }

		[Outlet]
		AppKit.NSTextField AddTeacherEMail { get; set; }

		[Outlet]
		AppKit.NSTextField AddTeacherHome { get; set; }

		[Outlet]
		AppKit.NSTextField AddTeacherHour { get; set; }

		[Outlet]
		AppKit.NSTextField AddTeacherName { get; set; }

		[Outlet]
		AppKit.NSTextField AddTeacherPesel { get; set; }

		[Outlet]
		AppKit.NSTextField AddTeacherPhone { get; set; }

		[Outlet]
		AppKit.NSTextField AddTeacheśrLastName { get; set; }

		[Outlet]
		AppKit.NSButton AddUnitApply { get; set; }

		[Outlet]
		AppKit.NSComboBox AddUnitHour { get; set; }

		[Outlet]
		AppKit.NSTextField AddUnitMinute { get; set; }

		[Outlet]
		AppKit.NSButton ChangeFormTutorApply { get; set; }

		[Outlet]
		AppKit.NSComboBox ChangeFormTutorClass { get; set; }

		[Outlet]
		AppKit.NSComboBox ChangeFormTutorTutor { get; set; }

		[Outlet]
		AppKit.NSButton CreateClassApply { get; set; }

		[Outlet]
		AppKit.NSComboBox CreateClassFormTutor { get; set; }

		[Outlet]
		AppKit.NSTextField CreateClassLetter { get; set; }

		[Outlet]
		AppKit.NSComboBox CreateClassProfile { get; set; }

		[Outlet]
		AppKit.NSTextField CreateClassYear { get; set; }

		[Outlet]
		AppKit.NSButton CreateLessonApply { get; set; }

		[Outlet]
		AppKit.NSComboBox CreateLessonClassLetter { get; set; }

		[Outlet]
		AppKit.NSComboBox CreateLessonClassNum { get; set; }

		[Outlet]
		AppKit.NSComboBox CreateLessonDay { get; set; }

		[Outlet]
		AppKit.NSComboBox CreateLessonFloor { get; set; }

		[Outlet]
		AppKit.NSComboBox CreateLessonRoom { get; set; }

		[Outlet]
		AppKit.NSComboBox CreateLessonSubject { get; set; }

		[Outlet]
		AppKit.NSComboBox CreateLessonUnitHour { get; set; }

		[Outlet]
		AppKit.NSComboBox CreateLessonUnitMinute { get; set; }

		[Outlet]
		AppKit.NSButton CreateRoomApply { get; set; }

		[Outlet]
		AppKit.NSTextField CreateRoomChairs { get; set; }

		[Outlet]
		AppKit.NSTextField CreateRoomFloor { get; set; }

		[Outlet]
		AppKit.NSTextField CreateRoomRoom { get; set; }

		[Outlet]
		AppKit.NSButton GrillApply { get; set; }

		[Outlet]
		AppKit.NSComboBox GrillParent { get; set; }

		[Outlet]
		AppKit.NSComboBox GrillStudent { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (AddStudentPesel != null) {
				AddStudentPesel.Dispose ();
				AddStudentPesel = null;
			}

			if (AddStudentName != null) {
				AddStudentName.Dispose ();
				AddStudentName = null;
			}

			if (AddStudentPhone != null) {
				AddStudentPhone.Dispose ();
				AddStudentPhone = null;
			}

			if (AddStudentLastName != null) {
				AddStudentLastName.Dispose ();
				AddStudentLastName = null;
			}

			if (AddStudentEMail != null) {
				AddStudentEMail.Dispose ();
				AddStudentEMail = null;
			}

			if (AddStudentClass != null) {
				AddStudentClass.Dispose ();
				AddStudentClass = null;
			}

			if (AddStudentNum != null) {
				AddStudentNum.Dispose ();
				AddStudentNum = null;
			}

			if (AddStudentHome != null) {
				AddStudentHome.Dispose ();
				AddStudentHome = null;
			}

			if (GrillParent != null) {
				GrillParent.Dispose ();
				GrillParent = null;
			}

			if (GrillStudent != null) {
				GrillStudent.Dispose ();
				GrillStudent = null;
			}

			if (CreateClassYear != null) {
				CreateClassYear.Dispose ();
				CreateClassYear = null;
			}

			if (CreateClassLetter != null) {
				CreateClassLetter.Dispose ();
				CreateClassLetter = null;
			}

			if (CreateClassFormTutor != null) {
				CreateClassFormTutor.Dispose ();
				CreateClassFormTutor = null;
			}

			if (CreateClassProfile != null) {
				CreateClassProfile.Dispose ();
				CreateClassProfile = null;
			}

			if (CreateLessonClassNum != null) {
				CreateLessonClassNum.Dispose ();
				CreateLessonClassNum = null;
			}

			if (CreateLessonClassLetter != null) {
				CreateLessonClassLetter.Dispose ();
				CreateLessonClassLetter = null;
			}

			if (CreateLessonFloor != null) {
				CreateLessonFloor.Dispose ();
				CreateLessonFloor = null;
			}

			if (CreateLessonRoom != null) {
				CreateLessonRoom.Dispose ();
				CreateLessonRoom = null;
			}

			if (CreateLessonUnitHour != null) {
				CreateLessonUnitHour.Dispose ();
				CreateLessonUnitHour = null;
			}

			if (CreateLessonUnitMinute != null) {
				CreateLessonUnitMinute.Dispose ();
				CreateLessonUnitMinute = null;
			}

			if (CreateLessonSubject != null) {
				CreateLessonSubject.Dispose ();
				CreateLessonSubject = null;
			}

			if (CreateLessonDay != null) {
				CreateLessonDay.Dispose ();
				CreateLessonDay = null;
			}

			if (CreateRoomFloor != null) {
				CreateRoomFloor.Dispose ();
				CreateRoomFloor = null;
			}

			if (CreateRoomChairs != null) {
				CreateRoomChairs.Dispose ();
				CreateRoomChairs = null;
			}

			if (CreateRoomRoom != null) {
				CreateRoomRoom.Dispose ();
				CreateRoomRoom = null;
			}

			if (ChangeFormTutorClass != null) {
				ChangeFormTutorClass.Dispose ();
				ChangeFormTutorClass = null;
			}

			if (ChangeFormTutorTutor != null) {
				ChangeFormTutorTutor.Dispose ();
				ChangeFormTutorTutor = null;
			}

			if (AddUnitHour != null) {
				AddUnitHour.Dispose ();
				AddUnitHour = null;
			}

			if (AddUnitMinute != null) {
				AddUnitMinute.Dispose ();
				AddUnitMinute = null;
			}

			if (AddSubjectName != null) {
				AddSubjectName.Dispose ();
				AddSubjectName = null;
			}

			if (AddParentIncome != null) {
				AddParentIncome.Dispose ();
				AddParentIncome = null;
			}

			if (AddParentPhone != null) {
				AddParentPhone.Dispose ();
				AddParentPhone = null;
			}

			if (AddParentEMail != null) {
				AddParentEMail.Dispose ();
				AddParentEMail = null;
			}

			if (AddParentHome != null) {
				AddParentHome.Dispose ();
				AddParentHome = null;
			}

			if (AddParentLastName != null) {
				AddParentLastName.Dispose ();
				AddParentLastName = null;
			}

			if (AddParentName != null) {
				AddParentName.Dispose ();
				AddParentName = null;
			}

			if (AddParentPesel != null) {
				AddParentPesel.Dispose ();
				AddParentPesel = null;
			}

			if (AddTeacherPesel != null) {
				AddTeacherPesel.Dispose ();
				AddTeacherPesel = null;
			}

			if (AddTeacherHour != null) {
				AddTeacherHour.Dispose ();
				AddTeacherHour = null;
			}

			if (AddTeacherPhone != null) {
				AddTeacherPhone.Dispose ();
				AddTeacherPhone = null;
			}

			if (AddTeacherEMail != null) {
				AddTeacherEMail.Dispose ();
				AddTeacherEMail = null;
			}

			if (AddTeacherHome != null) {
				AddTeacherHome.Dispose ();
				AddTeacherHome = null;
			}

			if (AddTeacheśrLastName != null) {
				AddTeacheśrLastName.Dispose ();
				AddTeacheśrLastName = null;
			}

			if (AddTeacherName != null) {
				AddTeacherName.Dispose ();
				AddTeacherName = null;
			}

			if (AddSubjectApply != null) {
				AddSubjectApply.Dispose ();
				AddSubjectApply = null;
			}

			if (AddParentApply != null) {
				AddParentApply.Dispose ();
				AddParentApply = null;
			}

			if (AddteacherApply != null) {
				AddteacherApply.Dispose ();
				AddteacherApply = null;
			}

			if (AddUnitApply != null) {
				AddUnitApply.Dispose ();
				AddUnitApply = null;
			}

			if (CreateRoomApply != null) {
				CreateRoomApply.Dispose ();
				CreateRoomApply = null;
			}

			if (GrillApply != null) {
				GrillApply.Dispose ();
				GrillApply = null;
			}

			if (AddStudentApply != null) {
				AddStudentApply.Dispose ();
				AddStudentApply = null;
			}

			if (CreateClassApply != null) {
				CreateClassApply.Dispose ();
				CreateClassApply = null;
			}

			if (CreateLessonApply != null) {
				CreateLessonApply.Dispose ();
				CreateLessonApply = null;
			}

			if (ChangeFormTutorApply != null) {
				ChangeFormTutorApply.Dispose ();
				ChangeFormTutorApply = null;
			}
		}
	}
}
