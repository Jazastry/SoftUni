using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompanyHierarchy
{
    public interface ISalesEmployee : IRegularEmployee
    {
        List<Sale> Sales { get; }

        string ToString();
        string ListActivity();
    }
}
