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
    [Theory]
    [InlineData("250", 250.0)]
    [InlineData(" 180 ", 180.0)]
    [InlineData ("0.5", 0.5)]
    public void ValidateSpeed_SpeedConvertsToDouble(string? input, double expected)
    {
        double result = Validators.ValidateGroundSpeed(input);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("0")]
    [InlineData("-50")]
    [InlineData("abc")]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("NaN")]
    [InlineData("Infinity")]
    public void ValidateSpeed_RejectsIncorrectValues(string? input)
    {
        Assert.Throws<ArgumentException>(() =>
            Validators.ValidateGroundSpeed(input)
        );
    }

}
