using Capsule_TaskManager.Models.ParentTask;
using Capsule_TaskManager.Models.Task;
using Capsule_TaskManagerDL;
using Capsule_TaskManagerDL.Model;
using System;
using System.Collections.Generic;

namespace Capsule_TaskManagerBL
{
    public class TaskManagerBL
    {
        #region Public Declaration

        TaskManagerDL objTaskManagerDL = null;

        #endregion

        #region GetParentTask
        /// <summary>
        /// To get Parent task details from DL using EF
        /// </summary>
        /// <returns></returns>

        public List<ParentTaskModel> GetParentTaskList()
        {
            objTaskManagerDL = new TaskManagerDL();
            var parentTaskList = objTaskManagerDL.GetParentTaskList();

            return parentTaskList;
        }
        #endregion

        #region GetTaskDetails
        /// <summary>
        /// To get task details from DL using EF
        /// </summary>
        /// <returns></returns>

        public List<TaskModel> GetTaskDetailList()
        {
            objTaskManagerDL = new TaskManagerDL();
            var vGetTaskDetails = objTaskManagerDL.GetTaskDetailList();

            return vGetTaskDetails;
        }
        #endregion

        #region InsertTaskDetails
        ///// <summary>
        ///// Insert the task values which user entered to DB from DL using EF
        ///// </summary>
        ///// <param name="objGET_TASK_DETAILS_Result"></param>
        ///// <returns></returns>
        //public string InsertTaskDetails(GET_TASK_DETAILS_Result objGET_TASK_DETAILS_Result)
        //{
        //    objTaskManagerDL = new TaskManagerDL();
        //    var vInsertTaskDetails = objTaskManagerDL.InsertTaskDetails(objGET_TASK_DETAILS_Result);

        //    if (objGET_TASK_DETAILS_Result.Task_ID != 0)
        //        if (vInsertTaskDetails == "1")
        //        {
        //            vInsertTaskDetails = "2";
        //        }

        //    return vInsertTaskDetails;
        //}

        /// <summary>
        /// Insert the task values which user entered to DB from DL using EF
        /// </summary>
        /// <param name="objGET_TASK_DETAILS_Result"></param>
        /// <returns></returns>
        public bool SubmitTaskDetail(TaskModel taskModel)
        {
            objTaskManagerDL = new TaskManagerDL();
            var isSubmitted = objTaskManagerDL.SubmitTaskDetail(taskModel);
            return isSubmitted;
        }
        #endregion

        #region UpdateEndTask
       /// <summary>
       /// 
       /// </summary>
       /// <param name="taskModel"></param>
       /// <returns></returns>
        public bool UpdateEndTask(TaskModel taskModel)
        {
            objTaskManagerDL = new TaskManagerDL();
            var isUpdated = objTaskManagerDL.UpdateEndTask(taskModel);

            return isUpdated;
        }
        #endregion 

    }
}
