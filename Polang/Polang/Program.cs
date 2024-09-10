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
var programState = new ProgramState();

for (var i = 0; i < lines.Length; i++)
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

    if (line.StartsWith(KeyPhrases.SayEhOh))
    {
        var toBeEhOhed = line.Substring(KeyPhrases.SayEhOh.Length);
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
    else if (line.StartsWith(KeyPhrases.TimeFor))
    {
        var variableName = line.Substring(KeyPhrases.TimeFor.Length).Split(' ')[0];

        var trail = line.Substring($"{KeyPhrases.TimeFor}{variableName} ".Length);

        object? value = null;
        if (!trail.Contains("\"") && trail.Contains(" "))
        {
            value = (int)variables[trail.Split(' ')[0]] + (int)variables[trail.Split(' ')[1]];
        }
        else
        {
            value = trail.Contains("\"") ? trail.Trim('"') : int.Parse(trail);
        }

        if (!variables.ContainsKey(variableName))
        {
            variables.Add(variableName, value);
        }
        else
        {
            variables[variableName] = value;
        }
    }
    else if (line.StartsWith(KeyPhrases.WhatsThat))
    {
        var variableOne = line.Substring(KeyPhrases.WhatsThat.Length).Split(' ')[0];
        var variableTwo = line.Substring(KeyPhrases.WhatsThat.Length).Split(' ')[1];

        var valueOne = variables[variableOne];
        var valueTwo = variables[variableTwo];

        if (variables[variableOne].Equals(variables[variableTwo]))
        {
            programState.IsInIfBlock = true;
        }
    }
    else if (line.StartsWith(KeyPhrases.LoopStart))
    {
        programState.CurrentLoopStartLine = i + 1;
    }
    else if (line.StartsWith(KeyPhrases.LoopEnd) && programState.CurrentLoopStartLine.HasValue)
    {
        if (programState.ExitingLoop)
        {
            programState.ExitingLoop = false;
        }
        else
        {
            i = programState.CurrentLoopStartLine.Value - 1;
        }
    }
    else if (line.StartsWith(KeyPhrases.LoopTerminate))
    {
        programState.CurrentLoopStartLine = null;
        programState.ExitingLoop = true;
    }
}