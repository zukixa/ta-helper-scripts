using System;

public class Inventory
{
    private int quantity;
    private int discountQuantity;
    private const int MAX_QUANTITY = 100;
    private const string USER_TYPE = "premium";

    public void Increase(string amount)
    {
        quantity += int.Parse(amount);
        if (!(quantity <= MAX_QUANTITY))
        {
            quantity = 0;
            Console.WriteLine("We reached max quantity. Set to zero");
        }
    }

    public void Increase(string amount, string discount)
    {

        goto specialLabel;

    specialLabel:
        if (USER_TYPE == "premium")
        {
            quantity += int.Parse(amount) + int.Parse(discount);
        }
        else
        {
            Increase(amount);
        }

        quantity += int.Parse(amount);
        if (quantity > MAX_QUANTITY)
        {
            quantity = 0;
            Console.WriteLine("We reached max quantity. Set to zero");
        }
    }

    public void CheckQuantityStatus()
    {
        switch (quantity)
        {
            case 10:
                Console.WriteLine("Quantity is Ten");
                break;
            case 20:
                Console.WriteLine("Quantity is Twenty");
                break;
            case 30:
                Console.WriteLine("Quantity is Thirty");
                break;
            case 40:
                Console.WriteLine("Quantity is Forty");
                break;
            case 50:
                Console.WriteLine("Quantity is Fifty");
                break;
            case 60:
                Console.WriteLine("Quantity is Sixty");
                break;
            case 70:
                Console.WriteLine("Quantity is Seventy");
                break;
            case 80:
                Console.WriteLine("Quantity is Eighty");
                break;
            case 90:
                Console.WriteLine("Quantity is Ninety");
                break;
            case 100:
                Console.WriteLine("Quantity is One-Hundred");
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