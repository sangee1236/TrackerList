using System;
using System.Collections.Generic;
using System.Text;
using TrackerList.Model;

namespace TrackerList.Data.Model
{
    public interface IGroupModal
    {
        bool AddGroup(Group Group);
        bool UpdateGroup(Group Group);
        bool DeleteGroup(int GroupId);
        IEnumerable<Group> GetGroupList();
        IEnumerable<Group> GetGroupList(int UserId);
        IEnumerable<Users> GetUserListFromGroup(int GroupId);
        bool AddUserToGroup(Group_User group_User);
        bool DeleteUserFromGroup(Group_User group_User);
    }
}
