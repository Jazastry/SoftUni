using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
class PcCatalogue
{
    static void Main()
    {
        Computer lenovoThinkIdeaBasic = new Computer(
                name: "Lenovo ThinkIdea-Basic",
                processor: new Component("Processor", 300, "Intel Core i5 4460 3.0 GHz"),
                graphicsCard: new Component("Graphics Card", 100, "Sapphire R9 280 3GB GD5 Boost"),
                motherboard: new Component("Mother Board", 257, "Gigabyte H97-HD3"),
                ram: new Component("RAM", 500, "8GB DDR3 1600MHZ"),
                hardDisc: new Component("Hard Disc", 230, "Scorpio 1TB 7200rpm"),
                lanCard: new Component("Lan Card", 50, "Turbo-X WLN-150"),
                screen: new Component("Screen", 220, "Panasonic XR300 22 inch"),
                mouse: new Component("Mouse", 15,"Microsoft Basic"),
                keyboard: new Component("Keyboard", 25, "Lenovo Basic RG-300")
                );
        Computer lenovoThinkIdea = new Computer(
                name: "Lenovo ThinkIdea",
                processor: new Component("Processor", 233, "Intel Core i3 360 1.8 GHz"),
                graphicsCard: new Component("Graphics Card", 150, "Radeon R9 280 2GB"),
                motherboard: new Component("Mother Board", 257, "Gigabyte H97-HD3"),
                ram: new Component("RAM", 500, "8GB DDR3 1600MHZ"),
                hardDisc: new Component("Hard Disc", 230, "Scorpio 1TB 7200rpm"),
                lanCard: new Component("Lan Card", 50, "Turbo-X WLN-150")
                );
        Computer lenovoThinkPad = new Computer(
                name: "Lenovo ThinkPad",
                processor: new Component("Processor", 340, "Intel Core i5 4460 3.2 GHz"),
                graphicsCard: new Component("Graphics Card", 220, "Sapphire R9 280 3GB GD5 Boost"),
                motherboard: new Component("Mother Board", 257, "Gigabyte H97-HD3"),
                ram: new Component("RAM", 500, "8GB DDR3 1600MHZ"),
                hardDisc: new Component("Hard Disc", 230, "Scorpio 1TB 7200rpm"),
                lanCard: new Component("Lan Card", 50, "Turbo-X WLN-150")
                );
        Computer acer = new Computer(
                name: "Acer Edge",
                processor: new Component("Processor", 440, "Intel Core i7 4460 3.2 GHz"),
                graphicsCard: new Component("Graphics Card", 520, "NVIDIA GeForce 280 4GB GD5 Boost"),
                motherboard: new Component("Mother Board", 257, "Gigabyte H97-HD3"),
                ram: new Component("RAM", 500, "8GB DDR3 1600MHZ"),
                hardDisc: new Component("Hard Disc", 230, "Scorpio 1TB 7200rpm"),
                lanCard: new Component("Lan Card", 50, "Turbo-X WLN-150"),
                screen: new Component("Screen", 250, "LG Clear View 25 inch"),
                mouse: new Component("Mouse", 22),
                keyboard: new Component("Keyboard", 35)
                );

        List<Computer> compList = new List<Computer>();

        compList.Add(lenovoThinkIdea);
        compList.Add(lenovoThinkIdeaBasic);
        compList.Add(acer);
        compList.Add(lenovoThinkPad);

        List<Computer> compsOrderedPriceAscend = compList.OrderBy(o => o.Price).ToList();

        foreach (var item in compsOrderedPriceAscend)
        {
            Console.WriteLine(item + Environment.NewLine);
        }
    }
}

