// WARNING
// This file has been generated automatically by Visual Studio to
// mirror C# types. Changes in this file made by drag-connecting
// from the UI designer will be synchronized back to C#, but
// more complex manual changes may not transfer correctly.


#import <Foundation/Foundation.h>
#import <AppKit/AppKit.h>


@interface AdminJednostkiViewController : NSViewController {
	NSComboBox *_GodzinaCombobox;
	NSTableView *_JednostkiTableView;
	NSComboBox *_MinutaCombobox;
	NSTextField *_StatusTextField;
}

@property (nonatomic, retain) IBOutlet NSComboBox *GodzinaCombobox;

@property (nonatomic, retain) IBOutlet NSTableView *JednostkiTableView;

@property (nonatomic, retain) IBOutlet NSComboBox *MinutaCombobox;

@property (nonatomic, retain) IBOutlet NSTextField *StatusTextField;

- (IBAction)OnDodajJednostkeButtonPressed:(id)sender;

@end
