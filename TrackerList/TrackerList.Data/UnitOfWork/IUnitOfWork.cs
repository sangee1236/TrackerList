using TrackerList.Data.Abstract;

namespace TrackerList.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }

        IGroupRepository GroupRepository { get; }

        IGroupListItemsRepository GroupListItemsRepository { get; }

        IGroup_UserRepository Group_UserRepository { get; }

        IMessagesRepository MessagesRepository { get; }

        void Commit();
    }
}
