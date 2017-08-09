using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class BuildScript {

	[MenuItem("Build/Build Android")]
	static void PerformAndroidBuild()
	{
		CleanBuild();
		PreBuildAndroid();
		GenericBuild(BuildTarget.Android, "Output/AndroidBuild.apk");
	}

	[MenuItem("Build/Build iOS")]
	static void PerformIOSBuild()
	{
		CleanBuild();
		PreBuildIOS();
		GenericBuild(BuildTarget.iOS, "XCProject");
	}

	[MenuItem("Build/Build Windows")]
	static void PerformWindowsBuild()
	{
		CleanBuild();
		GenericBuild(BuildTarget.StandaloneWindows64, "Output/WindowsBuild.exe");
	}

	static void PreBuildAndroid()
	{
		// EditorPrefs.SetString("AndroidSdkRoot", BuildSettings.Instance.androidSDKPath);
		// EditorPrefs.SetString("JdkPath", BuildSettings.Instance.jdkPath);
		PlayerSettings.bundleIdentifier = BuildSettings.Instance.bundleName;
		PreBuild();
	}

	static void PreBuildIOS()
	{
		PlayerSettings.iPhoneBundleIdentifier = BuildSettings.Instance.iPhoneBundle;
		PreBuild();
	}

	static void PreBuild()
	{
		PlayerSettings.productName = BuildSettings.Instance.productName;
		PlayerSettings.companyName = BuildSettings.Instance.companyName;
	}

	static void GenericBuild(BuildTarget target, string path)
	{
//		BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
//		buildPlayerOptions.scenes = BuildSettings.Instance.buildScenes;
//		buildPlayerOptions.locationPathName = path;
//		buildPlayerOptions.target = target;
//		buildPlayerOptions.options = BuildOptions.None;
//
//		BuildPipeline.BuildPlayer(buildPlayerOptions);
		BuildPipeline.BuildPlayer (BuildSettings.Instance.buildScenes, path, target, BuildOptions.None);

	}

	static void CleanBuild()
	{
		DirectoryInfo info = new DirectoryInfo("Output");
		if(info.Exists)
		{
			info.Delete(true);
		}
		info.Create();
	}
}
