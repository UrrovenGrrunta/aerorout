using Xunit;
using AeroRoute;

namespace AeroRoute.Tests;

public class ValidatorTests
{
    [Theory]
    [InlineData("egpd", "EGPD")]
    [InlineData("EgLl", "EGLL")]
    [InlineData(" EGPH ", "EGPH")]
    [InlineData("EGPF", "EGPF")]
    public void ValidateIcao_NormalizesValidInput(string input, string expected)
    {
        string result = Validators.ValidateIcao(input);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("egl")]
    [InlineData("UKBBB")]
    [InlineData("EG1D")]
    [InlineData("EG PD")]
    [InlineData("")]
    [InlineData("КGPD")]
    [InlineData(null)]
    public void ValidateIcao_RejectsInvalidInput(string? input)
    {
        Assert.Throws<ArgumentException>(() =>
            Validators.ValidateIcao(input)
        );
    }

}
