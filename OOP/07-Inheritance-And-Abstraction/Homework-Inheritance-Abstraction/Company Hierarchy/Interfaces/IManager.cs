using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace CompanyHierarchy
{
    public interface IManager : IEmployee
    {
        List<Employee> Team { get; }

        string ToString();

        string ListActivity();
    }
}
