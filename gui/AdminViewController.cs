using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;

namespace gui
{
    public partial class AdminViewController : AppKit.NSView
    {
        #region Constructors

        // Called when created from unmanaged code
        public AdminViewController(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public AdminViewController(NSCoder coder) : base(coder)
        {
            Initialize();
        }

        // Shared initialization code
        void Initialize()
        {
        }

        #endregion
    }
}
