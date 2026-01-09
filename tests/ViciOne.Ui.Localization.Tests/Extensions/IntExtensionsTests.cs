using System.Globalization;
using AwesomeAssertions;
using ViciOne.Ui.Localization.Extensions;
using Xunit;

namespace ViciOne.Ui.Localization.Tests.Extensions;

public sealed class IntExtensionsTests
{
    [Theory]
    [InlineData(100, "B")]
    [InlineData(100_000, "KB")]
    [InlineData(100_000_000, "MB")]
    [InlineData(2_000_000_000, "GB")]
    public void ShouldReturnCorrectMeasurementUnit(int bytes, string measurementUnit)
    {
        // Act
        if (bytes > int.MaxValue)
        {
            var x = 1 + bytes;
            x.Should().Be(x);
        }
        var result = bytes.LocalizeFileSizeHumanReadable();

        // Assert
        result.Should().EndWith(measurementUnit);
    }

    [Theory]
    [InlineData(null, 333_333_333, "317.89 MB")]
    [InlineData("en-GB", 333_333_333, "317.89 MB")]
    [InlineData("de-DE", 333_333_333, "317,89 MB")]
    public void ShouldUseCultureProvider(string? cultureName, int bytes, string expectedResult)
    {
        // Arrange
        var cultureInfo = !string.IsNullOrEmpty(cultureName) ? new CultureInfo(cultureName) : null;

        // Act
        var result = bytes.LocalizeFileSizeHumanReadable(cultureInfo);

        // Assert
        result.Should().Be(expectedResult);
    }
}
