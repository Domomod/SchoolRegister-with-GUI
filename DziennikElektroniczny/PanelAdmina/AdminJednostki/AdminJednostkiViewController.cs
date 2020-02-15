using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;

namespace DziennikElektroniczny.AdminJednostki
{
    public partial class AdminJednostkiViewController : AppKit.NSViewController
    {
        #region Constructors

        // Called when created from unmanaged code
        public AdminJednostkiViewController(IntPtr handle) : base(handle)
        {
            Initialize();

        }

        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public AdminJednostkiViewController(NSCoder coder) : base(coder)
        {
            Initialize();
        }

        // Call to load from the XIB/NIB file
        public AdminJednostkiViewController() : base("AdminJednostkiView", NSBundle.MainBundle)
        {
            Initialize();
        }

        // Shared initialization code
        void Initialize()
        {
        }

        #endregion

        //strongly typed view accessor
        public new AdminJednostkiView View
        {
            get
            {
                return (AdminJednostkiView)base.View;
            }
        }

        partial void OnDodajJednostkeButtonPressed(Foundation.NSObject sender)
        {
            var k = Database.Instance;
            k.AddUnit(GodzinaCombobox.StringValue, MinutaCombobox.StringValue);
        }

    }
}
