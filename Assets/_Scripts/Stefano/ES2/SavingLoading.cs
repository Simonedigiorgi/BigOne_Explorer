using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavingLoading : MonoBehaviour 
{


	#region Save

	/// <summary>
	/// Metodo che esegue tutti i salvataggi
	/// </summary>
	public void Save()
	{

		SaveCurrentScene ();
		SaveCurrentQuest ();
		SaveGadget ();
		SaveScenes ();
		SaveInteractableObjects ();

	}

	/// <summary>
	/// Metodo che salva il nome della scnea corrente
	/// </summary>
	private void SaveCurrentScene()
	{

		//String
		ES2.Save (Database.currentScene, PlayerPrefs.GetString ("Slot") + ".txt?tag=currentScene");

	}

	/// <summary>
	/// Metodo che permette il salvataggio della quest corrente
	/// </summary>
	private void SaveCurrentQuest()
	{

		//Enum string
		ES2.Save (Database.currentQuest.currentState, PlayerPrefs.GetString ("Slot") + ".txt?tag=currentQuestCurrentState");
		//string
		ES2.Save (Database.currentQuest.questName, PlayerPrefs.GetString ("Slot") + ".txt?tag=currentQuestName");

		for (int i = 0; i < Database.currentQuest.tasks.Count; i++) 
		{

			//bool
			ES2.Save (Database.currentQuest.tasks [i].currentState, PlayerPrefs.GetString ("Slot") + ".txt?tag=currentQuestTaskCurrentState" + i);
			//string
			ES2.Save (Database.currentQuest.tasks [i].taskName, PlayerPrefs.GetString ("Slot") + ".txt?tag=currentQuestTaskTaskName" + i);
			//int
			ES2.Save (Database.currentQuest.tasks[i].taskPriority, PlayerPrefs.GetString ("Slot") + ".txt?tag=currentQuestTaskTaskPriority" + i);

		}

		//bool
		ES2.Save (Database.currentQuest.activedTask.currentState, PlayerPrefs.GetString ("Slot") + ".txt?tag=currentQuestActivedTaskCurrentState");
		//string
		ES2.Save (Database.currentQuest.activedTask.taskName, PlayerPrefs.GetString ("Slot") + ".txt?tag=currentQuestActivedTaskTaskName");
		//int
		ES2.Save (Database.currentQuest.activedTask.taskPriority, PlayerPrefs.GetString ("Slot") + ".txt?tag=currentQuestActivedTaskTaskPriority");

		//int 
		ES2.Save (Database.currentQuest.questPriority, PlayerPrefs.GetString ("Slot") + ".txt?tag=currentQuestQuestPriority");

		Debug.Log ("Quest corrente salvata");

	}

	/// <summary>
	/// Metodo che salva i gadgets
	/// </summary>
	private void SaveGadget()
	{

		for (int i = 0; i < Database.gadgets.Count; i++) 
		{

			//string
			ES2.Save (Database.gadgets[i].gadgetName, PlayerPrefs.GetString ("Slot") + ".txt?tag=gadgetGadgetName"+i);
			//bool
			ES2.Save (Database.gadgets[i].isActive, PlayerPrefs.GetString ("Slot") + ".txt?tag=gadgetIsActive"+i);

		}

		Debug.Log ("Gadegts salvati");

	}

	/// <summary>
	/// Salvataggio delle scene
	/// </summary>
	private void SaveScenes()
	{

		for (int i = 0; i < Database.scenes.Count; i++) 
		{

			//String
			ES2.Save (Database.scenes[i].sceneName, PlayerPrefs.GetString ("Slot") + ".txt?tag=scenesSceneName"+i);
			//bool
			ES2.Save (Database.scenes[i].isUnlocked, PlayerPrefs.GetString ("Slot") + ".txt?tag=scenesIsActive"+i);

		}

		Debug.Log ("Scene salvate");

	}

	/// <summary>
	/// Salavtaggio degli interactable Objects
	/// </summary>
	private void SaveInteractableObjects()
	{

		for (int i = 0; i < Database.interactableObjects.Count; i++) 
		{

			//Enum String
			ES2.Save (Database.interactableObjects[i].type, PlayerPrefs.GetString ("Slot") + ".txt?tag=interactableObjectType"+i);
			//String
			ES2.Save (Database.interactableObjects[i].interactableName, PlayerPrefs.GetString ("Slot") + ".txt?tag=interactableObjectIntercatableName"+i);
			//bool
			ES2.Save (Database.interactableObjects[i].isInteractable, PlayerPrefs.GetString ("Slot") + ".txt?tag=interactableObjectIsinteractable"+i);
			//string
			ES2.Save (Database.interactableObjects[i].sceneContainer, PlayerPrefs.GetString ("Slot") + ".txt?tag=interactableObjectSceneContainer"+i);

		}

		Debug.Log ("Interctable Objects salvati");

	}

	#endregion

	#region Load

	/// <summary>
	/// Metodo che esegue tutti i metodi di caricamento
	/// </summary>
	public void Load()
	{

		if (ES2.Exists (PlayerPrefs.GetString("Slot")+".txt")) 
		{

			LoadCurrentScene ();
			LoadCurrentQuest ();
			LoadGadgets ();
			LoadScene ();
			LoadInteractableObjects ();

		}
		else
			Debug.Log ("Il file non esiste");

	}

	/// <summary>
	/// Metodo che carica il nome della scena corrente
	/// </summary>
	private void LoadCurrentScene()
	{

		Database.currentScene =  ES2.Load<string> (PlayerPrefs.GetString ("Slot") + ".txt?tag=currentScene");

		Debug.Log ("Scena corrente caricata");

	}

	/// <summary>
	/// Metodo che carica la quest corrente
	/// </summary>
	private void LoadCurrentQuest()
	{

		Database.currentQuest.currentState = ES2.Load<Quest.QuestState> (PlayerPrefs.GetString ("Slot") + ".txt?tag=currentQuestCurrentState");
		Database.currentQuest.questName = ES2.Load<string> (PlayerPrefs.GetString ("Slot") + ".txt?tag=currentQuestName");

		for (int i = 0; i < Database.currentQuest.tasks.Count; i++) 
		{

			Database.currentQuest.tasks [i].currentState = ES2.Load<Task.TaskState> (PlayerPrefs.GetString ("Slot") + ".txt?tag=currentQuestTaskCurrentState" + i);
			Database.currentQuest.tasks [i].taskName = ES2.Load<string> (PlayerPrefs.GetString ("Slot") + ".txt?tag=currentQuestTaskTaskName" + i);
			Database.currentQuest.tasks [i].taskPriority = ES2.Load<int> (PlayerPrefs.GetString ("Slot") + ".txt?tag=currentQuestTaskTaskPriority" + i);

		}

		Database.currentQuest.activedTask.currentState = ES2.Load<Task.TaskState> (PlayerPrefs.GetString ("Slot") + ".txt?tag=currentQuestActivedTaskCurrentState");
		Database.currentQuest.activedTask.taskName = ES2.Load<string> (PlayerPrefs.GetString ("Slot") + ".txt?tag=currentQuestActivedTaskTaskName");
		Database.currentQuest.activedTask.taskPriority = ES2.Load<int> (PlayerPrefs.GetString ("Slot") + ".txt?tag=currentQuestActivedTaskTaskPriority");
		Database.currentQuest.questPriority = ES2.Load<int> (PlayerPrefs.GetString ("Slot") + ".txt?tag=currentQuestQuestPriority");

		Debug.Log ("Quest corrente caricata");

	}

	/// <summary>
	/// Metodo che carica i gadgets
	/// </summary>
	private void LoadGadgets()
	{

		for (int i = 0; i < Database.gadgets.Count; i++) 
		{
			

			Database.gadgets [i].gadgetName = ES2.Load<string> (PlayerPrefs.GetString ("Slot") + ".txt?tag=gadgetGadgetName" + i);
			Database.gadgets [i].isActive = ES2.Load<bool> (PlayerPrefs.GetString ("Slot") + ".txt?tag=gadgetIsActive" + i);

		}

		Debug.Log ("Gadegts caricati");

	}

	/// <summary>
	/// Metodo che carica i dati delle scene
	/// </summary>
	private void LoadScene()
	{

		for (int i = 0; i < Database.scenes.Count; i++) 
		{

			Database.scenes [i].sceneName = ES2.Load<string> (PlayerPrefs.GetString ("Slot") + ".txt?tag=scenesSceneName" + i);
			Database.scenes [i].isUnlocked = ES2.Load<bool> (PlayerPrefs.GetString ("Slot") + ".txt?tag=scenesIsActive" + i);

		}

		Debug.Log ("Scene caricate");

	}

	/// <summary>
	/// Metodo che carica gli interactableObjects
	/// </summary>
	private void LoadInteractableObjects()
	{

		for (int i = 0; i < Database.interactableObjects.Count; i++) 
		{
			
			Database.interactableObjects [i].type = ES2.Load<InteractableType> (PlayerPrefs.GetString ("Slot") + ".txt?tag=interactableObjectType" + i);
			Database.interactableObjects [i].interactableName = ES2.Load<string> (PlayerPrefs.GetString ("Slot") + ".txt?tag=interactableObjectIntercatableName" + i);
			Database.interactableObjects [i].isInteractable = ES2.Load<bool> (PlayerPrefs.GetString ("Slot") + ".txt?tag=interactableObjectIsinteractable" + i);
			Database.interactableObjects [i].sceneContainer = ES2.Load<string> (PlayerPrefs.GetString ("Slot") + ".txt?tag=interactableObjectSceneContainer" + i);

		}

		Debug.Log ("Interctable Objects caricati");

	}

	#endregion

}
