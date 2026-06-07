namespace Cake.Docker.Tests.Compose.Exec;

public class DockerComposeExecFixture : DockerComposeFixture<DockerComposeExecSettings>
{
    public string Service { get; set; }
    public string Command { get; set; }
    public string[] Args { get; set; } = [];
    
    protected override void RunTool()
    {
        this.DockerComposeExec(Settings, Service, Command, ComposeSettings, Args);
    }
}
