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

        private bool IsValidPassword(string password)
        {
            _newUser.Password = password;
            _newUser.ValidatePassword();

            if (!_newUser.IsValid
                && _newUser.Errors["Password"] is string message
                && _newUser.Password.Length > 0)
                PasswordErrorLabel.Text = message;
            else
                PasswordErrorLabel.Text = "";

            return _newUser.Errors.Count < 1;
        }

        private bool IsValidUser(string username)
        {
            _newUser.Username = username;
            _newUser.ValidateUsername(_currentUsernames);

            if (!_newUser.IsValid
                && _newUser.Errors["Username"] is string message
                && _newUser.Username.Length > 0)
                UsernameErrorLabel.Text = message;
            else
                UsernameErrorLabel.Text = "";

            return !_currentUsernames.Contains(_newUser.Username);
        }

        private string GetUpdatedString(UITextField textfield, string replacementString)
        {
            var updatedText = textfield.Text + replacementString;

            if (replacementString.Equals(""))
                updatedText = textfield.Text.Length > 0
                    ? textfield.Text.TrimEnd(textfield.Text[textfield.Text.Length - 1])
                    : "";

            return updatedText;
        }

        #endregion

        #region UI Event Response

        partial void SaveButton_TouchUpInside(UIButton sender)
        {
            try
            {
                _newUser.Username = UsernameTextField.Text;
                _newUser.Password = PasswordTextField.Text;

                if (!IsValidUser(_newUser.Username) || !IsValidPassword(_newUser.Password))
                    return;
                
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
            var newPassword = GetUpdatedString(textfield, replacementString);
            IsValidPassword(newPassword);

            return true;
        }


        private bool UsernameTextFieldShouldChangeCharacters(UITextField textfield, NSRange range,
            string replacementString)
        {
            var username = GetUpdatedString(textfield, replacementString);
            IsValidUser(username);

            return true;
        }

        #endregion
    }
}