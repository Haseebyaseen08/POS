using POS.Models.DTO;

namespace POS.Repositories.Abstract
{
    public interface IUserAuthenticationService
    {
        Task<Status> Login(Login request);
        Task<Status> Register(Registration request);
        Task Logout();
    }
}
