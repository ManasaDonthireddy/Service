using Capsule_TaskManager.Models.User;
using Capsule_TaskManagerDL;
using Capsule_TaskManagerDL.Model;
using System.Collections.Generic;

namespace Capsule_TaskManagerBL
{
    public class UserBL
    {
        #region Public Declaration

        UserDL objUserDL = null;

        #endregion

        #region GetUserDetails
        /// <summary>
        /// To get User details from DL using EF
        /// </summary>
        /// <returns></returns>

        public List<UserModel> GetUserDetails()
        {
            objUserDL = new UserDL();
            var vGetUserDetails = objUserDL.GetUserDetails();

            return vGetUserDetails;
        }
        #endregion


        #region InsertUserDetails
        /// <summary>
        /// Insert the User values which user entered to DB from DL using EF
        /// </summary>
        /// <param name="objGET_User_DETAILS_Result"></param>
        /// <returns></returns>
        public bool SubmitUserDetail(UserModel userModel)
        {
            objUserDL = new UserDL();
            var isSubmitted = objUserDL.SubmitUserDetail(userModel);
            return isSubmitted;
        }
        #endregion

        public bool DeleteUserDetail(int userId)
        {
            objUserDL = new UserDL();
            var isSubmitted = objUserDL.DeleteUserDetail(userId);
            return isSubmitted;
        }
    }
}
