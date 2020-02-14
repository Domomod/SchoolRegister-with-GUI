// WARNING
// This file has been generated automatically by Visual Studio to
// mirror C# types. Changes in this file made by drag-connecting
// from the UI designer will be synchronized back to C#, but
// more complex manual changes may not transfer correctly.


#import <Foundation/Foundation.h>
#import <AppKit/AppKit.h>


@interface AdminOpiekunViewController : NSViewController {
	NSTextField *_AdresTextCell;
	NSTextField *_DochodTextCell;
	NSComboBox *_DzieciCombobox;
	NSTableView *_DzieciTableView;
	NSTextField *_EmailTextCell;
	NSTextField *_ImieTextCell;
	NSComboBox *_NauczycieleCombobox;
	NSTextField *_NazwiskoTextCell;
	NSTableView *_OpiekunowieTableView;
	NSTextField *_PeselTextCell;
	NSTextField *_SearchTextCell;
	NSTextField *_TelefonTextCell;
}

@property (nonatomic, retain) IBOutlet NSTextField *AdresTextCell;

@property (nonatomic, retain) IBOutlet NSTextField *DochodTextCell;

@property (nonatomic, retain) IBOutlet NSComboBox *DzieciCombobox;

@property (nonatomic, retain) IBOutlet NSTableView *DzieciTableView;

@property (nonatomic, retain) IBOutlet NSTextField *EmailTextCell;

@property (nonatomic, retain) IBOutlet NSTextField *ImieTextCell;

@property (nonatomic, retain) IBOutlet NSComboBox *NauczycieleCombobox;

@property (nonatomic, retain) IBOutlet NSTextField *NazwiskoTextCell;

@property (nonatomic, retain) IBOutlet NSTableView *OpiekunowieTableView;

@property (nonatomic, retain) IBOutlet NSTextField *PeselTextCell;

@property (nonatomic, retain) IBOutlet NSTextField *SearchTextCell;

@property (nonatomic, retain) IBOutlet NSTextField *TelefonTextCell;

- (IBAction)OnDodajNauczycielaOpiekubaButtonPressed:(id)sender;

- (IBAction)OnDodajOpiekunaButtonPressed:(id)sender;

- (IBAction)OnPrzypiszDzieckoButtonPressed:(id)sender;

- (IBAction)OnWyszukajTextCellEdited:(id)sender;

@end
