using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterData : ScriptableObject {

	public enum characterType{Medico, Ingeniere, Botanico, Geologo};

	[Header("Nome del personaggio")]
	public string name;
	[Header("Classe del personaggio")]
	public characterType type;
	[Header("Vita del personaggio")]
	[Range(0.0f, 100.0f)]
	public float health;
	[Header("Inventario")]
	public List<ObjectInventory> inventory;


}

//Classe inventario
[Serializable]
public class ObjectInventory
{
	public enum objectType{Type1, Type2, Type3, Type4};

	public bool isVisible = false;
	public string nameObject;
	public string informationText;
	[Range(0,99)]
	public int quantity;
	public objectType type;

}
