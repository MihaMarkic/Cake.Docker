using Cake.Core;
using Cake.Core.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cake.Docker
{
    internal static class DockerResolver
    {
        public static FilePath? GetDockerPath(IFileSystem fileSystem, ICakeEnvironment environment)
        {
            if (fileSystem == null)
            {
                throw new ArgumentNullException(nameof(fileSystem));
            }

            if (environment == null)
            {
                throw new ArgumentNullException(nameof(environment));
            }

            // Cake already searches the PATH for the executable tool names.
            // Check for other known locations.
            return !environment.Platform.IsUnix()
                ? CheckCommonWindowsPaths(fileSystem, environment)
                : null;
        }

        /// <summary>
        /// Check common docker client locations.
        /// </summary>
        /// <param name="fileSystem"></param>
        /// <param name="environment"></param>
        /// <returns></returns>
        private static FilePath? CheckCommonWindowsPaths(IFileSystem fileSystem, ICakeEnvironment environment)
        {
            // The docker client is included as part of the Docker Toolbox installer 
            // or can be installed using a Chocolatey package (name: docker).
            // The Chocolatey install does not have a fixed location, but Docker Toolbox does.
            return GetDefaultWindowsPaths(fileSystem, environment)
                .Select(path => path.CombineWithFilePath("docker.exe"))
                .FirstOrDefault(dockerExecutable => fileSystem.GetFile(dockerExecutable).Exists);
        }

        /// <summary>
        /// Get default paths for common docker client installations.
        /// </summary>
        /// <param name="fileSystem"></param>
        /// <param name="environment"></param>
        /// <returns></returns>
        private static DirectoryPath[] GetDefaultWindowsPaths(IFileSystem fileSystem, ICakeEnvironment environment)
        {
            var paths = new List<DirectoryPath>();

            var programFiles = environment.GetSpecialPath(SpecialPath.ProgramFiles);
            var defaultDockerToolboxPath = programFiles.Combine("Docker Toolbox");
            if (fileSystem.GetDirectory(defaultDockerToolboxPath).Exists)
            {
                paths.Add(defaultDockerToolboxPath);
            }

            return paths.ToArray();
        }
    }
}
