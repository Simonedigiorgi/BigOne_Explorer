using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    public void StartNewGame()
    {
        GameManager.newGame = true;
        SceneManager.LoadScene("_Main_Vincenzo");
    }

}
