using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capsule_TaskManager.Models.Project
{
    public class ProjectModel
    {
        public Nullable<int> Project_ID { get; set; }
        public string Project { get; set; }
        public Nullable<System.DateTime> Start_Date { get; set; }
        public Nullable<System.DateTime> End_Date { get; set; }
        public Nullable<int> Priority { get; set; }
        public Nullable<int> Manager_ID { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<int> TaskCount { get; set; }
        public string ProjStatus { get; set; }
        public string Action { get; set; }
        public Nullable<int> Is_Active { get; set; }
        public string Active_Progress { get; set; }
    }
}
