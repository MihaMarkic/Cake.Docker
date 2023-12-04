﻿using Cake.Core;
using Cake.Core.Configuration;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Testing.Fixtures;
using System;

namespace Cake.Docker.Tests.Run
{
    public class DockerPsFixture : ToolFixture<DockerContainerPsSettings>, ICakeContext
    {
        IFileSystem ICakeContext.FileSystem => FileSystem;

        ICakeEnvironment ICakeContext.Environment => Environment;

        public ICakeLog Log => Log;

        ICakeArguments ICakeContext.Arguments => throw new NotImplementedException();

        IProcessRunner ICakeContext.ProcessRunner => ProcessRunner;

        public IRegistry Registry => Registry;

        public ICakeDataResolver Data => throw new NotImplementedException();

        ICakeConfiguration ICakeContext.Configuration => throw new NotImplementedException();

        public DockerPsFixture(): base("docker")
        {
            ProcessRunner.Process.SetStandardOutput(Array.Empty<string>());
        }
        protected override void RunTool()
        {
            this.DockerPs(Settings);
        }
    }
}
