using System;
using System.Globalization;

namespace ViciOne.Ui.Localization.Extensions;

/// <summary>
/// Provides extension methods for the <see cref="long"/> type that return localized representations.
/// </summary>
public static class LongExtensions
{
    private const int Factor = 1024;

    /// <summary>
    /// Converts a file size in bytes to a human-readable string with appropriate unit suffix (B, KB, MB, GB, etc.).
    /// </summary>
    /// <param name="fileSize">The file size in bytes to format.</param>
    /// <param name="cultureInfo">The culture to use for number formatting. If <see langword="null"/>, <see cref="CultureInfo.InvariantCulture"/> is used.</param>
    /// <param name="numberFormat">The numeric format string to apply. Defaults to "F2" if <see langword="null"/>.</param>
    /// <returns>A human-readable string representing the <paramref name="fileSize"/> with the appropriate unit suffix.</returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="numberFormat"/> is not F or N format.</exception>
    /// <remarks>
    /// The optional <paramref name="numberFormat"/> accepts N, G or F according to
    /// <see href="https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings">standard numeric format strings</see>.
    /// Other formats make no sense for file sizes and will throw an <see cref="ArgumentException"/>.
    /// </remarks>
    public static string LocalizeFileSizeHumanReadable(this long fileSize, CultureInfo? cultureInfo = null, string? numberFormat = null)
    {
        if (fileSize < Factor) { return $"{fileSize} B"; }

        // https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings
        // N, G or F is allowed, other formats make no sense on file size
        if (!string.IsNullOrEmpty(numberFormat) && numberFormat[0] is not ('F' or 'N'))
            throw new ArgumentException("Only F and N formats are allowed.", nameof(numberFormat));

        var exp = (int)(Math.Log(fileSize) / Math.Log(Factor));
        var formatted = (fileSize / Math.Pow(Factor, exp)).ToString(numberFormat ?? "F2", cultureInfo ?? CultureInfo.InvariantCulture);

        return $"{formatted} {"KMGTPEZY"[exp - 1]}B";
    }
}
