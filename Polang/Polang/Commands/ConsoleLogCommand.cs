namespace Polang.Commands
{
    public class ConsoleLogCommand : ICommand
    {
        public LineNumber Execute(string line, int lineNumber, Dictionary<string, object> variables, ProgramState programState)
        {
            var toBeEhOhed = line.Substring(KeyPhrases.ConsoleLog.Length);
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

            return new LineNumber(lineNumber);
        }
    }
}