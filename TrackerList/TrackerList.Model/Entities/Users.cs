using System;

namespace TrackerList.Model
{
    public class Users : DefaultData, IEntityBase
    {
        public string Name { get; set; }
        public string EmailID { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime JoiningDate { get; set; }
        public string Avatar { get; set; }
        public bool Status { get; set; }
        public UserType UserTypeId { get; set; }
    }
}
