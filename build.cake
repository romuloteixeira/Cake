var target = Argument("target", "Test");
var configuration = Argument("configuration", "Release");
var solutionFolder = "./";

Task("Restore")
    .Does(() => {
        DotNetCoreRestore(solutionFolder);
    });

Task("Build")
    .IsDependentOn("Restore")
    .Does(() => {
        DotNetCoreBuild(solutionFolder, new DotNetCoreBuildSettings
        {
            NoRestore = true,
            Configuration = configuration
        });
    });

Task("Test")
    .IsDependentOn("Build")
    .Does(() => {
        DotNetCoreTest(solutionFolder, new DotNetCoreTestSettings
        {
            NoRestore = true,
            Configuration = configuration,
            NoBuild = true
        });
    });

RunTarget(target);