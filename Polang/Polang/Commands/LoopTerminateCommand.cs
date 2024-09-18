namespace Polang.Commands
{
    public class LoopTerminateCommand : ICommand
    {
        public LineNumber Execute(string line, int lineNumber, Dictionary<string, object> variables, ProgramState programState)
        {
            programState.CurrentLoopStartLine = null;
            programState.ExitingLoop = true;

            return new LineNumber(lineNumber);
        }
    }
}
