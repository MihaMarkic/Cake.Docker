using Cake.Docker.Tests.Compose;

namespace Cake.Docker.Tests.Build;

public class DockerComposeBuildFixture : DockerComposeFixture<DockerComposeBuildSettings>
{
    protected override void RunTool()
    {
        this.DockerComposeBuild(Settings, ComposeSettings, Services);
    }
}
