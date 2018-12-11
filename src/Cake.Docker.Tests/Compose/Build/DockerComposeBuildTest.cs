using NUnit.Framework;

namespace Cake.Docker.Tests.Build
{
    [TestFixture]
    public class DockerComposeBuildTest
    {
        [Test]
        public void WhenParallelFlagIsSet_CommandLineIsCorrect()
        {
            var fixture = new DockerComposeBuildFixture
            {
                Settings = new DockerComposeBuildSettings {  Parallel = true },
            };

            var actual = fixture.Run();

            Assert.That(actual.Args, Is.EqualTo("build --parallel"));
        }

        [Test]
        public void WhenParallelFlagIsSetToFalse_CommandLineDoesNotHaveRm()
        {
            var fixture = new DockerComposeBuildFixture
            {
                Settings = new DockerComposeBuildSettings { Parallel = false },
            };

            var actual = fixture.Run();

            Assert.That(actual.Args, Is.EqualTo("build"));
        }
    }
}
