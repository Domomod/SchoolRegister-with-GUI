using System;

using AppKit;
using Foundation;

namespace gui
{
    public partial class ViewController : NSViewController
    {
        Backendoptions back;
        ParentPanel parent;
        StudentPanel student;
        TeacherPanel teacher;
        HeadmasterPanel admin;
        SQLChecker checker;

        public ViewController(IntPtr handle) : base(handle)
        {
            back = new Backendoptions();
            back.OpenConnection();
            checker = new SQLChecker();
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
                admin = new HeadmasterPanel(back.GetCommand(), back.GetReader());
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
                parent = new ParentPanel("99999999999", back.GetCommand(), back.GetReader());
                
                
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
                student = new StudentPanel(PeselInput.StringValue, back.GetCommand(), back.GetReader());
               // StudentShowMyNotes.
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
                teacher = new TeacherPanel(PeselInput.StringValue, back.GetCommand(), back.GetReader());
                TeacherMyData.StringValue = teacher.MyData();
            }
           // else
                TextOnFirstPage.StringValue = "Błędny pesel";
        }

        partial void AASubApply(Foundation.NSObject sender)
        {
            if (AASub.StringValue != "" & checker.IsCorrect(AASub.StringValue))
                back.AddSubject(AASub.StringValue);


        }




    }


    
}