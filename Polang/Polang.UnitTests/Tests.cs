using FluentAssertions;
using System.Diagnostics;

namespace Polang.UnitTests
{
    public class Tests
    {
        [Fact]
        public void MissingStart()
        {
            RunProgram("MissingStart.po").Single().Should().Be("Error: " + ErrorMessages.MissingStart);
        }

        [Fact]
        public void MissingEnd()
        {
            RunProgram("MissingEnd.po").Single().Should().Be("Error: " + ErrorMessages.MissingEnd);
        }

        [Fact]
        public void HelloWorld()
        {
            RunProgram("HelloWorld.po").Single().Should().Be("Hello, world!");
        }

        [Fact]
        public void Variable()
        {
            RunProgram("Variable.po").Single().Should().Be("Naughty Noo-Noo!");
        }

        [Fact]
        public void TrueIfStatement()
        {
            RunProgram("IfStatementTrue.po").Single().Should().Be("It's Po!");
        }

        [Fact]
        public void FalseIfStatement()
        {
            RunProgram("IfStatementFalse.po").Should().BeEmpty();
        }

        [Fact]
        public void VariableReassignment()
        {
            RunProgram("VariableReassignment.po").Should().BeEquivalentTo(new[]
            {
                "Po",
                "Dipsy",
            });
        }

        [Fact]
        public void MathsAddition()
        {
            RunProgram("MathsAddition.po").Single().Should().Be("3");
        }

        [Fact]
        public void ForLoop()
        {
            RunProgram("ForLoop.po").Should().BeEquivalentTo(new[]
            {
                "1",
                "2",
                "3",
                "4",
                "5",
                "6",
                "7",
                "8",
                "9",
                "10",
            });
        }

        private string[] RunProgram(string poFile)
        {
            var process = new Process();
            process.StartInfo.FileName = "Polang.exe";
            process.StartInfo.Arguments = Path.Combine("TestPrograms", poFile);
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.Start();

            var output = process.StandardOutput.ReadToEnd();
            var outputLines = output.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            return outputLines;
        }
    }
}