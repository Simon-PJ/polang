namespace Polang.Commands
{
    public class LoopStartCommand : ICommand
    {
        public LineNumber Execute(string line, int lineNumber, Dictionary<string, object> variables, ProgramState programState)
        {
            programState.CurrentLoopStartLine = lineNumber + 1;

            return new LineNumber(lineNumber); 
        }
    }
}
