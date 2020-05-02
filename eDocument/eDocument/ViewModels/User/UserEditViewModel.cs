using eDocument.Helpers;
using eDocument.ViewModels.Base;
using System.ComponentModel.DataAnnotations;

namespace eDocument.ViewModels.User
{
    public class UserEditViewModel : UserBaseViewModel
    {
        public string CurrentPassword { get; set; }

        [MinLength(6, ErrorMessage = "New Password must be at least 6 characters")]
        public string NewPassword { get; set; }

        [MinimumCount(1, ErrorMessage = "Roles cannot be empty")]
        public string[] Roles { get; set; }
    }
}
