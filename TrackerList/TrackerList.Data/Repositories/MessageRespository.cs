using TrackerList.Data.Abstract;
using TrackerList.Model;

namespace TrackerList.Data.Repositories
{
   public class MessageRespository :EntityBaseRepository<Messages> , IMessagesRepository
    {
        public MessageRespository(TrackerListContext context): base(context)
        { }
    }
}
