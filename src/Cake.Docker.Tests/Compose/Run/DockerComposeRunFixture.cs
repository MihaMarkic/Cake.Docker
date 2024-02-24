using Cake.Docker.Tests.Compose;

namespace Cake.Docker.Tests.Run;

public class DockerComposeRunFixture : DockerComposeFixture<DockerComposeRunSettings>
{
    public string Command { get; set; }
    protected override void RunTool()
    {
        this.DockerComposeRun(Settings, Command, ComposeSettings);
    }
}
