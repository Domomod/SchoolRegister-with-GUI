using System;
using System.Collections.Generic;
using AppKit;
using Foundation;

namespace gui
{
    public partial class ViewController : NSViewController
    {
        Backendoptions back;

        SQLChecker checker;

        public ViewController(IntPtr handle) : base(handle)
        {
            back = new Backendoptions();
            back.OpenConnection();
            checker = new SQLChecker();
            SetClasses();
            AAUnitH = new NSComboBox();
            AAddStClass = new NSComboBox();
            AGrillParent = new NSComboBox();
            AGrillStudent = new NSComboBox();
            ACForm = new NSComboBox();
            ACClass = new NSComboBox();
            AALessClL = new NSComboBox();
            AALessDay = new NSComboBox();
            AALessRR = new NSComboBox();
            AALessUH = new NSComboBox();
            AALessSub = new NSComboBox();
            AAClassForm = new NSComboBox();
            AAClassProfile = new NSComboBox();
            PLegitimizeName = new NSComboBox();
            PLegitimizeData = new NSComboBox();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Do any additional setup after loading the view.
            var listHours = new List<string>(new string[] { "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16" });
            AAUnitH.UsesDataSource = true;
            AAUnitH.DataSource = new MyCombo(listHours);
            AAddStClass.UsesDataSource = true;
            AAddStClass.DataSource = new MyCombo(back.GetClasses());
            AGrillParent.UsesDataSource = true;
            AGrillStudent.UsesDataSource = true;
            AGrillStudent.DataSource = new MyCombo(back.GetAllStudents());
            AGrillParent.DataSource = new MyCombo(back.GetAllParents());
            ACForm.UsesDataSource = true;
            ACClass.UsesDataSource = true;
            ACForm.DataSource = new MyCombo(back.GetTeachers());
            ACClass.DataSource = new MyCombo(back.GetClasses());
            AALessSub.UsesDataSource = true;
            AALessUH.UsesDataSource = true;
            AALessRR.UsesDataSource = true;
            AALessDay.UsesDataSource = true;
            AALessClL.UsesDataSource = true;
            var listDay = new List<string>(new string[] { "1", "2", "3", "4", "5", "6" });
            AALessDay.DataSource=new MyCombo(listDay);
            AALessSub.DataSource = new MyCombo(back.GetSubjects());
            AALessRR.DataSource = new MyCombo(back.GetRooms());
            AALessUH.DataSource = new MyCombo(back.GetUnits());
            AALessClL.DataSource = new MyCombo(back.GetClasses());
            AAClassProfile.UsesDataSource = true;
            AAClassProfile.DataSource = new MyCombo(back.GetProfiles());
            AAClassForm.UsesDataSource = true;
            AAClassForm.DataSource = new MyCombo(back.GetTeachers());
            PLegitimizeName.UsesDataSource = true;
            PLegitimizeData.UsesDataSource = true;
        }



        public override NSObject RepresentedObject
        {
            get
            {
                return base.RepresentedObject;
            }
            set
            {
                base.RepresentedObject = value;
                // Update the view, if already loaded.
            }
        }

        partial void FirstUseButton(AppKit.NSButton sender)
        {
            back = new Backendoptions();
            back.FirstUse();
        }


        partial void LogInAdminMode(AppKit.NSButton sender)
        {
            if (PeselInput.StringValue == "666")
            {
                var storyboard = NSStoryboard.FromName("Main", null);
                var controller = storyboard.InstantiateControllerWithIdentifier("2") as NSWindowController;
                controller.ShowWindow(this);
            }
            else
                TextOnFirstPage.StringValue = "Illigal valju";

            
        }

        partial void LogInAsParent(AppKit.NSButton sender)
        {
            if (checker.IsCorrect(PeselInput.StringValue) & back.LogInAsParent(PeselInput.StringValue))
            {
                var storyboard = NSStoryboard.FromName("Main", null);
                var controller = storyboard.InstantiateControllerWithIdentifier("5") as NSWindowController;
                controller.ShowWindow(this);
               
            }
                
            else
                TextOnFirstPage.StringValue = "Błędny pesel";

        }

        partial void LogInAsStudent(AppKit.NSButton sender)
        {
            if (back.LogInAsStudent(PeselInput.StringValue))
            {
                var storyboard = NSStoryboard.FromName("Main", null);
                var controller = storyboard.InstantiateControllerWithIdentifier("3") as NSWindowController;
                controller.ShowWindow(this);
            }
                
            else
                TextOnFirstPage.StringValue = "Błędny pesel";
        }


        partial void LogInAsTeacher(AppKit.NSButton sender)
        {
            //if (back.LogInAsTeacher(PeselInput.StringValue))
            {
                var storyboard = NSStoryboard.FromName("Main", null);
                var controller = storyboard.InstantiateControllerWithIdentifier("9") as NSWindowController;
                controller.ShowWindow(this);
            }
           // else
                TextOnFirstPage.StringValue = "Błędny pesel";
        }

        partial void AASubApply(Foundation.NSObject sender)
        {
            if (AASub.StringValue != "" & checker.IsCorrect(AASub.StringValue))
                back.AddSubject(AASub.StringValue);

        }

        partial void AAClassApply(Foundation.NSObject sender)
        {
            int t;
            if (AAClassLetter.StringValue != "" & checker.IsCorrect(AAClassLetter.StringValue) )
                if (int.TryParse(AAClassYear.StringValue, out t) & t>2000 & t<3000)
                    back.AddClass(AAClassYear.StringValue, AAClassLetter.StringValue, AAClassForm.StringValue, AAClassProfile.StringValue);
        }



        partial void AAFOrmApply(Foundation.NSObject sender)
        {

            var tutor = ACForm.StringValue;
            var clas = ACClass.StringValue;
            back.ChangeFormTutor(tutor, clas);
        }

        partial void AAGrilApply(Foundation.NSObject sender)
        {
            string parent = AGrillParent.StringValue;
            string child = AGrillStudent.StringValue;
            back.Grill(parent, child);

        }

        partial void AALessonApply(Foundation.NSObject sender)
        {
            var clas = AALessClL.StringValue;
            var room = AALessRR.StringValue;
            var day = AALessDay.StringValue;
            var unitHour = AALessUH.StringValue;
            var subject = AALessSub.StringValue;
            back.AddLesson(day, unitHour, clas, room, subject);
        }

        partial void AARoomAPply(Foundation.NSObject sender)
        {
            int t;
            if (int.TryParse(AARoomFloor.ToString(), out t))
                if (int.TryParse(AARoomRoom.ToString(), out t))
                    if (int.TryParse(AARoomChairs.ToString(), out t))
                        back.AddRoom(AARoomFloor.ToString(), AARoomRoom.ToString(), AARoomChairs.ToString());
        }


        partial void AAStudentApply(Foundation.NSObject sender)
        {
            int t;
            if (checker.IsPesel(AAddStPesel.StringValue))
                if (checker.IsCorrect(AAddStName.StringValue) & checker.IsCorrect(AAddStLast.StringValue))
                    if (AAddStHome.StringValue == "" | checker.IsCorrect(AAddStHome.StringValue))
                        if (AAddStMail.StringValue == "" | checker.IsCorrect(AAddStMail.StringValue))
                            if (AAddStNum.StringValue == "" | int.TryParse(AAddStNum.StringValue, out t))
                                if (int.TryParse(AAddStRegNum.StringValue, out t)) {
                                   
                                    back.AddStudent(AAddStPesel.StringValue, AAddStName.StringValue, AAddStLast.StringValue, AAddStHome.StringValue, AAddStNum.StringValue, AAddStMail.StringValue, AAddStClass.StringValue, AAddStRegNum.StringValue);
                                    }
        }



        partial void AATeacher(Foundation.NSObject sender)
        {
            int t;
            decimal d;
            if (checker.IsPesel(AATeaPe.StringValue))
                if (checker.IsCorrect(AATeaName.StringValue) & checker.IsCorrect(AATeaLast.StringValue))
                    if (AATeaHome.StringValue == "" | checker.IsCorrect(AATeaHome.StringValue))
                        if (AATeaMail.StringValue == "" | checker.IsCorrect(AATeaMail.StringValue))
                            if (AATeaPhone.StringValue == "" | int.TryParse(AATeaPhone.StringValue, out t))
                                if (AATeaWork.StringValue == "" | decimal.TryParse(AATeaWork.StringValue, out d))
                                    back.AddTeacher(AATeaPe.StringValue, AATeaName.StringValue, AATeaLast.StringValue, AATeaHome.StringValue, AATeaPhone.StringValue, AATeaMail.StringValue, AATeaWork.StringValue);
        }

        partial void AAUnitApply(Foundation.NSObject sender)
        {
            int t;
            if (int.TryParse(AAUnitM.StringValue, out t))
                back.AddUnit(AAUnitH.StringValue, AAUnitM.StringValue);
        }

        partial void PLegitimizeApply(Foundation.NSObject sender)
        {
            back.LegitimizeAbsence(PLegitimizeName.StringValue, PLegitimizeData.StringValue);

        }

        partial void AAddParApply(Foundation.NSObject sender)
        {
            int t;
            decimal d;
            if (checker.IsPesel(AAParPe.StringValue))
                if (checker.IsCorrect(AAParNa.StringValue) & checker.IsCorrect(AAParLast.StringValue))
                    if (AAParHome.StringValue == "" | checker.IsCorrect(AAParHome.StringValue))
                        if (AAParMail.StringValue == "" | checker.IsCorrect(AAParMail.StringValue))
                            if (AAParNum.StringValue == "" | int.TryParse(AAParNum.StringValue, out t))
                                if (AAParMoney.StringValue == "" | decimal.TryParse(AAParMoney.StringValue, out d))
                                    back.AddParent(AAParPe.StringValue, AAParNa.StringValue, AAParLast.StringValue, AAParHome.StringValue, AAParNum.StringValue, AAParMail.StringValue, AAParMoney.StringValue);
        }


        partial void PLegitimizeSearch(Foundation.NSObject sender) {

            var pesel = back.ChildPesel(PLegitimizeName.StringValue);
            PLegitimizeData.DataSource = new MyCombo(back.GetAbsence(pesel));
        }

        partial void TANoteApply(Foundation.NSObject sender) {
            if (checker.IsCorrect(TAddNoteDesc.ToString()))
            { var pesel = back.GetPeselFromNames(TAddNoteStudent[TAddNoteStudent.SelectedIndex].ToString());
                back.AddNote(TAddNotevalue[TAddNotevalue.SelectedIndex].ToString(),
                    TAddNoteDesc.ToString(), TAddNoteCat[TAddNoteCat.SelectedIndex].ToString(),
                    TAddNoteSubj[TAddNoteSubj.SelectedIndex].ToString(), pesel);
            }
                
        }
        partial void TANoteSearch(Foundation.NSObject sender) {
            back.GetStudents(TAddNoteClass[TAddNoteClass.SelectedIndex].ToString());
        }
        partial void TAWarningApply(Foundation.NSObject sender) {
            int t;
            if (checker.IsCorrect(TAddWarningDesc.ToString()) &(TAddWarningPoints.ToString()=="" | int.TryParse(TAddWarningPoints.ToString(),out t)))
            {
                var pesel = TAddWarningStudent[TAddWarningStudent.SelectedIndex].ToString();
                back.AddWarning(TAddWarningDesc.ToString(), TAddWarningPoints.ToString(), pesel);

            }
        }
        partial void TAWarningSearch(Foundation.NSObject sender) {
            back.GetStudents(TAddWarningClass[TAddWarningClass.SelectedIndex].ToString());

        }
        partial void TCheckPrApply(Foundation.NSObject sender) {


        }
        partial void TCheckPrSearch(Foundation.NSObject sender) {

        }
        partial void TChePrApply(Foundation.NSObject sender) {

        }
        partial void TChePrSearch(Foundation.NSObject sender) {
            
        }



        void SetClasses()
        {
            
        }

        void SetChildrenNames()
        {

        }
    }


    
}