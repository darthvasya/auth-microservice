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
        IUserRoleRepository _userRoleRepository;
        IRolePermissionRepository _rolePermissionRepository;

        public UserManagerService(
                        IUnitOfWork unitOfWork,
                        IUserRepository userRepository,
                        IUserPasswordRepository passwordRepository,
                        IUserRoleRepository userRoleRepository)
        {
            this._unitOfWork = unitOfWork;
            this._userRepository = userRepository;
            this._userPasswordRepository = passwordRepository;
            this._userRoleRepository = userRoleRepository;
            //this._rolePermissionRepository = rolePermissionRepository;
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
                UserRole user_role = null;

                if (user_obj == null)
                {
                    //creating objects
                    user_obj = new User();
                    user_password = new UserPassword();
                    user_role = new UserRole();

                    //add information
                    user_obj.email = user.email;
                    user_obj.date_registration = DateTime.Now;

                    //add user object to context
                    user_obj = _userRepository.Add(user_obj);

                    //commit
                    _unitOfWork.Commit();

                    //add information to password object
                    user_password.user_id = user_obj.id;
                    user_password.passwrod_hash = user.password_hash;
                    

                    //add password object to context
                    _userPasswordRepository.Add(user_password);


                    //commit
                    _unitOfWork.Commit();

                    //add role
                    user_role.user_id = user_obj.id;
                    // 1 - admin, 2 -moderator, 3 - user
                    user_role.role_id = 3;

                    user_role = _userRoleRepository.Add(user_role);

                    //commit
                    _unitOfWork.Commit();

                    return user_obj;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public User GetByEmail(string email)
        {
            return null;
            User user = null;

            try
            {
                user = new User();
                if (email != null || email != "")
                {
                    user = _userRepository.GetAll().Where(p => p.email == email).FirstOrDefault();
                    if (user == null)
                        return null;
                    return user;
                }
                else
                    return null;
            }
            catch
            {
                return null;
            }
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
            return _userRepository.GetAll();
        }
    }
}
