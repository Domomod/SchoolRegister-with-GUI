// WARNING
// This file has been generated automatically by Visual Studio to
// mirror C# types. Changes in this file made by drag-connecting
// from the UI designer will be synchronized back to C#, but
// more complex manual changes may not transfer correctly.


#import <Foundation/Foundation.h>
#import <AppKit/AppKit.h>


@interface AdminPrzedmiotyViewController : NSViewController {
	NSTextField *_NazwaTextField;
	NSTableView *_PrzedmiotyTableView;
	NSScrollView *_StatusTextField;
	NSTextField *_WyszukajTextField;
}

@property (nonatomic, retain) IBOutlet NSTextField *NazwaTextField;

@property (nonatomic, retain) IBOutlet NSTableView *PrzedmiotyTableView;

@property (nonatomic, retain) IBOutlet NSScrollView *StatusTextField;

@property (nonatomic, retain) IBOutlet NSTextField *WyszukajTextField;

- (IBAction)OnDodajPrzedmiotPressed:(id)sender;

- (IBAction)OnWyszukajTextFieldEdited:(id)sender;

@end
