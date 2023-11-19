using System;
using System.Collections.Generic;

class CodeSmellExample
{
    private int X; // Not descriptive about purpose of this variable
    private int Temp; // Temporary variables
    private int area; // No Consistent naming style as compared to variables above
    private List<int> dataList = new List<int>(); // Not being used anywhere, dead code

    public void LargeMethod()
    {
        string str;
        string tmp;
        for (int i = 0; i < 100; i++) // Magic number
        {
            str = "Data" + i;
            Console.WriteLine(str);
            for (int j = 0; j < 50; j++)
            { // Magic number
                tmp = "Interim Data" + j; // Duplicate code
                Console.WriteLine(tmp);

                // Following condition checks can be simplified or split into smaller methods
                if (i > 20 && j > 10 && (i + j) > 30 && ((j * 10) % 5) == 0)
                {
                    Console.WriteLine("Met condition for:" + i + " and " + j);
                }
                else
                {
                    Console.WriteLine("Not met condition");
                    Console.WriteLine("Data" + i);
                    Console.WriteLine("Interim Data" + j);
                    Console.WriteLine("Attempt: " + i * 10 + j * 5);
                }
            }
        }
        Console.WriteLine("Done with processing...");
    }

    private void ExtraCode()
    {
        X = 20;
        Temp = 10;
        areAComputator();
        X = Temp * 12; // Magic number
        Console.WriteLine(X);
    }

    private void areAComputator()
    {
        X = X * Temp * 13; // Magic number
        Boolean check = (X > 25) ? true : false;  // Unnecessary variable
        if (check == true)
        {    // Redundant comparison
            Temp = X * Temp;
        }
        area = Temp * 11; // Magic number
        Console.WriteLine(area);
    }

    // Following method is never used, it could be removed
    private int UnusedMethod()
    {
        Console.WriteLine("This method is never used");
        return 0;
    }
}