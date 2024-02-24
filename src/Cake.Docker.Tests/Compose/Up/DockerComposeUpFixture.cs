using Cake.Docker.Tests.Compose;

namespace Cake.Docker.Tests.Up;

public class DockerComposeUpFixture : DockerComposeFixture<DockerComposeUpSettings>
{
    public string Service { get; set; }
    protected override void RunTool()
    {
        this.DockerComposeUp(Settings, ComposeSettings, Service);
        if(string.IsNullOrEmpty(Service))
        {
            this.DockerComposeUp(Settings, ComposeSettings);
        }
    }
}
