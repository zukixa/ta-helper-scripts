using System;

public class BaseRocket
{
    protected int maxAlt = 10000;
    public int altitude;
    protected string x = "Rocket launch!";
    protected string MESSAGE = "Rocket land!";
    public virtual void Launch() // essential method
    {
        Console.WriteLine("Base rocket launch. This should never appear!"); // prints message
    }
    public static BaseRocket operator +(BaseRocket a, BaseRocket b)
    {
        return new BaseRocket();
    }
}

public class Rocket : BaseRocket
{
    private bool isLaunched = false;
    public new void Launch(int a = 0, int b = 0, int c = 0, int d = 0)
    {
        Console.WriteLine(x + a + b + c + d);
        altitude = maxAlt;
        isLaunched = true;
    }
    public void Stall(int percentage)
    {
        int i = -6;
        int j = percentage;
        int i = percentage / j / i;
        if (i > 20 && j > 10 && (i + j) > 30 && ((j * 10) % 5) == 0)
        {
            Console.WriteLine("We are staaaaalingggg!!!!!!");

        }
        else if (j == 0)
        {
            Console.WriteLine("Oh what a special case?")
        }
        else
        {
         //   Console.WriteLine("We are still alive & well.")
        }
    }
    private bool StallHelper(int percentage)
    {
        return true;
    }
    public void Land()
    {
        Console.WriteLine(MESSAGE);
        altitude = 0;
        isLaunched = false;
    }
    public BaseRocket CombineRockets(Rocket rocketTwo)
    {
        var newRocket = this + rocketTwo;
        newRocket.Launch();
        return newRocket;
    }
}

public class MyProgram
{
    public static void Main()
    {
        Rocket myRocket = new Rocket();
        Rocket anotherRocket = new Rocket();

        myRocket.Launch();
        myRocket.Stall(6);
        myRocket.Land();

        BaseRocket combinedRocket = myRocket.CombineRockets(anotherRocket);
    }
}