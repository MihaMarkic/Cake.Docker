using Cake.Core.Configuration;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Core;
using Cake.Core.Tooling;
using Cake.Testing.Fixtures;
using System;

namespace Cake.Docker.Tests.Compose;

public abstract class DockerComposeFixture<TSettings> : ToolFixture<TSettings>, ICakeContext
    where TSettings: ToolSettings, new()
{
    public DockerComposeSettings ComposeSettings { get; set; }
    public string[] Services { get; set; } = [];

    IFileSystem ICakeContext.FileSystem => FileSystem;

    ICakeEnvironment ICakeContext.Environment => Environment;

    public ICakeLog Log => Log;

    ICakeArguments ICakeContext.Arguments => throw new NotImplementedException();

    IProcessRunner ICakeContext.ProcessRunner => ProcessRunner;

    public IRegistry Registry => Registry;

    public ICakeDataResolver Data => throw new NotImplementedException();

    ICakeConfiguration ICakeContext.Configuration => throw new NotImplementedException();
    public DockerComposeFixture() : base("docker")
    {
        ProcessRunner.Process.SetStandardOutput(Array.Empty<string>());
    }
}
