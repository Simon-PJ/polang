using Polang;

var poFile = args[0];

var lines = File.ReadAllLines(poFile).Where(line => !string.IsNullOrEmpty(line)).ToArray();

if (lines.First() != "Over the hills and faraway Teletubbies come to play")
{
    Console.WriteLine("Error: " + ErrorMessages.MissingStart);
    return;
}

if (lines.Last() != "The sun is setting in the sky, Teletubbies say goodbye")
{
    Console.WriteLine("Error: " + ErrorMessages.MissingEnd);
    return;
}

var variables = new Dictionary<string, object>();

foreach (var line in lines)
{
    if (line.StartsWith("Say eh-oh "))
    {
        var toBeEhOhed = line.Substring("Say eh-oh ".Length);
        var isString = toBeEhOhed.First() == '"' && toBeEhOhed.Last() == '"';

        if (isString)
        {
            Console.WriteLine(toBeEhOhed.Substring(1, toBeEhOhed.Length - 2));
        }
        else
        {
            var variableToBeEhOhed = variables[toBeEhOhed];
            Console.WriteLine(variableToBeEhOhed);
        }
    }
    else if (line.StartsWith("Time for "))
    {
        var variableName = line.Substring("Time for ".Length).Split(' ')[0];
        var initialValue = line.Substring($"Time for {variableName} ".Length).TrimEnd('\n').Trim('"');

        variables.Add(variableName, initialValue);
    }
}