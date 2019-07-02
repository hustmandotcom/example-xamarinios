using UIKit;

namespace PracticalCodingTest.Application.Extensions
{
    public static class UIViewControllerExtensions
    {
        public static void ShowAlert(this UIViewController uiViewController, string title, string message, string closeButtonText)
        {
            var alertController = UIAlertController.Create(title, message, UIAlertControllerStyle.Alert);
            var alertAction = UIAlertAction.Create(closeButtonText, UIAlertActionStyle.Default, null);
            alertController.AddAction(alertAction);
            uiViewController.PresentViewController(alertController, true, null);
        }

        public static void ShowFailAlert(this UIViewController uiViewController, string message)
        {
            uiViewController.ShowAlert("Not Successful", message, "Try Again");
        }
        public static void ShowSuccessAlert(this UIViewController uiViewController, string message)
        {
            uiViewController.ShowAlert("Successful", message, "Sweet!");
        }
    }
}