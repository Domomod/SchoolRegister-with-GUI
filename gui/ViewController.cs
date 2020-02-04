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
                ADelGrillSt = new NSComboBox();
                ADelGrillPar = new NSComboBox();
                ADelSt = new NSComboBox();
                ADelTea = new NSComboBox();
                ADelPar = new NSComboBox();
                AchCl = new NSComboBox();
                AChSt = new NSComboBox();

            }
            else
            {
                if (Backendoptions.isParent())
                {
                    PChildList = new NSComboBox();
                    PMyInfo = new NSTextField();
                    PLegitimize = new NSComboBox();
                    PNotes = new NSTextField();
                    PWarnings = new NSTextField();
                    PPresance = new NSTextField();
                }
                else
                {
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
                        TCheckPresance = new NSTextField();
                        TCheckStudent = new NSTextField();
                        TBest1 = new NSTextField();
                        TBest2 = new NSTextField();
                        TBest3 = new NSTextField();
                        
                    }
                    else if (Backendoptions.isStudent())
                    { 
                        SWarnings = new NSTextField();
                        SPresance = new NSTextField();
                        SPoints = new NSTextField();
                        SNotes = new NSTextField();
                        
                    }
                }
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
            if (Backendoptions.isParent())
            {
                string stringinfo = "dzieci pod moją opieką:\n";
                var child = Backendoptions.GetChildren();
                foreach (var ch in child)
                {
                    stringinfo = stringinfo + " " + ch + ",";
                }
                PMyInfo.StringValue = stringinfo.Remove(stringinfo.Length - 1);
                PChildList.UsesDataSource = true;
                PChildList.DataSource = new MyCombo(child);
                PChildList.SelectItem(0);
                if (Backendoptions.isChildSet())
                {
                    PNotes.StringValue = Backendoptions.getMyChildPresance();//Yes, presance - i've done a mistake while creating names in a builder
                    PPresance.StringValue = Backendoptions.getMyChildNotes();  //so here are notes
                    PWarnings.StringValue = Backendoptions.getMyChildWarnings();
                    PLegitimize.UsesDataSource = true;
                    PLegitimize.DataSource = new MyCombo(Backendoptions.GetAbsence());
                }
            }
            else
            {
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
                    ADelPar.UsesDataSource = true;
                    ADelPar.DataSource = new MyCombo(parents);
                    ADelPar.SelectItem(0);
                    ADelSt.UsesDataSource = true;
                    ADelSt.DataSource = new MyCombo(students);
                    ADelSt.SelectItem(0);
                    ADelTea.UsesDataSource = true;
                    ADelTea.DataSource = new MyCombo(teachers);
                    ADelTea.SelectItem(0);
                    AChSt.UsesDataSource = true;
                    AChSt.DataSource = new MyCombo(students);
                    AChSt.SelectItem(0);
                    AchCl.UsesDataSource = true;
                    AchCl.DataSource = new MyCombo(classes);
                    AchCl.SelectItem(0);
                    ADelGrillPar.UsesDataSource = true;
                    ADelGrillPar.DataSource = new MyCombo(parents);
                    ADelGrillPar.SelectItem(0);
                    ADelGrillSt.UsesDataSource = true;
                    ADelGrillSt.DataSource = new MyCombo(students);
                    ADelGrillSt.SelectItem(0);
                }
                else
                {
                    if (Backendoptions.isTeacher())
                    {
                        TClass.UsesDataSource = true;
                        TClass.DataSource = new MyCombo(classes);
                        if (Backendoptions.isClassSet()) 
                        { if (Backendoptions.GetStudents().Count != 0)
                            {
                                var classstudents = Backendoptions.GetStudents();
                                TWSt.UsesDataSource = true;
                                TWSt.DataSource = new MyCombo(classstudents);
                                TNSt.UsesDataSource = true;
                                TNSt.DataSource = new MyCombo(classstudents);
                                TPreSt.UsesDataSource = true;
                                TPreSt.DataSource = new MyCombo(classstudents);
                                TWSt.SelectItem(0);
                                TNSt.SelectItem(0);
                                TPreSt.SelectItem(0);
                                TCNSt.UsesDataSource = true;
                                TCNSt.DataSource = new MyCombo(classstudents);
                                TCNSt.SelectItem(0);
                                string studentsstring = "", presance = "";
                                foreach (var st in classstudents)
                                {
                                    studentsstring = studentsstring + st + "\n";
                                    presance += "obecny\n";
                                }
                                TCheckStudent.StringValue = studentsstring;
                                TCheckStudent.Editable = false;
                                TCheckPresance.StringValue = presance;
                                TCNDesc.UsesDataSource = true;
                                TCNDesc.DataSource = new MyCombo(Backendoptions.getLastNotes());
                                var best = Backendoptions.GetTopThree();
                                TBest1.StringValue = best[0];
                                TBest2.StringValue = best[1];
                                TBest3.StringValue = best[2];
                                TPreUnit.UsesDataSource = true;
                                TPreUnit.DataSource = new MyCombo(Backendoptions.LastLessonsForClass());
                                TPreUnit.SelectItem(0);
                            }
                        }
                        TNVal.UsesDataSource = true;
                        TNCat.UsesDataSource = true;
                        TNSub.UsesDataSource = true;
                        var values = new List<string>(new string[] { "1", "2", "2.5", "3", "3.5", "4", "4.5", "5", "5.5", "6" });
                        TNVal.DataSource = new MyCombo(values);
                        TCNVal.UsesDataSource = true;
                        TCNVal.DataSource = new MyCombo(values);
                        TNSub.DataSource = new MyCombo(subjects);
                        TNCat.DataSource = new MyCombo(Backendoptions.GetCategories());
                        TPreStat.UsesDataSource = true;                      
                        TPrUnit.UsesDataSource = true;
                        TPrUnit.DataSource = new MyCombo(units);                      
                        TPreStat.DataSource = new MyCombo(status);
                        TClass.SelectItem(0);
                        TNVal.SelectItem(0);
                        TNSub.SelectItem(0);
                        TNCat.SelectItem(0);
                        TPreStat.SelectItem(0);
                        TPrUnit.SelectItem(0);
                        TCNVal.SelectItem(0);
                    }
                    else
                    {if (Backendoptions.isStudent())
                        {
                        var warning = Backendoptions.getMydWarnings();
                        SWarnings.StringValue = warning.Item1;
                            SPoints.StringValue = warning.Item2.ToString();
                        SNotes.StringValue = Backendoptions.getMyNotes();
                        SPresance.StringValue = Backendoptions.getMyPresance();
                        }
                        
                    }
                }
            }
        }




        partial void FirstUseButton(AppKit.NSButton sender)
        {
            try
            {
                Backendoptions.FirstUse();
            }
            catch (Exception ex)
            {
                ;
            }
            
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
                TextOnFirstPage.StringValue = "Zalogowano";
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
                TextOnFirstPage.StringValue = "Zalogowano";
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
                TextOnFirstPage.StringValue = "Zalogowano";
            }
            else
                TextOnFirstPage.StringValue = "Błędny pesel";
        }

        partial void AASubApply(Foundation.NSObject sender)
        {
            try
            {
if (AASub.StringValue != "" & checker.IsCorrect(AASub.StringValue))
                Backendoptions.AddSubject(AASub.StringValue);
            }
            
            catch( Exception ex)
            {
                ;
            }
        }

        partial void AAClassApply(Foundation.NSObject sender)
        {
            try
            {
                int t;
                if (AAClassLetter.StringValue != "" & checker.IsCorrect(AAClassLetter.StringValue))
                    if (int.TryParse(AAClassYear.StringValue, out t) & t > 2000 & t < 3000)
                    {
                        Backendoptions.AddClass(AAClassYear.StringValue, AAClassLetter.StringValue, AAClassForm.StringValue, AAClassProfile.StringValue);
                        AAddClErr.StringValue = "Dodano klasę";
                    }
                else
                        AAddClErr.StringValue = "Nie utworzono klasy";

            }
            catch (Exception ex)
            {
                AAddClErr.StringValue = "Nie utworzono klasy";
            }
        }


        partial void AAFOrmApply(Foundation.NSObject sender)
        {
            try
            {
            Backendoptions.ChangeFormTutor(ACForm.StringValue, ACClass.StringValue);
            }
            catch(Exception ex)
            {
                ;
            }
            
        }

        partial void AAGrilApply(Foundation.NSObject sender)
        {
            try
            {
Backendoptions.Grill(AGrillParent.StringValue, AGrillStudent.StringValue);
            }
            catch (Exception ex)
            {
                ;
            }

        }

        partial void AALessonApply(Foundation.NSObject sender)
        {
            try
            {
 Backendoptions.AddLesson(AALessDay.StringValue, AALessUH.StringValue, AALessClL.StringValue, AALessRR.StringValue, AALessSub.StringValue);
            }
            catch (Exception ex)
            {
                ;
            }
           
        }

        partial void AARoomAPply(Foundation.NSObject sender)
        {
            try
            {
                int t;
                if (int.TryParse(AARoomFloor.StringValue, out t))
                    if (int.TryParse(AARoomRoom.StringValue, out t))
                        if (int.TryParse(AARoomChairs.StringValue, out t))
                        {
                            Backendoptions.AddRoom(AARoomFloor.StringValue, AARoomRoom.StringValue, AARoomChairs.StringValue);
                            AAddRoomErr.StringValue = "Utworzono salę";
                        }
                    else
                            AAddRoomErr.StringValue = "Nie udało się dodać pokoju";
                else
                        AAddRoomErr.StringValue= "Nie udało się dodać pokoju";

            }
            catch(Exception ex)
            {
                AAddRoomErr.StringValue= "Nie udało się dodać pokoju";
            }
        }


        partial void AAStudentApply(Foundation.NSObject sender)
        {
            try
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
                                        AAddStErr.StringValue = "Dodano ucznia";
                                    }
                                    else
                                        AAddStErr.StringValue = "Nie powiosło się dodawanie ucznia";
                                else
                                    AAddStErr.StringValue = "Nie powiosło się dodawanie ucznia";
                            else
                                AAddStErr.StringValue = "Nie powiosło się dodawanie ucznia";
                        else
                            AAddStErr.StringValue = "Nie powiosło się dodawanie ucznia";
                    else
                        AAddStErr.StringValue = "Nie powiosło się dodawanie ucznia";
                else
                    AAddStErr.StringValue = "Nie powiosło się dodawanie ucznia";
            }
            catch (Exception ex)
            {
                    AAddStErr.StringValue = "Nie powiosło się dodawanie ucznia";
            }
        }

        partial void AATeacher(Foundation.NSObject sender)
        {
            try
            {
                int t;
                decimal d;
                if (checker.IsPesel(AATeaPe.StringValue))
                    if (checker.IsCorrect(AATeaName.StringValue) & checker.IsCorrect(AATeaLast.StringValue))
                        if (AATeaHome.StringValue == "" | checker.IsCorrect(AATeaHome.StringValue))
                            if (AATeaMail.StringValue == "" | checker.IsCorrect(AATeaMail.StringValue))
                                if (AATeaPhone.StringValue == "" | int.TryParse(AATeaPhone.StringValue, out t))
                                    if (AATeaWork.StringValue == "" | decimal.TryParse(AATeaWork.StringValue, out d))
                                    {
                                        Backendoptions.AddTeacher(AATeaPe.StringValue, AATeaName.StringValue, AATeaLast.StringValue, AATeaHome.StringValue, AATeaPhone.StringValue, AATeaMail.StringValue, AATeaWork.StringValue);
                                        AAddTeaErr.StringValue = "Dodano nauczyciela";
                                    }
                                    else
                                        AAddTeaErr.StringValue = "Nie dodano nauczyciela";
                                else
                                    AAddTeaErr.StringValue = "Nie dodano nauczyciela";
                            else
                                AAddTeaErr.StringValue = "Nie dodano nauczyciela";
                        else
                            AAddTeaErr.StringValue = "Nie dodano nauczyciela";
                    else
                        AAddTeaErr.StringValue = "Nie dodano nauczyciela";
                else
                    AAddTeaErr.StringValue = "Nie dodano nauczyciela";
            }
            catch (Exception ex)
            {
                
                    AAddTeaErr.StringValue = "Nie dodano nauczyciela";
            }
            }

        partial void AAUnitApply(Foundation.NSObject sender)
        {
            try
            {
                int t;
                if (int.TryParse(AAUnitM.StringValue, out t))
                {
                    Backendoptions.AddUnit(AAUnitH.StringValue, AAUnitM.StringValue);
                    AAddUnitErr.StringValue = "Utworzono jednostkę";
                }
                else
                    AAddUnitErr.StringValue = "Nie utworzono jednostki";
            }
            catch (Exception ex)
            {
                AAddUnitErr.StringValue = "Nie utworzono jednostki";
            }
        }

        partial void PLegitimizeApply(Foundation.NSObject sender)
        {
            try
            {
                Backendoptions.LegitimizeAbsence(PLegitimize.StringValue);
            }
            catch( Exception ex)
            {
                ;
            }
        }

        partial void AAddParApply(Foundation.NSObject sender)
        {
            try
            {
                int t;
                decimal d;
                if (checker.IsPesel(AAParPe.StringValue))
                    if (checker.IsCorrect(AAParNa.StringValue) & checker.IsCorrect(AAParLast.StringValue))
                        if (AAParHome.StringValue == "" | checker.IsCorrect(AAParHome.StringValue))
                            if (AAParMail.StringValue == "" | checker.IsCorrect(AAParMail.StringValue))
                                if (AAParNum.StringValue == "" | int.TryParse(AAParNum.StringValue, out t))
                                    if (AAParMoney.StringValue == "" | decimal.TryParse(AAParMoney.StringValue, out d))
                                    {
                                        Backendoptions.AddParent(AAParPe.StringValue, AAParNa.StringValue, AAParLast.StringValue, AAParHome.StringValue, AAParNum.StringValue, AAParMail.StringValue, AAParMoney.StringValue);
                                        AAddParErr.StringValue = "Dodano rodzica";
                                    }
                                    else
                                        AAddParErr.StringValue = "Nie udało się dodać rodzica";
                                else
                                    AAddParErr.StringValue = "Nie udało się dodać rodzica";
                            else
                                AAddParErr.StringValue = "Nie udało się dodać rodzica";
                        else
                            AAddParErr.StringValue = "Nie udało się dodać rodzica";
                    else
                        AAddParErr.StringValue = "Nie udało się dodać rodzica";
                else
                    AAddParErr.StringValue = "Nie udało się dodać rodzica";
            }
            catch (Exception ex)
            {
                AAddParErr.StringValue = "Nie udało się dodać rodzica";
            }
         }


        


        partial void TANApply(Foundation.NSObject sender)
        {
            try
            {
                if (checker.IsCorrect(TNDesc.StringValue))
                {
                    Backendoptions.AddNote(TNVal.StringValue, TNDesc.StringValue, TNCat.StringValue, TNSub.StringValue, TNSt.StringValue);
                    TErrNote.StringValue = "Dodano ocenę";
                }
                else
                    TErrNote.StringValue = "Nie dodano oceny";
            }
            catch(Exception ex)
            {
                TErrNote.StringValue = "Nie dodano oceny";
            }
         }


       


        partial void TAWApply(Foundation.NSObject sender)
        {
            try
            {
                int t;
                if (checker.IsCorrect(TWDesc.StringValue) & int.TryParse(TWPoints.StringValue, out t))
                {
                    Backendoptions.AddWarning(TWDesc.StringValue, TWPoints.StringValue, TWSt.StringValue);
                    TErrWar.StringValue = "Dodano uwagę";
                }
                else
                    TErrWar.StringValue = "Nie powiodło się dodawanie uwagi";
            }
            catch (Exception ex)
            {
                TErrWar.StringValue = "Nie powiodło się dodawanie uwagi";
            }
        }


        partial void TChaPrApply(Foundation.NSObject sender)
        {
            try
            {
                Backendoptions.ChangeStatus(TPreStat.StringValue, TPreUnit.StringValue, TPreSt.StringValue);
            }

            catch (Exception ex)
            {
                ;
            }
        }


     


        partial void TChePrApply(Foundation.NSObject sender)
        {try
            {
                var studentlist = TCheckStudent.StringValue.Split("\n");
                var presancelist = TCheckPresance.StringValue.Split("\n");
                for (int i = 0; i < studentlist.Length; i++)
                {
                    if (checker.IsStatus(presancelist[i]))
                        Backendoptions.AddPresance(TPrUnit.StringValue, studentlist[i], presancelist[i]);
                    else
                        Backendoptions.AddPresance(TPrUnit.StringValue, studentlist[i], "inny");
                }
            }
            catch(Exception ex)
            {
                ;
            }
        }



        
        partial void TCNApply(Foundation.NSObject sender)
        {
            try
            {
                Backendoptions.ChangeNote(TCNVal.StringValue, TCNDesc.StringValue, TCNSt.StringValue);
            }
            catch (Exception ex)
            {
                ;
            }
             }


        partial void TCatApply(Foundation.NSObject sender)
        {
            try
            {
                if (checker.IsCorrect(TCatNam.StringValue))
                    Backendoptions.AddCategory(TCatNam.StringValue, TCatWeight.StringValue);
            }
            catch (Exception ex)
            {
                ;
            }
        }


        partial void PChildApply(Foundation.NSObject sender)
        {
            try
            {
                Backendoptions.setChild(PChildList.StringValue);
            }
            catch (Exception ex)
            {
                ;
            }
        }

        partial void TClassApply(Foundation.NSObject sender)
        {
            try
            {
                Backendoptions.setClass(TClass.StringValue);
            }
            catch (Exception ex)
            {
                ;
            }
        }


        partial void ADelApply(Foundation.NSObject sender)
        {
            try
            {
                Backendoptions.DeleteParent(ADelPar.StringValue);
            }
            catch (Exception ex)
            {
                ;
            }
        }

        
        partial void ADelGrillApply(Foundation.NSObject sender)
        {
            try
            {
                Backendoptions.DeleteGrill(ADelGrillPar.StringValue, ADelGrillSt.StringValue);
            }
            catch (Exception ex)
            {
                ADelgrillErr.StringValue = "Nie usunięto opieki (upewnij się, że istniała)";
            }
        }


        partial void ADelStApply(Foundation.NSObject sender)
        {
            try
            {
                Backendoptions.DeleteStudent(ADelSt.StringValue);
            }
            catch (Exception ex)
            {
                ;
            }

        }

     
        partial void ADelTeaApply(Foundation.NSObject sender)
        {
            try
            {
                Backendoptions.DeleteTeacher(ADelTea.StringValue);
            }
            catch (Exception ex)
            {
                ;
            }
        }
    }
}