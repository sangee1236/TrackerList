using System;
using System.Collections.Generic;
using System.Text;

namespace TrackerList.Model
{
    public class DefaultData
    {
        public int Id { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int ModifiedBy { get; set; }
    }
}
