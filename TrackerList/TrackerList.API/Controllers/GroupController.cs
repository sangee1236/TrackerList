using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrackerList.Model;
using TrackerList.Data.Model;

namespace TrackerList.API.Controllers
{
    [Route("api/[controller]")]
    public class GroupController : Controller
    {
        #region Private declartions
        private readonly IGroupModal GroupModel;
        #endregion

        #region constructor
        public GroupController(IGroupModal _GroupModal)
        {
            GroupModel = _GroupModal;
        }
        #endregion

        #region Adding Group

        /// <summary>
        /// CreatedBy :sangee
        /// CreatedOn :07 Aug 2018
        /// Description: To Add a new Group 
        /// </summary>
        /// <param name="GroupName"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("addGroup")]
        public IActionResult AddGroup(string GroupName)
        {
            try
            {
                if (string.IsNullOrEmpty(GroupName))
                    return BadRequest();
                else
                {
                    Group Group = new Group { Name = GroupName, Status = true };
                    bool status = GroupModel.AddGroup(Group);
                    if (status)
                        return Ok();
                    else
                        return NotFound();
                }
            }
            catch (Exception ex) { return BadRequest(ex); }
        }

        /// <summary>
        /// CreatedBy :sangee
        /// CreatedOn :07 Aug 2018
        /// Description :To update a existing group details
        /// </summary>
        /// <param name="Group"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("updateGroup")]
        public IActionResult UpdateGroup([FromBody]Group group)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                bool status = GroupModel.UpdateGroup(group);
                if (status)
                    return Ok();
                else
                    return NotFound();
            }
            catch (Exception ex) { return BadRequest(ex); }
        }

        /// <summary>
        /// CreatedBy :sangee
        /// CreatedOn :07 Aug 2018
        /// Description :To delete a existing project 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("deleteGroup")]
        public IActionResult DeleteGroup(int groupId)
        {
            try
            {
                bool status = GroupModel.DeleteGroup(groupId);
                if (status)
                    return Ok();
                else
                    return NotFound();
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
        #endregion

        #region Get Group list
        /// <summary>
        /// Created By : Sangee
        /// Created On : 07 Aug 2018
        /// Description: To get All Group List
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("allGrouplist")]
        public IActionResult GetGroupList()
        {
            try
            {
                IEnumerable<Group> Group = GroupModel.GetGroupList();
                return Ok(Group);
            }
            catch (Exception ex) { return NotFound(ex); }
        }

        /// <summary>
        /// get Group based on User
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("grouplistbyid")]
        public IActionResult GetGroupList(int userId)
        {
            try
            {
                IEnumerable<Group> GroupList = GroupModel.GetGroupList(userId);
                if (GroupList == null)
                    return NotFound();
                else
                    return Ok(GroupList);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }

        #endregion

        #region assign project to resources
        /// <summary>
        ///  Add new User to a group
        /// </summary>
        /// <param name="group_User"></param>
        /// <returns></returns>

        [HttpPost]
        [Route("addgroupresource")]
        public IActionResult AddUserToGroup([FromBody]Group_User group_User)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                bool status = GroupModel.AddUserToGroup(group_User);
                if (status)
                    return Ok();
                else
                    return new NotFoundResult();
            }
            catch (Exception ex) { return NotFound(ex); }
        }

        /// <summary>
        /// Delete a Usere From a group
        /// </summary>
        /// <param name="group_User"></param>
        /// <returns></returns>

        [HttpPut]
        [Route("deleteprojectresource")]
        public IActionResult DeleteUserFromGroup([FromBody]Group_User group_User)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                bool status = GroupModel.DeleteUserFromGroup(group_User);
                if (status)
                    return Ok();
                else
                    return new NotFoundResult();
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
        #endregion
    }
}