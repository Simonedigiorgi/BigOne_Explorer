using UnityEngine;
using UnityEngine.SceneManagement;

public class RoverManager : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            SceneManager.LoadScene("Olympus Mons");
        }
    }

}
