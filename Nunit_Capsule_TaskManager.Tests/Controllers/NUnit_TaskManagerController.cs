using Capsule_TaskManager.Controllers;
using Capsule_TaskManager.Models.Task;
using Capsule_TaskManagerDL.Model;
using NUnit.Framework;
using System;
using System.Linq;

namespace NUnit_TaskManagerController
{
    [TestFixture]
    public class NUnit_TaskManagerController
    {
        #region Public Declaration

        TaskManagerController objTaskManagerController = new TaskManagerController();
        GET_TASK_DETAILS_Result objGET_TASK_DETAILS_Result = null;

        #endregion

        #region GetParentTask
        /// <summary>
        /// To get Parent task details
        /// </summary>
        /// <returns></returns>
        [Test]
        public void GetParentTask()
        {
            var vlsit = objTaskManagerController.GetParentTaskList();

            Assert.IsTrue(vlsit != null);
        }
        #endregion

        #region GetTaskDetails
        /// <summary>
        /// Method for getting the task details from BL and send back to HTML
        /// </summary>
        /// <returns></returns>
        [Test]
        public void GetTaskDetails()
        {
            var vlsit = objTaskManagerController.GetTaskDetailList();

            Assert.IsTrue(vlsit != null);
        }
        #endregion

        #region Submit Task Detail

        [Test, Order(1)]
        public void InsertTaskDetail()
        {
            TaskModel taskModel = new TaskModel();
            taskModel.Task_ID = 0;
            taskModel.Parent_ID = 1;
            taskModel.Task = "Analysis";
            taskModel.Start_Date = DateTime.Now;
            taskModel.End_Date = null;
            taskModel.Priority = 4;
            taskModel.Status = 1;
            taskModel.Project_ID = 1001;


            TaskManagerController objController = new TaskManagerController();
            var isInserted = objController.SubmitTaskDetail(taskModel);
            Assert.IsTrue(isInserted);
        }

        [Test, Order(2)]
        public void UpdateTaskDetail()
        {
            TaskModel taskModel = new TaskModel();
            taskModel.Task_ID = 1;
            taskModel.Parent_ID = 1;
            taskModel.Task = "Coding";
            taskModel.Start_Date = DateTime.Now;
            taskModel.End_Date = null;
            taskModel.Priority = 4;
            taskModel.Status = 1;
            taskModel.Project_ID = 1001;


            TaskManagerController objController = new TaskManagerController();
            var isUpdated = objController.SubmitTaskDetail(taskModel);
            Assert.IsTrue(isUpdated);
        }
        #endregion

        #region UpdateEndTask
        /// <summary>
        /// Update the End task 
        /// </summary>
        /// <param name="objGET_TASK_DETAILS_Result"></param>
        /// <returns></returns>
        [Test, Order(3)]
        public void UpdateEndTask()
        {
            TaskModel taskModel = new TaskModel();
            taskModel.Task_ID = 1;
            taskModel.End_Date = DateTime.Now;

            var isUpdated = objTaskManagerController.UpdateEndTask(taskModel);
            Assert.IsTrue(isUpdated);
        }
        #endregion 
    }
}
