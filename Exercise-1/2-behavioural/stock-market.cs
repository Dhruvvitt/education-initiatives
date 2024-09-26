using System;
using System.Collections.Generic;

public interface IObserver
{
    void Update(double price);
}

public class Stock
{
    private double price;
    private List<IObserver> observers = new List<IObserver>();

    public double Price
    {
        get { return price; }
        set
        {
            price = value;
            NotifyObservers();
        }
    }

    public void Attach(IObserver observer)
    {
        observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        observers.Remove(observer);
    }

    private void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.Update(price);
        }
    }
}

public class Investor : IObserver
{
    public void Update(double price)
    {
        Console.WriteLine($"Investor received update: Price = {price}");
    }
}

public class Program
{
    public static void Main()
    {
        Stock stock = new Stock();
        Investor investor1 = new Investor();
        Investor investor2 = new Investor();

        stock.Attach(investor1);
        stock.Attach(investor2);

        stock.Price = 100;
        stock.Price = 120;
    }
}