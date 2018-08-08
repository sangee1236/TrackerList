using TrackerList.Model;

namespace TrackerList.Data.Abstract
{
    public interface IUserRepository : IEntityBaseRepository<Users> { }
    public interface IGroupRepository : IEntityBaseRepository<Group> { }
    public interface IGroupListItemsRepository : IEntityBaseRepository<GroupListItems> { }
    public interface IGroup_UserRepository : IEntityBaseRepository<Group_User> { }
    public interface IMessagesRepository : IEntityBaseRepository<Messages> { }
}
