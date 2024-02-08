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
    }
}
