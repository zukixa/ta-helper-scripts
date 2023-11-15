public class AdvancedCommandService
{
    // Variable naming shows some inconsistency
    // They are declared here but only 'command_title' will be used, making 'CommandTitle' a potential false positive for IDE0052
    string CommandTitle = "hello";
    string command_title;

    // Using "var" does not specify the type explicitly
    var commandKey = 'command_key';

    // Map could be made a constant, since it doesn't change. Should be a readonly field.
    Dictionary<string, string> commandMap = new Dictionary<string, string>
    {
        { "hello", "Hello, world!" },
        { "bye", "Goodbye, world!" },
    };

    // DRY principle ignored, could use commandMap instead of switch - False positive, switch may be clearer in some cases
    public string Execute(string command)
    {
        // Switch statement could have been consistent using modern C# switch expressions (IDE0066)
        switch (command)
        {
            case 'hello':
                return ExecuteHelloCommand();
            case 'bye':
                return ExecuteByeCommand();
            default:
                throw new Exception("Invalid command");
        }
    }
    // Unnecessary abstractions
    private string ExecuteHelloCommand()
    {
        command_title = "hello";
        return commandMap[command_title];
    }

    private string ExecuteByeCommand()
    {
        command_title = "bye";
        return commandMap[command_title];
    }
    // Unused code here: This method is never called
    public bool IsCommandInvalid(string command)
    {
        // Unnecessary value assignment (IDE0059)
        var valid = commandMap.ContainsKey(command);
        return !commandMap.ContainsKey(command);
    }
    public bool IsCommandValid(string command)
    {
        // Unnecessary value assignment (IDE0059)
        var valid = commandMap.ContainsKey(command);
        return commandMap.ContainsKey(command);
    }

    // Method has potential unnecessary abstraction. If the only use of it is to pass its result to Execute, consider restructuring
    public string GetResponse(string command)
    {
        var isValid = IsCommandValid(command);
        var response = string.Empty;

        if (isValid)
        {
            response = Execute(command);
        }
        else
        {
            throw new Exception("Invalid command");
        }

        // The use of Console.WriteLine here represents another issue in context - better communicated with more context-relevant Classes
        Console.WriteLine(response);

        return response;
    }
}
