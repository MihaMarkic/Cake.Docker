namespace Cake.Docker.Tests.Compose.Port;

public class DockerComposePortFixture : DockerComposeFixture<DockerComposePortSettings>
{
    public string Service { get; set; }
    public int Port { get; set; }
    protected override void RunTool()
    {
        this.DockerComposePort(Settings, Service, Port, ComposeSettings);
    }
}
