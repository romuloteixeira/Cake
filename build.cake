var target = Argument("target", "ExecuteBuild");
var configuration = Argument("configuration", "Release");
var solutionFolder = "./";
var myLibraryFolder = "./MyLibrary";
var outputFolder = "./artifacts";
var myLibraryOutputFolder = "./myLibraryArtifacts";

Task("Clean")
    .Does(() => {
        CleanDirectory(outputFolder);
        CleanDirectory(myLibraryOutputFolder);
    });

Task("Restore")
    .Does(() => {
        DotNetCoreRestore(solutionFolder);
    });

Task("Build")
    .IsDependentOn("Clean")
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

Task("Publish")
    .IsDependentOn("Test")
    .Does(() => {
        DotNetCorePublish(solutionFolder, new DotNetCorePublishSettings
        {
            NoRestore = true,
            Configuration = configuration,
            NoBuild = true,
            OutputDirectory = outputFolder
        });
    });

Task("PublishMyLibrary")
    .IsDependentOn("Test")
    .Does(() => 
    {
        DotNetCorePublish(myLibraryFolder, new DotNetCorePublishSettings
        {
            NoRestore = true,
            Configuration = configuration,
            OutputDirectory = myLibraryOutputFolder
        });
    });

Task("ExecuteBuild")
    .IsDependentOn("Publish")
    .IsDependentOn("PublishMyLibrary");
    // .Does(() => {

    // });

RunTarget(target);