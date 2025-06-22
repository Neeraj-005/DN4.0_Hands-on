using System;
using System.Collections.Generic;

// Subject Interface
interface IStock
{
    void RegisterObserver(IObserver o);
    void DeregisterObserver(IObserver o);
    void NotifyObservers();
}

// Concrete Subject
class StockMarket : IStock
{
    private readonly List<IObserver> observers = new List<IObserver>();
    private double stockPrice;

    public void RegisterObserver(IObserver o)
    {
        observers.Add(o);
    }

    public void DeregisterObserver(IObserver o)
    {
        observers.Remove(o);
    }

    public void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.Update(stockPrice);
        }
    }

    public void SetStockPrice(double price)
    {
        this.stockPrice = price;
        NotifyObservers(); // Notify all observers automatically
    }
}

// Observer Interface
interface IObserver
{
    void Update(double price);
}

// Concrete Observer: Mobile
class MobileApp : IObserver
{
    private readonly string appName;

    public MobileApp(string name)
    {
        appName = name;
    }

    public void Update(double stockPrice)
    {
        Console.WriteLine($"{appName} - Mobile App received stock price update: {stockPrice}");
    }
}

// Concrete Observer: Web
class WebApp : IObserver
{
    private readonly string appName;

    public WebApp(string name)
    {
        appName = name;
    }

    public void Update(double stockPrice)
    {
        Console.WriteLine($"{appName} - Web App received stock price update: {stockPrice}");
    }
}

// Client Code
class ObserverPatternExample
{
    static void Main(string[] args)
    {
        StockMarket stockMarket = new StockMarket();

        IObserver mobileObserver = new MobileApp("Zerodha");
        IObserver webObserver = new WebApp("Growww");

        stockMarket.RegisterObserver(webObserver);
        stockMarket.RegisterObserver(mobileObserver);

        stockMarket.SetStockPrice(10000);
    }
}
