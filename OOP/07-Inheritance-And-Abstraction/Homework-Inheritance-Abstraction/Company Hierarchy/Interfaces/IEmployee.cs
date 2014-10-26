namespace CompanyHierarchy
{
    public interface IEmployee : IPerson
    {
        decimal Salary { get; }
        Department Department { get; }
        string ToString();

        string ListActivity();
    }
}
