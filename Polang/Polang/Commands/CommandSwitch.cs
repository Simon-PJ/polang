namespace Polang.Commands
{
    public static class CommandSwitch
    {
        private static Dictionary<string, ICommand> commands = new()
        {
            { KeyPhrases.ConsoleLog, new ConsoleLogCommand() },
            { KeyPhrases.VariableAssignment, new VariableAssignmentCommand() },
            { KeyPhrases.IfStatement, new IfStatementCommand() },
            { KeyPhrases.LoopStart, new LoopStartCommand() },
            { KeyPhrases.LoopEnd, new LoopEndCommand() },
            { KeyPhrases.LoopTerminate, new LoopTerminateCommand() },
        };

        public static ICommand GetRelevantCommand(string line)
        {
            foreach (var commandKey in commands.Keys)
            {
                if (line.StartsWith(commandKey))
                {
                    return commands[commandKey];
                }
            }

            throw new PolangException($"No matching Polang keywords for line: {line}");
        }
    }
}
