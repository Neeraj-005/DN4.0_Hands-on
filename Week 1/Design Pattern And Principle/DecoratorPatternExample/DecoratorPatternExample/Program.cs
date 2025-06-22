using System;

interface INotifier
{
    void Send();
}

class EmailNotifier : INotifier
{
    public void Send()
    {
        Console.WriteLine("Email has been sent to your registered mail ID.");
    }
}

class NotifierDecorator : INotifier
{
    protected readonly INotifier notifier;

    public NotifierDecorator(INotifier notifier)
    {
        this.notifier = notifier;
    }

    public virtual void Send()
    {
        notifier.Send();
    }
}

class SMSNotifierDecorator : NotifierDecorator
{
    public SMSNotifierDecorator(INotifier notifier) : base(notifier) { }

    public override void Send()
    {
        base.Send(); // Important: call base to keep previous behavior
        Console.WriteLine("SMS has been sent.");
    }
}

class SlackNotifierDecorator : NotifierDecorator
{
    public SlackNotifierDecorator(INotifier notifier) : base(notifier) { }

    public override void Send()
    {
        base.Send(); // Important: call base to keep previous behavior
        Console.WriteLine("Slack has been sent.");
    }
}

class DecoratorPatternExample
{
    static void Main(string[] args)
    {
        INotifier notifier = new EmailNotifier();                          // Email
        notifier = new SMSNotifierDecorator(notifier);                    // + SMS
        notifier = new SlackNotifierDecorator(notifier);                  // + Slack

        notifier.Send();  // Should print all three
    }
}
