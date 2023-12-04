using Cake.Core.IO;
using Cake.Docker.Tests.Build;
using NUnit.Framework;

namespace Cake.Docker.Tests.Registry.Login
{
    [TestFixture]
    public class DockerLoginTest
    {
        [Test]
        public void WhenOnlyPathIsSet_CommandLineIsCorrect()
        {
            var fixture = new DockerRegistryLoginFixture
            {
                Settings = new DockerRegistryLoginSettings(),
                Path = "path"
            };

            var actual = fixture.Run();

            Assert.That(actual.Args, Is.EqualTo("login path"));
        }
        [Test]
        public void WhenOnlyUsernameIsSet_CommandLineIsCorrect()
        {
            var fixture = new DockerRegistryLoginFixture
            {
                Settings = new DockerRegistryLoginSettings { Username = "Tubo" },
                Path = "path"
            };

            var actual = fixture.Run();

            Assert.That(actual.Args, Is.EqualTo("login --username \"Tubo\" path"));
        }
        [Test]
        public void WhenOnlyPasswordIsSet_ArgumentIsRedacted()
        {
            var builder = new ProcessArgumentBuilder();
            builder.AppendAll("login", new DockerRegistryLoginSettings { Password = "Tubo" }, []);

            var actual = builder.RenderSafe();

            Assert.That(actual, Is.EqualTo("login --password \"[REDACTED]\""));
        }
    }
}
