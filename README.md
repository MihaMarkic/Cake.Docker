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

**Cake references**

* 0.9.4: Cake 0.28

- 0.9 references Cake 0.26 (and goes .NET Standard 2.0 only)

**Important**: Docker 17.* is supported since v0.8 and background compatibility is dropped (most notably, array arguments are converter to strings). If you wish to match older docker versions, user an older Cake.Docker version.

**Important**: Since version 0.8.0 the settings are generated from the latest Docker source code on github.

**BREAKING** Starting with 0.8.0 command's setting types that haven't been composed of all words have changed to full name. i.e. DockerBuildSettings to DockerImageBuildSettings). 

- [DockerComposeExec](https://docs.docker.com/compose/reference/exec/) v0.9.2
- DockerCustomCommand (*can execute any command*) v0.8.4
- [DockerLogout](https://docs.docker.com/engine/reference/commandline/logout/) v0.8.3
- [DockerStart](https://docs.docker.com/engine/reference/commandline/start/) v0.8.2
- [DockerLogs](https://docs.docker.com/engine/reference/commandline/logs/) v0.8.2
- [DockerExec](https://docs.docker.com/engine/reference/commandline/exec/) v0.8.0
- [DockerRun](https://docs.docker.com/engine/reference/commandline/run/) v0.7.2
- [DockerPull](https://docs.docker.com/engine/reference/commandline/pull/) v0.7.1
- [DockerComposeBuild](https://docs.docker.com/compose/reference/build/) v0.7.0
- [DockerComposeCreate](https://docs.docker.com/compose/reference/create/) v0.7.0
- [DockerComposeDown](https://docs.docker.com/compose/reference/down/) v0.7.0
- [DockerComposeKill](https://docs.docker.com/compose/reference/kill/) v0.7.0
- [DockerComposePause](https://docs.docker.com/compose/reference/pause/) v0.7.0
- [DockerComposePull](https://docs.docker.com/compose/reference/pull/) v0.7.0
- [DockerComposeRestart](https://docs.docker.com/compose/reference/restart/) v0.7.0
- [DockerComposeRm](https://docs.docker.com/compose/reference/rm/) v0.7.0
- [DockerComposeRun](https://docs.docker.com/compose/reference/run/) v0.7.0
- [DockerComposeScale](https://docs.docker.com/compose/reference/scale/) v0.7.0
- [DockerComposeStart](https://docs.docker.com/compose/reference/start/) v0.7.0
- [DockerComposeStop](https://docs.docker.com/compose/reference/stop/) v0.7.0
- [DockerComposeUnpause](https://docs.docker.com/compose/reference/unpause/) v0.7.0
- [DockerComposeUp](https://docs.docker.com/compose/reference/up/) v0.7.0
- [DockerLoad](https://docs.docker.com/engine/reference/commandline/load/) v0.6.0
- [DockerSave](https://docs.docker.com/engine/reference/commandline/save/) v0.6.0
- [DockerNetworkCreate](https://docs.docker.com/engine/reference/commandline/network_create/) v0.5.0
- [DockerNetworkConnect](https://docs.docker.com/engine/reference/commandline/network_connect/) v0.5.0
- [DockerNetworkDisconnect](https://docs.docker.com/engine/reference/commandline/network_disconnect/) v0.5.0
- [DockerNetworkRm](https://docs.docker.com/engine/reference/commandline/network_rm/) v0.5.0
- [DockerSwarmInit](https://docs.docker.com/engine/reference/commandline/swarm_init/) v0.5.0
- [DockerSwarmJoin](https://docs.docker.com/engine/reference/commandline/swarm_join/) v0.5.0
- [DockerSwarmLeave](https://docs.docker.com/engine/reference/commandline/swarm_leave/) v0.5.0
- [DockerSwarmUpdate](https://docs.docker.com/engine/reference/commandline/swarm_update/) v0.5.0
- [DockerLogin](https://docs.docker.com/engine/reference/commandline/login/) v0.4.0
- [DockerPush](https://docs.docker.com/engine/reference/commandline/push/) v0.4.0
- [DockerTag](https://docs.docker.com/engine/reference/commandline/tag/) v0.4.0
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

**Contributions welcome - but not for command settings code**. The reason being is that the actual code for settings is autogenerated from docker sources.

Tested only on Windows and Ubuntu. Ensure that Docker command line tool can be located using the PATH (e.g. check that it can be found with `which docker`).
On Linux machines, ensure that user has access to the `docker` daemon Unix socket or use the DOCKER_HOST environment variable to point to the daemon's TCP port.
Refer to the Docker documentation for controlling access to the docker daemon Unix socket.

[![Follow @mihamarkic](https://img.shields.io/badge/Twitter-Follow%20%40mihamarkic-blue.svg)](https://twitter.com/intent/follow?screen_name=mihamarkic)
