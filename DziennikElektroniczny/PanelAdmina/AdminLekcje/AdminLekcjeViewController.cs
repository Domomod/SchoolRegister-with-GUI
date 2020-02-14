using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;

namespace DziennikElektroniczny.AdminLekcje
{
    public partial class AdminLekcjeViewController : AppKit.NSViewController
    {
        #region Constructors

        // Called when created from unmanaged code
        public AdminLekcjeViewController(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public AdminLekcjeViewController(NSCoder coder) : base(coder)
        {
            Initialize();
        }

        // Call to load from the XIB/NIB file
        public AdminLekcjeViewController() : base("AdminLekcjeView", NSBundle.MainBundle)
        {
            Initialize();
        }

        // Shared initialization code
        void Initialize()
        {
        }

        #endregion

        //strongly typed view accessor
        public new AdminLekcjeView View
        {
            get
            {
                return (AdminLekcjeView)base.View;
            }
        }
    }
}
