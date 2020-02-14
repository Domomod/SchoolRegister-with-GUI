using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;

namespace DziennikElektroniczny.AdminUczenView
{
    public partial class AdminUczenView : AppKit.NSView
    {
        #region Constructors

        // Called when created from unmanaged code
        public AdminUczenView(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public AdminUczenView(NSCoder coder) : base(coder)
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
