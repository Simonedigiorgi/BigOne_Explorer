using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ManagerCharacters : MonoBehaviour {

	#region Tuple
	public struct Tuple
	{

		public bool valueBool;
		public int valueInt;

	
	}
	#endregion

	#region Public
	public CharacterData Billy;
	#endregion

	#region Inventory
	//metodo per controllare se esiste l'oggetto nella lista
	public Tuple searchObject(GameObject obj)
	{
		//Dichiaro la struct di ritorno
		Tuple T = new Tuple ();

		T.valueInt = Billy.inventory.FindIndex (x => x.nameObject == obj.name);
		var item = Billy.inventory [T.valueInt];

		if (item != null) 
		{

			if (item.isVisible == true) 
			{

				T.valueBool = true;
				return T;

			}
			else 
			{

				T.valueBool = false;
				return T;

			}

		}

		//Errore
		Debug.LogError ("L'oggetto che cerchi non si trova nell'inventario, aggiungilo");
		T.valueBool = false;
		T.valueInt = -1;
		return T;

	}

	//Metodo per aggiornare o aggiungere un oggetto dell'inventario
	public void addObjectInventory(GameObject obj, int quantity)
	{

		Tuple T = new Tuple ();

		//mi faccio tornare il risultati di ritorno della funzione
		T = searchObject (obj);

		if (T.valueBool == false) 
		{//Rendo visibile nell'inventario l'oggetto e associo la quantità passata

			Billy.inventory [T.valueInt].isVisible = true;
			Billy.inventory [T.valueInt].quantity = quantity;

		} 
		else 
		{//Aggiungo la qauntità passata alla quantità in giacenza

			Billy.inventory [T.valueInt].quantity += quantity;

		}

	}

	//Metodo per togliere o disattivare un oggetto dall'inventario
	public bool missObjectInventory(GameObject obj, int quantity)
	{

		Tuple T = new Tuple ();

		T = searchObject (obj);

		//Controllo se l'operazione è fattibile
		if (Billy.inventory [T.valueInt].quantity < quantity) {

			Debug.LogError ("Non hai abbastanza oggetti di questo tipo");
			return false;

		} 
		else 
		{

			Billy.inventory [T.valueInt].quantity -= quantity;

			if (Billy.inventory [T.valueInt].quantity == 0) 
			{
				
				//La quantità è zero di questo oggetto quindi lo disattivo dall'inventario 

				Billy.inventory [T.valueInt].isVisible = false;

			}

			return true;

		}

	}
	#endregion


	#region DEMO
	//metodo per controllare se esiste l'oggetto nella lista
	public Tuple testSearchObject(string objectName)
	{
		//Dichiaro la struct di ritorno
		Tuple T = new Tuple ();

		T.valueInt = Billy.inventory.FindIndex (x => x.nameObject == objectName);
		Debug.Log("Index = "+T.valueInt);

		if (T.valueInt != -1) 
		{

			var item = Billy.inventory [T.valueInt];

			if (item.isVisible == true) 
			{

				T.valueBool = true;
				return T;

			}
			else 
			{

				T.valueBool = false;
				return T;

			}

		}

		//Errore
		Debug.LogError ("L'oggetto che cerchi non si trova nell'inventario, aggiungilo");
		T.valueBool = false;
		return T;

	}


	public void testInventory(string objectName)
	{

		Tuple T = new Tuple ();

		//mi faccio tornare il risultati di ritorno della funzione
		T = testSearchObject (objectName);

		if (T.valueBool == false) 
		{//Rendo visibile nell'inventario l'oggetto e associo la quantità passata

			Billy.inventory [T.valueInt].isVisible = true;
			Billy.inventory [T.valueInt].quantity = 1;

		} 
		else 
		{//Aggiungo la qauntità passata alla quantità in giacenza

			Billy.inventory [T.valueInt].quantity += 1;

		}

	}
	#endregion

	
}
