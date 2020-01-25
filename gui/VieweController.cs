using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;

namespace gui
{
    public partial class VieweController : AppKit.NSViewController
    {
        #region Constructors

        // Called when created from unmanaged code
        public VieweController(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public VieweController(NSCoder coder) : base(coder)
        {
            Initialize();
        }

        // Call to load from the XIB/NIB file
        public VieweController() : base("Viewe", NSBundle.MainBundle)
        {
            Initialize();
        }

        // Shared initialization code
        void Initialize()
        {
        }

        #endregion

        //strongly typed view accessor
        public new Viewe View
        {
            get
            {
                return (Viewe)base.View;
            }
        }
    }
}
