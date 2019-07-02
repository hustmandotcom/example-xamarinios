using System;
using System.Linq;
using Foundation;
using PracticalCodingTest.Data;
using PracticalCodingTest.DomainInterfaces;
using UIKit;

namespace PracticalCodingTest.Application
{
    public partial class UserTableViewController : UITableViewController
    {
        private readonly IUserRepository _userRepository;
        private const string CellIdentifier = "TableCell";
        private User[] _usersCache;

        #region Class

        public UserTableViewController(IntPtr handle) : base(handle)
        {
            _userRepository = new UserRepository(new InMemoryDatabase());
            _usersCache = _userRepository.Users.ToArray();
        }

        public override void ViewWillAppear(bool animated)
        {
            RefreshData();
            base.ViewWillAppear(animated);
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            if (segue.Identifier.Equals("AddUserViewSegue"))
                if (segue.DestinationViewController is AddUserViewController addUserViewController)
                    addUserViewController.UserRepository = _userRepository;

            base.PrepareForSegue(segue, sender);
        }

        #endregion

        #region Load Table

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return _usersCache.Length;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(CellIdentifier) 
                ?? new UITableViewCell(UITableViewCellStyle.Default, CellIdentifier);

            var user = _usersCache[indexPath.Row];
            cell.TextLabel.Text = user.Username;
            return cell;
        }

        #endregion

        #region Private

        private void RefreshData()
        {
            _usersCache = _userRepository.Users.ToArray();
            UserTableView.ReloadData();
        }

        #endregion

    }
}