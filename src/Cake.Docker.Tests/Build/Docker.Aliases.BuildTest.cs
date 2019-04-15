using NUnit.Framework;

namespace Cake.Docker.Tests.Build
{
    [TestFixture]
    public class DockerBuildTest
    {
        [Test]
        public void WhenOnlyPathIsSet_CommandLineIsCorrect()
        {
            var fixture = new DockerBuildFixture
            {
                Settings = new DockerImageBuildSettings(),
                Path = "path"
            };

            var actual = fixture.Run();

            Assert.That(actual.Args, Is.EqualTo("build \"path\""));
        }
        [Test]
        public void WhenRmFlagIsSet_CommandLineIsCorrect()
        {
            var fixture = new DockerBuildFixture
            {
                Settings = new DockerImageBuildSettings {  Rm = true },
                Path = "path"
            };

            var actual = fixture.Run();

            Assert.That(actual.Args, Is.EqualTo("build --rm=True \"path\""));
        }

        [Test]
        public void WhenRmFlagIsSetToFalse_CommandLineDoesNotHaveRm()
        {
            var fixture = new DockerBuildFixture
            {
                Settings = new DockerImageBuildSettings { Rm = false },
                Path = "path"
            };

            var actual = fixture.Run();

            Assert.That(actual.Args, Is.EqualTo("build --rm=False \"path\""));
        }

        [Test]
        public void WhenForceRmFlagIsSetToFalse_CommandLineDoesNotHaveForceRm()
        {
            var fixture = new DockerBuildFixture
            {
                Settings = new DockerImageBuildSettings { ForceRm = false },
                Path = "path"
            };

            var actual = fixture.Run();

            Assert.That(actual.Args, Is.EqualTo("build \"path\""));
        }

        [Test]
        public void WhenPullFlagIsSetToFalse_CommandLineDoesNotHavePull()
        {
            var fixture = new DockerBuildFixture
            {
                Settings = new DockerImageBuildSettings { Pull = false },
                Path = "path"
            };

            var actual = fixture.Run();

            Assert.That(actual.Args, Is.EqualTo("build \"path\""));
        }

        [Test]
        public void WhenPullFlagIsSetToTrue_CommandLineDoesHavePull()
        {
            var fixture = new DockerBuildFixture
            {
                Settings = new DockerImageBuildSettings { Pull = true },
                Path = "path"
            };

            var actual = fixture.Run();

            Assert.That(actual.Args, Is.EqualTo("build --pull \"path\""));
        }
        [Test]
        public void WhenPathHasSpaces_ArgumentIsQuoted()
        {
            var fixture = new DockerBuildFixture
            {
                Settings = new DockerImageBuildSettings(),
                Path = @"C:\Some where"
            };

            var actual = fixture.Run();

            Assert.That(actual.Args, Is.EqualTo(@"build ""C:\Some where"""));
        }
        [Test]
        public void WhenPathHasSingleQuote_ArgumentIsQuoted()
        {
            var fixture = new DockerBuildFixture
            {
                Settings = new DockerImageBuildSettings(),
                Path = "\""
            };

            var actual = fixture.Run();

            Assert.That(actual.Args, Is.EqualTo(@"build """""""));
        }
        [TestCase("\"test\"")]
        [TestCase(" \"test\"")]
        [TestCase("\"test\" ")]
        [TestCase(" \"test\" ")]
        public void WhenPathIsQuoted_ArgumentIsNotDoubleQuoted(string path)
        {
            var fixture = new DockerBuildFixture
            {
                Settings = new DockerImageBuildSettings(),
                Path = path
            };

            var actual = fixture.Run();

            Assert.That(actual.Args, Is.EqualTo($"build {path}"));
        }
    }
}
