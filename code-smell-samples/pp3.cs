public class ComprehensiveScoreService
{
    // Inconsistent naming convention
    public int Score;
    public int another_score;

    /* Unnecessary constants - if it's only used once, it may not be a very useful constant,
     * would be better defined inside CalculatePercentage method
     */
    const double maxPercentage = 100.00;

    // List of students' scores
    List<int> scoresList = new List<int>();

    // 'var' hides the type of the dictionary
    var studentScores = new Dictionary<int, int>(); // student-id, score

    public double CalculatePercentage(int obtainedScore, int totalScore)
    {
        // Unnecessary value assignment and inconsistent declaration (IDE0059)
        double percentage = obtainedScore / totalScore * maxPercentage;
        return obtainedScore / totalScore * maxPercentage;
    }

    public void UpdateScore(int studentId, int score)
    {
        /* Update values and add score to scoresList.
         * In a method like this, you'd likely want to ensure that the dictionary 
         * 'studentScores' indeed has the studentId as a key before performing the update.
         */
        var oldScore = studentScores[studentId];
        studentScores[studentId] = score;
        scoresList.Add(score);
    }

    // Adherence to DRY principles can be questioned here.
    public void GenerateReport(int studentId)
    {
        var studentScore = studentScores[studentId];
        double percentage = studentScore / Score * maxPercentage;

        // Console.WriteLine in production code and in a test case, makes no sense.
        Console.WriteLine($"Student {studentId} score is: {percentage}%");

        // Poorly aligned responsibility: Throwing exception for condition seems odd.
        if (percentage < 40)
            throw new Exception("Score is less than passing score");
    }

    // A 'using' statement with no practical use in the code
    using var _ = new StringWriter();
}

public class ComprehensiveScoreServiceTest
{
    private readonly ComprehensiveScoreService _service = new ComprehensiveScoreService();

    [Fact]
    // Test method name could be more descriptive (IDE1006)
    public void Test_StudentScorePercentage()
    {
        const int studentId = 1;
        const int obtainedScore = 90;
        const int total = 100;
        _service.UpdateScore(studentId, obtainedScore);
        var result = _service.CalculatePercentage(obtainedScore, total);
        _service.GenerateReport(studentId)

        // Assert does what the writeline below doesnt.
        Assert.Equal(90.0, result);

        // Console.WriteLine never prints on failure.
        Console.WriteLine($"The result: is {result}");
    }
}