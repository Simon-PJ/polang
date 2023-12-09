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