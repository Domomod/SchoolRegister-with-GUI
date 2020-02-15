using System;

using AppKit;
using Foundation;

namespace DziennikElektroniczny
{
    public partial class ViewController : NSViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
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

        partial void ZamknijButton(Foundation.NSObject sender)
        {
            var k = Database.Instance;
            k.Close();
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
    }
}
