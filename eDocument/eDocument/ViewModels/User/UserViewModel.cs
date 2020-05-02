using eDocument.Helpers;
using eDocument.ViewModels.Base;

namespace eDocument.ViewModels.User
{
    public class UserViewModel : UserBaseViewModel
    {
        public bool IsLockedOut { get; set; }

        [MinimumCount(1, ErrorMessage = "Roles cannot be empty")]
        public string[] Roles { get; set; }
    }
}
