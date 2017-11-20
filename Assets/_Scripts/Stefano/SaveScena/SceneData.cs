using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SceneData : ScriptableObject {

	public List<SceneObject> SceneObjects;
	//public List<GameObject> SceneObjects;

}

[Serializable]
public class SceneObject
{

	[Header("ID")]
	public int hashcode;
	[Header("Posizione elemento")]
	public Vector3 position;
	[Header("Oggetto distrutto?")]
	public bool isDestroyed;

}
