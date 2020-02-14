// WARNING
// This file has been generated automatically by Visual Studio to
// mirror C# types. Changes in this file made by drag-connecting
// from the UI designer will be synchronized back to C#, but
// more complex manual changes may not transfer correctly.


#import <Foundation/Foundation.h>
#import <AppKit/AppKit.h>


@interface AdminUczenViewController : NSViewController {
	NSTextField *_AdresTextField;
	NSTextField *_EmailTextField;
	NSTextField *_ImieTextField;
	NSComboBox *_KlasaCombobox;
	NSTextField *_NazwiskoTextField;
	NSTableView *_ObecnościTableView;
	NSTableView *_OcenyTableView;
	NSTableView *_OpiekunowieTableView;
	NSTextField *_PeselTextField;
	NSTextView *_StatusTextView;
	NSTextField *_TextField;
	NSTableView *_UczniowieTableView;
	NSTableView *_UwagiTableView;
}

@property (nonatomic, retain) IBOutlet NSTextField *AdresTextField;

@property (nonatomic, retain) IBOutlet NSTextField *EmailTextField;

@property (nonatomic, retain) IBOutlet NSTextField *ImieTextField;

@property (nonatomic, retain) IBOutlet NSComboBox *KlasaCombobox;

@property (nonatomic, retain) IBOutlet NSTextField *NazwiskoTextField;

@property (nonatomic, retain) IBOutlet NSTableView *ObecnościTableView;

@property (nonatomic, retain) IBOutlet NSTableView *OcenyTableView;

@property (nonatomic, retain) IBOutlet NSTableView *OpiekunowieTableView;

@property (nonatomic, retain) IBOutlet NSTextField *PeselTextField;

@property (nonatomic, retain) IBOutlet NSTextView *StatusTextView;

@property (nonatomic, retain) IBOutlet NSTextField *TextField;

@property (nonatomic, retain) IBOutlet NSTableView *UczniowieTableView;

@property (nonatomic, retain) IBOutlet NSTableView *UwagiTableView;

- (IBAction)OnDodajUczniaButtonPressed:(id)sender;

- (IBAction)OnWyszukajTextCellEdited:(id)sender;

@end
