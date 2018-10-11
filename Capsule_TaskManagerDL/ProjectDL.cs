using Capsule_TaskManager.Models.Project;
using Capsule_TaskManagerDL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capsule_TaskManagerDL
{
    public class ProjectDL
    {
        #region GetProjectDetails
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<ProjectModel> GetProjectDetails()
        {

            List<ProjectModel> projectModelList = null;

            using (ProjectManagerEntities db = new ProjectManagerEntities())
            {
                var projectList = db.Projects.ToList();

                if (projectList != null)
                {
                    projectModelList = new List<ProjectModel>();

                    foreach (var item in projectList)
                    {
                        projectModelList.Add(new ProjectModel()
                        {
                            Project_ID = item.Project_ID,
                            Project = item.Project1,
                            Start_Date = item.Start_Date,
                            End_Date = item.End_Date,
                            Priority = item.Priority,
                            Manager_ID = item.Manager_ID,
                            ProjStatus = item.Is_Active != 0 ? "Completed" : "Pending",
                            Is_Active = item.Is_Active,
                            TaskCount = item.Tasks.Count(),
                            Active_Progress = Convert.ToString((item.Priority * 100) / 30)
                        });
                    }

                }

                return projectModelList;
            }

        }
        #endregion

        #region Insert/Update Project Detail
        /// <summary>
        /// Submit Project Model
        /// </summary>
        /// <param name="projectModel"></param>
        /// <returns>Whether Submitted Or Not</returns>

        public bool SubmitProjectDetail(ProjectModel projectModel)
        {
            var isSubmitted = false;

            // Update
            if (projectModel.Project_ID.GetValueOrDefault(0) > 0)
            {
                isSubmitted = UpdateProjectDetail(projectModel);
            }
            else
            {
                isSubmitted = InsertProjectDetail(projectModel);
            }

            return isSubmitted;
        }

        private bool UpdateProjectDetail(ProjectModel projectModel)
        {
            var isSubmitted = false;

            using (ProjectManagerEntities objEntities = new ProjectManagerEntities())
            {
                var existingTask = objEntities.Projects.FirstOrDefault(p => p.Project_ID == projectModel.Project_ID);

                if (existingTask != null)
                {
                    existingTask.Project1 = projectModel.Project;
                    existingTask.Priority = projectModel.Priority;
                    existingTask.Start_Date = projectModel.Start_Date;
                    existingTask.End_Date = projectModel.End_Date;
                    existingTask.Manager_ID = projectModel.Manager_ID;
                    existingTask.Is_Active = 1;
                }

                var updatedRecord = objEntities.SaveChanges();
                isSubmitted = updatedRecord > 0;
            }

            return isSubmitted;
        }

        private bool InsertProjectDetail(ProjectModel projectModel)
        {
            var isSubmitted = false;

            using (ProjectManagerEntities objEntities = new ProjectManagerEntities())
            {
                try
                {
                    Project objProject = new Project();

                    objProject.Project1 = projectModel.Project;
                    objProject.Priority = projectModel.Priority;
                    objProject.Start_Date = projectModel.Start_Date;
                    objProject.End_Date = projectModel.End_Date;
                    objProject.Manager_ID = projectModel.Manager_ID;
                    objProject.Is_Active = 1;

                    objEntities.Projects.Add(objProject);
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

        #region GetManagerDetails
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<ProjectModel> GetManagerDetails()
        {
            List<ProjectModel> projectModelList = null;

            using (ProjectManagerEntities db = new ProjectManagerEntities())
            {
                var projectList = db.Users.Select(o => new { o.Employee_ID }).Distinct().ToList();

                if (projectList != null)
                {
                    projectModelList = new List<ProjectModel>();

                    foreach (var item in projectList)
                    {
                        projectModelList.Add(new ProjectModel()
                        {
                            Manager_ID = item.Employee_ID
                        });
                    }

                }

                return projectModelList;
            }

        }
        #endregion

        #region GetProjectName
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<ProjectModel> GetProjectName()
        {
            List<ProjectModel> projectModelList = null;

            using (ProjectManagerEntities db = new ProjectManagerEntities())
            {
                var projectList = db.Projects.Select(o => new { o.Project_ID, o.Project1 }).Distinct().ToList();

                if (projectList != null)
                {
                    projectModelList = new List<ProjectModel>();

                    foreach (var item in projectList)
                    {
                        projectModelList.Add(new ProjectModel()
                        {
                            Project_ID = item.Project_ID,
                            Project = item.Project1,

                        });
                    }

                }

                return projectModelList;
            }

        }
        #endregion

        public bool SuspendProjectDetail(int projId)
        {
            var isSuspended = false;

            using (ProjectManagerEntities objEntities = new ProjectManagerEntities())
            {
                var existingproj = objEntities.Projects.FirstOrDefault(p => p.Project_ID == projId);

                if (existingproj != null)
                {
                    existingproj.Is_Active = 0;
                }

                var updatedRecord = objEntities.SaveChanges();
                isSuspended = updatedRecord > 0;
            }

            return isSuspended;
        }
    }
}
