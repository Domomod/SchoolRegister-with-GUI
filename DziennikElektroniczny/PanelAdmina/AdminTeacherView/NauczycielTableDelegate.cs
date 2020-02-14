using System;
using AppKit;
using CoreGraphics;
using Foundation;
using System.Collections;
using System.Collections.Generic;

namespace DziennikElektroniczny
{
    public class NauczycielTableDelegate : NSTableViewDelegate
    {
        #region Constants 
        private const string CellIdentifier = "ProdCell";
        #endregion

        #region Private Variables
        private NauczycielTableDataSource DataSource;
        private AdminNauczycieleViewController ViewController;
        #endregion

        #region Constructors
        public NauczycielTableDelegate(AdminNauczycieleViewController ViewController, NauczycielTableDataSource datasource)
        {
            this.DataSource = datasource;
            this.ViewController = ViewController;
        }
        #endregion

        #region Override Methods
        public override NSView GetViewForItem(NSTableView tableView, NSTableColumn tableColumn, nint row)
        {

            // This pattern allows you reuse existing views when they are no-longer in use.
            // If the returned view is null, you instance up a new view
            // If a non-null view is returned, you modify it enough to reflect the new data
            NSTableCellView view = (NSTableCellView)tableView.MakeView(tableColumn.Title, this);
            if (view == null)
            {
                view = new NSTableCellView();

                // Configure the view
                view.Identifier = tableColumn.Title;

                // Take action based on title
                switch (tableColumn.Title)
                {
                    case "Imie":
                        view.TextField = new NSTextField(new CGRect(20, 0, 400, 16));
                        ConfigureTextField(view, row);
                        break;
                    case "Nazwisko":
                        view.TextField = new NSTextField(new CGRect(0, 0, 400, 16));
                        ConfigureTextField(view, row);
                        break;
                    case "Usuń":
                        // Stwórz przycisk
                        var button = new NSButton(new CGRect(0, 0, 81, 16));
                        button.SetButtonType(NSButtonType.MomentaryPushIn);
                        button.Title = "Usuń";
                        button.Tag = row;

                        // Przypisz zachowanie do przycisku.
                        button.Activated += (sender, e) => {
                            var przycisk = sender as NSButton;
                            var rekord = DataSource.Nauczyciele[(int)przycisk.Tag];

                            // Show a popup alllert
                            var alert = new NSAlert()
                            {
                                AlertStyle = NSAlertStyle.Informational,
                                InformativeText = $"Czy na pewno chcesz usunąć {rekord.Imie} {rekord.Nazwisko}? Taka operacja jest permamentna.",
                                MessageText = $"Usunąć {rekord.Imie}?",
                            };
                            alert.AddButton("Anuluj");
                            alert.AddButton("Usuń");
                            var result = alert.RunModal();
                            if (result == 1001) {
                                // Remove the given row from the dataset
                                DataSource.Nauczyciele.RemoveAt((int)przycisk.Tag);
                                ViewController.ReloadTable();
                            }


                        };

                        // Add to view
                        view.AddSubview(button);
                        break;
                }

            }

            // Setup view based on the column selected
            switch (tableColumn.Title)
            {
                case "Imie":
                    view.TextField.StringValue = DataSource.Nauczyciele[(int)row].Imie;
                    view.TextField.Tag = row;
                    break;
                case "Nazwisko":
                    view.TextField.StringValue = DataSource.Nauczyciele[(int)row].Nazwisko;
                    view.TextField.Tag = row;
                    break;
                case "Usuń":
                    foreach (NSView subview in view.Subviews)
                    {
                        var btn = subview as NSButton;
                        if (btn != null)
                        {
                            btn.Tag = row;
                        }
                    }
                    break;
            }

            return view;
        }
        #endregion

        #region MyOwnMethods
        private void ConfigureTextField(NSTableCellView view, nint row)
        {
            // Add to view
            view.TextField.AutoresizingMask = NSViewResizingMask.WidthSizable;
            view.AddSubview(view.TextField);

            // Configure
            view.TextField.BackgroundColor = NSColor.Clear;
            view.TextField.Bordered = false;
            view.TextField.Selectable = false;
            view.TextField.Editable = true;


            // Wireup events
            view.TextField.EditingEnded += (sender, e) => {

                // Take action based on type
                switch (view.Identifier)
                {
                    case "Imie":
                        DataSource.Nauczyciele[(int)view.TextField.Tag].Imie = view.TextField.StringValue;
                        break;
                    case "Nazwisko":
                        DataSource.Nauczyciele[(int)view.TextField.Tag].Nazwisko = view.TextField.StringValue;
                        break;
                }
            };

            // Tag view
            view.TextField.Tag = row;
        }

        public bool DataCellContains(string columnName, nint row, string searchString)
        {
            string StringValue = "";
            switch (columnName)
            {
                case "Imie":
                    StringValue = DataSource.Nauczyciele[(int)row].Imie;
                    return StringValue.Contains(searchString); 
                case "Nazwisko":
                    StringValue = DataSource.Nauczyciele[(int)row].Nazwisko;
                    return StringValue.Contains(searchString); 
                default:
                    return true;
            }
        }
        #endregion
    }
}