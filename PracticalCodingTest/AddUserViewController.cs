using System;
using Foundation;
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

        public override void ViewDidAppear(bool animated)
        {
            ListenToEvents(true);
        }

        public override void ViewWillDisappear(bool animated)
        {
            ListenToEvents(false);
        }

        private void ListenToEvents(bool listen)
        {
            UsernameTextField.ShouldChangeCharacters -= UsernameTextFieldShouldChangeCharacters;
            PasswordTextField.ShouldChangeCharacters -= PasswordTextFieldShouldChangeCharacters;
            if (listen)
            {
                UsernameTextField.ShouldChangeCharacters += UsernameTextFieldShouldChangeCharacters;
                PasswordTextField.ShouldChangeCharacters += PasswordTextFieldShouldChangeCharacters;
            }
        }

        #endregion

        #region Private

        private void ResetView()
        {
            UsernameTextField.Text = "";
            PasswordTextField.Text = "";
            _newUser = User.DefaultUser();
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
            ResetView();
        }

        private bool PasswordTextFieldShouldChangeCharacters(UITextField textfield, NSRange range,
            string replacementString)
        {
            _newUser.Password = textfield.Text;
            _newUser.Validate();
            return true;
        }

        private bool UsernameTextFieldShouldChangeCharacters(UITextField textfield, NSRange range,
            string replacementString)
        {
            _newUser.Username = textfield.Text;
            return true;
        }

        #endregion
    }
}