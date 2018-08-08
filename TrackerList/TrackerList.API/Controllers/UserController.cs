using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TrackerList.Data.Model;
using TrackerList.Model;

namespace TrackerList.API.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {

        #region Private declartions
        private IUserModel UserModal;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="resourceRepository"></param>
        public UserController(IUserModel _IUserModal)
        {
            UserModal = _IUserModal;
        }
        #endregion

        #region CRUD Action methods

        /// <summary>
        /// Get all the resouces
        /// </summary>
        /// <returns></returns>'
        [HttpGet]
        [Route("GetAllUsers")]
        public IActionResult GetAllUser()
        {
            IEnumerable<Users> _User = UserModal.GetAllUser();
            return Ok(_User);
        }


        /// <summary>
        /// Get resource by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetUserById")]
        public IActionResult GetUser(int id)
        {
            try
            {
                IEnumerable<Users> user = UserModal.GetUserById(id);
                if (user == null)
                    return NotFound();
                else
                    return Ok(user);
            }
            catch (Exception ex) { return NotFound(ex); }
        }

        #region Adding User

        /// <summary>
        /// CreatedBy :sangee
        /// CreatedOn :07 Aug 2018
        /// Description: To Add a new User
        /// </summary>
        /// <param name="GroupName"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("addUser")]
        public IActionResult AddUser(Users user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            bool status = UserModal.AddUser(user);
            if (status)
                return Ok();
            else
                return NotFound();
        }

        /// <summary>
        /// CreatedBy :sangee
        /// CreatedOn :07 Aug 2018
        /// Description :To update a existing User details
        /// </summary>
        /// <param name="Group"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("updateUser")]
        public IActionResult UpdateUser([FromBody]Users user)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                bool status = UserModal.UpdateUser(user);
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
        /// Description :To delete a existing User 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("deleteUser")]
        public IActionResult DeleteGroup(int id)
        {
            try
            {
                bool status = UserModal.DeleteUser(id);
                if (status)
                    return Ok();
                else
                    return NotFound();
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
        #endregion

        #region Authentication
        [HttpGet("Login")]
        //[Route("LogCreds")]
        public IActionResult OnLogin(string emailID, string password)
        {
            Users user = UserModal.OnLogin(emailID, password);
            if (user != null)
                return Ok(user);
            else
                return NotFound();
        }
        #endregion

        #endregion
    }
}