using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class | AttributeTargets.Interface |
AttributeTargets.Method | AttributeTargets.Enum,
    AllowMultiple = true)]
public class VersionAttribute : System.Attribute
{
    private string version;
    public string Version { get; private set; }
    public VersionAttribute(int major, int minor)
    {
        string res = "e.g." + major.ToString() + "." + minor.ToString() + ".";
        this.Version = res;
    }
    public override string ToString()
    {
        return String.Format("Version :", this.Version);
    }
}

