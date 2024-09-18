using Polang;
using Polang.Commands;

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
var programState = new ProgramState();

for (var i = 1; i < lines.Length - 1; i++)
{
    var line = lines[i];

    if (line.StartsWith('\t') && !programState.IsInIfBlock)
    {
        continue;
    }

    if (line.StartsWith('\t'))
    {
        line = line.Substring(1);
    }
    else
    {
        programState.IsInIfBlock = false;
    }

    var command = CommandSwitch.GetRelevantCommand(line);
    i = command.Execute(line, i, variables, programState).Value;
}