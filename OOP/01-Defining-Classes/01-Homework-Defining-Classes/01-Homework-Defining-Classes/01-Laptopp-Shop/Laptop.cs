using System;

class Laptop : Object
{
    private string model;
    public string Model
    {
        get
        {
            return this.model;
        }
        set
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Model");
            }
            else
            {
                this.model = value;
            }
        }
    }
    private string manufacturer;
    public string Manufaturer 
    {
        get
        {
            return this.manufacturer;
        }
        set
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Manufacturer");
            }
            else 
            {
                this.manufacturer = value;
            }
        }
    }
    private string processor;
    public string Processor 
    {
        get
        {
            return this.processor;
        }
        set
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Processor");
            }
            else
            {
                this.processor = value; 
            }
        }
    }
    private string ram;
    public string Ram
    {
        get
        {
            return this.Ram;
        }
        set 
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Ram");
            }
            else
            {
                this.ram = value;
            }
        }
    }
    private string graphicsCard;
    public string GraphicsCard
    {
        get
        {
            return this.graphicsCard;
        }
        set
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("GraphicCard");
            }
            else
            {
                this.graphicsCard = value;
            }
        }
    }
    private string hdd;
    public string Hdd
    {
        get
        {
            return this.hdd;
        }
        set
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("GraphicCard");
            }
            else
            {
                this.hdd = value;
            }
        }
    }
    private string screen;
    public string Screen 
    {
        get 
        {
            return this.screen;
        }
        set
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Screen");
            }
            else
            {
                this.screen = value;
            }
        }
    }
    public decimal price = 0m;
    public decimal Price
    {
        get
        {
            return this.price;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Price");
            }
            else
            {
                this.price = value;
            }
        }
    }
    public Battery Battery { get; set; }
    public Laptop(string model, decimal price, string manufacturer = " ", string processor = " ", string hdd = " ", string ram = " ", string graphicsCard = " ",
        string batteryCells = " ", string screen = " ", double lifeInHours = 0)
        : this(model, price, manufacturer, processor, ram, graphicsCard, screen, hdd)
    {
        this.Battery = new Battery(batteryCells, lifeInHours);
    }
    public Laptop(string model, decimal price, string manufacturer, string processor, string ram, string hdd, string graphicsCard, string screen)
        : this(model, price, manufacturer, processor, ram, graphicsCard, screen)
    {
        this.Screen = screen;
        this.Hdd = hdd;
    }
    public Laptop(string model, decimal price, string manufacturer, string processor, string ram, string graphicsCard, string screen)
        : this(model, price, manufacturer, processor, ram, graphicsCard)
    {
        this.Screen = screen;
    }
    public Laptop(string model, decimal price, string manufacturer, string processor, string ram, string graphicsCard)
        : this(model, price, manufacturer, processor, ram)
    {
        this.GraphicsCard = graphicsCard;
    }
    public Laptop(string model, decimal price, string manufacturer, string processor, string ram)
        : this(model, price, manufacturer, processor)
    {
        this.Ram = ram;
    }
    public Laptop(string model, decimal price, string manufacturer, string processor)
        : this(model, price, manufacturer)
    {
        this.Processor = processor;
    }
    public Laptop(string model, decimal price, string manufacturer)
        : this(model, price)
    {
        this.Manufaturer = manufacturer;
    }
    public Laptop(string model, decimal price)
    {
        this.Model = model;
        this.Price = price;
    }

    public override string ToString()
    {
        string nonMandatoryParts = "";
        string[] parts = {" Manufacturer :", " Processor :", " RAM :", " GrphicsCard :", " HDD :", " Screen :"};
        string[] partsData = {this.Manufaturer, this.Processor, this.ram, this.GraphicsCard, this.Hdd, this.Screen};
        for (int i = 0; i < parts.Length; i++)
        {
            if ((!String.IsNullOrEmpty(partsData[i])) && partsData[i] != " ")
            {
                nonMandatoryParts += parts[i] + partsData[i] + "\n";
            }
        }
        string result = String.Format(
            "Laptop\n Model :{0}\n{1}{2} Price :{3}.lv",
            this.Model, nonMandatoryParts, this.Battery,this.Price);
        
        return result;
    }

}

