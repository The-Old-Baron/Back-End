namespace OldBarom.Core.Domain.Interface.Account{
    public interface IAuthenticate{
        Task<bool> Authenticate(string email, string password);
        Task<bool> Register(string email, string password);
        Task Logout();
    }
}