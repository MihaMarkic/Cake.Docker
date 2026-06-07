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
                ComposeSettings = new DockerComposeSettings { Parallel = 2, },
                Settings = new DockerComposeBuildSettings {   },
            };

            var actual = fixture.Run();

            Assert.That(actual.Args, Is.EqualTo("compose --parallel 2 build"));
        }

        [Test]
        public void WhenParallelFlagIsSetToFalse_CommandLineDoesNotHaveRm()
        {
            var fixture = new DockerComposeBuildFixture
            {
                ComposeSettings = new DockerComposeSettings { Parallel = null, },
                Settings = new DockerComposeBuildSettings { },
            };

            var actual = fixture.Run();

            Assert.That(actual.Args, Is.EqualTo("compose build"));
        }

        [Test]
        public void WhenFilesAreUsed_CommandLineIncludesIt()
        {
            var fixture = new DockerComposeBuildFixture
            {
                ComposeSettings = new DockerComposeSettings { File = ["alfa.yaml"], },
                Settings = new DockerComposeBuildSettings { },
            };

            var actual = fixture.Run();

            Assert.That(actual.Args, Is.EqualTo("compose --file \"alfa.yaml\" build"));
        }
        [Test]
        public void WhenTwoFilesAreProvided_CommandLineIncludesThem()
        {
            var fixture = new DockerComposeBuildFixture
            {
                ComposeSettings = new DockerComposeSettings { File = ["alfa.yaml", "beta.yaml"], },
            };

            var actual = fixture.Run();

            Assert.That(actual.Args, Is.EqualTo("compose --file \"alfa.yaml\" --file \"beta.yaml\" build"));
        }
        [Test]
        public void WhenFilesAreUsedAndMemoryIsSet_CommandLineIncludesIt()
        {
            var fixture = new DockerComposeBuildFixture
            {
                ComposeSettings = new DockerComposeSettings { File = ["alfa.yaml"], },
                Settings = new DockerComposeBuildSettings { Memory = 1024, },
            };

            var actual = fixture.Run();

            Assert.That(actual.Args, Is.EqualTo("compose --file \"alfa.yaml\" build --memory 1024"));
        }
    }
}
