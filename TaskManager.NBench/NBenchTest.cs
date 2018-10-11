using Capsule_TaskManager.Controllers;
using NBench;

namespace ProjectManager.NBench
{
    public class NBenchTest
    {
        private Counter _objCounter;

        [PerfSetup]
        public void SetUp(BenchmarkContext context)
        {
            _objCounter = context.GetCounter("ProjectCounter");
        }

        #region TASK
        TaskManagerController taskController;

        [PerfBenchmark(Description = "Counter iteration performance test GetParentTaskList()", NumberOfIterations = 10, RunMode = RunMode.Throughput, TestMode = TestMode.Measurement, RunTimeMilliseconds = 1000)]
        [CounterMeasurement("ProjectCounter")]
        [MemoryMeasurement(MemoryMetric.TotalBytesAllocated)]
        public void NBench_GetParentTaskList()
        {
            var bytes = new byte[1024];
            taskController = new TaskManagerController();
            var result = taskController.GetParentTaskList();
            _objCounter.Increment();
        }

        [PerfBenchmark(Description = "Counter iteration performance test for GetTaskDetailList()", NumberOfIterations = 10, RunMode = RunMode.Throughput, TestMode = TestMode.Measurement, RunTimeMilliseconds = 1000)]
        [CounterMeasurement("ProjectCounter")]
        [MemoryMeasurement(MemoryMetric.TotalBytesAllocated)]
        public void NBench_GetTaskDetailList()
        {
            var bytes = new byte[1024];
            taskController = new TaskManagerController();
            var result = taskController.GetTaskDetailList();
            _objCounter.Increment();
        }
        #endregion

        #region PROJECT
        ProjectController projectController;

        [PerfBenchmark(Description = "Counter iteration performance test GetProjectDetails()", NumberOfIterations = 10, RunMode = RunMode.Throughput, TestMode = TestMode.Measurement, RunTimeMilliseconds = 1000)]
        [CounterMeasurement("ProjectCounter")]
        [MemoryMeasurement(MemoryMetric.TotalBytesAllocated)]
        public void NBench_GetProjectDetails()
        {
            var bytes = new byte[1024];
            projectController = new ProjectController();
            var result = projectController.GetProjectDetails();
            _objCounter.Increment();
        }
        #endregion

        #region USER
        UserController userController;

        [PerfBenchmark(Description = "Counter iteration performance test GetUserDetails()", NumberOfIterations = 10, RunMode = RunMode.Throughput, TestMode = TestMode.Measurement, RunTimeMilliseconds = 1000)]
        [CounterMeasurement("ProjectCounter")]
        [MemoryMeasurement(MemoryMetric.TotalBytesAllocated)]
        public void NBench_GetUserDetails()
        {
            var bytes = new byte[1024];
            userController = new UserController();
            var result = userController.GetUserDetails();
            _objCounter.Increment();
        }
        #endregion

        [PerfCleanup]
        public void Clean()
        {
            //does nothing
        }
    }
}
