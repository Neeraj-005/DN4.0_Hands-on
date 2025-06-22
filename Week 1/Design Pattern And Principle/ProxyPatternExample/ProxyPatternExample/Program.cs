interface Image
{
    void display();
}
class RealImage : Image
{
    private String filename;
    public  RealImage(String filename)
    {
        this.filename = filename; 
        load();
    }
    public void load()
    {
        Console.WriteLine($"Loading {filename}");
    }
    public void display() {
        Console.WriteLine($"Displaying {filename}");
    }
}
class ProxyImage : Image
{
    private RealImage realImage;
    private String filename;
    public ProxyImage(String filename)
    {
        this.filename = filename;
    }
    public  void display()
    {
        if (realImage == null) {
            realImage = new RealImage(filename);
        }
        
        
             realImage.display();
        
    }
    
}

class ProxyPatternExample
{
    public static void Main(String[] args)
    {
        var image = new ProxyImage("image.jpg");
        image.display();
        image.display();

    }
}