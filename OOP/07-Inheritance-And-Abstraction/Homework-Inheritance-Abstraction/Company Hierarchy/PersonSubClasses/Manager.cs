using System;
using System.Collections.Generic;

namespace CompanyHierarchy
{
    public class Manager : Employee, IManager
    {
        public List<Employee> Team { get; private set; }

        public Manager(int id, string firstName, string lastName, Department department, decimal salary,
            List<Employee> team)
            : base(id, firstName, lastName, department, salary)
        {
            this.Team = team;
        }

        public override string ToString()
        {
            string result = String.Format("{0} {1} : {2}\n Employee : Manager" +
                                          "\n Department : {3}\n Salary : {4}\n Team Members : {5}",
                this.FirstName, this.LastName, this.Id, this.Department, this.Salary,
                ListActivity());
            return result;
        }

        public override string ListActivity()
        {
            string teamMembers = " Team Members : ";
            foreach (Employee member in this.Team)
            {
                teamMembers += member.FirstName + " " + member.LastName + ", ";
            }
            return teamMembers;
        }
    }
}
