using TrackerList.Data.Repositories;
using TrackerList.Data.Abstract;

namespace TrackerList.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TrackerListContext _context;

        public UnitOfWork(TrackerListContext context)
        {
            _context = context;
        }

        public IUserRepository UserRepository => new UserRepository(_context);

        public IGroupRepository GroupRepository => new GroupRepository(_context);

        public IGroupListItemsRepository GroupListItemsRepository => new GroupListItemsRepository(_context);

        public IGroup_UserRepository Group_UserRepository => new Group_UserRepository(_context);

        public IMessagesRepository MessagesRepository => new MessageRespository(_context);

    public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
