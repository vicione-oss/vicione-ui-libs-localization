using System;
using System.Globalization;
using System.Runtime.InteropServices;
using AwesomeAssertions;
using ViciOne.Ui.Localization.Extensions;
using ViciOne.Ui.Localization.Resources;
using Xunit;

namespace ViciOne.Ui.Localization.Tests.Extensions;

public sealed class DateTimeOffsetExtensionsTests
{
    private readonly DateTimeOffset _date = new(2025, 10, 16, 11, 30, 0, TimeSpan.Zero);

    [Theory]
    [InlineData("de-DE", "16. Oktober 2025")]
    [InlineData("en-US", "October 16, 2025")]
    public void ShouldReturnCorrectLongDateLocalizationWhenDateIsNotNull(string culture, string expected)
    {
        // Arrange
        CultureInfo.CurrentCulture = new CultureInfo(culture);

        // Act
        var result = _date.LocalizeFullDateLongTime();

        // Assert
        result.Should().Contain(expected);
    }

    [Fact]
    public void ShouldReturnUnknownWhenDateIsNull()
    {
        // Arrange
        DateTimeOffset? date = null;

        // Act
        var result = date.LocalizeFullDateLongTime();

        // Assert
        result.Should().Be(CommonVocabulary.Unknown);
    }

    [Theory]
    [InlineData("de-DE", "16.10.2025")]
    [InlineData("en-US", "10/16/2025")]
    public void ShouldReturnCorrectShortDateLocalization(string culture, string expected)
    {
        // Arrange
        CultureInfo.CurrentCulture = new CultureInfo(culture);

        // Act
        var result = _date.LocalizeShortDate();

        // Assert
        result.Should().Contain(expected);
    }

    [Theory]
    [InlineData("de-DE", "11:30")]
    [InlineData("en-US", "AM")]
    public void ShouldReturnCorrectShortTimeLocalization(string culture, string expected)
    {
        // Arrange
        CultureInfo.CurrentCulture = new CultureInfo(culture);

        // Act
        var result = _date.LocalizeShortTime();

        // Assert
        result.Should().Contain(expected);
    }

    [Fact]
    public void ShouldReturnCorrectDateWithOffset()
    {
        // Arrange
        var timeZone = TimeZoneInfo.FindSystemTimeZoneById(
            RuntimeInformation.IsOSPlatform(OSPlatform.Linux)
                ? "Europe/Berlin"
                : "W. Europe Standard Time");

        // Act
        var adjusted = _date.AdjustToTimeZone(timeZone);

        // Assert
        adjusted.Hour.Should().Be(13);
    }

    [Fact]
    public void ShouldReturnNullWhenDateIsNull()
    {
        // Arrange
        DateTimeOffset? date = null;
        var tz = TimeZoneInfo.Utc;

        // Act
        var result = date.AdjustToTimeZone(tz);

        // Assert
        result.Should().BeNull();
    }
}
