using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;

namespace gui
{
    public partial class TeaacherViewController : AppKit.NSView
    {
        #region Constructors

        // Called when created from unmanaged code
        public TeaacherViewController(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public TeaacherViewController(NSCoder coder) : base(coder)
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
