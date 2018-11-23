#region ScriptImports

// Scripts
#load "CakeScripts/base/base.buildsystem.cake"
#load "CakeScripts/base/base.variables.cake"
#load "CakeScripts/base/base.setup.cake"
#load "CakeScripts/base/base.nuget.restore.cake"
#load "CakeScripts/base/base.paket.restore.cake"
#load "CakeScripts/base/base.msbuild.cake"
#load "CakeScripts/base/base.dotnetcoretest.minicover.cake"
#load "CakeScripts/base/base.gitreleasenotes.cake"
#load "CakeScripts/base/base.nuget.pack.cake"
#load "CakeScripts/base/base.nuget.push.cake"
#load "CakeScripts/base/base.docfx.cake"

#endregion

#region Variables

var miniCoverProject = string.Format("./{0}.Tests/{0}.Tests.csproj", projectName);

#endregion


#region Tasks

// Set up the MiniCover project
SetMiniCoverToolsProject(miniCoverProject);

// Set up variables specific for the project
Task ("VariableSetup")
	.Does(() => {
		projectName = "VaraniumSharp.DryIoc";
		releaseFolderString = "./{0}/bin/{1}/netstandard2.0";
		releaseBinaryType = "dll";
		repoOwner = "NinetailLabs";
		botName = "NinetailLabsBot";
		botEmail = "gitbot@ninetaillabs.com";
		botToken = EnvironmentVariable("BotToken");
		gitRepo = string.Format("https://github.com/{0}/{1}.git", repoOwner, projectName);
	});

Task ("Default")
	.IsDependentOn ("DiscoverBuildDetails")
	.IsDependentOn ("OutputVariables")
	.IsDependentOn ("LocateFiles")
	.IsDependentOn ("VariableSetup")
	.IsDependentOn ("NugetRestore")
	.IsDependentOn ("PaketRestore")
	.IsDependentOn ("Build")
	.IsDependentOn ("UnitTests")
	.IsDependentOn ("GenerateReleaseNotes")
	.IsDependentOn ("NugetPack")
	.IsDependentOn ("NugetPush")
	.IsDependentOn ("Documentation")
	.IsDependentOn ("FailBuildIfTestFailed");

#endregion

#region RunTarget

RunTarget (target);

#endregion