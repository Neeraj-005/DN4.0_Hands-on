using System;

public class Logger
{
    private static Logger obj;

    
    private Logger()
    {
        Console.WriteLine("Logger Created");
    }
    public static Logger GetInstance()
    {
        if (obj == null)
        {
            obj = new Logger(); 
        }
        return obj;
    }
}

class SingletonPatternExample
{
    static void Main(string[] args)
    {
        var user1 = Logger.GetInstance();
        var user2 = Logger.GetInstance();

        if (user1 == user2)
        {
            Console.WriteLine("Only One instance is Created");
        }
    }
}

