using System;
using System.Collections.Generic;
class Computer
{
    private string name;
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
                throw new ArgumentNullException("Computer.Name");
            }
            else 
            {
                this.name = value;
            }
        }
    }
    public Component Processor { get; set; }
    public Component GraphicsCard { get; set; }
    public Component Motherboard { get; set; }
    public Component Ram { get; set; }
    public Component HardDisc { get; set; }
    public Component Screen { get; set; }
    public Component Keyboard { get; set; }
    public Component Mouse { get; set; }
    public Component LanCard { get; set; }
    private decimal price;
    public decimal Price
    {
        get
        {
            return this.price;
        }
        set
        {
            this.price = value;
        }
    }
    public Computer(string name,Component processor, Component graphicsCard, Component motherboard
        , Component ram, Component hardDisc, Component lanCard)
    {
        this.Name = name;
        this.Processor = processor;
        this.GraphicsCard = graphicsCard;
        this.Motherboard = motherboard;
        this.Ram = ram;
        this.HardDisc = hardDisc;
        this.LanCard = lanCard;
        this.Price = processor.Price + graphicsCard.Price + motherboard.Price
            + ram.Price + hardDisc.Price + lanCard.Price;
    }
    public Computer(string name, Component processor, Component graphicsCard, Component motherboard
       , Component ram, Component hardDisc,Component lanCard, Component screen)
    {
        this.Name = name;
        this.Processor = processor;
        this.GraphicsCard = graphicsCard;
        this.Motherboard = motherboard;
        this.Ram = ram;
        this.HardDisc = hardDisc;
        this.Screen = screen;
        this.Price = processor.Price + graphicsCard.Price + motherboard.Price
            + ram.Price + hardDisc.Price + screen.Price+ lanCard.Price;
    }
    public Computer(string name, Component processor, Component graphicsCard, Component motherboard
       , Component ram, Component hardDisc, Component lanCard, Component screen, Component keyboard, 
        Component mouse)
    {
        this.Name = name;
        this.Processor = processor;
        this.GraphicsCard = graphicsCard;
        this.Motherboard = motherboard;
        this.Ram = ram;
        this.HardDisc = hardDisc;
        this.Screen = screen;
        this.Keyboard = keyboard;
        this.Mouse = mouse;
        this.Price = processor.Price + graphicsCard.Price + motherboard.Price
            + ram.Price + hardDisc.Price + screen.Price + lanCard.Price + keyboard.Price
            + mouse.Price;
    }
    public override string ToString()
    {
        string result = String.Format("Computer - {1}{0}{2}{3}{4}{5}{6}{7}{8}{9}{10}Total Price:{11}.lv", Environment.NewLine, 
            this.Name, this.Processor, this.GraphicsCard, this.Motherboard,
            this.Ram, this.HardDisc, this.Screen, this.Keyboard, this.Mouse, this.LanCard,
            this.Price);
        return result;
    }

}