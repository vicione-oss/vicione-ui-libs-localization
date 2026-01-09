using System;
using System.Globalization;
using System.Text;
using ViciOne.Ui.Localization.Resources;

namespace ViciOne.Ui.Localization.Extensions;

/// <summary>
/// Provides extension methods for the <see cref="TimeSpan"/> type that return localized representations.
/// </summary>
public static class TimeSpanExtensions
{
    /// <summary>
    /// Converts the given <paramref name="timeSpan"/> into a localized human-readable string.
    /// </summary>
    /// <returns>
    /// <see cref="CommonVocabulary.Unknown"/> when the given <paramref name="timeSpan"/> is <see langword="null"/>, otherwise a localized string
    /// returned from <see cref="Localize(TimeSpan)"/>
    /// </returns>
    public static string Localize(this TimeSpan? timeSpan)
    {
        if (!timeSpan.HasValue)
            return CommonVocabulary.Unknown;

        return timeSpan.Value.Localize();
    }

    /// <summary>
    /// Converts the given <paramref name="timeSpan"/> into a localized human-readable string.
    /// </summary>
    /// <returns>
    /// Either a localized string with format '[[x full days, ]y hours, ]z minutes' when x, y or z is above zero
    /// otherwise a localized string with format 'x seconds'.
    /// </returns>
    public static string Localize(this TimeSpan timeSpan)
    {
        var stringBuilder = new StringBuilder();

        // Days
        var hasDays = false;

        var totalDays = timeSpan.TotalDays;
        if (totalDays > 1)
        {
            var totalFullDays = (uint)Math.Floor(totalDays);

            stringBuilder.AppendFormat(CultureInfo.CurrentCulture,
                totalFullDays == 1 ? CommonPatterns.SingleDay : CommonPatterns.MultipleDays,
                totalFullDays);

            hasDays = true;
        }

        // Hours
        var hasHours = false;

        var hours = timeSpan.Hours;

        if (hours > 0 || hasDays)
        {
            if (stringBuilder.Length > 0)
                stringBuilder.Append(", ");

            stringBuilder.AppendFormat(CultureInfo.CurrentCulture,
                hours == 1 ? CommonPatterns.SingleHour : CommonPatterns.MultipleHours,
                hours);

            hasHours = true;
        }

        // Minutes
        var minutes = timeSpan.Minutes;

        if (minutes > 0 || hasHours)
        {
            if (stringBuilder.Length > 0)
                stringBuilder.Append(", ");

            stringBuilder.AppendFormat(CultureInfo.CurrentCulture,
                minutes == 1 ? CommonPatterns.SingleMinute : CommonPatterns.MultipleMinutes,
                minutes);
        }

        // Seconds
        if (!hasDays && !hasHours && minutes < 1)
        {
            var seconds = Math.Ceiling(timeSpan.TotalSeconds);

            if (stringBuilder.Length > 0)
                stringBuilder.Append(", ");

            stringBuilder.AppendFormat(CultureInfo.CurrentCulture,
                seconds == 1 ? CommonPatterns.SingleSecond : CommonPatterns.MultipleSeconds,
                seconds);
        }

        return stringBuilder.ToString();
    }
}
