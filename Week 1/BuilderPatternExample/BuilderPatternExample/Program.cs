using System;

class Computer
{
    public string CPU { get; }
    public int Ram { get; }
    public int Storage { get; }

    // Private constructor - only accessible via Builder
    private Computer(Builder builder)
    {
        CPU = builder.CPU;
        Ram = builder.Ram;
        Storage = builder.Storage;
    }

    // Nested Builder class
    public class Builder
    {
        public string CPU;
        public int Ram;
        public int Storage;

        public Builder SetCPU(string cpu)
        {
            this.CPU = cpu;
            return this;
        }

        public Builder SetRam(int ram)
        {
            this.Ram = ram;
            return this;
        }

        public Builder SetStorage(int storage)
        {
            this.Storage = storage;
            return this;
        }

        public Computer Build()
        {
            return new Computer(this);
        }
    }
}

class BuilderPatternExample
{
    static void Main(string[] args)
    {
        var myPc = new Computer.Builder()
            .SetCPU("Ryzen 7 7600X")
            .SetRam(16)
            .SetStorage(1024)
            .Build();

        Console.WriteLine("CPU: " + myPc.CPU);
        Console.WriteLine("RAM: " + myPc.Ram);
        Console.WriteLine("Storage: " + myPc.Storage + " GB");
    }
}
