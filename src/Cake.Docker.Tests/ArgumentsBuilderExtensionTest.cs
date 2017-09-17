using Cake.Core.IO;
using NUnit.Framework;
using System;
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
        public static PropertyInfo NullableInt64Property => GetProperty(nameof(TestSettings.NullableInt64));
        public static PropertyInfo NullableUInt64Property => GetProperty(nameof(TestSettings.NullableUInt64));
        public static PropertyInfo NullableBoolProperty => GetProperty(nameof(TestSettings.NullableBool));
        public static PropertyInfo NullableTimeSpanProperty => GetProperty(nameof(TestSettings.NullableTimeSpan));
        public static PropertyInfo BoolProperty => GetProperty(nameof(TestSettings.Bool));
        public static PropertyInfo DecoratedStringProperty => GetProperty(nameof(TestSettings.DecoratedString));
        public static PropertyInfo DecoratedBoolProperty => GetProperty(nameof(TestSettings.DecoratedBool));
        public static PropertyInfo DecoratedStringsProperty => GetProperty(nameof(TestSettings.DecoratedStrings));
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

                Assert.That(actual, Is.EqualTo("--string \"tubo\""));
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

                Assert.AreEqual(actual.ToArray(), new string[] { "--strings \"tubo1\"", "--strings \"tubo2\"" }); 
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

                Assert.AreEqual(actual.ToArray(), new string[] { "--strings \"t1=v1\"", "--strings \"t2=v2\"" });
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

                Assert.That(actual, Is.EqualTo("--nullable-int 5"));
            }

            [Test]
            public void WhenGivenNull_NullIsReturned()
            {
                var actual = ArgumentsBuilderExtension.GetArgumentFromNullableIntProperty(NullableIntProperty, null);

                Assert.That(actual, Is.Null);
            }
        }
        [TestFixture]
        public class GetArgumentFromNullableInt64Property
        {
            [Test]
            public void WhenGivenValue_FormatsProperly()
            {
                var actual = ArgumentsBuilderExtension.GetArgumentFromNullableInt64Property(NullableInt64Property, 5);

                Assert.That(actual, Is.EqualTo("--nullable-int64 5"));
            }

            [Test]
            public void WhenGivenNull_NullIsReturned()
            {
                var actual = ArgumentsBuilderExtension.GetArgumentFromNullableIntProperty(NullableInt64Property, null);

                Assert.That(actual, Is.Null);
            }
        }
        [TestFixture]
        public class GetArgumentFromNullableUInt64Property
        {
            [Test]
            public void WhenGivenValue_FormatsProperly()
            {
                var actual = ArgumentsBuilderExtension.GetArgumentFromNullableUInt64Property(NullableUInt64Property, 5);

                Assert.That(actual, Is.EqualTo("--nullable-uint64 5"));
            }

            [Test]
            public void WhenGivenNull_NullIsReturned()
            {
                var actual = ArgumentsBuilderExtension.GetArgumentFromNullableIntProperty(NullableUInt64Property, null);

                Assert.That(actual, Is.Null);
            }
        }
        [TestFixture]
        public class GetArgumentFromNullableBoolProperty
        {
            [Test]
            public void WhenGivenValue_FormatsProperly()
            {
                var actual = ArgumentsBuilderExtension.GetArgumentFromNullableBoolProperty(NullableBoolProperty, true);

                Assert.That(actual, Is.EqualTo("--nullable-bool"));
            }

            [Test]
            public void WhenGivenNull_NullIsReturned()
            {
                var actual = ArgumentsBuilderExtension.GetArgumentFromNullableBoolProperty(NullableBoolProperty, null);

                Assert.That(actual, Is.Null);
            }
        }
        [TestFixture]
        public class GetArgumentFromNullableTimeSpanProperty
        {
            [Test]
            public void WhenGivenValue_FormatsProperly()
            {
                var actual = ArgumentsBuilderExtension.GetArgumentFromNullableTimeSpanProperty(NullableTimeSpanProperty, new TimeSpan(734, 18, 4));

                Assert.That(actual, Is.EqualTo("--nullable-time-span 734h18m4s"));
            }

            [Test]
            public void WhenGivenNull_NullIsReturned()
            {
                var actual = ArgumentsBuilderExtension.GetArgumentFromNullableTimeSpanProperty(NullableTimeSpanProperty, null);

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

                Assert.That(actual, Is.EqualTo("cmd --string \"tubo\" arg1"));
            }

        }

        [TestFixture]
        public class ConvertTimeSpan
        {
            public void WhenGivenInput_ConvertsProperly()
            {
                var actual = ArgumentsBuilderExtension.ConvertTimeSpan(new TimeSpan(734, 18, 4));

                Assert.That(actual, Is.EqualTo("734h18m4s"));
            }
        }
    }

    [TestFixture]
    public class GetAutoPropertyAttributeOrNull: ArgumentsBuilderExtensionTest
    {
        [Test]
        public void WhenDecorated_ReturnsAutoPropertyAttribute()
        {
            var actual = ArgumentsBuilderExtension.GetAutoPropertyAttributeOrNull(DecoratedStringProperty);

            Assert.That(actual.Format, Is.EqualTo("-s {1}"));
        }
        [Test]
        public void WhenNotDecorated_ReturnsNull()
        {
            var actual = ArgumentsBuilderExtension.GetAutoPropertyAttributeOrNull(StringProperty);

            Assert.That(actual, Is.Null);
        }
    }

    [TestFixture]
    public class GetArgumentFromAutoProperty: ArgumentsBuilderExtensionTest
    {
        [Test]
        public void WhenGivenValue_FormatsProperly()
        {
            var attribute = ArgumentsBuilderExtension.GetAutoPropertyAttributeOrNull(DecoratedStringProperty);
            var actual = ArgumentsBuilderExtension.GetArgumentFromAutoProperty(attribute, DecoratedStringProperty, "SIGNAL");

            Assert.That(actual, Is.EqualTo("-s SIGNAL"));
        }
        [Test]
        public void WhenOnlyWhenTrueValue_AndIsFalse_ReturnsEmptyString()
        {
            var attribute = ArgumentsBuilderExtension.GetAutoPropertyAttributeOrNull(DecoratedBoolProperty);
            var actual = ArgumentsBuilderExtension.GetArgumentFromAutoProperty(attribute, DecoratedBoolProperty, false);

            Assert.That(actual, Is.Empty);
        }
        [Test]
        public void WhenOnlyWhenTrueValue_AndIsTrue_FormatsProperly()
        {
            var attribute = ArgumentsBuilderExtension.GetAutoPropertyAttributeOrNull(DecoratedBoolProperty);
            var actual = ArgumentsBuilderExtension.GetArgumentFromAutoProperty(attribute, DecoratedBoolProperty, true);

            Assert.That(actual, Is.EqualTo("-v"));
        }
        [Test]
        public void WhenDecoratedStrings_FormatsProperly()
        {
            var attribute = ArgumentsBuilderExtension.GetAutoPropertyAttributeOrNull(DecoratedStringsProperty);
            var actual = ArgumentsBuilderExtension.GetArgumentFromAutoProperty(attribute, DecoratedStringsProperty, new string[] {"One=1", "Two=2" });

            Assert.That(actual, Is.EqualTo("-e One=1 -e Two=2"));
        }
    }

    public class TestSettings: AutoToolSettings
    {
        public string String { get; set; }
        public string[] Strings { get; set; }
        public int? NullableInt { get; set; }
        public Int64? NullableInt64 { get; set; }
        public UInt64? NullableUInt64 { get; set; }
        public  bool? NullableBool { get; set; }
        public TimeSpan? NullableTimeSpan { get; set; }
        public bool Bool { get; set; }
        [AutoProperty(Format = "-s {1}")]
        public string DecoratedString { get; set; }
        [AutoProperty(Format = "-v", OnlyWhenTrue = true)]
        public bool DecoratedBool { get; set; }
        [AutoProperty(Format = "-e {1}")]
        public string[] DecoratedStrings { get; set; }
    }
}
