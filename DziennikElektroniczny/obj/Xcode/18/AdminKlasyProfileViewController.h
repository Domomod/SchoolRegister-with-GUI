// WARNING
// This file has been generated automatically by Visual Studio to
// mirror C# types. Changes in this file made by drag-connecting
// from the UI designer will be synchronized back to C#, but
// more complex manual changes may not transfer correctly.


#import <Foundation/Foundation.h>
#import <AppKit/AppKit.h>


@interface AdminKlasyProfileViewController : NSViewController {
	NSTableView *_KlasyTableView;
	NSComboBox *_ProfilCombobox;
	NSTextField *_ProfilTextField;
	NSTextField *_RocznikTextField;
	NSTextField *_StatusTextField;
	NSTextField *_SymbolTextField;
	NSTextField *_WyszukajTextField;
}

@property (nonatomic, retain) IBOutlet NSTableView *KlasyTableView;

@property (nonatomic, retain) IBOutlet NSComboBox *ProfilCombobox;

@property (nonatomic, retain) IBOutlet NSTextField *ProfilTextField;

@property (nonatomic, retain) IBOutlet NSTextField *RocznikTextField;

@property (nonatomic, retain) IBOutlet NSTextField *StatusTextField;

@property (nonatomic, retain) IBOutlet NSTextField *SymbolTextField;

@property (nonatomic, retain) IBOutlet NSTextField *WyszukajTextField;

- (IBAction)OnDodajKlaseButtonPressed:(id)sender;

- (IBAction)OnDodajProfilButtonPressed:(id)sender;

- (IBAction)OnWyszukajTextFieldEdited:(id)sender;

@end
