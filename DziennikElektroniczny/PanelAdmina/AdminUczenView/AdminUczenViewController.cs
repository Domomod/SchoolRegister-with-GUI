using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;

namespace DziennikElektroniczny.AdminUczenView
{
    public partial class AdminUczenViewController : AppKit.NSViewController
    {
        #region Constructors

        // Called when created from unmanaged code
        public AdminUczenViewController(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public AdminUczenViewController(NSCoder coder) : base(coder)
        {
            Initialize();
        }

        // Call to load from the XIB/NIB file
        public AdminUczenViewController() : base("AdminUczenView", NSBundle.MainBundle)
        {
            Initialize();
        }

        // Shared initialization code
        void Initialize()
        {
        }

        #endregion

        //strongly typed view accessor
        public new AdminUczenView View
        {
            get
            {
                return (AdminUczenView)base.View;
            }
        }
    }
}
