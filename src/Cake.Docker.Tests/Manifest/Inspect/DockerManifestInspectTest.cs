using Cake.Docker.Tests.Run;
using NUnit.Framework;

namespace Cake.Docker.Tests.Manifest.Inspect
{
    [TestFixture]
    public class DockerManifestInspectTest
    {
        [Test]
        public void WhenInsecureIsSet_InsecureFlagIsPresent()
        {
            var fixture = new DockerManifestInspectFixture
            {
                Settings = new DockerManifestInspectSettings { Insecure = true },
            };

            var actual = fixture.Run();

            Assert.That(actual.Args.Trim(), Is.EqualTo("manifest inspect --insecure"));
        }
        [Test]
        public void WhenInsecureIsSetAndAllArgumentsPresent_ProducesCorrectCommand()
        {
            var fixture = new DockerManifestInspectFixture
            {
                Settings = new DockerManifestInspectSettings { Insecure = true },
                ManifestList = "manifest_list",
                Manifest = "manifest",
            };

            var actual = fixture.Run();

            Assert.That(actual.Args.Trim(), Is.EqualTo("manifest inspect --insecure manifest_list manifest"));
        }
        [Test]
        public void WhenNoCustomSettings_BothManifestListAndManifestArePresent()
        {
            var fixture = new DockerManifestInspectFixture
            {
                ManifestList = "manifest_list",
                Manifest = "manifest",
            };

            var actual = fixture.Run();

            Assert.That(actual.Args.Trim(), Is.EqualTo("manifest inspect manifest_list manifest"));
        }
    }
}
