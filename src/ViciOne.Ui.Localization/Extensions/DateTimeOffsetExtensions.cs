using System;
using System.Globalization;
using ViciOne.Ui.Localization.Resources;

namespace ViciOne.Ui.Localization.Extensions;

/// <summary>
/// Provides extension methods for the <see cref="DateTimeOffset"/> type that return localized date / time representations.
/// </summary>
public static class DateTimeOffsetExtensions
{
    /// <summary>
    /// Converts the given <paramref name="dateTimeOffset"/> into its localized full date long time string
    /// using <see cref="CultureInfo.CurrentCulture"/> as a format provider.
    /// </summary>
    /// <returns>
    /// <see href="https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings#FullDateLongTime">Full date long time</see>
    /// when <paramref name="dateTimeOffset"/> is not null, otherwise <see cref="CommonVocabulary.Unknown"/>.
    /// </returns>
    public static string LocalizeFullDateLongTime(this DateTimeOffset? dateTimeOffset)
        => dateTimeOffset.HasValue ? dateTimeOffset.Value.LocalizeFullDateLongTime() : CommonVocabulary.Unknown;

    /// <summary>
    /// Converts the given <paramref name="dateTimeOffset"/> into its localized full date long time string
    /// using <see cref="CultureInfo.CurrentCulture"/> as a format provider.
    /// </summary>
    /// <returns>
    /// <see href="https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings#FullDateLongTime">Full date long time</see>
    /// </returns>
    public static string LocalizeFullDateLongTime(this DateTimeOffset dateTimeOffset)
        => dateTimeOffset.ToString("F", CultureInfo.CurrentCulture);

    /// <summary>
    /// Converts the given <paramref name="dateTimeOffset"/> into its localized short date string
    /// using <see cref="CultureInfo.CurrentCulture"/> as a format provider.
    /// </summary>
    /// <returns>
    /// <see href="https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings#ShortDate">Short date</see>
    /// </returns>
    public static string LocalizeShortDate(this DateTimeOffset dateTimeOffset)
        => dateTimeOffset.ToString("d", CultureInfo.CurrentCulture);

    /// <summary>
    /// Converts the given <paramref name="dateTimeOffset"/> into its localized short time string
    /// using <see cref="CultureInfo.CurrentCulture"/> as a format provider.
    /// </summary>
    /// <returns>
    /// <see href="https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings#ShortTime">Short time</see>
    /// </returns>
    public static string LocalizeShortTime(this DateTimeOffset dateTimeOffset)
        => dateTimeOffset.ToString("t", CultureInfo.CurrentCulture);

    /// <summary>
    /// Adjusts the given <paramref name="dateTimeOffset"/> to the specified <paramref name="timeZone"/>.
    /// </summary>
    /// <returns>
    /// <see cref="DateTimeOffset"/> adjusted to the specified <paramref name="timeZone"/> if <paramref name="dateTimeOffset"/> is not <see langword="null"/>,
    /// otherwise <see langword="null"/>.
    /// </returns>
    public static DateTimeOffset? AdjustToTimeZone(this DateTimeOffset? dateTimeOffset, TimeZoneInfo timeZone)
    {
        if (dateTimeOffset is null)
            return null;

        return dateTimeOffset.Value.AdjustToTimeZone(timeZone);
    }

    /// <summary>
    /// Adjusts the given <paramref name="dateTimeOffset"/> to the specified <paramref name="timeZone"/>.
    /// </summary>
    /// <returns>
    /// <see cref="DateTimeOffset"/> adjusted to the specified <paramref name="timeZone"/>.
    /// </returns>
    public static DateTimeOffset AdjustToTimeZone(this DateTimeOffset dateTimeOffset, TimeZoneInfo timeZone)
        => TimeZoneInfo.ConvertTimeFromUtc(dateTimeOffset.UtcDateTime, timeZone);
}
