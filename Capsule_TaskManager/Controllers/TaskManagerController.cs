using Capsule_TaskManager.Models.ParentTask;
using Capsule_TaskManager.Models.Task;
using Capsule_TaskManagerBL;
using Capsule_TaskManagerDL.Model;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Capsule_TaskManager.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TaskManagerController : ApiController
    {
        #region Public Declaration

        TaskManagerBL objTaskManagerBL = null;

        #endregion

        #region GetParentTask
        /// <summary>
        /// To get Parent task details
        /// </summary>
        /// <returns></returns>
        [Route("api/TaskManager/GetParentTaskList")]
        [HttpGet]       
        public List<ParentTaskModel> GetParentTaskList()
        {
            objTaskManagerBL = new TaskManagerBL();
            var parentTaskList = objTaskManagerBL.GetParentTaskList();

            return parentTaskList;
        }
        #endregion

        #region GetTaskDetails
        /// <summary>
        /// Method for getting the task details from BL and send back to HTML
        /// </summary>
        /// <returns></returns>
        [Route("api/TaskManager/GetTaskDetailList")]
        [HttpGet]       
        public List<TaskModel> GetTaskDetailList()
        {
            objTaskManagerBL = new TaskManagerBL();
            var vGetTaskDetails = objTaskManagerBL.GetTaskDetailList();
            return vGetTaskDetails;
        }
        #endregion

        #region Submit Task Detail
        /// <summary>
        /// Insert the Task details which user entered
        /// </summary>
        /// <param name="objGET_TASK_DETAILS_Result"></param>
        /// <returns></returns>
        [Route("api/TaskManager/SubmitTaskDetail")]
        [HttpPost]
        public bool SubmitTaskDetail(TaskModel taskModel)
        {
            objTaskManagerBL = new TaskManagerBL();

            var vInsertTaskDetails = objTaskManagerBL.SubmitTaskDetail(taskModel);
            return vInsertTaskDetails;
        }
        #endregion

        #region UpdateEndTask
        /// <summary>
        /// Update the End task 
        /// </summary>
        /// <param name="objGET_TASK_DETAILS_Result"></param>
        /// <returns></returns>
        [Route("api/TaskManager/UpdateEndTask")]
        [HttpPost]
        public bool UpdateEndTask(TaskModel taskModel)
        {
            objTaskManagerBL = new TaskManagerBL();
            var vUpdateEndTask = objTaskManagerBL.UpdateEndTask(taskModel);

            return vUpdateEndTask;
        }
        #endregion 


    }
}
