using System;
using System.Collections.Generic;
using System.Text;

namespace TrackerList.Model
{
    public class Group_User : IEntityBase
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public int UserId { get; set; }
        public Group Group { get; set; }
        public Users User { get; set; }
    }
}
