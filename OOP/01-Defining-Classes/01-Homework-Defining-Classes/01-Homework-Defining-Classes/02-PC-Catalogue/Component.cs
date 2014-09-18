using System;
class Component
{
    private string name = "";
    public string Name
    {
        get 
        {
            return this.name;
        }
        set 
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Component.Name");
            }
            else
            {
                this.name = value;
            }
        }
    }
    private string details = "";
    public string Details
    {
        get
        {
            return this.details;
        }
        set
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Component.Details");
            }
            else
            {
                this.details = value;
            }
        }
    }
    public decimal price;
    public decimal Price
    {
        get
        {
            return this.price;
        }
        set
        {
            if(value < 0)
            {
                throw new ArgumentOutOfRangeException("Component.Price");
            }
            else
            {
                this.price = value;
            }
        }
    }
    public Component(string name, decimal price, string details = "")
    {
        this.name = name;
        this.price = price;
        this.details = details;
    }
    public override string ToString()
    {
        string result;
        if (this.Name == "")
        {
            result = "";
        }
        else if (this.Details == "")
        {
            result = String.Format("  {0}(Price: {1}lv.),{2}", this.Name, this.Price, Environment.NewLine);
        }
        else
        {
            result = String.Format("  {0}({2} ,Price: {1}lv.),{3}", this.Name, this.Price, this.Details, Environment.NewLine);
        }
        return result;
    }
}

