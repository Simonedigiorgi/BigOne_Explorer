using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProvaFiglio : ProvaDotween
{

    /*public string[] scenes;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            scenes = ReadNames();

            foreach(string s in scenes)
            {
                print(s);
            }
            
            //StartCoroutine(Prova());
        }


    }

    

    private static string[] ReadNames()
    {
        List<string> temp = new List<string>();
        foreach (UnityEditor.EditorBuildSettingsScene S in UnityEditor.EditorBuildSettings.scenes)
        {
            if (S.enabled)
            {
                string name = S.path.Substring(S.path.LastIndexOf('/') + 1);
                name = name.Substring(0, name.Length - 6);
                temp.Add(name);
            }
        }
        return temp.ToArray();
    }

    protected override IEnumerator Prova()
    {
        

        yield return StartCoroutine(base.Prova());

        Debug.Log("Olè");

        yield return null;

    }*/
}