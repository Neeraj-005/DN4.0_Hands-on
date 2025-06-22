interface Icommand
{
    void Execute();

}

class Light()
{
    public void turnon() {
        Console.WriteLine("Light is On");
    }
    public void turnoff() { 
        Console.WriteLine("Light is Off"); 
    }
}
class LightOnCommand : Icommand
{
    private Light light;
    public LightOnCommand(Light light)
    {
        this.light = light;
    }
    public void Execute()
    {
        light.turnon();
    }
   
}
class LightOffCommand : Icommand
{
    private Light light;
    public LightOffCommand(Light light)
    {
        this.light = light;
    }
    public void Execute()
    {
        light.turnoff();
    }
    
}
class RemoteControl
{
    private Icommand command;
    public void setcommand(Icommand command)
    {
        this.command = command;
    }
    public void pressbutton()
    {
        command.Execute();
    }
  

}

class CommandPatternExample
{
    public static void Main(string[] args)
    {
        Light light = new Light();
        Icommand lighton = new LightOnCommand(light);
        Icommand lightoff = new LightOffCommand(light);
        RemoteControl remote = new RemoteControl();
        remote.setcommand(lighton);
        remote.pressbutton();

        remote.setcommand(lightoff);
        remote.pressbutton();
    }
}