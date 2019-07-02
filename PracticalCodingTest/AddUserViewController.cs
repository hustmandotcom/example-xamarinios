using System;
using PracticalCodingTest.Application.Extensions;
using PracticalCodingTest.Data;
using PracticalCodingTest.DomainInterfaces;
using UIKit;

namespace PracticalCodingTest.Application
{
    public partial class AddUserViewController : UIViewController
    {
        public IUserRepository UserRepository { get; set; }

        private User _newUser = User.DefaultUser();

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
                UserRepository.AddUser(new User(_newUser.Username, _newUser.Password));
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
            _newUser = User.DefaultUser();
        }

        partial void PasswordTextField_ValueChanged(UITextField sender)
        {
            _newUser.Password = sender.Text;
            _newUser.Validate();
        }

        partial void UsernameTextField_ValueChanged(UITextField sender)
        {
            _newUser.Username = sender.Text;
        }

        #endregion
    }
}