﻿using System;

public enum Planet
{
    Mercury, Venus, Earth, Mars, Jupiter, Saturn, Uranus, Neptune
}
public struct Location
{
    public double Latitude { get; set; }
    public double Logitude { get; set; }
    public Planet Planet { get; set; }
    public Location(double latitude, double longitude, Planet planet)
        : this()
    {
        this.Logitude = longitude;
        this.Latitude = latitude;
        this.Planet = planet;
    }

    public override string ToString()
    {
        return
            this.Latitude + ", " +
            this.Logitude + " - " +
            this.Planet;
    }
}
public class Tests
{
    static void Main()
    {
        Location sofia = new Location(42.5, 22.4, Planet.Earth);
        Console.WriteLine(sofia);
    }
}


