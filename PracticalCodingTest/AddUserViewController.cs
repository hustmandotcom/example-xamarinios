using Foundation;
using PracticalCodingTest.Data;
using PracticalCodingTest.Extensions;
using PracticalCodingTest.Handlers;
using System;
using System.Collections.Generic;
using UIKit;

namespace PracticalCodingTest
{
    public partial class AddUserViewController : UIViewController
    {
        public IUserRepository UserRepository { get; set; }

        #region Class
        public AddUserViewController(IntPtr handle) : base(handle)
        {
        }

        #endregion

        #region UI Event Response

        partial void SaveButton_TouchUpInside(UIButton sender)
        {
            try
            {
                var user = new User(UsernameTextField.Text, new Password(PasswordTextField.Text));
                UserRepository.AddUser(user);
            }
            catch (ArgumentException ax)
            {
                this.ShowOkAlert(ax.Message);
            }
            catch (InvalidOperationException ex)
            {
                this.ShowOkAlert(ex.Message);
            }

            DismissViewController(true, null);
        }

        partial void PasswordTextField_ValueChanged(UITextField sender)
        {
        }

        partial void UsernameTextField_ValueChanged(UITextField sender)
        {
        }

        #endregion
    }
}