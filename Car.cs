// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;

public class Car
    {
    public string Name { get; set; }
    public int ProductionYear { get; set; }
    public int MaxSpeed { get; set; }

    public Car(string name, int productionYear, int maxSpeed)
        {
        Name = name;
        ProductionYear = productionYear;
        MaxSpeed = maxSpeed;
        }

    public override string ToString()
        {
        return $"Name: {Name}, Year: {ProductionYear}, Max Speed: {MaxSpeed} km/h";
        }
    }

public class CarComparer : IComparer<Car>
    {
    public enum SortCriteria
        {
        ByName,
        ByProductionYear,
        ByMaxSpeed
        }

    private SortCriteria criteria;

    public CarComparer(SortCriteria criteria)
        {
        this.criteria = criteria;
        }

    public int Compare(Car x, Car y)
        {
        switch (criteria)
            {
            case SortCriteria.ByName:
                return string.Compare (x.Name, y.Name);
            case SortCriteria.ByProductionYear:
                return x.ProductionYear.CompareTo (y.ProductionYear);
            case SortCriteria.ByMaxSpeed:
                return x.MaxSpeed.CompareTo (y.MaxSpeed);
            default:
                throw new ArgumentException("Invalid sort criteria");
            }
        }
    }

class Program
    {
    static void Main()
        {
        Car[] cars = new Car[]
            {
            new Car("Toyota", 2015, 180),
            new Car("BMW", 2018, 240),
            new Car("Audi", 2016, 220),
            new Car("Mercedes", 2020, 250),
            new Car("Ford", 2012, 160)
            };

        Console.WriteLine("Original array:");
        PrintCars(cars);

        Array.Sort(cars, new CarComparer(CarComparer.SortCriteria.ByName));
        Console.WriteLine("\nSorted by Name:");
        PrintCars(cars);

        Array.Sort(cars, new CarComparer(CarComparer.SortCriteria.ByProductionYear));
        Console.WriteLine("\nSorted by Production Year:");
        PrintCars(cars);

        Array.Sort(cars, new CarComparer(CarComparer.SortCriteria.ByMaxSpeed));
        Console.WriteLine("\nSorted by Max Speed:");
        PrintCars(cars);
        }

    static void PrintCars(Car[] cars)
        {
        foreach (var car in cars)
            {
            Console.WriteLine(car);
            }
        }
    }