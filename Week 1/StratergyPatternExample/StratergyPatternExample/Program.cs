using System;

// Strategy Interface
interface IPaymentStrategy
{
    void Pay(int amt);
}

// Concrete Strategy: Credit Card
class CreditCardPayment : IPaymentStrategy
{
    public void Pay(int amt)
    {
        Console.WriteLine($"The Amount of Rupees {amt} has been deducted from your Credit Card.");
    }
}

// Concrete Strategy: PayPal
class PayPalPayment : IPaymentStrategy
{
    public void Pay(int amt)
    {
        Console.WriteLine($"The Amount of Rupees {amt} has been deducted from your PayPal Account.");
    }
}

// Context
class PaymentContext
{
    private IPaymentStrategy strategy;

    public void SetPaymentStrategy(IPaymentStrategy strategy)
    {
        this.strategy = strategy;
    }

    public void Pay(int amt)
    {
        if (strategy != null)
            strategy.Pay(amt);
        else
            Console.WriteLine("No payment strategy selected.");
    }
}

// Client Code
class StrategyPatternExample
{
    static void Main(string[] args)
    {
        PaymentContext context = new PaymentContext();

        context.SetPaymentStrategy(new CreditCardPayment());
        context.Pay(1500);

        context.SetPaymentStrategy(new PayPalPayment());
        context.Pay(20000);
    }
}
