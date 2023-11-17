using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Networking;

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

public class MenuManagers : BobuMenuBase
{
    [MenuItem("Window/BobuMenu/Scripts/Managers")]
    public static void ShowWindow()
    {
        GetWindow<MenuManagers>("Import Scripts");
    }

    protected override string Owner => "ownerA";
    protected override string Repo => "repoA";

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

public class MenuControllers : BobuMenuBase
{
    [MenuItem("Window/BobuMenu/Scripts/Controllers")]
    public static void ShowWindow()
    {
        GetWindow<MenuControllers>("Import Scripts");
    }

    protected override string Owner => "ownerB";
    protected override string Repo => "repoB";

    private void OnGUI()
    {
        GUILayout.Label("Controllers");

        if (GUILayout.Button("Import LevelController"))
            ImportScript("LevelController.cs");
    }
}

public class MenuAnchor : BobuMenuBase
{
    [MenuItem("Window/BobuMenu/Scripts/Anchor")]
    public static void ShowWindow()
    {
        GetWindow<MenuAnchor>("Import Scripts");
    }

    protected override string Owner => "ownerB";
    protected override string Repo => "repoB";

    private void OnGUI()
    {
        GUILayout.Label("Anchor");

        if (GUILayout.Button("Import Anchor"))
            ImportScript("AnchorGameObject.cs");
    }
}

public class MenuTutorial : BobuMenuBase
{
    [MenuItem("Window/BobuMenu/Scripts/Tutorial")]
    public static void ShowWindow()
    {
        GetWindow<MenuTutorial>("Import Scripts");
    }

    protected override string Owner => "ownerB";
    protected override string Repo => "repoB";

    private void OnGUI()
    {
        GUILayout.Label("Tutorial");

        if (GUILayout.Button("Import TutorialDragAnimation"))
            ImportScript("TutorialAnimation.cs");
    }
}


//namespace BobuMenu
//{
//    public class BobuMenuBase : EditorWindow
//    {
//        [MenuItem("Window/BobuMenu/Scripts")]
//        public static void ShowWindow()
//        {
//            GetWindow<BobuMenuBase>("Import Scripts");
//        }



//        private void OnGUI()
//        {

//            if (GUILayout.Button("Import GameManager"))
//                ImportScript("GameManager.cs");

//            if (GUILayout.Button("Import LevelManager"))
//                ImportScript("LevelManager.cs");

//            if (GUILayout.Button("Import ButtonManager"))
//                ImportScript("ButtonManager.cs");

//            if (GUILayout.Button("Import LevelController"))
//                ImportScript("LevelController.cs");

//            if (GUILayout.Button("Import AnchorGameObject"))
//                ImportScript("AnchorGameObject.cs");

//            if (GUILayout.Button("Import TutorialDragAnimation"))
//                ImportScript("TutorialAnimation.cs");

//            if (GUILayout.Button("Import Audio"))
//                ImportScript("AudioManager.cs");
//        }

//        protected void ImportScript(string scriptName)
//        {
//            string githubApiUrl = "https://api.github.com/repos/{owner}/{repo}/contents/{path}";
//            string owner = "kidstellar";
//            string repo = "BobuScripts";
//            string path = scriptName;

//            string apiUrl = githubApiUrl.Replace("{owner}", owner).Replace("{repo}", repo).Replace("{path}", path);

//            UnityWebRequest request = UnityWebRequest.Get(apiUrl);
//            request.SetRequestHeader("Accept", "application/vnd.github.v3.raw");
//            request.SetRequestHeader("User-Agent", "UnityWebRequest");

//            request.SendWebRequest().completed += operation =>
//            {
//                if (request.result == UnityWebRequest.Result.Success)
//                {
//                    string scriptContent = request.downloadHandler.text;
//                    string destinationPath = "Assets/Scripts/" + scriptName;
//                    System.IO.File.WriteAllText(destinationPath, scriptContent);
//                    AssetDatabase.Refresh();
//                    Debug.Log("Script imported successfully!");
//                }
//                else
//                {
//                    Debug.LogError("Error importing script: " + request.error);
//                }
//            };
//        }
//    }
//}

//namespace BobuMenu
//{
//    public class Managers : BobuMenuBase
//    {
//        [MenuItem("Window/BobuMenu/Scripts/Managers")]

//        private void OnGUI()
//        {
//            if (GUILayout.Button("Import GameManager"))
//                ImportScript("GameManager.cs");

//            if (GUILayout.Button("Import LevelManager"))
//                ImportScript("LevelManager.cs");

//            if (GUILayout.Button("Import ButtonManager"))
//                ImportScript("ButtonManager.cs");

//            if (GUILayout.Button("Import Audio"))
//                ImportScript("AudioManager.cs");
//        }
//    }

//}

//namespace BobuMenu
//{
//    public class Controllers : BobuMenuBase
//    {
//        [MenuItem("Window/BobuMenu/Scripts/Controllers")]

//        private void OnGUI()
//        {

//            if (GUILayout.Button("Import LevelController"))
//                ImportScript("LevelController.cs");
//        }
//    }
//}

//namespace BobuMenu
//{
//    public class Anchor : BobuMenuBase
//    {
//        [MenuItem("Window/BobuMenu/Scripts/Anchor")]

//        private void OnGUI()
//        {

//            if (GUILayout.Button("Import AnchorGameObject"))
//                ImportScript("AnchorGameObject.cs");

//            if (GUILayout.Button("Import TutorialDragAnimation"))
//                ImportScript("TutorialAnimation.cs");

//            if (GUILayout.Button("Import Audio"))
//                ImportScript("AudioManager.cs");
//        }
//    }
//}

//namespace BobuMenu
//{
//    public class Tutorial : BobuMenuBase
//    {
//        [MenuItem("Window/BobuMenu/Scripts/Tutorial")]

//        private void OnGUI()
//        {

//            if (GUILayout.Button("Import TutorialDragAnimation"))
//                ImportScript("TutorialAnimation.cs");

//            if (GUILayout.Button("Import Audio"))
//                ImportScript("AudioManager.cs");
//        }
//    }
//}
