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
    public void Should_return_correct_long_date_localization_when_date_is_not_null(string culture, string expected)
    {
        // Arrange
        CultureInfo.CurrentCulture = new CultureInfo(culture);

        // Act
        var result = _date.LocalizeFullDateLongTime();

        // Assert
        result.Should().Contain(expected);
    }

    [Fact]
    public void Should_return_unknown_when_date_is_null()
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
    public void Should_return_correct_short_date_localization(string culture, string expected)
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
    public void Should_return_correct_short_time_localization(string culture, string expected)
    {
        // Arrange
        CultureInfo.CurrentCulture = new CultureInfo(culture);

        // Act
        var result = _date.LocalizeShortTime();

        // Assert
        result.Should().Contain(expected);
    }

    [Fact]
    public void Should_return_correct_date_with_offset()
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
    public void Should_return_null_when_date_is_null()
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
