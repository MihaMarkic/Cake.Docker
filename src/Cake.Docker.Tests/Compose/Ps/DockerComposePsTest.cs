using NUnit.Framework;

namespace Cake.Docker.Tests.Compose.Ps
{
    [TestFixture]
    public class DockerComposePsTest
    {
        [Test]
        public void WhenNoServiceAreSet_CommandLineIsCorrect()
        {
            var fixture = new DockerComposePsFixture
            {
                Settings = new DockerComposePsSettings { Filter = ["filter"] },
            };

            var actual = fixture.Run();

            Assert.That(actual.Args, Is.EqualTo("compose ps --filter filter"));
        }

        [Test]
        public void WhenSingleFilterIsSet_CommandLineIsCorrect()
        {
            var fixture = new DockerComposePsFixture
            {
                Settings = new DockerComposePsSettings { Filter = ["filter"] },
                Services = ["serviceA", "serviceB"],
            };

            var actual = fixture.Run();

            Assert.That(actual.Args, Is.EqualTo("compose ps --filter filter serviceA serviceB"));
        }

        [Test]
        public void WhenMultipleFilterIsSet_CommandLineIsCorrect()
        {
            var fixture = new DockerComposePsFixture
            {
                Settings = new DockerComposePsSettings { Filter = ["filter1", "filter2"] },
                Services = ["serviceA", "serviceB"],
            };

            var actual = fixture.Run();

            Assert.That(actual.Args, Is.EqualTo("compose ps --filter filter1 --filter filter2 serviceA serviceB"));
        }

        [Test]
        public void WhenQuietIsSet_CommandLineIsCorrect()
        {
            var fixture = new DockerComposePsFixture
            {
                Settings = new DockerComposePsSettings { Quiet = true },
                Services = ["serviceA", "serviceB", "serviceC"],
            };

            var actual = fixture.Run();

            Assert.That(actual.Args, Is.EqualTo("compose ps --quiet serviceA serviceB serviceC"));
        }
        [Test]
        public void WhenParallelFlagIsSet_CommandLineIsCorrect()
        {
            var fixture = new DockerComposePsFixture
            {
                ComposeSettings = new DockerComposeSettings { Parallel = 2, },
                Settings = new DockerComposePsSettings { Quiet = true },
                Services = ["serviceA", "serviceB", "serviceC"],
            };

            var actual = fixture.Run();

            Assert.That(actual.Args, Is.EqualTo("compose --parallel 2 ps --quiet serviceA serviceB serviceC"));
        }
    }
}
