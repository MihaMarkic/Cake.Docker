#nullable enable
using Cake.Core.IO;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Cake.Docker.Tests
{
    public class ArgumentsBuilderExtensionTest
    {
        public static PropertyInfo StringProperty => GetProperty(nameof(TestSettings.String));
        public static PropertyInfo NullableStringProperty => GetProperty(nameof(TestSettings.NullableString));
        public static PropertyInfo PasswordProperty => GetProperty(nameof(TestSettings.Password));
        public static PropertyInfo StringsProperty => GetProperty(nameof(TestSettings.Strings));
        public static PropertyInfo ListStringsProperty => GetProperty(nameof(TestSettings.ListStrings));
        public static PropertyInfo NullableIntProperty => GetProperty(nameof(TestSettings.NullableInt));
        public static PropertyInfo NullableInt64Property => GetProperty(nameof(TestSettings.NullableInt64));
        public static PropertyInfo NullableUInt64Property => GetProperty(nameof(TestSettings.NullableUInt64));
        public static PropertyInfo NullableUInt16Property => GetProperty(nameof(TestSettings.NullableUInt16));
        public static PropertyInfo NullableBoolProperty => GetProperty(nameof(TestSettings.NullableBool));
        public static PropertyInfo NullableTimeSpanProperty => GetProperty(nameof(TestSettings.NullableTimeSpan));
        public static PropertyInfo BoolProperty => GetProperty(nameof(TestSettings.Bool));
        public static PropertyInfo DecoratedStringProperty => GetProperty(nameof(TestSettings.DecoratedString));
        public static PropertyInfo DecoratedBoolProperty => GetProperty(nameof(TestSettings.DecoratedBool));
        public static PropertyInfo DecoratedStringsProperty => GetProperty(nameof(TestSettings.DecoratedStrings));
        public static PropertyInfo PreCommandValueProperty => GetProperty(nameof(TestSettings.PreCommandValue));
        public static PropertyInfo GetProperty(string name)
        {
            return typeof(TestSettings).GetProperty(name, BindingFlags.Public | BindingFlags.Instance) ?? throw new InvalidOperationException($"Property {name} not found!");
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
                var actual = ArgumentsBuilderExtension.GetArgumentFromStringProperty(StringProperty, "tubo", isSecret: false).Value;

                Assert.That(actual.Key, Is.EqualTo("--string"));
                Assert.That(actual.Value, Is.EqualTo("tubo"));
                Assert.That(actual.Quoting, Is.EqualTo(DockerArgumentQuoting.Quoted));
            }
            [Test]
            public void WhenGivenNull_NullIsReturned()
            {
                var actual = ArgumentsBuilderExtension.GetArgumentFromStringProperty(StringProperty, null, isSecret: false);

                Assert.That(actual, Is.Null);
            }
        }
        [TestFixture]
        public class GetArgumentFromNullableStringProperty
        {
            [Test]
            public void WhenGivenStringProperty_FormatsProperly()
            {
                var actual = ArgumentsBuilderExtension.GetArgumentFromStringProperty(NullableStringProperty, "tubo", isSecret: false).Value;

                Assert.That(actual.Key, Is.EqualTo("--nullable-string"));
                Assert.That(actual.Value, Is.EqualTo("tubo"));
                Assert.That(actual.Quoting, Is.EqualTo(DockerArgumentQuoting.Quoted));
            }
            [Test]
            public void WhenGivenNull_NullIsReturned()
            {
                var actual = ArgumentsBuilderExtension.GetArgumentFromStringProperty(NullableStringProperty, null, isSecret: false);

                Assert.That(actual, Is.Null);
            }
        }
        [TestFixture]
        public class GetArgumentFromPasswordProperty
        {
            [Test]
            public void WhenGivenStringProperty_FormatsProperly()
            {
                var actual = ArgumentsBuilderExtension.GetArgumentFromStringProperty(StringProperty, "tubo", isSecret: true).Value;

                Assert.That(actual.Key, Is.EqualTo("--string"));
                Assert.That(actual.Value, Is.EqualTo("tubo"));
                Assert.That(actual.Quoting, Is.EqualTo(DockerArgumentQuoting.QuotedSecret));
            }
        }
        [TestFixture]
        public class GetArgumentFromStringArrayProperty
        {
            [Test]
            public void WhenGivenStringArrayProperty_FormatsProperly()
            {
                var actual = ArgumentsBuilderExtension.GetArgumentFromStringArrayProperty(StringsProperty, ["tubo1", "tubo2"], isSecret: false);

                CollectionAssert.AreEqual(actual, new DockerArgument[] {
                    new DockerArgument("--strings", "tubo1", DockerArgumentQuoting.Quoted),
                    new DockerArgument("--strings", "tubo2", DockerArgumentQuoting.Quoted)});
            }
            [Test]
            public void WhenGivenNull_EmptyArrayReturned()
            {
                var actual = ArgumentsBuilderExtension.GetArgumentFromStringArrayProperty(StringsProperty, null, isSecret: false);

                Assert.That(actual, Is.Empty);
            }
        }
        [TestFixture]
        public class GetArgumentFromStringArrayListProperty
        {
            [Test]
            public void WhenGivenStringArrayProperty_FormatsProperly()
            {
                var actual = ArgumentsBuilderExtension.GetArgumentFromStringArrayListProperty(
                    ListStringsProperty, ["tubo1", "tubo2"], isSecret: false).Value;

                Assert.That(actual.Key, Is.EqualTo("--list-strings"));
                Assert.That(actual.Value, Is.EqualTo("tubo1,tubo2"));
                Assert.That(actual.Quoting, Is.EqualTo(DockerArgumentQuoting.Quoted));
            }
            [Test]
            public void WhenGivenNull_EmptyArrayReturned()
            {
                var actual = ArgumentsBuilderExtension.GetArgumentFromStringArrayProperty(ListStringsProperty, null, isSecret: false);

                Assert.That(actual, Is.Empty);
            }
        }
        [TestFixture]
        public class GetArgumentFromDictionaryProperty
        {
            [Test]
            public void WhenGivenStringArrayProperty_FormatsProperly()
            {
                var actual = ArgumentsBuilderExtension.GetArgumentFromDictionaryProperty(
                    StringsProperty, new Dictionary<string, string> { { "t1", "v1" }, { "t2", "v2" } }, isSecret: false);

                CollectionAssert.AreEqual(actual, new DockerArgument[] {
                    new DockerArgument("--strings", "t1=v1", DockerArgumentQuoting.Quoted),
                    new DockerArgument("--strings","t2=v2", DockerArgumentQuoting.Quoted),
                    });
            }
            [Test]
            public void WhenGivenNull_EmptyArrayReturned()
            {
                var actual = ArgumentsBuilderExtension.GetArgumentFromDictionaryProperty(StringsProperty, null, isSecret: false);

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

                Assert.That(actual, Is.EqualTo("--nullable-u-int64 5"));
            }

            [Test]
            public void WhenGivenNull_NullIsReturned()
            {
                var actual = ArgumentsBuilderExtension.GetArgumentFromNullableIntProperty(NullableUInt64Property, null);

                Assert.That(actual, Is.Null);
            }
        }
        [TestFixture]
        public class GetArgumentFromNullableUInt16Property
        {
            [Test]
            public void WhenGivenValue_FormatsProperly()
            {
                var actual = ArgumentsBuilderExtension.GetArgumentFromNullableUInt16Property(NullableUInt16Property, 5);

                Assert.That(actual, Is.EqualTo("--nullable-u-int16 5"));
            }

            [Test]
            public void WhenGivenNull_NullIsReturned()
            {
                var actual = ArgumentsBuilderExtension.GetArgumentFromNullableIntProperty(NullableUInt16Property, null);

                Assert.That(actual, Is.Null);
            }
        }
        [TestFixture]
        public class GetArgumentFromNullableBoolProperty
        {
            [Test]
            public void WhenGivenValueIsTrue_FormatsProperly()
            {
                var actual = ArgumentsBuilderExtension.GetArgumentFromNullableBoolProperty(NullableBoolProperty, true);

                Assert.That(actual, Is.EqualTo("--nullable-bool"));
            }

            [Test]
            public void WhenGivenValueIsFalse_NullIsReturned()
            {
                var actual = ArgumentsBuilderExtension.GetArgumentFromNullableBoolProperty(NullableBoolProperty, false);

                Assert.That(actual, Is.Null);
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
                builder.AppendAll("cmd", input, ["arg1"]);
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
    public class GetAutoPropertyAttributeOrNull : ArgumentsBuilderExtensionTest
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
    public class GetArgumentFromAutoProperty : ArgumentsBuilderExtensionTest
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
            var actual = ArgumentsBuilderExtension.GetArgumentFromAutoProperty(attribute, DecoratedStringsProperty, new string[] { "One=1", "Two=2" });

            Assert.That(actual, Is.EqualTo("-e One=1 -e Two=2"));
        }
    }
    [TestFixture]
    public class GetArgumentFromProperty : ArgumentsBuilderExtensionTest
    {
        [Test]
        public void WhenPreCommand_DoesNotAppearInNormalCommands()
        {
            TestSettings input = new TestSettings { PreCommandValue = "preCommand" };
            var actual = ArgumentsBuilderExtension.GetArgumentFromProperty(PreCommandValueProperty, input, preCommand: false, isSecret: false);

            Assert.That(actual.Count(), Is.Zero);
        }
        [Test]
        public void WhenPreCommand_ItAppearsInPreCommands()
        {
            TestSettings input = new TestSettings { PreCommandValue = "preCommand" };
            var actual = ArgumentsBuilderExtension.GetArgumentFromProperty(PreCommandValueProperty, input, preCommand: true, isSecret: false);

            Assert.That(actual.Count(), Is.EqualTo(1));
        }
    }

    public class TestSettings : AutoToolSettings
    {
        public string String { get; set; }
        public string? NullableString { get; set; }
        public string[] Strings { get; set; }
        [AutoProperty(AutoArrayType = AutoArrayType.List)]
        public string[] ListStrings { get; set; }
        public string Password { get; set; }
        public int? NullableInt { get; set; }
        public Int64? NullableInt64 { get; set; }
        public UInt64? NullableUInt64 { get; set; }
        public UInt16? NullableUInt16 { get; set; }
        public bool? NullableBool { get; set; }
        public TimeSpan? NullableTimeSpan { get; set; }
        public bool Bool { get; set; }
        [AutoProperty(Format = "-s {1}")]
        public string DecoratedString { get; set; }
        [AutoProperty(Format = "-v", OnlyWhenTrue = true)]
        public bool DecoratedBool { get; set; }
        [AutoProperty(Format = "-e {1}")]
        public string[] DecoratedStrings { get; set; }
        [AutoProperty(PreCommand = true)]
        public string PreCommandValue { get; set; }
        protected override string[] CollectSecretProperties()
        {
            return [nameof(Password)];
        }
    }
}
