using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompanyHierarchy
{
    public enum ProjectState
    {
        Open, Closed
    }

    public class Project
    {
        public string Name { get; private set; }
        public DateTime StarTime { get; private set; }

        private ProjectState projectState = ProjectState.Open;
        public ProjectState ProjectState {

            get { return this.projectState; }
        }

        public Project(string name, DateTime startTime)
        {
            this.Name = name;
            this.StarTime = startTime;
        }

        public void CloseProject()
        {
            this.projectState = ProjectState.Closed;   
        }
    }
}
