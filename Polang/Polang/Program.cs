﻿using Polang;

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

foreach (var rawLine in lines)
{
    var line = rawLine;

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
        var initialValue = line.Substring($"{KeyPhrases.TimeFor}{variableName} ".Length).Trim('"');

        if (!variables.ContainsKey(variableName))
        {
            variables.Add(variableName, initialValue);
        }
        else
        {
            variables[variableName] = initialValue;
        }
    }
    else if (line.StartsWith(KeyPhrases.WhatsThat))
    {
        var variableOne = line.Substring(KeyPhrases.WhatsThat.Length).Split(' ')[0];
        var variableTwo = line.Substring(KeyPhrases.WhatsThat.Length).Split(' ')[1];

        if (variables[variableOne].Equals(variables[variableTwo]))
        {
            programState.IsInIfBlock = true;
        }
    }
}