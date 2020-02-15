using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;

namespace DziennikElektroniczny
{
    public partial class AdminNauczycieleViewController : AppKit.NSViewController
    {
        #region Private Members

        private NSMutableIndexSet hiddenRows { get; } = new NSMutableIndexSet();
        private NauczycielTableDataSource NauczycieleDataSource;
        #endregion

        #region Constructors

        // Called when created from unmanaged code
        public AdminNauczycieleViewController(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public AdminNauczycieleViewController(NSCoder coder) : base(coder)
        {
            Initialize();
        }

        // Call to load from the XIB/NIB file
        public AdminNauczycieleViewController() : base("AdminNauczycieleView", NSBundle.MainBundle)
        {
            Initialize();
        }

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();

            // Create the Product Table Data Source and populate it
            var DataSource = new NauczycielTableDataSource();

            // Populate the Product Table
            NauczycieleTableView.DataSource = DataSource;
            NauczycieleDataSource = (NauczycielTableDataSource)NauczycieleTableView.DataSource; //To avoid type casting
            NauczycieleTableView.Delegate = new NauczycielTableDelegate(this, DataSource);
        }

        // Shared initialization code
        void Initialize()
        {
            SearchTextCell = new NSTextField();
            NauczycieleTableView = new NSTableView();
        }

        #endregion

        #region Actions
        partial void OnSearchTextCellChange(Foundation.NSObject sender) {
            String searchString = SearchTextCell.StringValue;
            String columnName = "";

            NauczycieleTableView.UnhideRows(hiddenRows, 0);

            switch (NauczycieleTableView.SelectedColumn) {
                case -1:
                case 0:
                    columnName = "Imie";
                    break;
                case 1:
                    columnName = "Nazwisko";
                    break;
            }

            hiddenRows.Clear();

            for (nint row = 0; row < NauczycieleTableView.RowCount; row++) {

               if (!((NauczycielTableDelegate)NauczycieleTableView.Delegate).DataCellContains(columnName, row, searchString))
                {
                    hiddenRows.Add((nuint)row);
                }
            }
            NauczycieleTableView.HideRows(hiddenRows, 0);
        }
        #endregion


        public void ReloadTable() {
            NauczycieleTableView.ReloadData();
        }

        //strongly typed view accessor
        public new AdminNauczycieleView View
        {
            get
            {
                return (AdminNauczycieleView)base.View;
            }
        }

        public void SetStatusTextField(string msg) {
            StatusTextField.StringValue = msg;
        }

        partial void DodajButton(Foundation.NSObject sender)
        {
            var imie = ImieTextField.StringValue;
            var nazwisko = NazwiskoTextField.StringValue;
            var pesel = PeselTextField.StringValue;
            var telefon = TelefonTextField.StringValue != "Telefon" ? TelefonTextField.StringValue : "";
            var adres = AdresTextField.StringValue != "Adres" ? AdresTextField.StringValue : "";
            var email = EmailTextField.StringValue != "Email" ? EmailTextField.StringValue : "";
            var etat = EtatTextField.StringValue;
            try
            {
                NauczycieleDataSource.AddNauczyciel(new Nauczyciel(imie, nazwisko, pesel, telefon, adres, email, etat));
                StatusTextField.StringValue = $"Nauczyciel {imie} {nazwisko} został dodany";
                ReloadTable();
            }
            catch (Exception e) {
                StatusTextField.StringValue = e.Message;
            }
        }

    }
}
