using TrackerList.Data.Abstract;
using TrackerList.Model;

namespace TrackerList.Data.Repositories
{
    public class GroupRepository : EntityBaseRepository<Group>, IGroupRepository
    {
        public GroupRepository(TrackerListContext context) : base(context)
        {
        }
    }

    public class GroupListItemsRepository : EntityBaseRepository<GroupListItems>, IGroupListItemsRepository
    {
        public GroupListItemsRepository(TrackerListContext context) : base(context)
        {
        }
    }

    public class Group_UserRepository : EntityBaseRepository<Group_User>, IGroup_UserRepository
    {
        public Group_UserRepository(TrackerListContext context) : base(context)
        {
        }
    }

}
