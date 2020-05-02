using eDocument.Authorization;

namespace eDocument.Policies
{
    public static class AccountManagementOperations
    {
        public const string CreateOperationName = "Create";
        public const string ReadOperationName = "Read";
        public const string UpdateOperationName = "Update";
        public const string DeleteOperationName = "Delete";

        public static UserAccountAuthorizationRequirement Create = new UserAccountAuthorizationRequirement(CreateOperationName);
        public static UserAccountAuthorizationRequirement Read = new UserAccountAuthorizationRequirement(ReadOperationName);
        public static UserAccountAuthorizationRequirement Update = new UserAccountAuthorizationRequirement(UpdateOperationName);
        public static UserAccountAuthorizationRequirement Delete = new UserAccountAuthorizationRequirement(DeleteOperationName);
    }
}
