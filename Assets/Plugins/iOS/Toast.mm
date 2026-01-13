#import <UIKit/UIKit.h>

extern "C"
{
    void ShowNativeToast(const char* message)
    {
        NSString* msg = [NSString stringWithUTF8String:message];

        UIAlertController* alert =
            [UIAlertController alertControllerWithTitle:nil
                                                message:msg
                                         preferredStyle:UIAlertControllerStyleAlert];

        UIViewController* rootVC =
            [UIApplication sharedApplication].keyWindow.rootViewController;

        [rootVC presentViewController:alert animated:YES completion:nil];

        dispatch_after(dispatch_time(DISPATCH_TIME_NOW, 2 * NSEC_PER_SEC),
                       dispatch_get_main_queue(), ^{
            [alert dismissViewControllerAnimated:YES completion:nil];
        });
    }
}
