using System;
public class LaptopShop
{
    static void Main()
    {
        Laptop[] lenovoLaptopArr = {
            new Laptop( 
                        model: "LENOVO ThinkPad Yoga",
                        manufacturer: "Lenovo",
                        processor: "Intel® Core™ i5-4300U",
                        ram: "8 GB",
                        graphicsCard: "Intel HD Graphics 4400",
                        hdd: "350GB 7500 RPM",
                        lifeInHours: 8.5,
                        batteryCells: "4-cell",
                        screen: "12.5-inch (31.75 sm.) - 1920x1080 (Full HD IPS), math, sensor",
                        price: 2259.0m
                       ),
            new Laptop( 
                        model: "LENOVO ThinkPad Yoga",
                        manufacturer: "Lenovo",
                        processor: "Intel® Core™ i5-4300U",
                        ram: "8 GB",
                        graphicsCard: "Intel HD Graphics 4400",
                        screen: "12.5-inch (31.75 sm.) - 1920x1080 (Full HD IPS), math, sensor",
                        price: 2259.0m
                       ),
            new Laptop( 
                        model: "LENOVO ThinkPad Yoga",
                        processor: "Intel® Core™ i5-4300U",
                        ram: "8 GB",
                        hdd: "350GB 7500 RPM",
                        screen: "12.5-inch (31.75 sm.) - 1920x1080 (Full HD IPS), math, sensor",
                        price: 2259.0m
                       ),
            new Laptop( 
                        model: "LENOVO ThinkPad Yoga",
                        manufacturer: "Lenovo",
                        processor: "Intel® Core™ i5-4300U",
                        screen: "12.5-inch (31.75 sm.) - 1920x1080 (Full HD IPS), math, sensor",
                        price: 2259.0m
                       ),
            new Laptop( 
                        model: "LENOVO ThinkPad Yoga",
                        price: 2259.0m
                       )           
        };
        foreach (var item in lenovoLaptopArr)
        {
            Console.WriteLine(item + "\n");
        }
    }
}

