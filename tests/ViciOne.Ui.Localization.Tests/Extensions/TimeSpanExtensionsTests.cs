using System;
using AwesomeAssertions;
using ViciOne.Ui.Localization.Extensions;
using Xunit;

namespace ViciOne.Ui.Localization.Tests.Extensions;

public sealed class TimeSpanExtensionsTests
{
    [Fact]
    public void ShouldLocalizeSingleDay()
    {
        // Arrange
        var dateTimeNow = DateTime.Now;
        var dateTimeFuture = dateTimeNow.AddDays(1.5);
        TimeSpan? timeSpan = dateTimeFuture - dateTimeNow;

        // Act
        var text = timeSpan.Localize();

        // Assert
        text.Should().StartWith("1 day, ");
    }

    [Fact]
    public void ShouldLocalizeMultipleDays()
    {
        // Arrange
        var dateTimeNow = DateTime.Now;
        var dateTimeFuture = dateTimeNow.AddDays(2.5);
        TimeSpan? timeSpan = dateTimeFuture - dateTimeNow;

        // Act
        var text = timeSpan.Localize();

        // Assert
        text.Should().StartWith("2 days, ");
    }

    [Fact]
    public void ShouldNotReturnDays()
    {
        // Arrange
        var dateTimeNow = DateTime.Now;
        var dateTimeFuture = dateTimeNow.AddDays(0.5);
        TimeSpan? timeSpan = dateTimeFuture - dateTimeNow;

        // Act
        var text = timeSpan.Localize();

        // Assert
        text.Should().NotContain("day");
    }

    [Fact]
    public void ShouldLocalizeSingleHour()
    {
        // Arrange
        var dateTimeNow = DateTime.Now;
        var dateTimeFuture = dateTimeNow.AddHours(1);
        TimeSpan? timeSpan = dateTimeFuture - dateTimeNow;

        // Act
        var text = timeSpan.Localize();

        // Assert
        text.Should().StartWith("1 hour, ");
    }

    [Fact]
    public void ShouldLocalizeMultipleHours()
    {
        // Arrange
        var dateTimeNow = DateTime.Now;
        var dateTimeFuture = dateTimeNow.AddHours(2);
        TimeSpan? timeSpan = dateTimeFuture - dateTimeNow;

        // Act
        var text = timeSpan.Localize();

        // Assert
        text.Should().StartWith("2 hours, ");
    }

    [Fact]
    public void ShouldNotReturnHours()
    {
        // Arrange
        var dateTimeNow = DateTime.Now;
        var dateTimeFuture = dateTimeNow.AddHours(0.5);
        TimeSpan? timeSpan = dateTimeFuture - dateTimeNow;

        // Act
        var text = timeSpan.Localize();

        // Assert
        text.Should().NotContain("hour");
    }

    [Fact]
    public void ShouldLocalizeSingleMinute()
    {
        // Arrange
        var dateTimeNow = DateTime.Now;
        var dateTimeFuture = dateTimeNow.AddMinutes(1);
        TimeSpan? timeSpan = dateTimeFuture - dateTimeNow;

        // Act
        var text = timeSpan.Localize();

        // Assert
        text.Should().StartWith("1 minute");
    }

    [Fact]
    public void ShouldLocalizeMultipleMinutes()
    {
        // Arrange
        var dateTimeNow = DateTime.Now;
        var dateTimeFuture = dateTimeNow.AddMinutes(2);
        TimeSpan? timeSpan = dateTimeFuture - dateTimeNow;

        // Act
        var text = timeSpan.Localize();

        // Assert
        text.Should().StartWith("2 minutes");
    }

    [Fact]
    public void ShouldNotReturnMinutes()
    {
        // Arrange
        var dateTimeNow = DateTime.Now;
        var dateTimeFuture = dateTimeNow.AddMinutes(0.5);
        TimeSpan? timeSpan = dateTimeFuture - dateTimeNow;

        // Act
        var text = timeSpan.Localize();

        // Assert
        text.Should().NotContain("minute");
    }

    [Fact]
    public void ShouldLocalizeSingleSecond()
    {
        // Arrange
        var dateTimeNow = DateTime.Now;
        var dateTimeFuture = dateTimeNow.AddSeconds(1);
        TimeSpan? timeSpan = dateTimeFuture - dateTimeNow;

        // Act
        var text = timeSpan.Localize();

        // Assert
        text.Should().StartWith("1 second");
    }

    [Fact]
    public void ShouldLocalizeMultipleSeconds()
    {
        // Arrange
        var dateTimeNow = DateTime.Now;
        var dateTimeFuture = dateTimeNow.AddSeconds(2);
        TimeSpan? timeSpan = dateTimeFuture - dateTimeNow;

        // Act
        var text = timeSpan.Localize();

        // Assert
        text.Should().StartWith("2 seconds");
    }
}
