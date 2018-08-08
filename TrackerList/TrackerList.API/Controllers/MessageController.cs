using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrackerList.Data.Model;
using TrackerList.Model;

namespace TrackerList.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Message")]
    public class MessageController : Controller
    {

        #region Private declartions
        private IMessagesModel messagesModel;
        #endregion

        #region Constructor
        public MessageController(IMessagesModel _messagesModel)
        {
            messagesModel = _messagesModel;
        }
        #endregion

        #region Adding User

        /// <summary>
        /// CreatedBy :sangee
        /// CreatedOn :07 Aug 2018
        /// Description: To Add a new message
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddMessages")]
        public IActionResult AddMessages(Messages message)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            bool status = messagesModel.AddMessages(message);
            if (status)
                return Ok();
            else
                return NotFound();
        }

        /// <summary>
        /// CreatedBy :sangee
        /// CreatedOn :07 Aug 2018
        /// Description :To update a existing message
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateMessages")]
        public IActionResult UpdateMessages([FromBody]Messages message)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                bool status = messagesModel.UpdateMessages(message);
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
        /// Description :To delete a existing message 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteMessages")]
        public IActionResult DeleteMessages(int id)
        {
            try
            {
                bool status = messagesModel.DeleteMessages(id);
                if (status)
                    return Ok();
                else
                    return NotFound();
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
        #endregion

        /// <summary>
        /// Get message by ListItemId
        /// </summary>
        /// <param name="listItemId"></param>
        /// <returns></returns>
        [HttpGet("{listItemId}", Name = "GetMessagesByListItem")]
        public IActionResult GetMessagesByListItem(int listItemId)
        {
            try
            {
                IEnumerable<Messages> message = messagesModel.GetMessagesByListItem(listItemId);
                if (message == null)
                    return NotFound();
                else
                    return Ok(message);
            }
            catch (Exception ex) { return NotFound(ex); }
        }
    }
}