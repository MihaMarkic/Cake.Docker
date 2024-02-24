﻿using System;
using Cake.Core;
using Cake.Core.Configuration;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Testing.Fixtures;

namespace Cake.Docker.Tests.Image.Build
{
    public class DockerBuildFixture : ToolFixture<DockerImageBuildSettings>, ICakeContext
    {
        public string Path { get; set; }

        IFileSystem ICakeContext.FileSystem => FileSystem;

        ICakeEnvironment ICakeContext.Environment => Environment;

        public ICakeLog Log => Log;

        ICakeArguments ICakeContext.Arguments => throw new NotImplementedException();

        IProcessRunner ICakeContext.ProcessRunner => ProcessRunner;

        public IRegistry Registry => Registry;

        public ICakeDataResolver Data => throw new NotImplementedException();

        ICakeConfiguration ICakeContext.Configuration => throw new NotImplementedException();

        public DockerBuildFixture() : base("docker")
        {
            ProcessRunner.Process.SetStandardOutput(Array.Empty<string>());
        }
        protected override void RunTool()
        {
            this.DockerBuild(Settings, Path);
        }
    }
}