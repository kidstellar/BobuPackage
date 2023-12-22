using System.Collections;
using System;
using UnityEngine;
using UnityEditor;
using UnityEngine.Networking;

#if UNITY_EDITOR
public abstract class BobuMenuBase : EditorWindow
{
    protected abstract string Owner { get; }
    protected abstract string Repo { get; }

    protected void ImportScript(string scriptName)
    {
        string githubApiUrl = "https://api.github.com/repos/{owner}/{repo}/contents/{path}";
        string path = scriptName;

        string apiUrl = githubApiUrl.Replace("{owner}", Owner).Replace("{repo}", Repo).Replace("{path}", path);

        UnityWebRequest request = UnityWebRequest.Get(apiUrl);
        request.SetRequestHeader("Accept", "application/vnd.github.v3.raw");
        request.SetRequestHeader("User-Agent", "UnityWebRequest");

        request.SendWebRequest().completed += operation =>
        {
            if (request.result == UnityWebRequest.Result.Success)
            {
                string scriptContent = request.downloadHandler.text;
                string destinationPath = "Assets/Scripts/" + scriptName;
                System.IO.File.WriteAllText(destinationPath, scriptContent);
                AssetDatabase.Refresh();
                Debug.Log("Script imported successfully!");
            }
            else
            {
                Debug.LogError("Error importing script: " + request.error);
            }
        };
    }
}
#endif

#if UNITY_EDITOR
public class MenuManagers : BobuMenuBase
{
    [MenuItem("Window/BobuMenu/Scripts/Managers")]
    public static void ShowWindow()
    {
        GetWindow<MenuManagers>("Import Scripts");
    }

    protected override string Owner => "kidstellar";
    protected override string Repo => "BobuScripts";

    private void OnGUI()
    {
        GUILayout.Label("Managers");

        if (GUILayout.Button("Import GameManager"))
            ImportScript("GameManager.cs");

        if (GUILayout.Button("Import LevelManager"))
            ImportScript("LevelManager.cs");

        if (GUILayout.Button("Import ButtonManager"))
            ImportScript("ButtonManager.cs");

        if (GUILayout.Button("Import Audio"))
            ImportScript("AudioManager.cs");
    }
}
#endif

#if UNITY_EDITOR
public class MenuControllers : BobuMenuBase
{
    [MenuItem("Window/BobuMenu/Scripts/Controllers")]
    public static void ShowWindow()
    {
        GetWindow<MenuControllers>("Import Scripts");
    }

    protected override string Owner => "kidstellar";
    protected override string Repo => "BobuScripts";

    private void OnGUI()
    {
        GUILayout.Label("Controllers");

        if (GUILayout.Button("Import LevelController"))
            ImportScript("LevelController.cs");
    }
}
#endif

#if UNITY_EDITOR
public class MenuAnchor : BobuMenuBase
{
    [MenuItem("Window/BobuMenu/Scripts/Anchor")]
    public static void ShowWindow()
    {
        GetWindow<MenuAnchor>("Import Scripts");
    }

    protected override string Owner => "kidstellar";
    protected override string Repo => "BobuScripts";


    private void OnGUI()
    {
        GUILayout.Label("Anchor");

        if (GUILayout.Button("Import Anchor"))
            ImportScript("AnchorGameObject.cs");
    }
}
#endif

#if UNITY_EDITOR
public class MenuTutorial : BobuMenuBase
{
    [MenuItem("Window/BobuMenu/Scripts/Tutorial")]
    public static void ShowWindow()
    {
        GetWindow<MenuTutorial>("Import Scripts");
    }

    protected override string Owner => "kidstellar";
    protected override string Repo => "BobuScripts";


    private void OnGUI()
    {
        GUILayout.Label("Tutorial");

        if (GUILayout.Button("Import TutorialDragAnimation"))
            ImportScript("TutorialAnimation.cs");
    }
}
#endif

#if UNITY_EDITOR
public class MenuTimeCounter : BobuMenuBase
{
    [MenuItem("Window/BobuMenu/Scripts/Timer")]
    public static void ShowWindow()
    {
        GetWindow<MenuTimeCounter>("Import Scripts");
    }

    protected override string Owner => "kidstellar";
    protected override string Repo => "BobuScripts";


    private void OnGUI()
    {
        GUILayout.Label("Timer");

        if (GUILayout.Button("Import MinuteConverter"))
            ImportScript("TimeCounter.cs");
    }
}
#endif

#if UNITY_EDITOR
public class MenuLine : BobuMenuBase
{
    [MenuItem("Window/BobuMenu/Scripts/Line")]
    public static void ShowWindow()
    {
        GetWindow<MenuLine>("Import Scripts");
    }

    protected override string Owner => "kidstellar";
    protected override string Repo => "BobuScripts";


    private void OnGUI()
    {
        GUILayout.Label("LineDrawer");

        if (GUILayout.Button("Import LineDrawer"))
            ImportScript("LineDrawer.cs");
    }
}
#endif

#if UNITY_EDITOR
public class MenuDragDrop : BobuMenuBase
{
    [MenuItem("Window/BobuMenu/Scripts/DragDropElements")]
    public static void ShowWindow()
    {
        GetWindow<MenuDragDrop>("Import Scripts");
    }

    protected override string Owner => "kidstellar";
    protected override string Repo => "BobuScripts";


    private void OnGUI()
    {
        GUILayout.Label("DragDropElements");

        if (GUILayout.Button("Import DragDrop"))
            ImportScript("DragDrop.cs");

        if (GUILayout.Button("Import Slots"))
            ImportScript("Slots.cs");
    }
}
#endif
