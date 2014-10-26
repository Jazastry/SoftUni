using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompanyHierarchy
{
    public interface IPerson
    {
        int Id { get; }
        string FirstName { get; }
        string LastName { get; }

        string ToString();
    }
}
