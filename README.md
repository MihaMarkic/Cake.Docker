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

* 1.1.0: Cake 2.0.0

- 1.0.0: Cake 1.0.0

- 0.10.0: Cake 0.33

- 0.9.4: Cake 0.28

- 0.9 references Cake 0.26 (and goes .NET Standard 2.0 only)

**Important**: In version 1.1.0 the .netstandard 2.0 version is dropped and instead .netcore 3.1, .net5 and .net6 versions are distributed.

**Important**: Since version 0.10.0 path argument to DockerBuild is now quoted if not quoted already.

**Important**: Docker 17.* is supported since v0.8 and background compatibility is dropped (most notably, array arguments are converter to strings). If you wish to match older docker versions, user an older Cake.Docker version.

**Important**: Since version 0.8.0 the settings are generated from the latest Docker source code on github.

**BREAKING** Starting with 0.8.0 command's setting types that haven't been composed of all words have changed to full name. i.e. DockerBuildSettings to DockerImageBuildSettings). 

- [DockerBuildXBake](https://docs.docker.com/engine/reference/commandline/buildx_bake/) v1.1.0
- [DockerBuildXBuild](https://docs.docker.com/engine/reference/commandline/buildx_build/) v1.1.0
- [DockerBuildXCreate](https://docs.docker.com/engine/reference/commandline/buildx_create/) v1.1.0
- [DockerBuildXDu](https://docs.docker.com/engine/reference/commandline/buildx_du/) v1.1.0
- [DockerBuildXImageToolsCreate](https://docs.docker.com/engine/reference/commandline/buildx_imagetools_create/) v1.1.0
- [DockerBuildXImageToolsInspect](https://docs.docker.com/engine/reference/commandline/buildx_imagetools_inspect/) v1.1.0
- [DockerBuildXInspect](https://docs.docker.com/engine/reference/commandline/buildx_inspect/) v1.1.0
- [DockerBuildXInstall](https://docs.docker.com/engine/reference/commandline/buildx_install/) v1.1.0
- [DockerBuildXLs](https://docs.docker.com/engine/reference/commandline/buildx_ls/) v1.1.0
- [DockerBuildXPrune](https://docs.docker.com/engine/reference/commandline/buildx_prune/) v1.1.0
- [DockerBuildXRm](https://docs.docker.com/engine/reference/commandline/buildx_rm/) v1.1.0
- [DockerBuildXStop](https://docs.docker.com/engine/reference/commandline/buildx_stop/) v1.1.0
- [DockerBuildXUninstall](https://docs.docker.com/engine/reference/commandline/buildx_uninstall/) v1.1.0
- [DockerBuildXUse](https://docs.docker.com/engine/reference/commandline/buildx_use/) v1.1.0
- [DockerBuildXVersion](https://docs.docker.com/engine/reference/commandline/buildx_version/) v1.1.0
- [DockerComposePush](https://docs.docker.com/compose/reference/push/) v1.0.0
- [DockerContainerLs](https://docs.docker.com/engine/reference/commandline/container_ls/) v0.11.1
- [DockerImageLs](https://docs.docker.com/engine/reference/commandline/image_ls/) v0.11.1
- [DockerManifestAnnotate](https://docs.docker.com/engine/reference/commandline/manifest_annotate/) v0.11.0
- [DockerManifestCreate](https://docs.docker.com/engine/reference/commandline/manifest_create/) v0.11.0
- [DockerManifestInspect](https://docs.docker.com/engine/reference/commandline/manifest_inspect/) v0.11.0
- [DockerManifestPush](https://docs.docker.com/engine/reference/commandline/manifest_push/) v0.11.0
- [DockerComposePs](https://docs.docker.com/compose/reference/ps/) v0.10.1
- [DockerComposePort](https://docs.docker.com/compose/reference/port/) v0.10.1
- [DockerVolumeCreate](https://docs.docker.com/engine/reference/commandline/volume_create/) v0.10.0
- [DockerVolumeInspect](https://docs.docker.com/engine/reference/commandline/volume_inspect/) v0.10.0
- [DockerVolumeLs](https://docs.docker.com/engine/reference/commandline/volume_ls/) v0.10.0
- [DockerVolumePrune](https://docs.docker.com/engine/reference/commandline/volume_prune/) v0.10.0
- [DockerVolumeRm](https://docs.docker.com/engine/reference/commandline/volume_rm/) v0.10.0
- [DockerPs](https://docs.docker.com/engine/reference/commandline/ps/) v0.9.9
- [DockerComposeLogs](https://docs.docker.com/compose/reference/logs/) v0.9.7
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

**Contributions welcome - but ask first (create an issue)**.

Tested only on Windows and Ubuntu. Ensure that Docker command line tool can be located using the PATH (e.g. check that it can be found with `which docker`).
On Linux machines, ensure that user has access to the `docker` daemon Unix socket or use the DOCKER_HOST environment variable to point to the daemon's TCP port.
Refer to the Docker documentation for controlling access to the docker daemon Unix socket.

[![Follow @mihamarkic](https://img.shields.io/badge/Twitter-Follow%20%40mihamarkic-blue.svg)](https://twitter.com/intent/follow?screen_name=mihamarkic)

## Discussion

For questions and to discuss ideas & feature requests, use the [GitHub discussions on the Cake GitHub repository](https://github.com/cake-build/cake/discussions), under the [Extension Q&A](https://github.com/cake-build/cake/discussions/categories/extension-q-a) category.

[![Join in the discussion on the Cake repository](https://img.shields.io/badge/GitHub-Discussions-green?logo=github)](https://github.com/cake-build/cake/discussions)
