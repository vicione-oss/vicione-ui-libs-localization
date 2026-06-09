using System;
using System.Globalization;
using AwesomeAssertions;
using ViciOne.Ui.Localization.Extensions;
using Xunit;

namespace ViciOne.Ui.Localization.Tests.Extensions;

public sealed class LongExtensionsTests
{
    [Theory]
    [InlineData(100L, "B")]
    [InlineData(100_000L, "KB")]
    [InlineData(100_000_000L, "MB")]
    [InlineData(100_000_000_000L, "GB")]
    [InlineData(100_000_000_000_000L, "TB")]
    public void Should_return_correct_measurement_unit(long bytes, string measurementUnit)
    {
        // Act
        var result = bytes.LocalizeFileSizeHumanReadable();

        // Assert
        result.Should().EndWith(measurementUnit);
    }

    [Theory]
    [InlineData(null, 333_333_333L, "317.89 MB")]
    [InlineData("en-GB", 333_333_333L, "317.89 MB")]
    [InlineData("de-DE", 333_333_333L, "317,89 MB")]
    public void Should_use_culture_provider(string? cultureName, int bytes, string expectedResult)
    {
        // Arrange
        var cultureInfo = !string.IsNullOrEmpty(cultureName) ? new CultureInfo(cultureName) : null;

        // Act
        var result = bytes.LocalizeFileSizeHumanReadable(cultureInfo);

        // Assert
        result.Should().Be(expectedResult);
    }

    [Theory]
    [InlineData(null, 333_333_333L, "317.89 MB")]
    [InlineData("F0", 333_333_333L, "318 MB")]
    [InlineData("F1", 333_333_333L, "317.9 MB")]
    [InlineData("F2", 333_333_333L, "317.89 MB")]
    [InlineData("F3", 333_333_333L, "317.891 MB")]
    [InlineData("N0", 333_333_333L, "318 MB")]
    [InlineData("N1", 333_333_333L, "317.9 MB")]
    public void Should_use_number_format(string? numberFormat, int bytes, string expectedResult)
    {
        // Act
        var result = bytes.LocalizeFileSizeHumanReadable(numberFormat: numberFormat);

        // Assert
        result.Should().Be(expectedResult);
    }

    [Theory]
    [InlineData("B")]
    [InlineData("C")]
    [InlineData("D")]
    [InlineData("E")]
    [InlineData("P")]
    [InlineData("R")]
    [InlineData("X")]
    public void Should_throw_argument_exception_on_unsupported_formats(string? numberFormat)
    {
        // Arrange
        Action action = () => _ = 333_333_333L.LocalizeFileSizeHumanReadable(numberFormat: numberFormat);

        // Act + Assert
        action.Should().Throw<ArgumentException>();
    }
}
