using Cake.Core;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Testing.Fixtures;
using System;

namespace Cake.Docker.Tests.Run
{
    public class DockerComposeRunFixture : ToolFixture<DockerComposeRunSettings>, ICakeContext
    {
        public string Command { get; set; }

        IFileSystem ICakeContext.FileSystem => FileSystem;

        ICakeEnvironment ICakeContext.Environment => Environment;

        public ICakeLog Log => Log;

        ICakeArguments ICakeContext.Arguments => throw new NotImplementedException();

        IProcessRunner ICakeContext.ProcessRunner => ProcessRunner;

        public IRegistry Registry => Registry;

        public ICakeDataResolver Data => throw new NotImplementedException();

        public DockerComposeRunFixture(): base("docker-compose")
        {
            ProcessRunner.Process.SetStandardOutput(new string[] { });
        }
        protected override void RunTool()
        {
            this.DockerComposeRun(Settings, Command);
        }
    }
}
