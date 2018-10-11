
using Capsule_TaskManager.Controllers;
using Capsule_TaskManager.Models.Project;
using Capsule_TaskManagerDL.Model;
using NUnit.Framework;
using System;
using System.Linq;


namespace Nunit_Capsule_ProjectManager.Tests.Controllers
{
    [TestFixture]
    public class NUnit_ProjectController
    {
        #region Public Declaration

        ProjectController objProjectController = new ProjectController();
        GET_PROJECT_DETAILS_Result objGET_PROJECT_DETAILS_Result = null;

        #endregion

        #region GetProjectDetails
        /// <summary>
        /// To get project details
        /// </summary>
        /// <returns></returns>
        [Test]
        public void GetProjectDetails()
        {
            var vlsit = objProjectController.GetProjectDetails();
            var vCount = vlsit.Count();

            Assert.IsTrue(vCount > 0);
        }
        #endregion

        #region Submit Task Detail

        [Test, Order(1)]
        public void InsertProjectDetail()
        {
            ProjectModel projectModel = new ProjectModel();
            projectModel.Project = "Wharehouse Serialization";
            projectModel.Start_Date = DateTime.Now;
            projectModel.End_Date = DateTime.Now;
            projectModel.Priority = 4;
            projectModel.Manager_ID = 119086;

            ProjectController objController = new ProjectController();
            var isInserted = objController.SubmitProjectDetail(projectModel);
            Assert.IsTrue(isInserted);
        }

        [Test, Order(2)]
        public void UpdateProjectDetails()
        {
            ProjectModel projectModel = new ProjectModel();
            projectModel.Project_ID = 1;
            projectModel.Project = "WSS 2.0";
            projectModel.Start_Date = DateTime.Now;
            projectModel.End_Date = DateTime.Now;
            projectModel.Priority = 4;
            projectModel.Manager_ID = 119086;

            ProjectController objController = new ProjectController();
            var isInserted = objController.SubmitProjectDetail(projectModel);
            Assert.IsTrue(isInserted);
        }
        #endregion
    }
}
