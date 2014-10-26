using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompanyHierarchy
{
    public class Developer : RegularEmployee, IDeveloper
    {
        public List<Project> Projects { get; private set; }

        public Developer(int id, string firstName, string lastName,
            Department department, decimal salary, List<Project> projects)
            : base(id, firstName, lastName, department, salary)
        {
            this.Projects = projects;
        }

        public override string ToString()
        {
            string result = String.Format("{0} {1} : {2}\n Employee\n Specialty : Developer\n Department : {3}" +
                                          " Salary : {4}\n Projects : {5}",
                this.FirstName, this.LastName, this.Id, this.Department, this.Salary, ListActivity());
            return result;
        }

        public override string ListActivity()
        {
            string projects = "";
            foreach (Project project in this.Projects)
            {
                projects += project.Name + ", start - " +
                    project.StarTime + ", state - " + project.ProjectState;
            }
            return projects;
        }
    }
}
