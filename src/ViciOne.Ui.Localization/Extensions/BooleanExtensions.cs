using ViciOne.Ui.Localization.Resources;

namespace ViciOne.Ui.Localization.Extensions;

/// <summary>
/// Provides extension methods for the <see cref="bool"/> type that return localized representations.
/// </summary>
public static class BooleanExtensions
{
    /// <summary>
    /// Converts the given <paramref name="value"/> into a localized yes / no representation.
    /// </summary>
    /// <returns>
    /// <see cref="CommonVocabulary.Yes"/> when <paramref name="value"/> is <see langword="true"/>, otherwise <see cref="CommonVocabulary.No"/>.
    /// </returns>
    public static string LocalizeYesNo(this bool value)
        => value ? CommonVocabulary.Yes : CommonVocabulary.No;
}
