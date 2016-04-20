# Cake.Docker 0.1.1
- Fixed NuGet package

# Cake.Docker 0.1.0
Cake AddIn that extends Cake with Docker command tools.
## Including addin
Including addin in cake script is easy.
```
#addin "Cake.Docker"
```
## Commands supported

- DockerRm
- DockerRmi
- DockerStop
- DockerBuild

All come with settings argument and support all settings except for DockerBuild which supports only major settings.
# General Notes
**This is an initial version and not tested thoroughly**.
Contributions welcome.

Tested only on Windows. I guess it should work on Linux, too, assuming a proper docker exe name is added.
