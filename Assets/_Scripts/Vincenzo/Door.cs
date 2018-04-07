using UnityEngine;

public class Door : MonoBehaviour {

    GenericSettings genericSettings;

	private void OnTriggerEnter(Collider other)
	{
        if(other.CompareTag("Player"))
        {
            StartCoroutine(other.GetComponent<GenericSettings>().ChangePlayer());
        }
	}

}
