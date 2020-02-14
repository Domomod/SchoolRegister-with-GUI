using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;

namespace DziennikElektroniczny.AdminJednostki
{
    public partial class AdminJednostkiView : AppKit.NSView
    {
        #region Constructors

        // Called when created from unmanaged code
        public AdminJednostkiView(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public AdminJednostkiView(NSCoder coder) : base(coder)
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
