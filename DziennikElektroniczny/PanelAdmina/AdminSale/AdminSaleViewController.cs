using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;

namespace DziennikElektroniczny.AdminSale
{
    public partial class AdminSaleViewController : AppKit.NSViewController
    {
        #region Constructors

        // Called when created from unmanaged code
        public AdminSaleViewController(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public AdminSaleViewController(NSCoder coder) : base(coder)
        {
            Initialize();
        }

        // Call to load from the XIB/NIB file
        public AdminSaleViewController() : base("AdminSaleView", NSBundle.MainBundle)
        {
            Initialize();
        }

        // Shared initialization code
        void Initialize()
        {
        }

        #endregion

        //strongly typed view accessor
        public new AdminSaleView View
        {
            get
            {
                return (AdminSaleView)base.View;
            }
        }


        partial void OnDodajSaleButtonPressed(Foundation.NSObject sender)
        {
            var k = Database.Instance;
            k.AddRoom(PietroTextField.StringValue, SalaTextField.StringValue, LiczbaMiejscTextField.StringValue);
        }

    }
}
