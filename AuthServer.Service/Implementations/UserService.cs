using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthServer.Model;
using AuthServer.Service.Contracts;
using AuthServer.DAL.Contracts;
using AuthServer.Repository;

namespace AuthServer.Service.Implementations
{
    public class UserService : IUserService
    {
        IUnitOfWork _unitOfWork;
        IUserRepository _userRepository;

        public UserService(
                        IUnitOfWork unitOfWork,
                        IUserRepository userRepository)
        {
            this._unitOfWork = unitOfWork;
            this._userRepository = userRepository;
        }

        public User GetUsers(int id)
        {
            return _userRepository.GetById(id);
        }
    }
}
