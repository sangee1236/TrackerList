
namespace TrackerList.Model
{
    public class GroupListItems : DefaultData, IEntityBase
    {
        public string Name { get; set; }
        public bool Status { get; set; }
        public string Description { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}
