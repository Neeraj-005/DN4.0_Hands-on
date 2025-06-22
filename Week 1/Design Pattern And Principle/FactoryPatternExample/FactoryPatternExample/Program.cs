using System;

// Interface
interface IDocumentTypes
{
    void Spec();
}

// Concrete implementations
class WordDocument : IDocumentTypes
{
    public void Spec()
    {
        Console.WriteLine("Word Document Created");
    }
}

class ExcelDocument : IDocumentTypes
{
    public void Spec()
    {
        Console.WriteLine("Excel Document Created");
    }
}

class PDFDocument : IDocumentTypes
{
    public void Spec()
    {
        Console.WriteLine("PDF Document Created");
    }
}

// Factory class
class DocumentFactory
{
    public IDocumentTypes CreateDocument(string str)
    {
        return str switch
        {
            "Word" => new WordDocument(),
            "Pdf" => new PDFDocument(),
            _ => new ExcelDocument()
        };
    }
}

// Main program
class FactoryMethodPatternExample
{
    static void Main(string[] args)
    {
        var factory = new DocumentFactory();
        factory.CreateDocument("Pdf").Spec();
        factory.CreateDocument("Word").Spec();
        factory.CreateDocument("Excel").Spec();
    }
}
