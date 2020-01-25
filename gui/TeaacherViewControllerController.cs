using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;

namespace gui
{
    public partial class TeaacherViewControllerController : AppKit.NSViewController
    {
        #region Constructors

        // Called when created from unmanaged code
        public TeaacherViewControllerController(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public TeaacherViewControllerController(NSCoder coder) : base(coder)
        {
            Initialize();
        }

        // Call to load from the XIB/NIB file
        public TeaacherViewControllerController() : base("TeaacherViewController", NSBundle.MainBundle)
        {
            Initialize();
        }

        // Shared initialization code
        void Initialize()
        {
        }

        #endregion

        //strongly typed view accessor
        public new TeaacherViewController View
        {
            get
            {
                return (TeaacherViewController)base.View;
            }
        }
    }
}
