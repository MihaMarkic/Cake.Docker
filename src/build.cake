#addin "Cake.FileHelpers"

var Project = Directory("./Cake.Docker/");
var TestProject = Directory("./Cake.Docker.Tests/");
var CakeDockerProj = Project + File("Cake.Docker.csproj");
var CakeTestDockerProj = TestProject + File("Cake.Docker.Test.csproj");
var CakeTestDockerAssembly = TestProject + Directory("bin/Release") + File("Cake.Docker.Tests.dll");
var AssemblyInfo = Project + File("Properties/AssemblyInfo.cs");
var CakeDockerSln = File("./Cake.Docker.sln");
var CakeDockerNuspec = File("./Cake.Docker.nuspec");
var Nupkg = Directory("./nupkg");

var target = Argument("target", "Default");
var version = "";

Task("Default")
	.Does (() =>
	{
		NuGetRestore (CakeDockerSln);
		DotNetBuild (CakeDockerSln, c => {
			c.Configuration = "Release";
			c.Verbosity = Verbosity.Minimal;
		});
});

Task("UnitTest")
	.IsDependentOn("Default")
	.Does(() =>
	{
		NUnit3(CakeTestDockerAssembly);
	});

Task("NuGetPack")
	.IsDependentOn("GetVersion")
	.IsDependentOn("Default")
	.IsDependentOn("UnitTest")
	.Does (() =>
{
	CreateDirectory(Nupkg);
	NuGetPack (CakeDockerNuspec, new NuGetPackSettings { 
		Version = version,
		Verbosity = NuGetVerbosity.Detailed,
		OutputDirectory = Nupkg,
		BasePath = "./",
	});	
});

Task("GetVersion")
	.Does(() => {
		var assemblyInfo = ParseAssemblyInfo(AssemblyInfo);
		var semVersion = string.Join(".", assemblyInfo.AssemblyVersion.Split('.').Take(3));
		Information("Version {0}", semVersion);
		version = semVersion;
	});

RunTarget (target);
