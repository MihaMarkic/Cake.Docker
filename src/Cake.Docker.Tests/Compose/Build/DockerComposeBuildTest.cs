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
                Settings = new DockerComposeBuildSettings {  Parallel = 2 },
            };

            var actual = fixture.Run();

            Assert.That(actual.Args, Is.EqualTo("compose build --parallel 2"));
        }

        [Test]
        public void WhenParallelFlagIsSetToFalse_CommandLineDoesNotHaveRm()
        {
            var fixture = new DockerComposeBuildFixture
            {
                Settings = new DockerComposeBuildSettings { Parallel = null },
            };

            var actual = fixture.Run();

            Assert.That(actual.Args, Is.EqualTo("compose build"));
        }

        [Test]
        public void WhenFilesFlagIsUsed_CommandLineIncludesIt()
        {
            var fixture = new DockerComposeBuildFixture
            {
                Settings = new DockerComposeBuildSettings { File = ["alfa.yaml"] },
            };

            var actual = fixture.Run();

            Assert.That(actual.Args, Is.EqualTo("compose build --file \"alfa.yaml\""));
        }
        [Test]
        public void WhenTwoFilesAreProvided_CommandLineIncludesThem()
        {
            var fixture = new DockerComposeBuildFixture
            {
                Settings = new DockerComposeBuildSettings { File = ["alfa.yaml", "beta.yaml"] },
            };

            var actual = fixture.Run();

            Assert.That(actual.Args, Is.EqualTo("compose build --file \"alfa.yaml\" --file \"beta.yaml\""));
        }
    }
}
