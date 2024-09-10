namespace Polang
{
    public class ProgramState
    {
        public bool IsInIfBlock { get; set; }

        public int? CurrentLoopStartLine { get; set; }

        public bool ExitingLoop { get; set; }
    }
}
