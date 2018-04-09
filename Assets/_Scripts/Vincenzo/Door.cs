using UnityEngine;

public class Door : MonoBehaviour {

	private void OnTriggerEnter(Collider other)
	{
        if(other.CompareTag("Player"))
        {
            StartCoroutine(other.GetComponent<GenericSettings>().ChangePlayer());
        }
	}

}
