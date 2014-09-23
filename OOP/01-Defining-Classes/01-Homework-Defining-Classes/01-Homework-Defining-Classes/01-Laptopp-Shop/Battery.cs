using System;

class Battery
{
    public string Description { get; set; }
    public double LifeInHours { get; set; }
    public Battery() {}
    public Battery(string description, double lifeInHours ) 
    {
        this.Description = description;
        this.LifeInHours = lifeInHours;
    }
    public override string ToString()
    {
        string result;
        if (((this.Description == "") || (this.Description == " "))
            && this.LifeInHours <= 0)
        {
            result = "";
        }
        else if (((this.Description == "") || (this.Description == " "))
            && this.LifeInHours > 0)
        {
            result = String.Format(" Battery Life :{0}\n", this.LifeInHours);
        }
        else if (this.LifeInHours == 0)
        {
            result = String.Format(" Battery :{0}\n",
                this.Description);
        }
        else
        {
            result = String.Format(" Battery :{0}\n Battery Life :{1}\n",
                this.Description, this.LifeInHours);
        }
        return result;
    }
}

