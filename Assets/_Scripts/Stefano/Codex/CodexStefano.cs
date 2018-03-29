using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix;
using UnityEngine.UI;
using System;

namespace Sirenix.OdinInspector.Demos
{
	
	public class CodexStefano : MonoBehaviour {

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

		#endregion

		#region Public

		[Header("Lista delle informazioni del Codex")]
		public CodexGadget[] listGadget;
		public CodexCharacter[] listCharacter;
		public CodexPlace[] listPlace;

		[Header("Variabili dedicate alla grafica del Codex")]
		public Text nameCategory;
		public Text name;
		public Text description; 
		public Image photo;

		#endregion

		#region Private

		//Variabile che indica la categoria corrente del codex che stiamo visualizzando
		private int currentCategory = 0;
		//Variabile che indica la scheda corrente del codex che stiamo visualizzando
		private int currentSchede = 0;

		//Variabile che indica se il codex è aperto
		private bool isOpen = false;

		private HUD hud; 

		#endregion

		void Start()
		{

			//Assegno la referenza del mio menu di pausa
			//hud = GameObject.FindGameObjectWithTag ("PauseMenu").GetComponent<HUD> ();

			GetFirstView ();

		}

		void Update()
		{

			//Gestione dei comandi per il cambio di scheda da Joystick


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

			Debug.Log ("Previous scheda");

		}
			
		/// <summary>
		/// Metodoo che passa alla categoria successiva
		/// </summary>
		public void NextCategory()
		{

			#region OutOfTherRange
			if (currentCategory == 2) 
			{

				currentCategory = 2;

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

			} else if (currentCategory == 1) 
			{

				nameCategory.text = "Personaggi";

				//Stampo i valori a schermo 
				name.text = listCharacter [0].name;
				description.text = listCharacter [0].description;
				photo.sprite = listCharacter [0].photo;

			} else if (currentCategory == 2) {

				nameCategory.text = "Luoghi";

				//Stampo i valori a schermo 
				name.text = listPlace [0].name;
				description.text = listPlace [0].description;
				photo.sprite = listPlace [0].photo;

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

		}

		#endregion

	}
}
