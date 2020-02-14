using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;

namespace DziennikElektroniczny.AdminKlasyProfile
{
    public partial class AdminKlasyProfileView : AppKit.NSView
    {
        #region Constructors

        // Called when created from unmanaged code
        public AdminKlasyProfileView(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public AdminKlasyProfileView(NSCoder coder) : base(coder)
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
