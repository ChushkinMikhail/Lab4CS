// See https://aka.ms/new-console-template for more information
using System;
using System.Collections;
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

public class CarCatalog : IEnumerable<Car>
    {
    private Car[] cars;

    public CarCatalog(Car[] cars)
        {
        this.cars = cars;
        }

    public IEnumerator<Car> GetEnumerator()
        {
        foreach (var car in cars)
            {
            yield return car;
            }
        }

    public IEnumerable<Car> GetReverseEnumerator()
        {
        for (int i = cars.Length - 1; i >= 0; i--)
            {
            yield return cars[i];
            }
        }

    public IEnumerable<Car> GetCarsByYear(int year)
        {
        foreach (var car in cars)
            {
            if (car.ProductionYear == year)
                {
                yield return car;
                }
            }
        }

    public IEnumerable<Car> GetCarsByMaxSpeed(int maxSpeed)
        {
        foreach (var car in cars)
            {
            if (car.MaxSpeed >= maxSpeed)
                {
                yield return car;
                }
            }
        }

    IEnumerator IEnumerable.GetEnumerator()
        {
        return GetEnumerator();
        }
    }

class Program
    {
    static void Main(string[] args)
        {
        Car[] cars = new Car[]
            {
            new Car("Toyota", 2015, 180),
            new Car("BMW", 2018, 240),
            new Car("Audi", 2016, 220),
            new Car("Mercedes", 2020, 250),
            new Car("Ford", 2012, 160)
            };

        CarCatalog catalog = new CarCatalog(cars);

        Console.WriteLine("Direct iteration:");
        foreach (var car in catalog)
            {
            Console.WriteLine(car);
            }

        Console.WriteLine("\nReverse iteration:");
        foreach (var car in catalog.GetReverseEnumerator())
            {
            Console.WriteLine(car);
            }

        Console.WriteLine("\nCars from year 2016:");
        foreach (var car in catalog.GetCarsByYear(2016))
            {
            Console.WriteLine(car);
            }

        Console.WriteLine("\nCars with max speed >= 200:");
        foreach (var car in catalog.GetCarsByMaxSpeed(200))
            {
            Console.WriteLine(car);
            }
        }
    }
