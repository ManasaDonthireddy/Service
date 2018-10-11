using Capsule_TaskManager.Models.User;
using Capsule_TaskManagerDL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capsule_TaskManagerDL
{
    public class UserDL
    {
        #region GetUserDetails
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<UserModel> GetUserDetails()
        {
            List<UserModel> userModelList = null;
            using (ProjectManagerEntities db = new ProjectManagerEntities())
            {
                var userList = db.Users.ToList();

                if (userList != null)
                {
                    userModelList = new List<UserModel>();

                    foreach (var item in userList)
                    {
                        userModelList.Add(new UserModel()
                        {
                            User_ID = item.User_ID,
                            First_Name = item.First_Name,
                            Last_Name = item.Last_Name,
                            Employee_ID = item.Employee_ID
                        });
                    }
                }

                return userModelList;
            }
        }
        #endregion

        #region Insert/Update User Detail
       /// <summary>
       /// 
       /// </summary>
       /// <param name="taskModel"></param>
       /// <returns></returns>

        public bool SubmitUserDetail(UserModel userModel)
        {
            var isSubmitted = false;

            // Update
            if (userModel.User_ID.GetValueOrDefault(0) > 0)
            {
                isSubmitted = UpdateUserDetail(userModel);
            }
            else
            {
                isSubmitted = InsertUserDetail(userModel);
            }

            return isSubmitted;
        }

        private bool UpdateUserDetail(UserModel userModel)
        {
            var isSubmitted = false;

            using (ProjectManagerEntities objEntities = new ProjectManagerEntities())
            {
                var existingTask = objEntities.Users.FirstOrDefault(p => p.User_ID == userModel.User_ID);

                if (existingTask != null)
                {
                    existingTask.First_Name = userModel.First_Name;
                    existingTask.Last_Name = userModel.Last_Name;
                    existingTask.Employee_ID = userModel.Employee_ID;
                }

                var updatedRecord = objEntities.SaveChanges();
                isSubmitted = updatedRecord > 0;
            }

            return isSubmitted;
        }

        private bool InsertUserDetail(UserModel userModel)
        {
            var isSubmitted = false;

            using (ProjectManagerEntities objEntities = new ProjectManagerEntities())
            {
                try
                {
                    User objUser = new User();
                    objUser.First_Name = userModel.First_Name;
                    objUser.Last_Name = userModel.Last_Name;
                    objUser.Employee_ID = userModel.Employee_ID;

                    objEntities.Users.Add(objUser);

                    var insertedRecord = objEntities.SaveChanges();
                    isSubmitted = insertedRecord > 0;
                }
                catch (Exception ex)
                {
                    isSubmitted = false;
                }

            }

            return isSubmitted;
        }
        #endregion

        public bool DeleteUserDetail(int userId)
        {
            var isDeleted = false;

            using (ProjectManagerEntities objEntities = new ProjectManagerEntities())
            {
                var existingUser = objEntities.Users.FirstOrDefault(p => p.User_ID == userId);
                var existingUserTask = objEntities.Tasks.FirstOrDefault(p => p.User_ID == userId);

                if(existingUserTask !=null)
                {
                    objEntities.Tasks.Remove(existingUserTask);
                    var deletedRecord = objEntities.SaveChanges();
                    isDeleted = deletedRecord > 0;
                }

                if (existingUser != null)
                {
                    objEntities.Users.Remove(existingUser);
                    var deletedRecord = objEntities.SaveChanges();

                    isDeleted = deletedRecord > 0;
                }

                return isDeleted;
            }
        }
    }
}
