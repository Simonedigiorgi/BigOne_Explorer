using UnityEngine;
using UnityEditor;

public class SceneDataAsset 
{

	[MenuItem("Assets/Create/Scene Data")]
	public static void CreateAsset ()
	{
		ScriptableObjectUtility.CreateAsset<SceneData> ();
	}

}
