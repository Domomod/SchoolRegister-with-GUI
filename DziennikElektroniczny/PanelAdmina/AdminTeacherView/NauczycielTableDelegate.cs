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
                        view.TextField = new NSTextField(new CGRect(0, 0, 400, 16));
                        ConfigureTextField(view, row);
                        break;
                    case "Nazwisko":
                        view.TextField = new NSTextField(new CGRect(0, 0, 400, 16));
                        ConfigureTextField(view, row);
                        break;
                    case "Pesel":
                        view.TextField = new NSTextField(new CGRect(0, 0, 400,16));
                        ConfigureTextField(view, row);
                        break;
                    case "Telefon":
                        view.TextField = new NSTextField(new CGRect(0, 0, 400, 16));
                        ConfigureTextField(view, row);
                        break;
                    case "Email":
                        view.TextField = new NSTextField(new CGRect(0, 0, 400, 16));
                        ConfigureTextField(view, row);
                        break;
                    case "Adres":
                        view.TextField = new NSTextField(new CGRect(0, 0, 400, 16));
                        ConfigureTextField(view, row);
                        break;
                    case "Etat":
                        view.TextField = new NSTextField(new CGRect(0, 0, 400, 16));
                        ConfigureTextField(view, row);
                        break;
                    case "Zapisz":
                        {
                            var button = new NSButton(new CGRect(0, 0, 43, 16));
                            button.Cell = new NSButtonCell { BackgroundColor = NSColor.Green };
                            button.SetButtonType(NSButtonType.MomentaryPushIn);
                            button.Title = "+";
                            button.Tag = row;

                            // Przypisz zachowanie do przycisku.
                            button.Activated += (sender, e) =>
                            {
                                var przycisk = sender as NSButton;
                                var rekord = DataSource.Nauczyciele[(int)przycisk.Tag];

                                try
                                {
                                    DataSource.UpdateAt((int)przycisk.Tag);
                                    var nauczyciel = DataSource.Nauczyciele[(int)przycisk.Tag];
                                    ViewController.SetStatusTextField($"Zmodyfikowano {nauczyciel.Imie} {nauczyciel.Nazwisko}");
                                }
                                catch (Exception exception) {
                                    ViewController.SetStatusTextField(exception.Message);
                                }
                                // Remove the given row from the dataset
                            };

                            // Add to view
                            view.AddSubview(button);
                        }
                        break;
                    case "Usuń":
                        {
                            // Stwórz przycisk
                            var button = new NSButton(new CGRect(0, 0, 43, 16));
                            button.Cell = new NSButtonCell { BackgroundColor = NSColor.Red };
                            button.SetButtonType(NSButtonType.MomentaryPushIn);
                            button.Title = "X";
                            button.Tag = row;

                            // Przypisz zachowanie do przycisku.
                            button.Activated += (sender, e) =>
                            {
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
                                if (result == 1001)
                                {
                                    // Remove the given row from the dataset
                                    DataSource.Nauczyciele.RemoveAt((int)przycisk.Tag);
                                    ViewController.ReloadTable();
                                }


                            };

                            // Add to view
                            view.AddSubview(button);
                        }
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
                case "Pesel":
                    view.TextField.StringValue = DataSource.Nauczyciele[(int)row].Pesel;
                    view.TextField.Tag = row;
                    break;
                case "Telefon":
                    view.TextField.StringValue = DataSource.Nauczyciele[(int)row].Telefon;
                    view.TextField.Tag = row;
                    break;
                case "Email":
                    view.TextField.StringValue = DataSource.Nauczyciele[(int)row].Email;
                    view.TextField.Tag = row;
                    break;
                case "Adres":
                    view.TextField.StringValue = DataSource.Nauczyciele[(int)row].Adres;
                    view.TextField.Tag = row;
                    break;
                case "Etat":
                    view.TextField.StringValue = DataSource.Nauczyciele[(int)row].Etat;
                    view.TextField.Tag = row;
                    break;
                case "Zapisz":
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
                try
                {
                    switch (view.Identifier)
                    {
                        case "Imie":
                            DataSource.Nauczyciele[(int)view.TextField.Tag].Imie = view.TextField.StringValue;
                            break;
                        case "Nazwisko":
                            DataSource.Nauczyciele[(int)view.TextField.Tag].Nazwisko = view.TextField.StringValue;
                            break;
                        case "Etat":
                            DataSource.Nauczyciele[(int)view.TextField.Tag].Etat = view.TextField.StringValue;
                            break;
                        case "Pesel":
                            DataSource.Nauczyciele[(int)view.TextField.Tag].Pesel = view.TextField.StringValue;
                            break;
                        case "Adres":
                            DataSource.Nauczyciele[(int)view.TextField.Tag].Adres = view.TextField.StringValue;
                            break;
                        case "Email":
                            DataSource.Nauczyciele[(int)view.TextField.Tag].Email = view.TextField.StringValue;
                            break;
                        case "Telefon":
                            DataSource.Nauczyciele[(int)view.TextField.Tag].Telefon = view.TextField.StringValue;
                            break;
                    }
                }
                catch(Exception exception)
                {
                    ViewController.SetStatusTextField(exception.Message);
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
                case "Etat":
                    StringValue = DataSource.Nauczyciele[(int)row].Etat;
                    return StringValue.Contains(searchString);
                case "Pesel":
                    StringValue = DataSource.Nauczyciele[(int)row].Pesel;
                    return StringValue.Contains(searchString);
                case "Adres":
                    StringValue = DataSource.Nauczyciele[(int)row].Adres;
                    return StringValue.Contains(searchString);
                case "Email":
                    StringValue = DataSource.Nauczyciele[(int)row].Email;
                    return StringValue.Contains(searchString);
                case "Telefon":
                    StringValue = DataSource.Nauczyciele[(int)row].Telefon;
                    return StringValue.Contains(searchString);
                default:
                    return true;
            }
        }
        #endregion
    }
}