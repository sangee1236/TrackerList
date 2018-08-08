using System;
using System.Collections.Generic;
using System.Linq;
using TrackerList.Data.UnitOfWork;
using TrackerList.Model;

namespace TrackerList.Data.Model
{
    public class UserModel : IUserModel
    {
        private IUnitOfWork _unitOfWork;

        public UserModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool AddUser(Users user)
        {
            try
            {
                _unitOfWork.UserRepository.Add(user);
                _unitOfWork.Commit();
                if (user.Id > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex) { return false; }
        }

        public bool UpdateUser(Users user)
        {
            try
            {
                Users users = _unitOfWork.UserRepository.GetSingle(user.Id);

                if (users == null)
                    return false;
                else
                {
                    if (!string.IsNullOrEmpty(user.Name))
                        users.Name = user.Name;
                    if (!string.IsNullOrEmpty(user.EmailID))
                        users.EmailID = user.EmailID;
                    if (!string.IsNullOrEmpty(user.Password))
                        users.Password = user.Password;
                    if (!string.IsNullOrEmpty(user.Mobile))
                        users.Mobile = user.Mobile;
                    if (!string.IsNullOrEmpty(user.DateOfBirth.ToString()))
                        users.DateOfBirth = user.DateOfBirth;
                    if (!string.IsNullOrEmpty(user.JoiningDate.ToString()))
                        users.JoiningDate = user.JoiningDate;
                    if (!string.IsNullOrEmpty(user.Avatar))
                        users.Avatar = user.Avatar;
                    if (!string.IsNullOrEmpty(user.Status.ToString()))
                        users.Status = user.Status;
                    if (!string.IsNullOrEmpty(user.UserTypeId.ToString()))
                        users.UserTypeId = user.UserTypeId;
                    if (!string.IsNullOrEmpty(user.CreatedBy.ToString()))
                        users.CreatedBy = user.CreatedBy;
                    if (!string.IsNullOrEmpty(user.CreatedOn.ToString()))
                        users.CreatedOn = user.CreatedOn;
                    if (!string.IsNullOrEmpty(user.ModifiedOn.ToString()))
                        users.ModifiedOn = user.ModifiedOn;
                    if (!string.IsNullOrEmpty(user.ModifiedBy.ToString()))
                        users.ModifiedBy = user.ModifiedBy;
                    _unitOfWork.Commit();
                    return true;
                }
            }
            catch (Exception ex) { return false; }
        }

        public bool DeleteUser(int id)
        {
            try
            {
                Users user = _unitOfWork.UserRepository.GetSingle(id);
                if (user == null)
                    return false;
                else
                {
                    _unitOfWork.UserRepository.Delete(user);
                    _unitOfWork.Group_UserRepository.DeleteWhere(e => e.UserId == id);
                    _unitOfWork.Commit();
                    return true;
                }
            }
            catch (Exception ex) { return false; }
        }

        public IEnumerable<Users> GetAllUser()
        {
            IEnumerable<Users> _User = Enumerable.Empty<Users>();
            try
            {
                _User = _unitOfWork.UserRepository.GetAll();
                return _User;
            }
            catch (Exception ex) { return _User; }

        }

        public IEnumerable<Users> GetUserById(int Id)
        {
            IEnumerable<Users> User = Enumerable.Empty<Users>();
            try
            {
                User = _unitOfWork.UserRepository.FindBy(x => x.Id == Id);
                return User;
            }
            catch (Exception ex) { return User; }
        }


        public Users OnLogin(string emailID, string password)
        {
            Users user = new Users();
            try
            {
                user = _unitOfWork.UserRepository.GetCredentials(x => x.EmailID == emailID && x.Password == password);
                return user;
            }
            catch (Exception ex) { return user; }
        }


    }
}
