// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace PracticalCodingTest.Application
{
    [Register ("UserTableViewController")]
    partial class UserTableViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem AddUserButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView UserTableView { get; set; }

        [Action ("AddUserButton_Activated:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void AddUserButton_Activated (UIKit.UIBarButtonItem sender);

        void ReleaseDesignerOutlets ()
        {
            if (AddUserButton != null) {
                AddUserButton.Dispose ();
                AddUserButton = null;
            }

            if (UserTableView != null) {
                UserTableView.Dispose ();
                UserTableView = null;
            }
        }
    }
}