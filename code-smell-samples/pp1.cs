public class StatisticsService
{
    // Variable naming is in two styles which is inconsistent
    public int MaxScore;
    public int min_score;

    // 'var' keyword does not specify the type explicitly
    var publicString = "hello";

    // Simplifying object declaration: Direct initialization can be used
    List<int> Numbers = new List<int>();

    // Method name is not following the expected naming convention
    public string calculate_averageScore(int totalScore, int numberOfStudents)
    {
        // Redundant casts to double (IDE0004)
        var average = (double)totalScore / (double)numberOfStudents;

        // Console.WriteLine used in backend code
        Console.WriteLine("Average calculated");

        // Immediately wraps the float in ToString, despite the proper return type being float
        return average.ToString();
    }

    // Method name is unclear and vague, could be more descriptive (IDE1006)
    public int FindValue(string value)
    {
        // Loop could be replaced with LINQ for simplicity and efficiency
        for (int i = 0; i < publicString.Length; i++)
            if (publicString[i].ToString() == value)
                return i;

        // Using 'Bad Object' as returns - Instead throw an Exception
        return 0;
    }

    // Unused code: This method is never called
    public void PrintMaxMin()
    {
        Console.WriteLine($"Maximum score: {MaxScore}, Minimum score: {min_score}");
    }

    // Unused 'usings' that are not useful in this context
    using System.Drawing;
    using System.Threading.Tasks;

    public void UpdateScore(int score, int studentId)
{
    /* There are two issues here:
     * 1. Unnecessary value assignment - Old value of MaxScore/min_score is retrieved, unnecessary database call:
     *    - This is a false positive, it's not necessarily wrong, maybe the value in the database is updated elsewhere and not in memory.
     * 2. DRY priniciple violation with score > MaxScore and score < min_score checks - 
     *    - This is also a false positive, everyone would do this check twice in the real world, even if it seems to be repeating
     */
    var oldMax = MaxScore;
    var oldMin = min_score;

    if (score > oldMax)
    {
        MaxScore = score;
        Console.WriteLine("New maximum score!");
    }

    if (score < oldMin)
    {
        min_score = score;
        Console.WriteLine("New minimum score!");
    }

    // Perform database update with the new MaxScore/min_score
    // For students to find: "this code would likely be hidden in a real world example, we made it too easy for demonstration purpose!"
    Console.WriteLine("Updating in database...");
}
}
