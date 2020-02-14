// WARNING
// This file has been generated automatically by Visual Studio to
// mirror C# types. Changes in this file made by drag-connecting
// from the UI designer will be synchronized back to C#, but
// more complex manual changes may not transfer correctly.


#import <Foundation/Foundation.h>
#import <AppKit/AppKit.h>


@interface AdminNauczycieleViewController : NSViewController {
	NSTextField *_AdresTextField;
	NSButton *_DodajTextField;
	NSTextField *_EmailTextField;
	NSTextField *_EtatTextField;
	NSTableColumn *_ImieTableColumn;
	NSTextField *_ImieTextField;
	NSTableView *_NauczycieleTableView;
	NSTableColumn *_NazwiskoTableColumn;
	NSTextField *_NazwiskoTextField;
	NSTextField *_PeselTextField;
	NSTextField *_SearchTextCell;
	NSScrollView *_StatusTextField;
	NSTextField *_TelefonTextField;
}

@property (nonatomic, retain) IBOutlet NSTextField *AdresTextField;

@property (nonatomic, retain) IBOutlet NSButton *DodajTextField;

@property (nonatomic, retain) IBOutlet NSTextField *EmailTextField;

@property (nonatomic, retain) IBOutlet NSTextField *EtatTextField;

@property (nonatomic, retain) IBOutlet NSTableColumn *ImieTableColumn;

@property (nonatomic, retain) IBOutlet NSTextField *ImieTextField;

@property (nonatomic, retain) IBOutlet NSTableView *NauczycieleTableView;

@property (nonatomic, retain) IBOutlet NSTableColumn *NazwiskoTableColumn;

@property (nonatomic, retain) IBOutlet NSTextField *NazwiskoTextField;

@property (nonatomic, retain) IBOutlet NSTextField *PeselTextField;

@property (nonatomic, retain) IBOutlet NSTextField *SearchTextCell;

@property (nonatomic, retain) IBOutlet NSScrollView *StatusTextField;

@property (nonatomic, retain) IBOutlet NSTextField *TelefonTextField;

- (IBAction)OnSearchTextCellChange:(id)sender;

@end
