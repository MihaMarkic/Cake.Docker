using System;
using Cake.Docker;
using Cake.Testing.Fixtures;
using Cake.Core;
using Cake.Core.Diagnostics;
using Cake.Core.IO;

namespace Cake.Docker.Tests.Build
{
    public class DockerRegistryLoginFixture : ToolFixture<DockerRegistryLoginSettings>, ICakeContext
    {
        public string Path { get; set; }

        IFileSystem ICakeContext.FileSystem => FileSystem;

        ICakeEnvironment ICakeContext.Environment => Environment;

        public ICakeLog Log => Log;

        ICakeArguments ICakeContext.Arguments => throw new NotImplementedException();

        IProcessRunner ICakeContext.ProcessRunner => ProcessRunner;

        public IRegistry Registry => Registry;

        public DockerRegistryLoginFixture(): base("docker")
        {
            ProcessRunner.Process.SetStandardOutput(new string[] { });
        }
        protected override void RunTool()
        {
            this.DockerLogin(Settings, Path);
        }
    }
}
