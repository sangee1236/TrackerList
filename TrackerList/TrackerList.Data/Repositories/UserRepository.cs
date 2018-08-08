using TrackerList.Model;
using TrackerList.Data.Abstract;

namespace TrackerList.Data.Repositories
{
    public class UserRepository : EntityBaseRepository<Users>, IUserRepository
    {
        public UserRepository(TrackerListContext context)
            : base(context)
        { }
    }
}
