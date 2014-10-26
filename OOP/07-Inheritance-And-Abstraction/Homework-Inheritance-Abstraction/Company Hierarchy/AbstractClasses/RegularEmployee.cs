using System;

namespace CompanyHierarchy
{
    public abstract class RegularEmployee : Employee, IRegularEmployee
    {
        public RegularEmployee(int id, string firstName, string lastName, Department department, decimal salary)
            : base(id, firstName, lastName, department, salary) {}

        public RegularEmployee() {}

        public abstract override string ToString();

        public abstract override string ListActivity();
    }
}
