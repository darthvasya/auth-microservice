using AuthServer.Model;

namespace AuthServer.Service.Contracts
{
    public interface IUserService
    {
        User GetUsers(int id);
    }
}
