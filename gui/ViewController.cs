using System;

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
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Do any additional setup after loading the view.


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
            //if (checker.IsCorrect(PeselInput.StringValue) & back.LogInAsParent(PeselInput.StringValue))
            {
                var storyboard = NSStoryboard.FromName("Main", null);
                var controller = storyboard.InstantiateControllerWithIdentifier("5") as NSWindowController;
                controller.ShowWindow(this);
            }
                
            //else
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
            if (AAClassLetter.StringValue != "" & checker.IsCorrect(AAClassLetter.StringValue))
                if (AAClassYear.StringValue != "" & checker.IsCorrect(AAClassYear.StringValue))
                    back.AddClass(AAClassYear.StringValue, AAClassLetter.StringValue, AAClassForm.StringValue, AAClassProfile.StringValue);
        }



        partial void AAFOrmApply(Foundation.NSObject sender)
        {
            string tutor = ACForm[ACForm.SelectedIndex].ToString();
            string clas= ACClass[ACClass.SelectedIndex].ToString();
            back.ChangeFormTutor(tutor, clas[0].ToString()+clas[1].ToString()+clas[2].ToString()+clas[3].ToString(), clas[4].ToString());
        }

        partial void AAGrilApply(Foundation.NSObject sender)
        {
            string parent = AGrillParent[AGrillParent.SelectedIndex].ToString();
            string child = AGrillStudent[AGrillStudent.SelectedIndex].ToString();
            back.Grill(parent, child);

        }

        partial void AALessonApply(Foundation.NSObject sender)
        {
            var year = AALessClY[AALessClY.SelectedIndex].ToString();
            var let = AALessClL[AALessClL.SelectedIndex].ToString();
            var floor = AALessRF[AALessRF.SelectedIndex].ToString();
            var room = AALessRR[AALessRR.SelectedIndex].ToString();
            var day = AALessDay[AALessDay.SelectedIndex].ToString();
            var unitHour = AALessUH[AALessUH.SelectedIndex].ToString();
            var unitMinute = AALessUM[AALessUM.SelectedIndex].ToString();
            var subject = AALessSub[AALessSub.SelectedIndex].ToString();
            back.AddLesson(day, unitHour, unitMinute, year, let, floor, room, subject);
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
            if (int.TryParse(AAddStPesel.StringValue, out t))
                if (checker.IsCorrect(AAddStName.StringValue) & checker.IsCorrect(AAddStLast.StringValue))
                    if (AAddStHome.StringValue == "" | checker.IsCorrect(AAddStHome.StringValue))
                        if (AAddStMail.StringValue == "" | checker.IsCorrect(AAddStMail.StringValue))
                            if (AAddStNum.StringValue == "" | int.TryParse(AAddStNum.StringValue, out t))
                                if (int.TryParse(AAddStRegNum.StringValue, out t)) {
                                    var k = AAddStClass[AAddStClass.SelectedIndex].ToString();
                                    back.AddStudent(AAddStPesel.StringValue, AAddStName.StringValue, AAddStLast.StringValue, AAddStHome.StringValue, AAddStNum.StringValue, AAddStMail.StringValue, k[0].ToString() + k[1].ToString() + k[2].ToString() + k[3].ToString(), AAddStRegNum.StringValue, k[4].ToString());
                                    }
        }



        partial void AATeacher(Foundation.NSObject sender)
        {
            int t;
            decimal d;
            if (int.TryParse(AATeaPe.StringValue, out t))
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
                back.AddUnit(AAUnitH[AAUnitH.SelectedIndex].ToString(), AAUnitM.StringValue);
        }

        partial void PLegitimizeApply(Foundation.NSObject sender)
        {
        }

        partial void AAddParApply(Foundation.NSObject sender)
        {
            int t;
            decimal d;
            if (int.TryParse(AAParPe.StringValue, out t))
                if (checker.IsCorrect(AAParNa.StringValue) & checker.IsCorrect(AAParLast.StringValue))
                    if (AAParHome.StringValue == "" | checker.IsCorrect(AAParHome.StringValue))
                        if (AAParMail.StringValue == "" | checker.IsCorrect(AAParMail.StringValue))
                            if (AAParNum.StringValue == "" | int.TryParse(AAParNum.StringValue, out t))
                                if (AAParMoney.StringValue == "" | decimal.TryParse(AAParMoney.StringValue, out d))
                                    back.AddParent(AAParPe.StringValue, AAParNa.StringValue, AAParLast.StringValue, AAParHome.StringValue, AAParNum.StringValue, AAParMail.StringValue, AAParMoney.StringValue);
        }


        partial void PLegitimizeSearch(Foundation.NSObject sender) {

        }
        partial void TANoteApply(Foundation.NSObject sender) {
        }
        partial void TANoteSearch(Foundation.NSObject sender) {
        }
        partial void TAWarningApply(Foundation.NSObject sender) {
        }
        partial void TAWarningSearch(Foundation.NSObject sender) {
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