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

            Assert.That(actual.Args, Is.EqualTo("compose run --entrypoint \"somepoint\" cmd"));
        }

        [Test]
        public void WhenVolumeIsSet_CommandLineIsCorrect()
        {
            var fixture = new DockerComposeRunFixture
            {
                Command = "cmd",
                Settings = new DockerComposeRunSettings { Volume = ["host:guest"] },
            };

            var actual = fixture.Run();

            Assert.That(actual.Args, Is.EqualTo("compose run --volume \"host:guest\" cmd"));
        }
        [Test]
        public void WhenTwoVolumesAreSet_CommandLineIsCorrect()
        {
            var fixture = new DockerComposeRunFixture
            {
                Command = "cmd",
                Settings = new DockerComposeRunSettings { Volume = ["host:guest", "host2:guest2"] },
            };

            var actual = fixture.Run();

            Assert.That(actual.Args, Is.EqualTo("compose run --volume \"host:guest\" --volume \"host2:guest2\" cmd"));
        }
    }
}
