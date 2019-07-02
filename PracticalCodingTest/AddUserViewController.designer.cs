// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//

using System.CodeDom.Compiler;
using Foundation;

namespace PracticalCodingTest.Application
{
    [Register ("AddUserViewController")]
    partial class AddUserViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField PasswordTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton SaveButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField UsernameTextField { get; set; }

        [Action ("PasswordTextField_ValueChanged:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void PasswordTextField_ValueChanged (UIKit.UITextField sender);

        [Action ("SaveButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void SaveButton_TouchUpInside (UIKit.UIButton sender);

        [Action ("UsernameTextField_ValueChanged:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void UsernameTextField_ValueChanged (UIKit.UITextField sender);

        void ReleaseDesignerOutlets ()
        {
            if (PasswordTextField != null) {
                PasswordTextField.Dispose ();
                PasswordTextField = null;
            }

            if (SaveButton != null) {
                SaveButton.Dispose ();
                SaveButton = null;
            }

            if (UsernameTextField != null) {
                UsernameTextField.Dispose ();
                UsernameTextField = null;
            }
        }
    }
}