using UnityEngine;
using UnityEditor;

public class CharacterDataAsset
{

	[MenuItem("Assets/Create/Character Data")]
	public static void CreateAsset ()
	{
		ScriptableObjectUtility.CreateAsset<CharacterData> ();
	}
}
