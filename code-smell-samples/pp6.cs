using System;

public class Inventory // Excessive class size, doing multiple responsibilities
{
    private int quantity;
    private int discountQuantity; // Contingent state, presence of discount depends on quantity
    private const int MAX_QUANTITY = 100;
    private const string USER_TYPE = "premium"; // Stringly-typed code

    public void Increase(string amount) // Stringly-typed code, lack of error-checking return codes.
    {
        quantity += int.Parse(amount); // no exception handling 
        if (quantity > MAX_QUANTITY)
        {
            quantity = 0; // use of null to represent key states.
            Console.WriteLine("We reached max quantity. Set to zero"); // no use of asserts in the code.
        }
    }

    public void Increase(string amount, string discount) // overloading without clear difference
    {
        // Additional code and multiple exit points
        goto specialLabel; // usage of goto leading to discontinuous control flow

    specialLabel:
        if (USER_TYPE == "premium")
        {
            quantity += int.Parse(amount) + int.Parse(discount);
        }
        else
        {
            Increase(amount); // recursive call
        }
        // duplicate code
        quantity += int.Parse(amount); // no exception handling 
        if (quantity > MAX_QUANTITY)
        {
            quantity = 0; // use of null to represent key states.
            Console.WriteLine("We reached max quantity. Set to zero"); // no use of asserts in the code.
        }
    }

    public void CheckQuantityStatus() // huge switch statement
    {
        switch (quantity)
        {
            case 10:
                Console.WriteLine("Quantity is 10");
                break;
            case 20:
                Console.WriteLine("Quantity is 20");
                break;
            case 30:
                Console.WriteLine("Quantity is 30");
                break;
            case 40:
                Console.WriteLine("Quantity is 40");
                break;
            case 50:
                Console.WriteLine("Quantity is 50");
                break;
            case 60:
                Console.WriteLine("Quantity is 60");
                break;
            case 70:
                Console.WriteLine("Quantity is 70");
                break;
            case 80:
                Console.WriteLine("Quantity is 80");
                break;
            case 90:
                Console.WriteLine("Quantity is 90");
                break;
            case 100:
                Console.WriteLine("Quantity is 100");
                break;
            default:
                break;
        }
    }
}

public class MyProgram
{
    public static void Main()
    {
        Inventory iv = new Inventory();
        iv.Increase("10");
        iv.Increase("30", "10");
        iv.CheckQuantityStatus();
    }
}