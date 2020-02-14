using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;

namespace DziennikElektroniczny.AdminSale
{
    public partial class AdminSaleView : AppKit.NSView
    {
        #region Constructors

        // Called when created from unmanaged code
        public AdminSaleView(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public AdminSaleView(NSCoder coder) : base(coder)
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
