using Capsule_TaskManager.Models.ParentTask;
using Capsule_TaskManager.Models.Task;
using Capsule_TaskManagerDL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capsule_TaskManagerDL
{
    public class TaskManagerDL
    {
        #region GetParentTask List
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<ParentTaskModel> GetParentTaskList()
        {
            List<ParentTaskModel> parenttaskModelList = null;
            using (ProjectManagerEntities db = new ProjectManagerEntities())
            {
                var parentTaskList = db.Parent_Task.ToList();

                if (parentTaskList != null)
                {
                    parenttaskModelList = new List<ParentTaskModel>();

                    foreach (var item in parentTaskList)
                    {
                        parenttaskModelList.Add(new ParentTaskModel()
                        {
                            Parent_ID = item.Parent_ID,
                            Parent_Task = item.Parent_Task1
                        });
                    }

                }

                return parenttaskModelList;
            }
        }
        #endregion

        #region GetTaskDetails
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<TaskModel> GetTaskDetailList()
        {
            List<TaskModel> taskModelList = null;

            using (ProjectManagerEntities db = new ProjectManagerEntities())
            {
                var taskList = db.Tasks.ToList();

                if (taskList != null)
                {
                    taskModelList = new List<TaskModel>();

                    foreach (var item in taskList)
                    {
                        taskModelList.Add(new TaskModel()
                        {
                            Task_ID = item.Task_ID,
                            Parent_ID = item.Parent_ID,
                            Parent_Task = item.Parent_Task != null ? item.Parent_Task.Parent_Task1 : "",
                            Task = item.Task1,
                            Start_Date = item.Start_Date,
                            End_Date = item.End_Date,
                            Priority = item.Priority,
                            Project_ID = item.Project_ID,
                            Status = item.Status,
                            User_ID = item.User_ID,
                            Project_Name = item.Project != null ? item.Project.Project1 : "",
                            Is_Active = item.Is_Active
                        });
                    }

                }

                return taskModelList;
            }

        }
        #endregion

        #region Insert/Update Task Detail
        /// <summary>
        /// Submit Task Model
        /// </summary>
        /// <param name="taskModel"></param>
        /// <returns>Whether Submitted Or Not</returns>

        public bool SubmitTaskDetail(TaskModel taskModel)
        {
            var isSubmitted = false;

            // Update
            if (taskModel.Task_ID.GetValueOrDefault(0) > 0)
            {
                isSubmitted = UpdateTaskDetail(taskModel);
            }
            else
            {
                isSubmitted = InsertTaskDetail(taskModel);
            }

            return isSubmitted;
        }

        private bool UpdateTaskDetail(TaskModel taskModel)
        {
            var isSubmitted = false;

            using (ProjectManagerEntities objEntities = new ProjectManagerEntities())
            {
                var existingTask = objEntities.Tasks.FirstOrDefault(p => p.Task_ID == taskModel.Task_ID);

                if (existingTask != null)
                {
                    existingTask.Task1 = taskModel.Task;
                    existingTask.Project_ID = taskModel.Project_ID.Value;
                    existingTask.Parent_ID = taskModel.Parent_ID;
                    existingTask.Priority = taskModel.Priority;
                    existingTask.Start_Date = taskModel.Start_Date;
                    existingTask.End_Date = taskModel.End_Date;
                    existingTask.User_ID = taskModel.User_ID;
                }

                var updatedRecord = objEntities.SaveChanges();
                isSubmitted = updatedRecord > 0;
            }

            return isSubmitted;
        }

        private bool InsertTaskDetail(TaskModel taskModel)
        {
            var isSubmitted = false;

            using (ProjectManagerEntities objEntities = new ProjectManagerEntities())
            {
                try
                {
                    Task objTask = new Task();
                    objTask.Task1 = taskModel.Task;
                    objTask.Project_ID = taskModel.Project_ID.Value;
                    objTask.Parent_ID = taskModel.Parent_ID;
                    objTask.Priority = taskModel.Priority;
                    objTask.Start_Date = taskModel.Start_Date;
                    objTask.End_Date = taskModel.End_Date;
                    objTask.User_ID = taskModel.User_ID;
                    objTask.Is_Active = 1;

                    objEntities.Tasks.Add(objTask);
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

        #region UpdateEndTask
        /// <summary>
        /// 
        /// </summary>
        /// <param name="taskModel"></param>
        /// <returns></returns>
        public bool UpdateEndTask(TaskModel taskModel)
        {
            var isSubmitted = false;

            using (ProjectManagerEntities objEntities = new ProjectManagerEntities())
            {
                var existingTask = objEntities.Tasks.FirstOrDefault(p => p.Task_ID == taskModel.Task_ID);

                if (existingTask != null)
                {
                    existingTask.End_Date = taskModel.End_Date;
                    existingTask.Is_Active = 0;
                }

                var updatedRecord = objEntities.SaveChanges();
                isSubmitted = updatedRecord > 0;
            }

            return isSubmitted;
        }
        #endregion 
    }
}
