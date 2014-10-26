using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompanyHierarchy
{
    public interface IDeveloper : IRegularEmployee
    {
        List<Project> Projects { get; }

        string ToString();
        string ListActivity();
    }
}
