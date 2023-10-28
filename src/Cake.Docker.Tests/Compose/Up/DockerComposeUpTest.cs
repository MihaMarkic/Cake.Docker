using NUnit.Framework;

namespace Cake.Docker.Tests.Up
{
    [TestFixture]
    public class DockerComposeUpTest
    {
        [Test]
        public void WhenDetachedIsSet_CommandLineIsCorrect()
        {
            var fixture = new DockerComposeUpFixture
            {
                Service = "service",
                Settings = new DockerComposeUpSettings {  Detach = true },
            };

            var actual = fixture.Run();

            Assert.That(actual.Args, Is.EqualTo("up --detach service"));
        }

        [Test]
        public void WhenNoColorIsSet_CommandLineIsCorrect()
        {
            var fixture = new DockerComposeUpFixture
            {
                Service = "service",
                Settings = new DockerComposeUpSettings { NoColor = true },
            };

            var actual = fixture.Run();

            Assert.That(actual.Args, Is.EqualTo("up --no-color service"));
        }
        [Test]
        public void WhenWaitIsSet_CommandLineIsCorrect()
        {
            var fixture = new DockerComposeUpFixture
            {
                Service = "service",
                Settings = new DockerComposeUpSettings { Wait = true },
            };

            var actual = fixture.Run();

            Assert.That(actual.Args, Is.EqualTo("up --wait service"));
        }

        [Test]
        public void WhenNoServiceIsSet_CommandLineIsCorrect()
        {
            var fixture = new DockerComposeUpFixture
            {
                Settings = new DockerComposeUpSettings { AbortOnContainerExit = true, RemoveOrphans = true},
            };

            var actual = fixture.Run();

            Assert.That(actual.Args, Is.EqualTo("up --abort-on-container-exit --remove-orphans"));
        }
        [Test]
        public void WhenWaitTimeoutIsSet_CommandLineIsCorrect()
        {
            var fixture = new DockerComposeUpFixture
            {
                Settings = new DockerComposeUpSettings { WaitTimeout = 1 },
            };

            var actual = fixture.Run();

            Assert.That(actual.Args, Is.EqualTo("up --wait-timeout 1"));
        }
    }
}
