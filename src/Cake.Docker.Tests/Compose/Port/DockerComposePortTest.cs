using NUnit.Framework;

namespace Cake.Docker.Tests.Compose.Port
{
    [TestFixture]
    public class DockerComposePortTest
    {
        [Test]
        public void WhenServiceAndPortAreSet_CommandLineIsCorrect()
        {
            var fixture = new DockerComposePortFixture
            {
                Settings = new DockerComposePortSettings(),
                Service = "serviceA",
                Port = 8080,
            };

            var actual = fixture.Run();

            Assert.That(actual.Args, Is.EqualTo("compose port serviceA 8080"));
        }

        [Test]
        public void WhenServiceAndPortAndIndexAreSet_CommandLineIsCorrect()
        {
            var fixture = new DockerComposePortFixture
            {
                Settings = new DockerComposePortSettings { Index = 2 },
                Service = "serviceA",
                Port = 8080,
            };

            var actual = fixture.Run();

            Assert.That(actual.Args, Is.EqualTo("compose port --index 2 serviceA 8080"));
        }
        [Test]
        public void WhenParallelFlagIsSet_CommandLineIsCorrect()
        {
            var fixture = new DockerComposePortFixture
            {
                Settings = new DockerComposePortSettings { Index = 2 },
                Service = "serviceA",
                Port = 8080,
                ComposeSettings = new DockerComposeSettings { Parallel = 2, },
            };

            var actual = fixture.Run();

            Assert.That(actual.Args, Is.EqualTo("compose --parallel 2 port --index 2 serviceA 8080"));
        }
    }
}
