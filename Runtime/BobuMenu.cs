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
        if (GUILayout.Button("Import DragDrop"))
        {
            ImportScript("AudioManager.cs");
        }

        if (GUILayout.Button("Import Audio"))
        {
            ImportScript("AudioManager.cs");
        }
    }

    private void ImportScript(string scriptName)
    {
        string githubApiUrl = "https://api.github.com/repos/{owner}/{repo}/contents/{path}";
        string owner = "kidstellar"; // GitHub kullan?c? ad? veya organizasyon ad?
        string repo = "BobuScripts"; // GitHub reposu ad?
        string path = scriptName; // GitHub'daki scriptin yolunu i?eren dosya yolu

        string apiUrl = githubApiUrl.Replace("{owner}", owner).Replace("{repo}", repo).Replace("{path}", path);

        UnityWebRequest request = UnityWebRequest.Get(apiUrl);
        request.SetRequestHeader("Accept", "application/vnd.github.v3.raw");
        request.SetRequestHeader("User-Agent", "UnityWebRequest");

        request.SendWebRequest().completed += operation =>
        {
            if (request.result == UnityWebRequest.Result.Success)
            {
                string scriptContent = request.downloadHandler.text;
                string destinationPath = "Assets/Scripts/" + scriptName; // Scriptin projeye kopyalanaca?? yol
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
