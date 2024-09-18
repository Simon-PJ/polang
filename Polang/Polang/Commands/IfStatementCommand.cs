namespace Polang.Commands
{
    public class IfStatementCommand : ICommand
    {
        public LineNumber Execute(string line, int lineNumber, Dictionary<string, object> variables, ProgramState programState)
        {
            var variableOne = line.Substring(KeyPhrases.IfStatement.Length).Split(' ')[0];
            var variableTwo = line.Substring(KeyPhrases.IfStatement.Length).Split(' ')[1];

            var valueOne = variables[variableOne];
            var valueTwo = variables[variableTwo];

            if (valueOne.Equals(valueTwo))
            {
                programState.IsInIfBlock = true;
            }

            return new LineNumber(lineNumber);
        }
    }
}
