namespace Cake.Docker.Tests.Compose.Ps;

public class DockerComposePsFixture : DockerComposeFixture<DockerComposePsSettings>
{
    protected override void RunTool()
    {
        this.DockerComposePs(Settings, ComposeSettings, Services);
    }
}
