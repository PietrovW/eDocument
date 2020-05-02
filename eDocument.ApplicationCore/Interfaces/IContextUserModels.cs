namespace eDocument.ApplicationCore.Interfaces
{
    public interface IContextUserModels
    {
        string CurrentUserId();
        string[] GetRoles();
    }
}
