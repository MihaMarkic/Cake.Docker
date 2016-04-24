# Cake.Docker

A Cake AddIn that extends Cake with [Docker](https://www.docker.com/) command tools.

[![cakebuild.net](https://img.shields.io/badge/WWW-cakebuild.net-blue.svg)](http://cakebuild.net/)
[![NuGet](https://img.shields.io/nuget/v/Cake.Docker.svg)](https://www.nuget.org/packages/Cake.Docker)

## Including addin
Including addin in cake script is easy.
```
#addin "Cake.Docker"
```
## Commands supported

- [DockerPs](https://docs.docker.com/engine/reference/commandline/ps/) v0.3.0
- [DockerRm](https://docs.docker.com/engine/reference/commandline/rm/)
- [DockerRmi](https://docs.docker.com/engine/reference/commandline/rmi/)
- [DockerStop](https://docs.docker.com/engine/reference/commandline/stop/)
- [DockerBuild](https://docs.docker.com/engine/reference/commandline/build/)
- [DockerCreate](https://docs.docker.com/engine/reference/commandline/create/) v0.2.0
- [DockerBuild](https://docs.docker.com/engine/reference/commandline/build/) v0.1.0, 0.2.0 (full settings)
- [DockerCp](https://docs.docker.com/engine/reference/commandline/cp/) v0.2.0

## Usage

To use the addin just add it to Cake call the aliases and configure any settings you want.

```csharp
#addin "Cake.Docker"

...

// How to remove a container with no settings
Task("DockerRm")
	.Does(() => {
		// or more containers at once
		DockerRm("containerName1", "containerName2", ...);
	)};
	
// How to remove a container with settings
Task("DockerRmWithSettings")
	.Does(() => {
		// or more containers at once
		DockerRm(new DockerRmSettings { Force = true }, "containerName1", "containerName2", ...);
	)};
```
Other commands follow same convention.

All come with settings argument and support all settings except for DockerBuild which supports only major settings.
# General Notes
**This is an initial version and not tested thoroughly**.
Contributions welcome.

Tested only on Windows. I guess it should work on Linux, too, assuming a proper docker exe name is added.

[![Follow @mihamarkic](https://img.shields.io/badge/Twitter-Follow%20%40mihamarkic-blue.svg)](https://twitter.com/intent/follow?screen_name=mihamarkic)
