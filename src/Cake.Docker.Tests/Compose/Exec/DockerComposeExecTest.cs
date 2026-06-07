using NUnit.Framework;

namespace Cake.Docker.Tests.Compose.Exec
{
    [TestFixture]
    public class DockerComposeExecTest
    {
        [Test]
        public void WhenDisablePseudoTtyIsSet_AddsItsArgument()
        {
            var fixture = new DockerComposeExecFixture
            {
                Settings = new DockerComposeExecSettings(),
                Service = "service",
                Command = "command"
            };

            var actual = fixture.Run();

            Assert.That(actual.Args, Is.EqualTo("compose exec service command"));
        }
        [Test]
        public void WhenParallelFlagIsSet_CommandLineIsCorrect()
        {
            var fixture = new DockerComposeExecFixture
            {
                Service = "service",
                Command = "command",
                ComposeSettings = new DockerComposeSettings { Parallel = 2, },
                Settings = new DockerComposeExecSettings { },
            };

            var actual = fixture.Run();

            Assert.That(actual.Args, Is.EqualTo("compose --parallel 2 exec service command"));
        }
    }
}
