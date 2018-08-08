using TrackerList.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using TrackerList.Data.UnitOfWork;

namespace TrackerList.Data.Model
{
    public class GroupModel : IGroupModal
    {
        #region Private declartions
        private IUnitOfWork _unitOfWork;
        #endregion

        #region constructor
        public GroupModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Crud Group 

        /// <summary>
        /// CreatedBy :sangee
        /// CreatedOn :07 Aug,2018
        /// Description: To Add a new Group
        /// </summary>
        /// <param name="Group"></param>
        /// <returns></returns>
        public bool AddGroup(Group group)
        {
            try
            {
                _unitOfWork.GroupRepository.Add(group);
                _unitOfWork.Commit();
                if (group.Id > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex) { return false; }
        }

        /// <summary>
        /// CreatedBy :sangee
        /// CreatedOn :07 Aug,2018
        /// Description :To update a existing Group details
        /// </summary>
        /// <param name="Group"></param>
        /// <returns></returns>
        public bool UpdateGroup(Group group)
        {
            try
            {
                Group _GroupDb = _unitOfWork.GroupRepository.GetSingle(group.Id);

                if (_GroupDb == null)
                    return false;
                else
                {
                    if (!string.IsNullOrEmpty(group.Name))
                        _GroupDb.Name = group.Name;
                    if (!string.IsNullOrEmpty(group.Status.ToString()))
                        _GroupDb.Status = group.Status;
                    if (!string.IsNullOrEmpty(group.CreatedBy.ToString()))
                        _GroupDb.CreatedBy = group.CreatedBy;
                    if (!string.IsNullOrEmpty(group.CreatedOn.ToString()))
                        _GroupDb.CreatedOn = group.CreatedOn;
                    if (!string.IsNullOrEmpty(group.ModifiedOn.ToString()))
                        _GroupDb.ModifiedOn = group.ModifiedOn;
                    if (!string.IsNullOrEmpty(group.ModifiedBy.ToString()))
                        _GroupDb.ModifiedBy = group.ModifiedBy;
                    _unitOfWork.Commit();
                    return true;
                }
            }
            catch (Exception ex) { return false; }
        }

        /// <summary>
        /// CreatedBy :sangee
        /// CreatedOn : 07 Aug 2018
        /// Description :To delete a existing Group 
        /// </summary>
        /// <param name="GroupId"></param>
        /// <returns></returns>
        public bool DeleteGroup(int groupId)
        {
            try
            {
                Group _GroupDb = _unitOfWork.GroupRepository.GetSingle(groupId);
                if (_GroupDb == null)
                    return false;
                else
                {
                    _unitOfWork.GroupRepository.Delete(_GroupDb);
                    _unitOfWork.Group_UserRepository.DeleteWhere(e => e.GroupId == groupId);
                    _unitOfWork.Commit();
                    return true;
                }
            }
            catch (Exception ex) { return false; }
        }
        #endregion

        #region Get Group
        /// <summary>
        /// CreatedBy : Sangee
        /// CreatedOn :  07 Aug 2018
        /// Description: To get entire Group List
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Group> GetGroupList()
        {
            IEnumerable<Group> Group = Enumerable.Empty<Group>();
            try
            {
                Group = _unitOfWork.GroupRepository.GetAll();
                return Group;
            }
            catch (Exception ex) { return Group; }
        }

        /// <summary>
        /// CreatedBy : sangee
        /// CreatedOn :  07 Aug 2018
        /// Description: get Group based on User
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IEnumerable<Group> GetGroupList(int userId)
        {
            IEnumerable<Group> GroupList = Enumerable.Empty<Group>();
            try
            {
                GroupList = from e in _unitOfWork.Group_UserRepository.FindBy(x => x.UserId == userId)
                            join d in _unitOfWork.GroupRepository.FindBy(y => y.Status == true) on e.GroupId equals d.Id
                            select new Group
                            {
                                Id = e.GroupId,
                                Name = d.Name
                            };
                return GroupList;
            }
            catch (Exception ex) { return GroupList; }
        }

        /// <summary>
        /// CreatedBy : sangee
        /// CreatedOn :  07 Aug 2018
        /// Description: get UserList based on Group
        /// </summary>
        /// <param name="GroupId"></param>
        /// <returns></returns>
        public IEnumerable<Users> GetUserListFromGroup(int groupId)
        {
            IEnumerable<Users> UserList = Enumerable.Empty<Users>();
            try
            {
                UserList = from e in _unitOfWork.Group_UserRepository.FindBy(x => x.GroupId == groupId)
                           join d in _unitOfWork.UserRepository.FindBy(x => x.Status == true) on e.UserId equals d.Id
                           select new Users
                           {
                               Id = d.Id,
                               Name = d.Name,
                               EmailID = d.EmailID,

                           };
                return UserList;
            }
            catch (Exception Ex) { return UserList; }
        }
        #endregion

        #region assign Group to User
        /// <summary>
        /// CreatedBy  : sangeee
        /// CreatedOn  :  07 Aug 2018
        /// Description : Add new User to Group 
        /// </summary>
        /// <param name="group_User"></param>
        /// <returns></returns>
        public bool AddUserToGroup(Group_User group_User)
        {
            try
            {
                Group_User _resourceExistDb = _unitOfWork.Group_UserRepository.GetSingle(x => x.GroupId == group_User.GroupId && x.UserId == group_User.UserId);
                if (_resourceExistDb == null)
                    _unitOfWork.Group_UserRepository.Add(group_User);
                else
                    _unitOfWork.Group_UserRepository.Update(group_User);
                _unitOfWork.Commit();
                return true;
            }
            catch (Exception ex) { return false; }
        }

        /// <summary>
        /// Created By  : sangeee
        /// Created On  :  07 Aug 2018
        /// Description : Delete an User from a Group 
        /// </summary>
        /// <param name="group_User"></param>
        /// <returns></returns>
        public bool DeleteUserFromGroup(Group_User group_User)
        {
            try
            {
                Group_User _resourceExistDb = _unitOfWork.Group_UserRepository.GetSingle(x => x.GroupId == group_User.GroupId && x.UserId == group_User.UserId);
                if (_resourceExistDb == null)
                    return false;
                _unitOfWork.Group_UserRepository.DeleteWhere(x => x.UserId == group_User.UserId && x.GroupId == group_User.GroupId);
                _unitOfWork.Commit();
                return true;
            }
            catch (Exception ex) { return false; }
        }
        #endregion
    }
}
