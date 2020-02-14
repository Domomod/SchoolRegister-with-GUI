using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;

namespace DziennikElektroniczny.AdminPrzedmioty
{
    public partial class AdminPrzedmiotyView : AppKit.NSView
    {
        #region Constructors

        // Called when created from unmanaged code
        public AdminPrzedmiotyView(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public AdminPrzedmiotyView(NSCoder coder) : base(coder)
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
