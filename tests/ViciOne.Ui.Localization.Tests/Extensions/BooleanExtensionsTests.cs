using AwesomeAssertions;
using ViciOne.Ui.Localization.Extensions;
using ViciOne.Ui.Localization.Resources;
using Xunit;

namespace ViciOne.Ui.Localization.Tests.Extensions;

public sealed class BooleanExtensionsTests
{
    [Fact]
    public void ShouldReturnYes()
    {
        // Arrange
        const bool Value = true;

        // Act
        var text = Value.LocalizeYesNo();

        // Assert
        text.Should().Be(CommonVocabulary.Yes);
    }

    [Fact]
    public void ShouldReturnNo()
    {
        // Arrange
        const bool Value = false;

        // Act
        var text = Value.LocalizeYesNo();

        // Assert
        text.Should().Be(CommonVocabulary.No);
    }
}
