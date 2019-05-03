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
                Settings = new DockerComposePsSettings { Filters = new[] { "filter" } },
            };

            var actual = fixture.Run();

            Assert.That(actual.Args, Is.EqualTo("ps --filter filter"));
        }

        [Test]
        public void WhenSingleFilterIsSet_CommandLineIsCorrect()
        {
            var fixture = new DockerComposePsFixture
            {
                Settings = new DockerComposePsSettings { Filters = new[] { "filter" } },
                Services = new string[] { "serviceA", "serviceB" },
            };

            var actual = fixture.Run();

            Assert.That(actual.Args, Is.EqualTo("ps --filter filter serviceA serviceB"));
        }

        [Test]
        public void WhenMultipleFilterIsSet_CommandLineIsCorrect()
        {
            var fixture = new DockerComposePsFixture
            {
                Settings = new DockerComposePsSettings { Filters = new[] { "filter1", "filter2" } },
                Services = new string[] { "serviceA", "serviceB" },
            };

            var actual = fixture.Run();

            Assert.That(actual.Args, Is.EqualTo("ps --filter filter1 --filter filter2 serviceA serviceB"));
        }

        [Test]
        public void WhenQuietIsSet_CommandLineIsCorrect()
        {
            var fixture = new DockerComposePsFixture
            {
                Settings = new DockerComposePsSettings { Quiet = true },
                Services = new string[] { "serviceA", "serviceB", "serviceC" },
            };

            var actual = fixture.Run();

            Assert.That(actual.Args, Is.EqualTo("ps --quiet serviceA serviceB serviceC"));
        }
    }
}
