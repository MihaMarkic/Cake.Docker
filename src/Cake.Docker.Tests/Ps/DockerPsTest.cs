using NUnit.Framework;

namespace Cake.Docker.Tests.Run
{
    [TestFixture]
    public class DockerPsTest
    {
        [Test]
        public void WhenNoTruncIsSet_CommandLineIsCorrect()
        {
            var fixture = new DockerPsFixture
            {
                Settings = new DockerContainerPsSettings {  NoTrunc = true },
            };

            var actual = fixture.Run();

            Assert.That(actual.Args, Is.EqualTo("ps --no-trunc"));
        }
        [Test]
        public void WhenNoTruncIsNotSet_CommandLineIsCorrect()
        {
            var fixture = new DockerPsFixture
            {
                Settings = new DockerContainerPsSettings { NoTrunc = false },
            };

            var actual = fixture.Run();

            Assert.That(actual.Args, Is.EqualTo("ps"));
        }
        [Test]
        public void WhenQuietIsSet_CommandLineIsCorrect()
        {
            var fixture = new DockerPsFixture
            {
                Settings = new DockerContainerPsSettings { Quiet = true },
            };

            var actual = fixture.Run();

            Assert.That(actual.Args, Is.EqualTo("ps --quiet"));
        }
    }
}
