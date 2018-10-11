using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capsule_TaskManager.Models.Task
{
    public class TaskModel
    {
        public Nullable<int> Task_ID { get; set; }
        public Nullable<int> Parent_ID { get; set; }
        public string Parent_Task { get; set; }
        public string Task { get; set; }
        public Nullable<System.DateTime> Start_Date { get; set; }
        public Nullable<System.DateTime> End_Date { get; set; }
        public Nullable<int> Priority { get; set; }
        public Nullable<int> Project_ID { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<int> User_ID { get; set; }
        public string Action { get; set; }
        public Nullable<int> Is_Active { get; set; }
        public string Project_Name { get; set; }

    }
}
