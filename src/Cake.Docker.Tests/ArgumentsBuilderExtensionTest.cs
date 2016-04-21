using Cake.Docker;
using Cake.Core.IO;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Cake.Docker.Tests
{
    public class ArgumentsBuilderExtensionTest
    {
        public static PropertyInfo StringProperty => GetProperty(nameof(TestSettings.String));
        public static PropertyInfo StringsProperty => GetProperty(nameof(TestSettings.Strings));
        public static PropertyInfo NullableIntProperty => GetProperty(nameof(TestSettings.NullableInt));
        public static PropertyInfo BoolProperty => GetProperty(nameof(TestSettings.Bool));
        public static PropertyInfo GetProperty(string name)
        {
            return typeof(TestSettings).GetProperty(name, BindingFlags.Public | BindingFlags.Instance);
        }
        [TestFixture]
        public class GetArgumentFromBoolProperty
        {
            [Test]
            public void WhenTrue_FormatsProperly()
            {
                var actual = ArgumentsBuilderExtension.GetArgumentFromBoolProperty(BoolProperty, true);

                Assert.That(actual, Is.EqualTo("--bool"));
            }
            [Test]
            public void WhenFalse_NullIsReturned()
            {
                var actual = ArgumentsBuilderExtension.GetArgumentFromBoolProperty(BoolProperty, false);

                Assert.That(actual, Is.Null);
            }
        }
        [TestFixture]
        public class GetArgumentFromStringProperty
        {
            [Test]
            public void WhenGivenStringProperty_FormatsProperly()
            {
                var actual = ArgumentsBuilderExtension.GetArgumentFromStringProperty(StringProperty, "tubo");

                Assert.That(actual, Is.EqualTo("--string=\"tubo\""));
            }
            [Test]
            public void WhenGivenNull_NullIsReturned()
            {
                var actual = ArgumentsBuilderExtension.GetArgumentFromStringProperty(StringProperty, null);

                Assert.That(actual, Is.Null);
            }
        }
        [TestFixture]
        public class GetArgumentFromStringArrayProperty
        {
            [Test]
            public void WhenGivenStringArrayProperty_FormatsProperly()
            {
                var actual = ArgumentsBuilderExtension.GetArgumentFromStringArrayProperty(StringsProperty, new string[] { "tubo1", "tubo2" });

                Assert.AreEqual(actual.ToArray(), new string[] { "--strings=\"tubo1\"", "--strings=\"tubo2\"" }); 
            }
            [Test]
            public void WhenGivenNull_EmptyArrayReturned()
            {
                var actual = ArgumentsBuilderExtension.GetArgumentFromStringArrayProperty(StringsProperty, null);

                Assert.That(actual, Is.Empty);
            }
        }
        [TestFixture]
        public class GetArgumentFromDictionaryProperty
        {
            [Test]
            public void WhenGivenStringArrayProperty_FormatsProperly()
            {
                var actual = ArgumentsBuilderExtension.GetArgumentFromDictionaryProperty(StringsProperty, new Dictionary<string, string> { { "t1", "v1" }, { "t2", "v2" } });

                Assert.AreEqual(actual.ToArray(), new string[] { "--strings=\"t1=v1\"", "--strings=\"t2=v2\"" });
            }
            [Test]
            public void WhenGivenNull_EmptyArrayReturned()
            {
                var actual = ArgumentsBuilderExtension.GetArgumentFromDictionaryProperty(StringsProperty, null);

                Assert.That(actual, Is.Empty);
            }
        }
        [TestFixture]
        public class GetArgumentFromNullableIntProperty
        {
            [Test]
            public void WhenGivenValue_FormatsProperly()
            {
                var actual = ArgumentsBuilderExtension.GetArgumentFromNullableIntProperty(NullableIntProperty, 5);

                Assert.That(actual, Is.EqualTo("--nullable-int=5"));
            }

            [Test]
            public void WhenGivenNull_NullIsReturned()
            {
                var actual = ArgumentsBuilderExtension.GetArgumentFromNullableIntProperty(NullableIntProperty, null);

                Assert.That(actual, Is.Null);
            }
        }

        [TestFixture]
        public class GetPropertyName
        {
            [TestCase("Name", ExpectedResult = "name")]
            [TestCase("NameExtended", ExpectedResult = "name-extended")]
            public string WhenInput_ReturnsCorrectlyFormatted(string name)
            {
                return ArgumentsBuilderExtension.GetPropertyName(name);
            }
        }

        [TestFixture]
        public class AppendAll
        {
            [Test]
            public void WhenStringInput_AddsAsArgument()
            {
                TestSettings input = new TestSettings { String = "tubo" };

                ProcessArgumentBuilder builder = new ProcessArgumentBuilder();
                builder.AppendAll("cmd", input, new string[] { "arg1" });
                var actual = builder.Render();

                Assert.That(actual, Is.EqualTo("cmd --string=\"tubo\" arg1"));
            }

        }
    }

    public class TestSettings: AutoToolSettings
    {
        public string String { get; set; }
        public string[] Strings { get; set; }
        public int? NullableInt { get; set; }
        public bool Bool { get; set; }
    }
}
