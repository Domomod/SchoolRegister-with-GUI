using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;

namespace DziennikElektroniczny.AdminPrzedmioty
{
    public partial class AdminPrzedmiotyViewController : AppKit.NSViewController
    {
        #region Constructors

        // Called when created from unmanaged code
        public AdminPrzedmiotyViewController(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public AdminPrzedmiotyViewController(NSCoder coder) : base(coder)
        {
            Initialize();
        }

        // Call to load from the XIB/NIB file
        public AdminPrzedmiotyViewController() : base("AdminPrzedmiotyView", NSBundle.MainBundle)
        {
            Initialize();
        }

        // Shared initialization code
        void Initialize()
        {
        }

        #endregion

        //strongly typed view accessor
        public new AdminPrzedmiotyView View
        {
            get
            {
                return (AdminPrzedmiotyView)base.View;
            }
        }
    }
}
