namespace CompanyHierarchy
{
    public interface ICostumer : IPerson
    {
        decimal NetPurchaseAmount { get; }

        string ToString();
    }
}
