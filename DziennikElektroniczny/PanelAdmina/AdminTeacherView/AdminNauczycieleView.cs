using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;

namespace DziennikElektroniczny
{
    public partial class AdminNauczycieleView : AppKit.NSView
    {
        #region Constructors

        // Called when created from unmanaged code
        public AdminNauczycieleView(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public AdminNauczycieleView(NSCoder coder) : base(coder)
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
