// WARNING
// This file has been generated automatically by Visual Studio to
// mirror C# types. Changes in this file made by drag-connecting
// from the UI designer will be synchronized back to C#, but
// more complex manual changes may not transfer correctly.


#import <Foundation/Foundation.h>
#import <AppKit/AppKit.h>


@interface AdminSaleViewController : NSViewController {
	NSTextField *_LiczbaMiejscTextField;
	NSTextField *_PietroTextField;
	NSTextField *_SalaTextField;
	NSTextField *_StatusTextField;
	NSTextFieldCell *_WyszukajTextField;
}

@property (nonatomic, retain) IBOutlet NSTextField *LiczbaMiejscTextField;

@property (nonatomic, retain) IBOutlet NSTextField *PietroTextField;

@property (nonatomic, retain) IBOutlet NSTextField *SalaTextField;

@property (nonatomic, retain) IBOutlet NSTextField *StatusTextField;

@property (nonatomic, retain) IBOutlet NSTextFieldCell *WyszukajTextField;

- (IBAction)OnDodajSaleButtonPressed:(id)sender;

- (IBAction)OnWyszukajTextFieldEdited:(id)sender;

@end
