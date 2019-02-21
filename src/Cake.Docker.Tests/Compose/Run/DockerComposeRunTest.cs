using NUnit.Framework;

namespace Cake.Docker.Tests.Run
{
    [TestFixture]
    public class DockerComposeRunTest
    {
        [Test]
        public void WhenEntrypointIsSet_CommandLineIsCorrect()
        {
            var fixture = new DockerComposeRunFixture
            {
                Command = "cmd",
                Settings = new DockerComposeRunSettings {  Entrypoint = "somepoint" },
            };

            var actual = fixture.Run();

            Assert.That(actual.Args, Is.EqualTo("run --entrypoint \"somepoint\" cmd"));
        }
    }
}
