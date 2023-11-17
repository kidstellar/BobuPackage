using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Networking;

public class BobuMenu : EditorWindow
{
    [MenuItem("Window/BobuMenu/Scripts")]
    public static void ShowWindow()
    {
        GetWindow<BobuMenu>("Import Scripts");
    }

    private void OnGUI()
    {
        if (GUILayout.Button("Import GameManager"))
            ImportScript("GameManager.cs");

        if (GUILayout.Button("Import LevelManager"))
            ImportScript("LevelManager.cs");

        if (GUILayout.Button("Import ButtonManager"))
            ImportScript("ButtonManager.cs");

        if (GUILayout.Button("Import LevelController"))
            ImportScript("LevelController.cs");

        if (GUILayout.Button("Import AnchorGameObject"))
            ImportScript("AnchorGameObject.cs");

        if (GUILayout.Button("Import TutorialDragAnimation"))
            ImportScript("TutorialAnimation.cs");

        if (GUILayout.Button("Import Audio"))
            ImportScript("AudioManager.cs");
    }

    private void ImportScript(string scriptName)
    {
        string githubApiUrl = "https://api.github.com/repos/{owner}/{repo}/contents/{path}";
        string owner = "kidstellar";
        string repo = "BobuScripts";
        string path = scriptName;

        string apiUrl = githubApiUrl.Replace("{owner}", owner).Replace("{repo}", repo).Replace("{path}", path);

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
