using System.Collections.Generic;
using TrackerList.Model;

namespace TrackerList.Data.Model
{
    public interface IGroupListItemsModel
    {
        bool AddGroupListItems(GroupListItems groupListItems);
        bool UpdateGroupListItems(GroupListItems groupListItems);
        bool DeleteGroupListItems(int id);
        IEnumerable<GroupListItems> GetGroupListItems(int groupId);
    }
}
