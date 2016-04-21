# Cake.Docker

A Cake AddIn that extends Cake with [Docker](https://www.docker.com/) command tools.

[![cakebuild.net](https://img.shields.io/badge/WWW-cakebuild.net-blue.svg)](http://cakebuild.net/)

## Including addin
Including addin in cake script is easy.
```
#addin "Cake.Docker"
```
## Commands supported

- [DockerRm](https://docs.docker.com/engine/reference/commandline/rm/)
- [DockerRmi](https://docs.docker.com/engine/reference/commandline/rmi/)
- [DockerStop](https://docs.docker.com/engine/reference/commandline/stop/)
- [DockerBuild](https://docs.docker.com/engine/reference/commandline/build/)
- [DockerCreate](https://docs.docker.com/engine/reference/commandline/create/)
- [DockerBuild](https://docs.docker.com/engine/reference/commandline/build/)

## Usage

To use the addin just add it to Cake call the aliases and configure any settings you want.

```csharp
#addin "Cake.Docker"

...

// How to remove a container with no settings
Task("DockerRm")
	.Does(() => {
		DockerRm("containerName");
		// or more containers at once
		DockerRm(new string[]{"containerName1", "containerName2", ...});
	)};
	
// How to remove a container with settings
Task("DockerRmWithSettings")
	.Does(() => {
		DockerRm("containerName", new DockerRmSettings { Force = true });
		// or more containers at once
		DockerRm(new string[]{"containerName1", "containerName2", ...}, new DockerRmSettings { Force = true });
	)};
```
Other commands follow same approach.

All come with settings argument and support all settings except for DockerBuild which supports only major settings.
# General Notes
**This is an initial version and not tested thoroughly**.
Contributions welcome.

Tested only on Windows. I guess it should work on Linux, too, assuming a proper docker exe name is added.
