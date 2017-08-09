using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BuildSettings
{
    private static BuildSettings instance;
    private BuildSettings(){}
    public static BuildSettings Instance
    {
        get
        {
            if(instance == null)
                instance = new BuildSettings();
            return instance;
        }
    }
    public string productName = "自动构建测试";
    public string companyName = "大熊";
    public string[] buildScenes = new [] {"Assets/Scenes/Main.unity", "Assets/Scenes/Loading.unity"};

    #region Android Settings
    public string jdkPath = @"C:\Program Files\Java\jdk1.8.0_121";
    public string androidSDKPath = "C:/Users/jiaki/AppData/Local/Android/sdk";
    public string bundleName = "com.wh.demo";
    #endregion

    #region iOS Settings
    public string iPhoneBundle = "com.lasbear.ocean";
    #endregion
}