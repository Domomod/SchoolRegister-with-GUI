using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;

namespace DziennikElektroniczny.AdminKlasyProfile
{
    public partial class AdminKlasyProfileViewController : AppKit.NSViewController
    {
        #region Constructors

        // Called when created from unmanaged code
        public AdminKlasyProfileViewController(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public AdminKlasyProfileViewController(NSCoder coder) : base(coder)
        {
            Initialize();
        }

        // Call to load from the XIB/NIB file
        public AdminKlasyProfileViewController() : base("AdminKlasyProfileView", NSBundle.MainBundle)
        {
            Initialize();
        }

        // Shared initialization code
        void Initialize()
        {
        }

        #endregion

        //strongly typed view accessor
        public new AdminKlasyProfileView View
        {
            get
            {
                return (AdminKlasyProfileView)base.View;
            }
        }
    }
}
