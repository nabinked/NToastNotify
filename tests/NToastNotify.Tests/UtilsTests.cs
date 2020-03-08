using System.Collections.Generic;
using NToastNotify.Helpers;
using Xunit;

namespace NToastNotify.Tests
{
    public class UtilsTests
    {
         [Fact]
        public void ShouldReturnDefaultValueWhenParamsAreNull()
        {
            //Arrange
            var expected = ExpectedDefaultValue.ToJson();

            //Act
            var result = Utils.GetLibraryDetails<ToastrLibrary>(null, null).ToJson();

            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(ScriptScrData))]
        public void ShouldCopyScriptSrc(string scriptSrc, string expected)
        {
            //Arrange
            var nToastNotifyOption = new NToastNotifyOption
            {
                ScriptSrc = scriptSrc
            };

            //Act
            var result = Utils.GetLibraryDetails<ToastrLibrary>(nToastNotifyOption, null);

            //Assert
            Assert.Equal(expected, result.ScriptSrc);
        }

        [Theory]
        [MemberData(nameof(StyleHrefData))]
        public void ShouldCopyStyleHref(string styleHref, string expected)
        {
            //Arrange
            var nToastNotifyOption = new NToastNotifyOption
            {
                StyleHref = styleHref
            };

            //Act
            var result = Utils.GetLibraryDetails<ToastrLibrary>(nToastNotifyOption, null);

            //Assert
            Assert.Equal(expected, result.StyleHref);
        }

        [Theory]
        [MemberData(nameof(DefaultOptionsData))]
        public void ShouldSetOptions(LibraryOptions libraryOptions, LibraryOptions expected)
        {
            //Act
            var result = Utils.GetLibraryDetails<ToastrLibrary>(null, libraryOptions);

            //Assert
            Assert.Equal(expected.ToJson(), result.Options.ToJson());
        }

        private static readonly ToastrLibrary ExpectedDefaultValue = new ToastrLibrary();
        private static readonly LibraryOptions ToastrOptions = new ToastrOptions();

        public static IEnumerable<object[]> ScriptScrData =>
            new List<object[]>
            {
                new object[] {null, ExpectedDefaultValue.ScriptSrc},
                new object[] {"", ExpectedDefaultValue.ScriptSrc},
                new object[] {"dummyValue", "dummyValue"}
            };

        public static IEnumerable<object[]> StyleHrefData =>
            new List<object[]>
            {
                new object[] {null, ExpectedDefaultValue.StyleHref},
                new object[] {"", ExpectedDefaultValue.StyleHref},
                new object[] {"dummyValue", "dummyValue"}
            };

        public static IEnumerable<object[]> DefaultOptionsData =>
            new List<object[]>
            {
                new object[] {null, ExpectedDefaultValue.Options},
                new object[] {ToastrOptions, ToastrOptions}
            };
    }
}