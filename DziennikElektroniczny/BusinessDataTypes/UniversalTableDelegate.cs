using System;
using AppKit;
using CoreGraphics;
using Foundation;
using System.Collections;
using System.Collections.Generic;

namespace DziennikElektroniczny
{
    //Ta klasa powinna być zgodna z interjfejsem każdej implementowanej przez nas tabeli
    //
    //Do ustawiani statusu, który to znajduje się w ViewControlerach użyłem klasy zawierającej referencję na TextField statusu.
    //Dzięki temu nie musimy znać konkretnego typu ViewControlera z którym mamy doczynienia
    //
    //Nie musimy też wiedzieć jakie dane wyświetlamy ponieważ:
    // - Każda tabela zawierająca przyciski Usuń/Zmodyfikuj (Nazwy muszą być identyczne!), jest implementowana w ten sam sposób dla każdej tabeli.
    // natomiast wykonywane przez nie akcje są delegowane do konkretnej implemntacji TableDataSource i polegają jedynie na indeksie wiersza w którym
    // wciśnięto przycisk
    //
    // - Tworzenie pól dla kolumn nie zawierających przycisków Usuń/Modyfikuj przebiega tak samo dla każdej kolumny. Natomiast pobranie odpowiedniej wartości,
    // delegowane jest do konkretnej implementacji TableDataSource. Wartość ta pobierana jest na podstawie nazwy kolumny i numeru wiersza.
    //
    // - Edycja pól jest delegowana do konkretnego TableDataSource w podobnysposób co pobieranie wartości, na podstawie nazwy kolumny, numeru wiersza oraz 
    // nowo zmodyfikowanej wartości pola
    public class UniversalTableDelegate : NSTableViewDelegate
    {
        #region Constants 
        private const string CellIdentifier = "ProdCell";
        #endregion

        #region Private Variables
        private AbstractTableDataSource DataSource;
        private NSTextFieldProxy StatusTextFieldProxy;
        private NSViewController ViewController;
        #endregion

        #region Constructors
        public UniversalTableDelegate(AdminNauczycieleViewController ViewController, NauczycielTableDataSource datasource, NSTextFieldProxy StatusTextFieldProxy)
        {
            this.DataSource = datasource;
            this.ViewController = ViewController;
            this.StatusTextFieldProxy = StatusTextFieldProxy;
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
                CreateCellAppropiateToGivenCollumn(tableView, tableColumn, row);

            }

            // Setup view based on the column selected
            UpdateCellView(tableView, tableColumn, row);

            return view;
        }
        #endregion

        #region Populating Table With Content
        protected void UpdateCellView(NSTableView tableView, NSTableColumn tableColumn, nint row)
        {
            switch (tableColumn.Title)
            {
                default:
                    view.TextField.StringValue = DataSource.Osoby[(int)row].Imie;
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
        }

        protected void CreateCellAppropiateToGivenCollumn(NSTableCellView view, NSTableColumn tableColumn, nint row)
        {
            // Take action based on title
            switch (tableColumn.Title)
            {
                default:
                    CreateTextFieldCell(view, tableColumn, row);
                    break;
                case "Zapisz":
                    CreateZapiszButtonCell(view, tableColumn, row);
                    break;
                case "Usuń":
                    CreateUsuńButtonCell(view, tableColumn, row);
                    break;
            }
        }

        private void CreateTextFieldCell(NSTableCellView view, NSTableColumn tableColumn, nint row) {
            view.TextField = new NSTextField(new CGRect(0, 0, 400, 16));
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
                EditingEnded(view);
            };

            // Tag view
            view.TextField.Tag = row;
        }

        private void CreateZapiszButtonCell(NSTableCellView view, NSTableColumn tableColumn, nint row)
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
                ZapiszButtonPressed(przycisk);
            };

            // Add to view
            view.AddSubview(button);
        }

        private void CreateUsuńButtonCell(NSTableCellView view, NSTableColumn tableColumn, nint row)
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

                UsuńButtonPressed(przycisk);

            };

            // Add to view
            view.AddSubview(button);
        }
        #endregion

        #region Reactions 
        void EditingEnded(NSTableCellView view) {
            try
            {
                switch (view.Identifier)
                {
                    default:
                        DataSource.SetAt(view.Identifier, view.TextField.StringValue, (int)view.TextField.Tag);
                        break;
                    case "Zapisz":
                    case "Usuń":
                        break;
                }
            }
            catch (Exception exception)
            {
                StatusTextFieldProxy.StringValue = exception.Message;
            }
        }

        void ZapiszButtonPressed(NSButton przycisk) {
            try
            {
                DataSource.UpdateAt((int)przycisk.Tag);
                StatusTextFieldProxy.StringValue = $"Zmodyfikowano {DataSource.GetRepresentationAt((int)przycisk.Tag)}";
            }
            catch (Exception exception)
            {
                StatusTextFieldProxy.StringValue = exception.Message;
                //Zmiany są już widoczne w tabeli więc nie trzeba nic przeładowywać
            }
        }

        void UsuńButtonPressed(NSButton przycisk) {
            // Show a popup alllert
            var alert = new NSAlert()
            {
                AlertStyle = NSAlertStyle.Informational,
                InformativeText = $"Czy na pewno chcesz usunąć {DataSource.GetRepresentationAt((int)przycisk.Tag)}? Taka operacja jest permamentna.",
                MessageText = $"Usunąć {DataSource.GetRepresentationAt((int)przycisk.Tag)}?",
            };
            alert.AddButton("Anuluj");
            alert.AddButton("Usuń");
            var result = alert.RunModal();
            if (result == 1001)
            {
                try
                {
                    // Remove the given row from the dataset
                    DataSource.RemoveAt((int)przycisk.Tag);
                    ViewController.ReloadTable(); 
                }
                catch (Exception exception)
                {
                    StatusTextFieldProxy.StringValue = exception.Message;
                }
                
            }
        }
         #endregion

        #region MyOwnMethods
        //Do wyszukiwania, sprawdza czy parametr o nazwie odpowiadającej columnName row-tej krotki zawiera searchString 
        public bool DataCellContains(string columnName, nint row, string searchString)
        {
            string StringValue = "";
            switch (columnName)
            {
                default:
                    string StringValue = DataSource.GetAt(columnName, (int)row);
                    return StringValue.Contains(searchString);
                case "Zapisz":
                case "Usuń":
                    return true;
            }
        }
        #endregion
    }
}