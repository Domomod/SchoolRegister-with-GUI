using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;

namespace gui
{
    public partial class ParentViewControllerController : AppKit.NSViewController
    {
        #region Constructors

        // Called when created from unmanaged code
        public ParentViewControllerController(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public ParentViewControllerController(NSCoder coder) : base(coder)
        {
            Initialize();
        }

        // Call to load from the XIB/NIB file
        public ParentViewControllerController() : base("ParentViewController", NSBundle.MainBundle)
        {
            Initialize();
        }

        // Shared initialization code
        void Initialize()
        {
        }

        #endregion

        //strongly typed view accessor
        public new ParentViewController View
        {
            get
            {
                return (ParentViewController)base.View;
            }
        }
    }
}
