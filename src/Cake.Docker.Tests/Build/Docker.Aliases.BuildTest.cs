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
                Settings = new DockerBuildSettings(),
                Path = "path"
            };

            var actual = fixture.Run();

            Assert.That(actual.Args, Is.EqualTo("build path"));
        }
        [Test]
        public void WhenRmFlagIsSet_CommandLineIsCorrect()
        {
            var fixture = new DockerBuildFixture
            {
                Settings = new DockerBuildSettings {  Rm = true },
                Path = "path"
            };

            var actual = fixture.Run();

            Assert.That(actual.Args, Is.EqualTo("build --rm path"));
        }
    }
}
