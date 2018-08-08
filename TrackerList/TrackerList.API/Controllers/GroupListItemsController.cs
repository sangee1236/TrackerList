using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrackerList.Model;
using TrackerList.Data.UnitOfWork;
using TrackerList.Data.Model;

namespace TrackerList.API.Controllers
{
    [Route("api/[controller]")]
    public class GroupListItemsController : Controller
    {
        private readonly IGroupListItemsModel GroupListItemsModal;

        #region Constructor
        public GroupListItemsController(IGroupListItemsModel _GroupListItemsModal)
        {
            GroupListItemsModal = _GroupListItemsModal;
        }
        #endregion



        #region Adding GroupListItems

        /// <summary>
        /// CreatedBy :sangee
        /// CreatedOn :07 Aug 2018
        /// Description: To Add a new GroupListItems 
        /// </summary>
        /// <param name="GroupListItems"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("addGroupListItems")]
        public IActionResult AddGroupListItems(GroupListItems groupListItems)
        {
            try
            {
                bool status = GroupListItemsModal.AddGroupListItems(groupListItems);
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
        /// Description :To update a existing GroupListItems details
        /// </summary>
        /// <param name="Group"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("updateGroupListItems")]
        public IActionResult UpdateGroupListItems([FromBody]GroupListItems groupListItems)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                bool status = GroupListItemsModal.UpdateGroupListItems(groupListItems);
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
        /// Description :To delete a listItem under a group 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteGroupListItems")]
        public IActionResult DeleteGroupListItems(int id)
        {
            try
            {
                bool status = GroupListItemsModal.DeleteGroupListItems(id);
                if (status)
                    return Ok();
                else
                    return NotFound();
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
        #endregion

        /// <summary>
        /// CreatedBy :sangee
        /// CreatedOn :07 Aug 2018
        /// Description :To Get a listItem under a group
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetGroupListItems")]
        public IActionResult GetGroupListItems(int groupId)
        {

            IEnumerable<GroupListItems> GroupListItems = Enumerable.Empty<GroupListItems>();
            try
            {
                GroupListItems = GroupListItemsModal.GetGroupListItems(groupId);
                return Ok(GroupListItems);
            }
            catch (Exception ex) { return BadRequest(ex); }

        }
    }
}