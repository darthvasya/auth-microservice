using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthServer.Model;
using AuthServer.Service.Contracts;
using AuthServer.Repository;
using AuthServer.DAL.Contracts;
using AuthServer.Model.Models;

namespace AuthServer.Service.Implementations
{
    public class UserManagerService : IUserManagerService
    {
        IUnitOfWork _unitOfWork;
        IUserRepository _userRepository;
        IUserPasswordRepository _userPasswordRepository;

        public UserManagerService(
                        IUnitOfWork unitOfWork,
                        IUserRepository userRepository,
                        IUserPasswordRepository passwordRepository)
        {
            this._unitOfWork = unitOfWork;
            this._userRepository = userRepository;
            this._userPasswordRepository = passwordRepository;
        }

        public User BlockUser(User user)
        {
            throw new NotImplementedException();
        }

        public User CreateUser(CreateUserWrapper user)
        {
            if (user == null || user.password_hash == "")
                return null;
            try
            {
                User user_obj = _userRepository.GetAll().Where(p => p.email == user.email).FirstOrDefault();
                UserPassword user_password = null;
                if (user_obj == null)
                {
                    //creating objects
                    user_obj = new User();
                    user_password = new UserPassword();

                    //add information
                    user_obj.email = user.email;
                    user_obj.date_registration = DateTime.Now;

                    //add user object to context
                    user_obj = _userRepository.Add(user_obj);

                    //commit
                    _unitOfWork.Commit();

                    //add information to password object
                    user_password.id = user_obj.id;
                    user_password.password_hash = user.password_hash;

                    //add password object to context
                    _userPasswordRepository.Add(user_password);

                    //commit
                    _unitOfWork.Commit();


                    return user_obj;
                }
                else
                    return null;
            }
            catch
            {
                return null;
            }
        }

        public User GetByEmail(int id)
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public User UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> Users()
        {
            throw new NotImplementedException();
        }
    }
}
