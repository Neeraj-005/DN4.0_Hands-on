using System;

// Target Interface
interface IPaymentProcessor
{
    void MakePayment(double amt);
}

// Adaptee 1
class IciciGateway
{
    public void Pay(double amt)
    {
        Console.WriteLine("Paid " + amt + " using Icici Gateway.");
    }
}

// Adaptee 2
class PaytmGateway
{
    public void Payment(double amt)
    {
        Console.WriteLine("Paid " + amt + " using Paytm.");
    }
}

// Adapter for Icici
class IciciTranslator : IPaymentProcessor
{
    private readonly IciciGateway icici;

    public IciciTranslator(IciciGateway icici)
    {
        this.icici = icici;
    }

    public void MakePayment(double amt)
    {
        icici.Pay(amt);
    }
}

// Adapter for Paytm
class PaytmTranslator : IPaymentProcessor
{
    private readonly PaytmGateway paytm;

    public PaytmTranslator(PaytmGateway paytm)
    {
        this.paytm = paytm;
    }

    public void MakePayment(double amt)
    {
        paytm.Payment(amt);
    }
}

// Client code
class AdapterPatternExample
{
    static void Main(string[] args)
    {
        IPaymentProcessor icici = new IciciTranslator(new IciciGateway());
        icici.MakePayment(2000);

        IPaymentProcessor paytm = new PaytmTranslator(new PaytmGateway());
        paytm.MakePayment(200);
    }
}

