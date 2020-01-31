using System;
using System.Collections.Generic;
using AppKit;
using Foundation;

namespace gui
{
    public partial class ViewController : NSViewController
    {
        public static Backendoptions back = new Backendoptions();
        SQLChecker checker;

        public ViewController(IntPtr handle) : base(handle)
        {

            if (!Backendoptions.IsOpen())
                Backendoptions.OpenConnection();
            checker = new SQLChecker();
            if (Backendoptions.isAdmin())
            {
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
                
            }
            if (Backendoptions.isParent())
            {
                PChildList = new NSComboBox();
                PMyInfo = new NSTextField();
                PLegitimize = new NSComboBox();
                
            }
            if (Backendoptions.isTeacher())
            {
                TClass = new NSComboBox();
                TWSt = new NSComboBox();
                TCNSt = new NSComboBox();
                TCNVal = new NSComboBox();
                TCNDesc = new NSComboBox();
                TNCat = new NSComboBox();
                TNSt = new NSComboBox();
                TNSub = new NSComboBox();
                TNVal = new NSComboBox();
                TPreSt = new NSComboBox();
                TPreStat = new NSComboBox();
                TPreUnit = new NSComboBox();
                TPrUnit = new NSComboBox();
            }
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Do any additional setup after loading the view.
            var listHours = new List<string>(new string[] { "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16" });
            var students = Backendoptions.GetAllStudents();
            var subjects = Backendoptions.GetSubjects();
            var classes = Backendoptions.GetClasses();
            var parents = Backendoptions.GetAllParents();
            var teachers = Backendoptions.GetTeachers();
            var rooms = Backendoptions.GetRooms();
            var units = Backendoptions.GetUnits();
            var profiles = Backendoptions.GetProfiles();
            var status = Backendoptions.GetStatuses();
            if (Backendoptions.isAdmin())
            {
                AAUnitH.UsesDataSource = true;
                AAUnitH.DataSource = new MyCombo(listHours);
                AAUnitH.SelectItem(0);
                AAddStClass.UsesDataSource = true;
                AAddStClass.DataSource = new MyCombo(classes);
                AAddStClass.SelectItem(0);
                AGrillParent.UsesDataSource = true;
                AGrillStudent.UsesDataSource = true;
                AGrillStudent.DataSource = new MyCombo(students);
                AGrillStudent.SelectItem(0);
                AGrillParent.DataSource = new MyCombo(parents);
                AGrillParent.SelectItem(0);
                ACForm.UsesDataSource = true;
                ACClass.UsesDataSource = true;
                ACForm.DataSource = new MyCombo(teachers);
                ACForm.SelectItem(0);
                ACClass.DataSource = new MyCombo(classes);
                ACClass.SelectItem(0);
                AALessSub.UsesDataSource = true;
                AALessUH.UsesDataSource = true;
                AALessRR.UsesDataSource = true;
                AALessDay.UsesDataSource = true;
                AALessClL.UsesDataSource = true;
                var listDay = new List<string>(new string[] { "1", "2", "3", "4", "5", "6" });
                AALessDay.DataSource = new MyCombo(listDay);
                AALessDay.SelectItem(0);
                AALessSub.DataSource = new MyCombo(subjects);
                AALessSub.SelectItem(0);
                AALessRR.DataSource = new MyCombo(rooms);
                AALessRR.SelectItem(0);
                AALessUH.DataSource = new MyCombo(units);
                AALessUH.SelectItem(0);
                AALessClL.DataSource = new MyCombo(classes);
                AALessClL.SelectItem(0);
                AAClassProfile.UsesDataSource = true;
                AAClassProfile.DataSource = new MyCombo(profiles);
                AAClassProfile.SelectItem(0);
                AAClassForm.UsesDataSource = true;
                AAClassForm.DataSource = new MyCombo(teachers);
                AAClassForm.SelectItem(0);
                
            }
            if (Backendoptions.isParent())
            {
                string stringinfo = "dzieci pod moją opieką:\n";
                var child = Backendoptions.GetChildren();
                foreach (var ch in child)
                {
                    stringinfo = stringinfo +" "+ ch + ",";
                }
                PMyInfo.StringValue = stringinfo.Remove(stringinfo.Length - 1);
                PChildList.UsesDataSource = true;
                PChildList.DataSource = new MyCombo(child);
                PChildList.SelectItem(0);
            }
            if (Backendoptions.isTeacher())
            {
                TClass.UsesDataSource = true;
                TClass.DataSource = new MyCombo(classes); 
                if (Backendoptions.isClassSet())
                {       TWSt.UsesDataSource = true;
                        TWSt.DataSource=new MyCombo(Backendoptions.GetStudents());
                        TNSt.UsesDataSource = true;
                        TNSt.DataSource= new MyCombo(Backendoptions.GetStudents());
                    TPreSt.UsesDataSource = true;
                    TPreSt.DataSource = new MyCombo(Backendoptions.GetStudents());
                    TWSt.SelectItem(0);
                    TNSt.SelectItem(0);
                    TPreSt.SelectItem(0);
                }
                TNVal.UsesDataSource = true;
                TNCat.UsesDataSource = true;
                TNSub.UsesDataSource = true;
                var values = new List<string>(new string[] {"1","2","2.5","3","3.5","4","4.5","5","5.5","6" });
                TNVal.DataSource = new MyCombo(values);
                TNSub.DataSource = new MyCombo(subjects);               
                TNCat.DataSource = new MyCombo(Backendoptions.GetCategories());
                TPreStat.UsesDataSource = true;
                TPreUnit.UsesDataSource = true;
                TPrUnit.UsesDataSource = true;
                TPrUnit.DataSource = new MyCombo(units);
                TPreUnit.DataSource = new MyCombo(units);
                TPreStat.DataSource = new MyCombo(status);
                TClass.SelectItem(0);
                TNVal.SelectItem(0);
                TNSub.SelectItem(0);
                TNCat.SelectItem(0);
                TPreStat.SelectItem(0);
                TPreUnit.SelectItem(0);
                TPrUnit.SelectItem(0);
            }
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

            Backendoptions.FirstUse();
        }


        partial void LogInAdminMode(AppKit.NSButton sender)
        {
            if (PeselInput.StringValue == "666")
            {
                Backendoptions.setAdmin();
                var storyboard = NSStoryboard.FromName("Main", null);
                var controller = storyboard.InstantiateControllerWithIdentifier("2") as NSWindowController;
                controller.ShowWindow(this);
            }
            else
                TextOnFirstPage.StringValue = "Illigal valju";


        }

        partial void LogInAsParent(AppKit.NSButton sender)
        {
            if (checker.IsCorrect(PeselInput.StringValue) & Backendoptions.LogInAsParent(PeselInput.StringValue))
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
            if (Backendoptions.LogInAsStudent(PeselInput.StringValue))
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
            if (checker.IsCorrect(PeselInput.StringValue) & Backendoptions.LogInAsTeacher(PeselInput.StringValue))
            {
                var storyboard = NSStoryboard.FromName("Main", null);
                var controller = storyboard.InstantiateControllerWithIdentifier("17") as NSWindowController;
                controller.ShowWindow(this);
            }
            else
                TextOnFirstPage.StringValue = "Błędny pesel";
        }

        partial void AASubApply(Foundation.NSObject sender)
        {
            if (AASub.StringValue != "" & checker.IsCorrect(AASub.StringValue))
                Backendoptions.AddSubject(AASub.StringValue);

        }

        partial void AAClassApply(Foundation.NSObject sender)
        {
            int t;
            if (AAClassLetter.StringValue != "" & checker.IsCorrect(AAClassLetter.StringValue))
                if (int.TryParse(AAClassYear.StringValue, out t) & t > 2000 & t < 3000)
                    Backendoptions.AddClass(AAClassYear.StringValue, AAClassLetter.StringValue, AAClassForm.StringValue, AAClassProfile.StringValue);
        }


        partial void AAFOrmApply(Foundation.NSObject sender)
        {

            var tutor = ACForm.StringValue;
            var clas = ACClass.StringValue;
            Backendoptions.ChangeFormTutor(tutor, clas);
        }

        partial void AAGrilApply(Foundation.NSObject sender)
        {
            string parent = AGrillParent.StringValue;
            string child = AGrillStudent.StringValue;
            Backendoptions.Grill(parent, child);

        }
        //SQL error :(
        partial void AALessonApply(Foundation.NSObject sender)
        {
            var clas = AALessClL.StringValue;
            var room = AALessRR.StringValue;
            var day = AALessDay.StringValue;
            var unitHour = AALessUH.StringValue;
            var subject = AALessSub.StringValue;
            Backendoptions.AddLesson(day, unitHour, clas, room, subject);
        }

        partial void AARoomAPply(Foundation.NSObject sender)
        {
            int t;
            if (int.TryParse(AARoomFloor.ToString(), out t))
                if (int.TryParse(AARoomRoom.ToString(), out t))
                    if (int.TryParse(AARoomChairs.ToString(), out t))
                        Backendoptions.AddRoom(AARoomFloor.ToString(), AARoomRoom.ToString(), AARoomChairs.ToString());
        }


        partial void AAStudentApply(Foundation.NSObject sender)
        {
            int t;
            if (checker.IsPesel(AAddStPesel.StringValue))
                if (checker.IsCorrect(AAddStName.StringValue) & checker.IsCorrect(AAddStLast.StringValue))
                    if (AAddStHome.StringValue == "" | checker.IsCorrect(AAddStHome.StringValue))
                        if (AAddStMail.StringValue == "" | checker.IsCorrect(AAddStMail.StringValue))
                            if (AAddStNum.StringValue == "" | int.TryParse(AAddStNum.StringValue, out t))
                                if (int.TryParse(AAddStRegNum.StringValue, out t))
                                {

                                    Backendoptions.AddStudent(AAddStPesel.StringValue, AAddStName.StringValue, AAddStLast.StringValue, AAddStHome.StringValue, AAddStNum.StringValue, AAddStMail.StringValue, AAddStClass.StringValue, AAddStRegNum.StringValue);
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
                                    Backendoptions.AddTeacher(AATeaPe.StringValue, AATeaName.StringValue, AATeaLast.StringValue, AATeaHome.StringValue, AATeaPhone.StringValue, AATeaMail.StringValue, AATeaWork.StringValue);
        }

        partial void AAUnitApply(Foundation.NSObject sender)
        {
            int t;
            if (int.TryParse(AAUnitM.StringValue, out t))
                Backendoptions.AddUnit(AAUnitH.StringValue, AAUnitM.StringValue);
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
                                    Backendoptions.AddParent(AAParPe.StringValue, AAParNa.StringValue, AAParLast.StringValue, AAParHome.StringValue, AAParNum.StringValue, AAParMail.StringValue, AAParMoney.StringValue);
        }


        


        partial void TANApply(Foundation.NSObject sender)
        {
             }


       


        partial void TAWApply(Foundation.NSObject sender)
        {
           
        }


        partial void TChaPrApply(Foundation.NSObject sender)
        {
        }


     


        partial void TChePrApply(Foundation.NSObject sender)
        {

        }



        
        partial void TCNApply(Foundation.NSObject sender)
        {
             }


        partial void TCatApply(Foundation.NSObject sender)
        {
            if (checker.IsCorrect(TCatNam.StringValue))
                Backendoptions.AddCategory(TCatNam.StringValue, TCatWeight.StringValue);
        }


    }
}