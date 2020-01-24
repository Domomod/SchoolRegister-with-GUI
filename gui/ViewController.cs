using System;

using AppKit;
using Foundation;

namespace gui
{
    public partial class ViewController : NSViewController
    {
        Backendoptions back;

        public ViewController(IntPtr handle) : base(handle)
        {
            back = new Backendoptions();
            back.OpenConnection();
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
                TextOnFirstPage.StringValue = "Illigal valju";
        }

        partial void LogInAsParent(AppKit.NSButton sender)
        {
            if (back.LogInAsParent(PeselInput.StringValue))
                TextOnFirstPage.StringValue = "Zalogowano";
            else
                TextOnFirstPage.StringValue = "Błędny pesel";

        }

        partial void LogInAsStudent(AppKit.NSButton sender)
        {
            if (back.LogInAsStudent(PeselInput.StringValue))
                TextOnFirstPage.StringValue = "Zalogowano";
            else
                TextOnFirstPage.StringValue = "Błędny pesel";
        }


        partial void LogInAsTeacher(AppKit.NSButton sender)
        {
            if (back.LogInAsTeacher(PeselInput.StringValue))
                TextOnFirstPage.StringValue = "Zalogowano";
            else
                TextOnFirstPage.StringValue = "Błędny pesel";
        }
    }
}