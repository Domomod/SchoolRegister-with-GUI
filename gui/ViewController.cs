﻿using System;
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
            {
                if(!Backendoptions.OpenConnection())
                    System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
            checker = new SQLChecker();
            if (Backendoptions.IsAdmin())
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
                ATeaList = new NSTextField();
                AParList= new NSTextField();
                AStList = new NSTextField();
            }
            else
            {
                if (Backendoptions.IsParent())
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
                    if (Backendoptions.IsTeacher())
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
                    }
                    else if (Backendoptions.IsStudent())
                    {
                        SWarnings = new NSTextField();
                        SPresance = new NSTextField();
                        SPoints = new NSTextField();
                        SNotes = new NSTextField();
                        SyInfo = new NSTextField();
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
            if (Backendoptions.IsParent())
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
                PChildList.Editable = false;
                PChildList.SelectItem(0);
                if (Backendoptions.IsChildSet())
                {
                    PNotes.StringValue = Backendoptions.GetMyChildPresance();//Yes, presance - i've done a mistake while creating names in a builder
                    PPresance.StringValue = Backendoptions.GetMyChildNotes();  //so here are notes
                    PWarnings.StringValue = Backendoptions.GetMyChildWarnings();
                    PLegitimize.UsesDataSource = true;
                    PLegitimize.DataSource = new MyCombo(Backendoptions.GetAbsence());
                }
            }
            else
            {
                if (Backendoptions.IsAdmin())
                {
                    AStList.StringValue = Backendoptions.GetAllStudentsData();
                    AParList.StringValue = Backendoptions.GetAllParentsData();

                    ATeaList.StringValue = Backendoptions.GetAllTeachersData();
                    AAUnitH.UsesDataSource = true;
                    AAUnitH.DataSource = new MyCombo(listHours);
                    AAUnitH.Editable = false;
                    AAUnitH.SelectItem(0);
                    AAddStClass.UsesDataSource = true;
                    AAddStClass.DataSource = new MyCombo(classes);
                    AAddStClass.Editable = false;                   
                    AGrillParent.UsesDataSource = true;
                    AGrillStudent.UsesDataSource = true;
                    AGrillStudent.DataSource = new MyCombo(students);
                    AGrillStudent.Editable = false;
                    AGrillParent.DataSource = new MyCombo(parents);
                    AGrillParent.Editable = false;
                    
                    ACForm.UsesDataSource = true;
                    ACClass.UsesDataSource = true;
                    ACForm.DataSource = new MyCombo(teachers);
                    ACForm.Editable = false;
                    
                    ACClass.DataSource = new MyCombo(classes);
                    ACClass.Editable = false;
                    AALessSub.UsesDataSource = true;
                    AALessUH.UsesDataSource = true;
                    AALessRR.UsesDataSource = true;
                    AALessDay.UsesDataSource = true;
                    AALessClL.UsesDataSource = true;
                    var listDay = new List<string>(new string[] { "1", "2", "3", "4", "5", "6" });
                    AALessDay.DataSource = new MyCombo(listDay);
                    AALessDay.Editable = false;
                    AALessDay.SelectItem(0);
                    AALessSub.DataSource = new MyCombo(subjects);
                    AALessSub.Editable = false;
                    AALessRR.DataSource = new MyCombo(rooms);
                    AALessRR.Editable = false;
                    if (rooms.Count>0)
                        AALessRR.SelectItem(0);
                    AALessUH.DataSource = new MyCombo(units);
                    AALessUH.Editable = false;
                    AALessUH.SelectItem(0);
                    AALessClL.DataSource = new MyCombo(classes);
                    AALessClL.Editable = false;
                    AAClassProfile.UsesDataSource = true;
                    AAClassProfile.DataSource = new MyCombo(profiles);
                    AAClassProfile.Editable = false;
                  
                    AAClassForm.UsesDataSource = true;
                    AAClassForm.DataSource = new MyCombo(teachers);
                    AAClassForm.Editable = false;
                    ADelPar.UsesDataSource = true;
                    ADelPar.DataSource = new MyCombo(parents);
                    ADelPar.Editable = false;
                    ADelSt.UsesDataSource = true;
                    ADelSt.DataSource = new MyCombo(students);
                    ADelSt.Editable = false;
                   
                    ADelTea.UsesDataSource = true;
                    ADelTea.DataSource = new MyCombo(teachers);
                    ADelTea.Editable = false;
                  
                    AChSt.UsesDataSource = true;
                    AChSt.DataSource = new MyCombo(students);
                    AChSt.Editable = false;
             
                    AchCl.UsesDataSource = true;
                    AchCl.DataSource = new MyCombo(classes);
                    AchCl.Editable = false;
                    ADelGrillPar.UsesDataSource = true;
                    ADelGrillPar.DataSource = new MyCombo(parents);
                    ADelGrillPar.Editable = false;
                    ADelGrillSt.UsesDataSource = true;
                    ADelGrillSt.DataSource = new MyCombo(students);
                    ADelGrillSt.Editable = false;
                  if (classes.Count > 0)
                    {
                        AAddStClass.SelectItem(0);
                        ACClass.SelectItem(0);
                        AALessClL.SelectItem(0);
                        AchCl.SelectItem(0);
                    }
                  if (students.Count > 0)
                    {
                        AGrillStudent.SelectItem(0);
                        ADelGrillSt.SelectItem(0);
                        AChSt.SelectItem(0);
                        ADelSt.SelectItem(0);
                    }
                  if (parents.Count > 0)
                    {
                        AGrillParent.SelectItem(0);
                        ADelPar.SelectItem(0);
                        ADelGrillPar.SelectItem(0);
                    }
                  if (teachers.Count > 0)
                    {
                        ADelTea.SelectItem(0);
                        ACForm.SelectItem(0);
                        AAClassForm.SelectItem(0);
                    }
                  
                }
                else
                {
                    if (Backendoptions.IsTeacher())
                    {
                        TClass.UsesDataSource = true;
                        TClass.DataSource = new MyCombo(classes);
                        TClass.Editable = false;
                        if (Backendoptions.IsClassSet())
                        {
                            if (Backendoptions.GetStudents().Count != 0)
                            {
                                var classstudents = Backendoptions.GetStudents();
                                TWSt.UsesDataSource = true;
                                TWSt.DataSource = new MyCombo(classstudents);
                                TWSt.Editable = false;
                                TNSt.UsesDataSource = true;
                                TNSt.DataSource = new MyCombo(classstudents);
                                TNSt.Editable = false;
                                TPreSt.UsesDataSource = true;
                                TPreSt.DataSource = new MyCombo(classstudents);
                                TPreSt.Editable = false;
                                TWSt.SelectItem(0);
                                TNSt.SelectItem(0);
                                TPreSt.SelectItem(0);
                                TCNSt.UsesDataSource = true;
                                TCNSt.DataSource = new MyCombo(classstudents);
                                TCNSt.Editable = false;
                                TCNSt.SelectItem(0);
                                string studentsstring = "", presance = "";
                                foreach (var st in classstudents)
                                {
                                    studentsstring = studentsstring + st + "\n";
                                }
                                TCheckStudent.StringValue = studentsstring;
                                TCheckStudent.Editable = false;
                                TCheckPresance.StringValue = presance;
                                TCNDesc.UsesDataSource = true;
                                TCNDesc.DataSource = new MyCombo(Backendoptions.GetLastNotes());
                                TCNDesc.Editable = false;
                                var best = Backendoptions.GetTopThree();
                                TBest1.StringValue = best;
                                TPreUnit.UsesDataSource = true;
                                TPreUnit.DataSource = new MyCombo(Backendoptions.LastLessonsForClass());
                                TPreUnit.Editable = false;
                            }
                        }
                        TNVal.UsesDataSource = true;
                        TNCat.UsesDataSource = true;
                        TNSub.UsesDataSource = true;
                        var values = new List<string>(new string[] { "1", "2", "2.5", "3", "3.5", "4", "4.5", "5", "5.5", "6" });
                        TNVal.DataSource = new MyCombo(values);
                        TNVal.Editable = false;
                        TCNVal.UsesDataSource = true;
                        TCNVal.DataSource = new MyCombo(values);
                        TCNVal.Editable = false;
                        TNSub.DataSource = new MyCombo(subjects);
                        TNSub.Editable = false;
                        TNCat.DataSource = new MyCombo(Backendoptions.GetCategories());
                        TNCat.Editable = false;
                        TPreStat.UsesDataSource = true;
                        TPrUnit.UsesDataSource = true;
                        TPrUnit.DataSource = new MyCombo(units);
                        TPrUnit.Editable = false;
                        TPreStat.DataSource = new MyCombo(status);
                        TPreStat.Editable = false;
                        TClass.SelectItem(0);
                        TNVal.SelectItem(0);
                        TNSub.SelectItem(0);
                        TNCat.SelectItem(0);
                        TPreStat.SelectItem(0);
                        TPrUnit.SelectItem(0);
                        TCNVal.SelectItem(0);
                    }
                    else
                    {
                        if (Backendoptions.IsStudent())
                        {
                            var warning = Backendoptions.GetMydWarnings();
                            SWarnings.StringValue = warning.Item1;
                            SPoints.StringValue = warning.Item2.ToString();
                            SNotes.StringValue = Backendoptions.GetMyNotes();
                            SPresance.StringValue = Backendoptions.GetMyPresance();
                            SyInfo.StringValue = Backendoptions.GetMyStudentInfo();
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
            catch (Exception)
            {
                ;
            }

        }


        partial void LogInAdminMode(AppKit.NSButton sender)
        {
            if (PeselInput.StringValue == "666")
            {
                Backendoptions.SetAdmin();
                var storyboard = NSStoryboard.FromName("Main", null);
                var controller = storyboard.InstantiateControllerWithIdentifier("2") as NSWindowController;
                controller.ShowWindow(this);
                TextOnFirstPage.StringValue = "Zalogowano";
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
            if (PeselInput.StringValue != "666" & checker.IsCorrect(PeselInput.StringValue) & Backendoptions.LogInAsTeacher(PeselInput.StringValue))
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
                {
                    Backendoptions.AddSubject(AASub.StringValue);
                    AAddSubErr.StringValue = "Utworzono przedmiot";
                }
                else
                    AAddSubErr.StringValue = "Podano nieprawidłową nazwę";
            }
            catch (Exception)
            {
                AAddSubErr.StringValue = "Wystąpił błąd";
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
                        AAddClErr.StringValue = "Nie prawidłowy rocznik lub literka";
            }
            catch (Exception)
            {
                AAddClErr.StringValue = "Wystąpił błąd";
            }
        }


        partial void AAFOrmApply(Foundation.NSObject sender)
        {
            try
            {
                Backendoptions.ChangeFormTutor(ACForm.StringValue, ACClass.StringValue);
                AChFormEr.StringValue = "Zapisano wychowawcę";
            }
            catch (Exception)
            {
                AChFormEr.StringValue = "Wystąpił błąd";
            }
        }

        partial void AAGrilApply(Foundation.NSObject sender)
        {
            try
            {
                Backendoptions.Grill(AGrillParent.StringValue, AGrillStudent.StringValue);
                AAddGrillErr.StringValue = "Utworzono relację opieki";
            }
            catch (Exception)
            {
                AAddGrillErr.StringValue = "Wystąpił błąd";
            }
        }

        partial void AALessonApply(Foundation.NSObject sender)
        {
            try
            {
                Backendoptions.AddLesson(AALessDay.StringValue, AALessUH.StringValue, AALessClL.StringValue, AALessRR.StringValue, AALessSub.StringValue);
                AAddLessErr.StringValue = "Utworzono klasę";
            }
            catch (Exception)
            {
                AAddLessErr.StringValue = "Wystąpił błąd";
            }
        }

        partial void AARoomAPply(Foundation.NSObject sender)
        {
            try
            {
                int t;
                if (int.TryParse(AARoomFloor.StringValue, out t))
                    if (int.TryParse(AARoomRoom.StringValue, out t) & t > 0)
                        if (int.TryParse(AARoomChairs.StringValue, out t) & t > 0)
                        {
                            Backendoptions.AddRoom(AARoomFloor.StringValue, AARoomRoom.StringValue, AARoomChairs.StringValue);
                            AAddRoomErr.StringValue = "Utworzono salę";
                        }
                        else
                            AAddRoomErr.StringValue = "Zła ILOŚĆ krzeseł";
                    else
                        AAddRoomErr.StringValue = "Zły NUMER pokoju";
                else
                    AAddRoomErr.StringValue = "Zły NUMER piętra";
            }
            catch (Exception)
            {
                AAddRoomErr.StringValue = "Wystąpił błąd";
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
                            if (AAddStMail.StringValue == "" | (checker.IsCorrect(AAddStMail.StringValue) & checker.IsMail(AAddStMail.StringValue)))
                                if (AAddStNum.StringValue == "" | int.TryParse(AAddStNum.StringValue, out t))
                                    {
                                        var home = AAddStHome.StringValue == "" ? "NULL" : AAddStHome.StringValue;
                                        var phone = AAddStNum.StringValue == "" ? "NULL" : AAddStNum.StringValue;
                                        var mail = AAddStMail.StringValue == "" ? "NULL" : AAddStMail.StringValue;
                                        Backendoptions.AddStudent(AAddStPesel.StringValue, AAddStName.StringValue, AAddStLast.StringValue, home, phone, mail, AAddStClass.StringValue);
                                        AAddStErr.StringValue = "Dodano ucznia";
                                    }
                                else
                                    AAddStErr.StringValue = "Zły numer telefonu";
                            else
                                AAddStErr.StringValue = "Zły email";
                        else
                            AAddStErr.StringValue = "Zły dom";
                    else
                        AAddStErr.StringValue = "Złe dane osobowe";
                else
                    AAddStErr.StringValue = "Zły pesel";
            }
            catch (Exception)
            {
                AAddStErr.StringValue = "Wystąpił błąd";
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
                            if (AATeaMail.StringValue == "" | (checker.IsCorrect(AATeaMail.StringValue) & checker.IsMail(AATeaMail.StringValue)))
                                if (AATeaPhone.StringValue == "" | int.TryParse(AATeaPhone.StringValue, out t))
                                    if (AATeaWork.StringValue == "" | decimal.TryParse(AATeaWork.StringValue, out d))
                                    {
                                        var home = AATeaHome.StringValue == "" ? "NULL" : AATeaHome.StringValue;
                                        var phone = AATeaPhone.StringValue == "" ? "NULL" : AATeaPhone.StringValue;
                                        var mail = AATeaMail.StringValue == "" ? "NULL" : AATeaMail.StringValue;
                                        Backendoptions.AddTeacher(AATeaPe.StringValue, AATeaName.StringValue, AATeaLast.StringValue, home, phone, mail, AATeaWork.StringValue);
                                        AAddTeaErr.StringValue = "Dodano nauczyciela";
                                    }
                                    else
                                        AAddTeaErr.StringValue = "Nieprawidłowy wymiar etatu";
                                else
                                    AAddTeaErr.StringValue = "Zły numer";
                            else
                                AAddTeaErr.StringValue = "Zły email";
                        else
                            AAddTeaErr.StringValue = "Zły dom";
                    else
                        AAddTeaErr.StringValue = "Złe dane osobowe";
                else
                    AAddTeaErr.StringValue = "Zły pesel";
            }
            catch (Exception)
            {

                AAddTeaErr.StringValue = "Wystąpił błąd";
            }
        }

        partial void AAUnitApply(Foundation.NSObject sender)
        {
            try
            {
                int t;
                if (int.TryParse(AAUnitM.StringValue, out t) & t >= 0 & t <= 60)
                {
                    Backendoptions.AddUnit(AAUnitH.StringValue, AAUnitM.StringValue);
                    AAddUnitErr.StringValue = "Utworzono jednostkę";
                }
                else
                    AAddUnitErr.StringValue = "Nie istnieje taka minuta";
            }
            catch (Exception)
            {
                AAddUnitErr.StringValue = "Wystąpił błąd";
            }
        }


        partial void AAddProfileApply(Foundation.NSObject sender)
        {
            try
            {
                if (checker.IsCorrect(AAddProfile.StringValue))
                {
                    AAddProfileErr.StringValue = "Utworzono profil";
                    Backendoptions.AddProfile(AAddProfile.StringValue);
                }
                else
                    AAddProfileErr.StringValue = "Nieprawidłowa nazwa";
            }
            catch (Exception)
            {
                AAddProfileErr.StringValue = "Wystąpił błąd, upewnij się, że taki profil jeszcze nie istnieje";
            }
        }

        partial void PLegitimizeApply(Foundation.NSObject sender)
        {
            try
            {
                Backendoptions.LegitimizeAbsence(PLegitimize.StringValue);
                PLegitimizeErr.StringValue = "Usprawiedliwiono";
            }
            catch (Exception)
            {
                PLegitimizeErr.StringValue = "Wystąpił błąd";
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
                            if (AAParMail.StringValue == "" | (checker.IsCorrect(AAParMail.StringValue) & checker.IsMail(AAParMail.StringValue)))
                                if (AAParNum.StringValue == "" | (int.TryParse(AAParNum.StringValue, out t)) & t > 0)
                                    if (AAParMoney.StringValue == "" | (decimal.TryParse(AAParMoney.StringValue, out d) & d >= 0))
                                    {
                                        var home = AAParHome.StringValue == "" ? "NULL" : AAParHome.StringValue;
                                        var phone = AAParNum.StringValue == "" ? "NULL" : AAParNum.StringValue;
                                        var mail = AAParMail.StringValue == "" ? "NULL" : AAParMail.StringValue;
                                        Backendoptions.AddParent(AAParPe.StringValue, AAParNa.StringValue, AAParLast.StringValue, home,phone , mail, AAParMoney.StringValue);
                                        AAddParErr.StringValue = "Dodano rodzica";
                                    }
                                    else
                                        AAddParErr.StringValue = "Zły dochów";
                                else
                                    AAddParErr.StringValue = "Zły numer telefonu";
                            else
                                AAddParErr.StringValue = "Zły email";
                        else
                            AAddParErr.StringValue = "Zły dom";
                    else
                        AAddParErr.StringValue = "Złe dane osobowe";
                else
                    AAddParErr.StringValue = "Zły pesel";
            }
            catch (Exception)
            {
                AAddParErr.StringValue = "Wystąpił błąd";
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
            catch (Exception)
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
            catch (Exception)
            {
                TErrWar.StringValue = "Nie powiodło się dodawanie uwagi";
            }
        }


        partial void TChaPrApply(Foundation.NSObject sender)
        {
            try
            {
                Backendoptions.ChangeStatus(TPreStat.StringValue, TPreUnit.StringValue, TPreSt.StringValue);
                TChaPrErr.StringValue = "Zmieniono status";
            }
            catch (Exception)
            {
                TChaPrErr.StringValue = "Wystąpił błąd";
            }
        }

        partial void AChClassApply(Foundation.NSObject sender)
        {
            try
            {
                Backendoptions.ChangeClass(AChSt.StringValue, AchCl.StringValue);
                AChClErr.StringValue = "Przepisano ucznia";
            }
            catch (Exception)
            {
                AChClErr.StringValue = "Wystąpił błąd";
            }
        }


        partial void TChePrApply(Foundation.NSObject sender)
        {
            try
            {
                var studentlist = TCheckStudent.StringValue.Split("\n");
                var presancelist = TCheckPresance.StringValue.Split("\n");
                TChePrErr.StringValue = "";
                for (int i = 0; i < studentlist.Length - 1; i++)
                {
                    if (!checker.IsStatus(presancelist[i]))
                        TChePrErr.StringValue = "Nieprawidłowy status dla ucznia " + studentlist[i];
                }
                if (TChePrErr.StringValue == "")
                {
                    for (int i = 0; i < studentlist.Length - 1; i++)
                        Backendoptions.AddPresance(TPrUnit.StringValue, studentlist[i], presancelist[i]);
                    TChePrErr.StringValue = "Dodano status wszystkim uczniom";
                }
                    
            }
            catch (Exception)
            {
                TChePrErr.StringValue = "Wystąpił błąd, upewnij się, że dana klasa ma zajęcia o tej godzinie";
            }
        }


        partial void TCNApply(Foundation.NSObject sender)
        {
            try
            {
                Backendoptions.ChangeNote(TCNVal.StringValue, TCNDesc.StringValue, TCNSt.StringValue);
                TErrNoteChange.StringValue = "Zmieniono ocenę";
            }
            catch (Exception)
            {
                TErrNoteChange.StringValue = "Wystąpił błąd";
            }
        }


        partial void TCatApply(Foundation.NSObject sender)
        {
            try
            {
                if (checker.IsCorrect(TCatNam.StringValue))
                {
                    Backendoptions.AddCategory(TCatNam.StringValue, TCatWeight.StringValue);
                    TAddCatErr.StringValue = "Utworzono kategorię";
                }
                else
                    TAddCatErr.StringValue = "Nieprawidłowa nazwa";
            }
            catch (Exception)
            {
                TAddCatErr.StringValue = "Wystąpił błąd";
            }
        }


        partial void PChildApply(Foundation.NSObject sender)
        {
            Backendoptions.SetChild(PChildList.StringValue);
        }

        partial void TClassApply(Foundation.NSObject sender)
        {
            Backendoptions.SetClass(TClass.StringValue);
        }


        partial void ADelApply(Foundation.NSObject sender)
        {
            try
            {
                Backendoptions.DeleteParent(ADelPar.StringValue);
                ADelParErr.StringValue = "Usunięto rodzica";
            }
            catch (Exception)
            {
                ADelParErr.StringValue = "Wystąpił błąd";
            }
        }


        partial void ADelGrillApply(Foundation.NSObject sender)
        {
            try
            {
                Backendoptions.DeleteGrill(ADelGrillPar.StringValue, ADelGrillSt.StringValue);
                ADelgrillErr.StringValue = "Usunięto wybraną relację";
            }
            catch (Exception)
            {
                ADelgrillErr.StringValue = "Nie usunięto opieki (upewnij się, że istniała)";
            }
        }


        partial void ADelStApply(Foundation.NSObject sender)
        {
            try
            {
                Backendoptions.DeleteStudent(ADelSt.StringValue);
                ADelStErr.StringValue = "Usunięto ucznia";
            }
            catch (Exception)
            {
                ADelStErr.StringValue = "Wystąpił błąd";
            }

        }


        partial void ADelTeaApply(Foundation.NSObject sender)
        {
            try
            {
                Backendoptions.DeleteTeacher(ADelTea.StringValue);
                ADelteaErr.StringValue = "Zwolniono nauczyciela";
            }
            catch (Exception)
            {
                ADelteaErr.StringValue = "Wystąpił błąd";
            }
        }

        partial void TChePrFind(Foundation.NSObject sender)
        {
            if (Backendoptions.IsClassSet())
            {
                if (Backendoptions.WasPresanceChecked(TPrUnit.StringValue))
                {
                    var lists = Backendoptions.GetPresanceThiSUnit(TPrUnit.StringValue);
                    TCheckStudent.StringValue = lists.Item1;
                    TCheckStudent.Editable = false;
                    TCheckPresance.StringValue = lists.Item2;
                    TCheckPresance.Editable = false;
                    TChePrErr.StringValue = "Sprawdzono już obecność na tej jednostce";
                }
                else
                {
                    var classstudents = Backendoptions.GetStudents();
                    string studentsstring = "", presance = "";
                    foreach (var st in classstudents)
                    {
                        studentsstring = studentsstring + st + "\n";
                        presance += "nie/obecny/usprawiedliwiony/inny\n";
                    }
                    TCheckStudent.StringValue = studentsstring;
                    TCheckStudent.Editable = false;
                    TCheckPresance.StringValue = presance;
                    TCheckPresance.Editable = true;
                    TChePrErr.StringValue = "Status:";
                }
            }
            else
                TChePrErr.StringValue = "Nie ustawiono klasy";
        }


        partial void CloseApp(NSObject sender)
        {
            Backendoptions.CloseConnection();
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
    }
}