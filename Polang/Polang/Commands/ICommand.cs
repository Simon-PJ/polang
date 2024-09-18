namespace Polang.Commands
{
    public interface ICommand
    {
        LineNumber Execute(string line, int lineNumber, Dictionary<string, object> variables, ProgramState programState);
    }
}
