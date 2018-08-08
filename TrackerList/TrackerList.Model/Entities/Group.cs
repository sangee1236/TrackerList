using System;
using System.Collections.Generic;
using System.Text;

namespace TrackerList.Model
{ 
    public class Group : DefaultData ,IEntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<bool> Status { get; set; }
    }
}
