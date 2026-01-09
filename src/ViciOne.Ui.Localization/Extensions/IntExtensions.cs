using System.Globalization;

namespace ViciOne.Ui.Localization.Extensions;

/// <summary>
/// Extension methods for <see cref="int"/>
/// </summary>
public static class IntExtensions
{
    /// <inheritdoc cref="LongExtensions.LocalizeFileSizeHumanReadable(long, CultureInfo?, string?)"/>
    public static string LocalizeFileSizeHumanReadable(this int value, CultureInfo? cultureInfo = null, string? numberFormat = null)
        => ((long)value).LocalizeFileSizeHumanReadable(cultureInfo, numberFormat);
}
