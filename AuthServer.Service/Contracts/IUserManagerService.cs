using AuthServer.Model;
using AuthServer.Model.Models;
using System.Collections;
using System.Collections.Generic;

namespace AuthServer.Service.Contracts
{
    public interface IUserManagerService
    {
        User CreateUser(CreateUserWrapper user);
        User BlockUser(User user);
        User UpdateUser(User user);

        IEnumerable<User> Users(); //get all users

        User GetById(int id);
        User GetByEmail(int id);


    }
}
