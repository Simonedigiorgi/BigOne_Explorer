using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Sirenix;
using Sirenix.Utilities;
using UnityEngine.UI;
using System;

	
public class CodexStefano : MonoBehaviour 
{

	#region Class

	/// <summary>
	/// Classe che definisce un gadget 
	/// </summary>
	[Serializable]
	public class CodexGadget
	{

		[FoldoutGroup("$name")]
		[Header("Nome del Gadget")]

		public string name;

		[FoldoutGroup("$name")]
		[Header("Descrizione del Gadget")]
		[TextArea]

		public string description;

		[FoldoutGroup("$name")]
		[Header("Immagine del Gadget")]

		public Sprite photo;

		[FoldoutGroup("$name")]
		[Header("Modello 3d del Gadget")]
		[AssetList]
		[InlineEditor(InlineEditorModes.LargePreview)]

		public GameObject gadgetObj;

		[FoldoutGroup("$name")]
		[Space(10)]
		[Header("variabile che indica se queste informazioni sono disponibili")]
		public bool isAvaiable;

	}

	/// <summary>
	/// Classe che definiscie un personaggio
	/// </summary>
	[Serializable]
	public class CodexCharacter
	{

		[FoldoutGroup("$name")]
		[Header("Nome del Personaggio")]

		public string name;

		[FoldoutGroup("$name")]
		[Header("Descrizione del Personaggio")]
		[TextArea]

		public string description; 

		[FoldoutGroup("$name")]
		[Header("Immagine del personaggio")]

		public Sprite photo;

		[FoldoutGroup("$name")]
		[Header("Modello 3d del personaggio")]
		[AssetList]
		[InlineEditor(InlineEditorModes.LargePreview)]
		public GameObject charcterObj;

		[FoldoutGroup("$name")]
		[Space(10)]
		[Header("variabile che indica se queste informazioni sono disponibili")]
		public bool isAvaiable;

	}

	/// <summary>
	/// Classe che definisce un luogo del mondo di gioco
	/// </summary>
	[Serializable]
	public class CodexPlace
	{

		[FoldoutGroup("$name")]
		[Header("Nome del luogo")]

		public string name; 

		[FoldoutGroup("$name")]
		[Header("Descrizione del luogo")]
		[TextArea]

		public string description;

		[FoldoutGroup("$name")]
		[Header("Immagine del luogo")]
		public Sprite photo;

		[FoldoutGroup("$name")]
		[Space(10)]
		[Header("variabile che indica se queste informazioni sono disponibili")]
		public bool isAvaiable;

	}

	/// <summary>
	/// Classe che definisce una missione
	/// </summary>
	[Serializable]
	public class CodexMission
	{

		[FoldoutGroup("$name")]
		[Header("Nome della Missione")]

		public string name; 

		[FoldoutGroup("$name")]
		[Header("Descrizione della Missione")]
		[TextArea]

		public string description;

		[FoldoutGroup("$name")]
		[Header("Immagine della Missione")]
		public Sprite photo;

		[FoldoutGroup("$name")]
		[Space(10)]
		[Header("variabile che indica se queste informazioni sono disponibili")]
		public bool isAvaiable;


	}

	#endregion

	#region Public

	[Header("Lista delle informazioni del Codex")]
	public CodexGadget[] listGadget;
	[Space(10)]
	public CodexCharacter[] listCharacter;
	[Space(10)]
	public CodexPlace[] listPlace;
	[Space(10)]
	public CodexMission[] listMission;

	[Header("Variabili dedicate alla grafica del Codex")]
	public Text nameCategory;
	public Text name;
	public Text description; 
	public Image photo;
	public GameObject obj;

	[Space(30)]
	[Header("Sezione per l'animazione del Codex")]
	public Animator anim;

	#endregion

	#region Private

	//Variabile che indica la categoria corrente del codex che stiamo visualizzando
	private int currentCategory = 0;
	//Variabile che indica la scheda corrente del codex che stiamo visualizzando
	private int currentSchede = 0;

	//Variabile che indica se il codex è aperto
	private bool isOpen = false;

	private HUD hud; 

	//Variabili per la gestione del cambio di categorie
	private bool isPressedLT = false;
	private bool isPressedRT = false;

	#endregion

	void Start()
	{

		//Assegno la referenza del mio menu di pausa
		//hud = GameObject.FindGameObjectWithTag ("PauseMenu").GetComponent<HUD> ();

		GetFirstView ();

	}

	void Update()
	{


		Debug.Log (InputManager.RTbutton());
		Debug.Log (InputManager.LTbutton());

		//Gestione dei comandi per il cambio di scheda da Joystick
		if (InputManager.RBbutton ()) 
		{

			NextSchede ();

		}

		if (InputManager.LBbutton ()) 
		{

			PreviousSchede ();

		}

		if (InputManager.RTbutton () == 1 && isPressedRT == false && isPressedLT == false) 
		{

			Debug.Log ("Premuto RT");

			isPressedRT = true;
			isPressedLT = true;
			NextCategory ();

		}


		if (InputManager.LTbutton () == 1 && isPressedLT == false && isPressedRT == false) 
		{

			Debug.Log ("Premuto LT");
			Debug.Log (InputManager.LTbutton ());

			isPressedLT = true;
			isPressedRT = true;
			PreviousCategory ();

		}

		if (InputManager.LTbutton () == 0 && InputManager.RTbutton() == 0 && isPressedLT == true && isPressedRT == true) 
		{

			isPressedRT = false;
			isPressedLT = false;

		}

	}

	#region Controller

	/// <summary>
	/// Metodo che passa alla scheda successiva del Codex
	/// </summary>
	public void NextSchede()
	{
		//Evitiamo di andare in out of the range
		#region OutOfTheRange
		if (currentCategory == 0) 
		{

			if (currentSchede == listGadget.Length -1) 
			{
				currentSchede = listGadget.Length -1;
			}
			else
			{

				currentSchede++;

			}

		} 
		else if (currentCategory == 1) 
		{

			if (currentSchede == listCharacter.Length - 1) 
			{
				currentSchede = listCharacter.Length - 1;
			}
			else
			{

				currentSchede++;

			}

		} 
		else if (currentCategory == 2) 
		{

			if (currentSchede == listPlace.Length - 1) 
			{
				currentSchede = listPlace.Length - 1;
			}
			else
			{

				currentSchede++;

			}

		} 
		else if (currentCategory == 3) 
		{

			if (currentSchede == listMission.Length - 1) 
			{
				currentSchede = listMission.Length - 1;
			}
			else
			{

				currentSchede++;

			}

		} 

		#endregion

		//Controllo che array devo scorrere a seconda della categoria
		if (currentCategory == 0) 
		{

			GetCodexGadgetData (listGadget [currentSchede]);

		} 
		else if (currentCategory == 1) 
		{

			GetCodexCharactertData (listCharacter [currentSchede]);

		} 
		else if (currentCategory == 2) 
		{

			GetCodexPlacetData (listPlace [currentSchede]);

		} 
		else if (currentCategory == 3) 
		{

			GetCodexMissionData ( listMission[currentSchede]);

		}

		Debug.Log ("Next scheda");

	}

	/// <summary>
	/// Meotodo che passa alla scheda precedente del Codex
	/// </summary>
	public void PreviousSchede()
	{

		#region OutOfTheRange
		//Evitiamo di andare indietro a -1
		if (currentSchede == 0) 
		{

			currentSchede = 0;

		} 
		else 
		{
			currentSchede--;
		}
		#endregion

		//Controllo che array devo scorrere a seconda della categoria
		if (currentCategory == 0) 
		{
			
			GetCodexGadgetData (listGadget [currentSchede]);

		} 
		else if (currentCategory == 1) 
		{
			
			GetCodexCharactertData (listCharacter [currentSchede]);

		} 
		else if (currentCategory == 2) 
		{
			
			GetCodexPlacetData (listPlace [currentSchede]);

		} 
		else if (currentCategory == 3) 
		{

			GetCodexMissionData (listMission [currentSchede]);

		}

		Debug.Log ("Previous scheda");

	}
		
	/// <summary>
	/// Metodoo che passa alla categoria successiva
	/// </summary>
	public void NextCategory()
	{

		#region OutOfTherRange
		if (currentCategory == 3) 
		{

			currentCategory = 3;

		} 
		else 
		{

			currentCategory++;

		}
		#endregion

		ChangeCategory ();

		Debug.Log ("Next categoria");

	}

	/// <summary>
	/// Metodo che passa alla categoria precedente
	/// </summary>
	public void PreviousCategory()
	{

		#region OutOfTherRange
		if (currentCategory == 0) 
		{

			currentCategory = 0;

		} 
		else 
		{

			currentCategory--;

		}
		#endregion

		ChangeCategory ();

		Debug.Log ("Previous categoria");

	}

	#endregion

	#region Manipulate Data

	/// <summary>
	/// Metodo che passando la classe, ti restituisce i valori a schermo
	/// </summary>
	public void GetCodexGadgetData(CodexGadget cg)
	{

		//Stampo i valori a schermo 
		name.text = cg.name;
		description.text = cg.description;
		photo.sprite = cg.photo;

		if (listGadget [0].gadgetObj != null) 
		{

			//Instantiate (listGadget [0].gadgetObj, obj.transform);
			//obj = listGadget [0].gadgetObj;

		}

	}

	/// <summary>
	/// Metodo che passando la classe, ti restituisce i valori a schermo
	/// </summary>
	public void GetCodexCharactertData(CodexCharacter ch)
	{

		//Stampo i valori a schermo 
		name.text = ch.name;
		description.text = ch.description;
		photo.sprite = ch.photo;

		if (listCharacter [0].charcterObj != null) 
		{

			//Instantiate (listCharacter [0].charcterObj, obj.transform);
			//obj = listCharacter [0].charcterObj.GetComponent<Mesh>();

		}

	}

	/// <summary>
	/// Metodo che passando la classe, ti restituisce i valori a schermo
	/// </summary>
	public void GetCodexMissionData(CodexMission cm)
	{

		//Stampo i valori a schermo 
		name.text = cm.name;
		description.text = cm.description;
		photo.sprite = cm.photo;

	}

	/// <summary>
	/// Metodo che passando la classe, ti restituisce i valori a schermo
	/// </summary>
	public void GetCodexPlacetData(CodexPlace cp)
	{

		//Stampo i valori a schermo 
		name.text = cp.name;
		description.text = cp.description;
		photo.sprite = cp.photo;

	}

	/// <summary>
	/// Metodo che definisce azioni quando avviene il cambio di categoria
	/// </summary>
	public void ChangeCategory()
	{

		if (currentCategory == 0) 
		{

			nameCategory.text = "Gadget";

			//Stampo i valori a schermo 
			name.text = listGadget [0].name;
			description.text = listGadget [0].description;
			photo.sprite = listGadget [0].photo;

			if (listGadget [0].gadgetObj != null) 
			{

				//Instantiate (listGadget [0].gadgetObj, obj.transform);
				//obj = listGadget [0].gadgetObj;

			}


		}
		else if (currentCategory == 1) 
		{

			nameCategory.text = "Personaggi";

			//Stampo i valori a schermo 
			name.text = listCharacter [0].name;
			description.text = listCharacter [0].description;
			photo.sprite = listCharacter [0].photo;

			if (listCharacter [0].charcterObj != null) {

				//Instantiate (listCharacter [0].charcterObj, obj.transform);
				//obj = listCharacter [0].charcterObj.GetComponent<Mesh>();

			}


		} 
		else if (currentCategory == 2) 
		{

			nameCategory.text = "Luoghi";

			//Stampo i valori a schermo 
			name.text = listPlace [0].name;
			description.text = listPlace [0].description;
			photo.sprite = listPlace [0].photo;


		}
		else if (currentCategory == 3) 
		{

			nameCategory.text = "Missione";

			//Stampo i valori a schermo 
			name.text = listMission [0].name;
			description.text = listMission [0].description;
			photo.sprite = listMission [0].photo;

		}

	}

	/// <summary>
	/// Metodo richiamato al primo avvio del codex
	/// </summary>
	public void GetFirstView()
	{

		nameCategory.text = "Gadget";

		//Stampo i valori a schermo 
		name.text = listGadget[0].name;
		description.text = listGadget[0].description;
		photo.sprite = listGadget[0].photo;

		if (listGadget [0].gadgetObj != null) 
		{

			Instantiate (listGadget [0].gadgetObj, obj.transform);
			//obj = listCharacter [0].charcterObj.GetComponent<Mesh>();

		}

	

	}

	#endregion

	#region Animation

	/// <summary>
	/// Metodo che ti muovi nel menu
	/// </summa
	public void MoveOnCodex(string value)
	{

		anim.Play (value);

	}

	#endregion
}

