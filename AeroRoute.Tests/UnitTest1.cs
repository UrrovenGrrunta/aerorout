using Xunit;
using AeroRoute;

namespace AeroRoute.Tests;

public class ProgramTests
{
    [Fact]
    public void Main_PrintsWelcomeMessage()
    {
        // Arrange
        var writer = new StringWriter();
        TextWriter originalOutput = Console.Out;

        try
        {
            Console.SetOut(writer);

            // Act
            Program.Main(Array.Empty<string>());

            // Assert
            Assert.Equal(
                "AeroRoute v0.1" + Environment.NewLine,
                writer.ToString()
            );
        }
        finally
        {
            Console.SetOut(originalOutput);
        }
    }
}