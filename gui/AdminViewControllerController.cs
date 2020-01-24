using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;

namespace gui
{
    public partial class AdminViewControllerController : AppKit.NSViewController
    {
        #region Constructors

        // Called when created from unmanaged code
        public AdminViewControllerController(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public AdminViewControllerController(NSCoder coder) : base(coder)
        {
            Initialize();
        }

        // Call to load from the XIB/NIB file
        public AdminViewControllerController() : base("AdminViewController", NSBundle.MainBundle)
        {
            Initialize();
        }

        // Shared initialization code
        void Initialize()
        {
        }

        #endregion

        //strongly typed view accessor
        public new AdminViewController View
        {
            get
            {
                return (AdminViewController)base.View;
            }
        }
    }
}
