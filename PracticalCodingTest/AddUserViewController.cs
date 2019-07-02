using System;
using System.Collections.Generic;
using System.Linq;
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
        private IEnumerable<string> _currentUsernames = new List<string>();

        #region Class

        public AddUserViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidAppear(bool animated)
        {
            ListenToEvents(true);
            ResetView();
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
            _currentUsernames = UserRepository.Users.Select(u => u.Username);
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
            _newUser.Password = replacementString.Equals(string.Empty) ? "" : PasswordTextField.Text + replacementString;
            _newUser.Validate();

            if (_newUser.Errors.Count > 0 && _newUser.Errors["Password"] is string message && _newUser.Password.Length > 0)
                PasswordErrorLabel.Text = message;
            else
                PasswordErrorLabel.Text = "";

            return true;
        }

        private bool UsernameTextFieldShouldChangeCharacters(UITextField textfield, NSRange range,
            string replacementString)
        {
            _newUser.Username = replacementString.Equals(string.Empty) ? "" : UsernameTextField.Text + replacementString;
            if (_currentUsernames.Contains(_newUser.Username))
                UsernameErrorLabel.Text = "Username already exists";
            else
                UsernameErrorLabel.Text = "";

            return true;
        }

        #endregion
    }
}