using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using Capsule_TaskManagerDL.Model;
using Capsule_TaskManagerBL;
using Capsule_TaskManager.Models.Project;

namespace Capsule_TaskManager.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProjectController : ApiController
    {

        #region Public Declaration

        ProjectBL objProjectBL = null;

        #endregion

        #region GetProjectDetails
        /// <summary>
        /// To get project details
        /// </summary>
        /// <returns></returns>
        [Route("api/Project/GetProjectDetails")]
        [HttpGet]
        public List<ProjectModel> GetProjectDetails()
        {
            objProjectBL = new ProjectBL();
            var vGetProjectDetails = objProjectBL.GetProjectDetails();

            return vGetProjectDetails;
        }
        #endregion

        #region InsertProjectDetails
        /// <summary>
        /// Insert the project details which user entered
        /// </summary>
        /// <param name="objGET_PROJECT_DETAILS_Result"></param>
        /// <returns></returns>
        [Route("api/Project/SubmitProjectDetail")]
        [HttpPost]
        public bool SubmitProjectDetail(ProjectModel projectModel)
        {
            objProjectBL = new ProjectBL();
            var isSubmitted = objProjectBL.SubmitProjectDetail(projectModel);
            return isSubmitted;
        }
        #endregion

        #region GetManagerDetails
        /// <summary>
        /// To get Manager details
        /// </summary>
        /// <returns></returns>
        [Route("api/Project/GetManagerDetails")]
        [HttpGet]
        public List<ProjectModel> GetManagerDetails()
        {
            objProjectBL = new ProjectBL();
            var vGetManagerDetails = objProjectBL.GetManagerDetails();
            return vGetManagerDetails;
        }
        #endregion

        #region GetProjectName
        /// <summary>
        /// To get Project name 
        /// </summary>
        /// <returns></returns>
        [Route("api/Project/GetProjectName")]
        [HttpGet]
        public List<ProjectModel> GetProjectName()
        {
            objProjectBL = new ProjectBL();
            var vGetManagerDetails = objProjectBL.GetProjectName();
            return vGetManagerDetails;
        }
        #endregion

        #region SuspendProjectDetail

       /// <summary>
       /// 
       /// </summary>
       /// <param name="projectModel"></param>
       /// <returns></returns>
        [Route("api/Project/SuspendProjectDetail")]
        [HttpPost]
        public bool SuspendProjectDetail(ProjectModel projectModel)
        {
            objProjectBL = new ProjectBL();
            var vSuspendProjectDetail = objProjectBL.SuspendProjectDetail(projectModel.Project_ID.GetValueOrDefault(0));
            return vSuspendProjectDetail;
        }

        #endregion
    }

}
