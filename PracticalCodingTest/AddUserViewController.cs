using System;
using PracticalCodingTest.Application.Extensions;
using PracticalCodingTest.DomainInterfaces;
using UIKit;

namespace PracticalCodingTest.Application
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
                //var user = new User(UsernameTextField.Text, new Password(PasswordTextField.Text));
                //UserRepository.AddUser(user);
            }
            catch (SystemException e) when (e is ArgumentException || e is InvalidOperationException)
            {
                this.ShowFailAlert(e.Message);
                return;
            }

            this.ShowSuccessAlert("A new user has been added");
            ResetForm();
        }

        private void ResetForm()
        {
            UsernameTextField.Text = "";
            PasswordTextField.Text = "";
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