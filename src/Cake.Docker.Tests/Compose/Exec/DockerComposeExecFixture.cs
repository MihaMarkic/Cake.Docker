using Cake.Core;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Testing.Fixtures;
using System;

namespace Cake.Docker.Tests.Compose.Exec
{
    public class DockerComposeExecFixture : ToolFixture<DockerComposeExecSettings>, ICakeContext
    {
        public string Service { get; set; }
        public string Command { get; set; }
        public string[] Args { get; set; } = new string[0];

        IFileSystem ICakeContext.FileSystem => FileSystem;

        ICakeEnvironment ICakeContext.Environment => Environment;

        public ICakeLog Log => Log;

        ICakeArguments ICakeContext.Arguments => throw new NotImplementedException();

        IProcessRunner ICakeContext.ProcessRunner => ProcessRunner;

        public IRegistry Registry => Registry;

        public ICakeDataResolver Data => Data;

        public DockerComposeExecFixture() : base("DockerCompose")
        {
            ProcessRunner.Process.SetStandardOutput(new string[] { });
        }
        protected override void RunTool()
        {
            this.DockerComposeExec(Settings, Service, Command, Args);
        }
    }
}
