using System;

public class BaseRocket
{ // poor class name, not describing which type of rocket
    protected int maxAlt = 10000; // Abbreviated variable name
    public int altitude;  // Violating encapsulation, altitude should be private or protected

    public virtual void Launch()
    { // This method is not handling any base launch logic but provides an implementation
        Console.WriteLine("Base rocket launch. This should never appear!");
    }

    // Overloading of operators for no clear benefit
    public static BaseRocket operator +(BaseRocket a, BaseRocket b)
    {
        return new BaseRocket();
    }
}

public class Rocket : BaseRocket
{
    private bool isLaunched = false; // Nested dependencies, other classes need to check launched status

    public new void Launch()
    { // poor argument passing, launch could take an argument to set height
        Console.WriteLine("Rocket launch!");
        altitude = maxAlt; // No use of 'const' where appropriate, altitude set to hardcoded maximum
        isLaunched = true;
    }

    public void Land()
    { // Too much code in one method, landing and resetting could be separate functions
        Console.WriteLine("Rocket land!");
        altitude = 0;
        isLaunched = false;
    }

    public BaseRocket CombineRockets(Rocket rocketTwo) // Method doing more than one thing
    {
        var newRocket = this + rocketTwo; // Using operator overloading, creates potential for confusion
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
        myRocket.Land();

        BaseRocket combinedRocket = myRocket.CombineRockets(anotherRocket); // Rigidity, only works with Rocket instances
    }
}