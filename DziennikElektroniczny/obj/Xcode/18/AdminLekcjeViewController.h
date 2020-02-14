// WARNING
// This file has been generated automatically by Visual Studio to
// mirror C# types. Changes in this file made by drag-connecting
// from the UI designer will be synchronized back to C#, but
// more complex manual changes may not transfer correctly.


#import <Foundation/Foundation.h>
#import <AppKit/AppKit.h>


@interface AdminLekcjeViewController : NSViewController {
	NSComboBox *_DzienTygodniaCombobox;
	NSComboBox *_JednostkaCombobox;
	NSComboBox *_KlasaCombobox;
	NSTableView *_LekcjeTableView;
	NSTextField *_OnWyszukajTextFieldEdited;
	NSComboBox *_PrzedmiotCombobox;
	NSComboBox *_SalaCombobox;
	NSTextField *_StatusTextField;
	NSTextField *_WyszukajTextField;
}

@property (nonatomic, retain) IBOutlet NSComboBox *DzienTygodniaCombobox;

@property (nonatomic, retain) IBOutlet NSComboBox *JednostkaCombobox;

@property (nonatomic, retain) IBOutlet NSComboBox *KlasaCombobox;

@property (nonatomic, retain) IBOutlet NSTableView *LekcjeTableView;

@property (nonatomic, retain) IBOutlet NSTextField *OnWyszukajTextFieldEdited;

@property (nonatomic, retain) IBOutlet NSComboBox *PrzedmiotCombobox;

@property (nonatomic, retain) IBOutlet NSComboBox *SalaCombobox;

@property (nonatomic, retain) IBOutlet NSTextField *StatusTextField;

@property (nonatomic, retain) IBOutlet NSTextField *WyszukajTextField;

- (IBAction)OnDodajLekcjeButtonPressed:(id)sender;

@end
