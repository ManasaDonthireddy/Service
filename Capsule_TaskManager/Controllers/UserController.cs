using Capsule_TaskManager.Models.User;
using Capsule_TaskManagerBL;
using Capsule_TaskManagerDL.Model;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Capsule_TaskManager.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        #region Public Declaration

        UserBL objUserBL = null;

        #endregion

        #region GetUserDetails
        /// <summary>
        /// To get User details
        /// </summary>
        /// <returns></returns>
        [Route("api/User/GetUserDetails")]
        [HttpGet]
        public List<UserModel> GetUserDetails()
        {
            objUserBL = new UserBL();
            var userList = objUserBL.GetUserDetails();

            return userList;
        }
        #endregion

        #region SubmitUserDetail
        /// <summary>
        /// Insert the User details which user entered
        /// </summary>
        /// <param name="objGET_User_DETAILS_Result"></param>
        /// <returns></returns>
        [Route("api/User/SubmitUserDetail")]
        [HttpPost]
        public bool SubmitUserDetail(UserModel userModel)
        {
            objUserBL = new UserBL();
            var vInsertUserDetails = objUserBL.SubmitUserDetail(userModel);
            return vInsertUserDetails;
        }
        #endregion

        #region DeleteUserDetail

        /// <summary>
        /// Insert the User details which user entered
        /// </summary>
        /// <param name="objGET_User_DETAILS_Result"></param>
        /// <returns></returns>
        [Route("api/User/DeleteUserDetail")]
        [HttpPost]
        public bool DeleteUserDetail(UserModel userModel)
        {
            objUserBL = new UserBL();
            var vInsertUserDetails = objUserBL.DeleteUserDetail(userModel.User_ID.GetValueOrDefault(0));
            return vInsertUserDetails;
        }

#endregion
    }
}
