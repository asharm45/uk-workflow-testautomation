using System.ComponentModel;

namespace WorkflowSpecflowTests.Apis
{
    public partial class ListOfTasksDTO
    {
        public string Assignee { get; set; }
        public string Broker { get; set; }
        public long? ClaimNumber { get; set; }
        public string TaskDescription { get; set; }
        public DateTimeOffset CreationDate { get; set; }
        public DateTimeOffset TaskDueDate { get; set; }
        public long TaskId { get; set; }
        public string TaskName { get; set; }
        public string PolicyExternalNumber { get; set; }
        public string TaskPriority { get; set; }
        public string Product { get; set; }
        public object TaskRemarks { get; set; }
        public string TaskStatus { get; set; }
        public string Queue { get; set; }
        public string QuoteExternalNumber { get; set; }
       
    }
    
}
