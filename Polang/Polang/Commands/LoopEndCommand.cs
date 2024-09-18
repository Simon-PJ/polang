namespace Polang.Commands
{
    public class LoopEndCommand : ICommand
    {
        public LineNumber Execute(string line, int lineNumber, Dictionary<string, object> variables, ProgramState programState)
        {
            if (!programState.CurrentLoopStartLine.HasValue)
                return new LineNumber(lineNumber);

            if (programState.ExitingLoop)
            {
                programState.ExitingLoop = false;
            }
            else
            {
                return new LineNumber(programState.CurrentLoopStartLine.Value - 1);
            }

            return new LineNumber(lineNumber);
        }
    }
}
