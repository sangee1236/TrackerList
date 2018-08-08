using System;
using System.Collections.Generic;
using System.Text;

namespace TrackerList.Model
{
    public class Messages :DefaultData,IEntityBase
    {
        public string Text { get; set; }
        public int GroupListItemId { get; set; }
        public GroupListItems GroupListItems { get; set; }
    }
}
