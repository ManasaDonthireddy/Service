using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capsule_TaskManager.Models.ParentTask
{
    public class ParentTaskModel
    {
        public Nullable<int> Parent_ID { get; set; }
        public string Parent_Task { get; set; }
    }
}
