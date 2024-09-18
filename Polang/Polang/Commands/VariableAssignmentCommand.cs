namespace Polang.Commands
{
    public class VariableAssignmentCommand : ICommand
    {
        public LineNumber Execute(string line, int lineNumber, Dictionary<string, object> variables, ProgramState programState)
        {
            var variableName = line.Substring(KeyPhrases.VariableAssignment.Length).Split(' ')[0];

            var trail = line.Substring($"{KeyPhrases.VariableAssignment}{variableName} ".Length);

            object? value;
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

            return new LineNumber(lineNumber);
        }
    }
}
