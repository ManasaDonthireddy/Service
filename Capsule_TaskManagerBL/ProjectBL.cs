using Capsule_TaskManager.Models.Project;
using Capsule_TaskManagerDL;
using Capsule_TaskManagerDL.Model;
using System.Collections.Generic;

namespace Capsule_TaskManagerBL
{
    public class ProjectBL
    {

        #region Public Declaration

        ProjectDL objProjectDL = null;

        #endregion

        #region GetProjectDetails
        /// <summary>
        /// To get project details from DL using EF
        /// </summary>
        /// <returns></returns>

        public List<ProjectModel> GetProjectDetails()
        {
            objProjectDL = new ProjectDL();
            var vGetProjectDetails = objProjectDL.GetProjectDetails();

            return vGetProjectDetails;
        }
        #endregion
        
        #region InsertProjectDetails
        /// <summary>
        /// Insert the project values which user entered to DB from DL using EF
        /// </summary>
        /// <param name="objGET_PROJECT_DETAILS_Result"></param>
        /// <returns></returns>
        public bool SubmitProjectDetail(ProjectModel projectModel)
        {
            objProjectDL = new ProjectDL();
            var isSubmitted = objProjectDL.SubmitProjectDetail(projectModel);
            return isSubmitted;
        }
        #endregion

        #region GetManagerDetails
        /// <summary>
        /// To get manager details from DL using EF
        /// </summary>
        /// <returns></returns>

        public List<ProjectModel> GetManagerDetails()
        {
            objProjectDL = new ProjectDL();
            var vGetManagerDetails = objProjectDL.GetManagerDetails();

            return vGetManagerDetails;
        }
        #endregion

        #region GetProjectName
        /// <summary>
        /// To get project name from DL using EF
        /// </summary>
        /// <returns></returns>

        public List<ProjectModel> GetProjectName()
        {
            objProjectDL = new ProjectDL();
            var vGetProjectName = objProjectDL.GetProjectName();

            return vGetProjectName;
        }
        #endregion

        #region SuspendProjectDetail
       /// <summary>
       /// 
       /// </summary>
       /// <param name="projId"></param>
       /// <returns></returns>
        public bool SuspendProjectDetail(int projId)
        {
            objProjectDL = new ProjectDL();
            var isSuspend = objProjectDL.SuspendProjectDetail(projId);
            return isSuspend;
        }
        #endregion
    }
}
