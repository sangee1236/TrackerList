using System;
using System.Collections.Generic;
using System.Text;
using TrackerList.Model;

namespace TrackerList.Data.Model
{
    public interface IMessagesModel
    {
        bool AddMessages(TrackerList.Model.Messages message);
        bool UpdateMessages(TrackerList.Model.Messages message);
        bool DeleteMessages(int id);
        IEnumerable<TrackerList.Model.Messages> GetMessagesByListItem(int listItemId);
    }
}
