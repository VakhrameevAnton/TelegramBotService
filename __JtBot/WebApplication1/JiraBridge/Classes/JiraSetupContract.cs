using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraBridge.Classes
{
    public class JiraSetupContract
    {
        public string JiraHost { get; set; }
        public string JiraService { get; set; }
        public string JiraUser { get; set; }
        public string JiraPassword { get; set; }
        public string JiraAssignee { get; set; }
        public string JiraUrl { get; set; }
        public string JiraProject { get; set; }
        public string JiraPriority { get; set; }
    }
}
