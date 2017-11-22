using UnityEngine;
using System.Collections;

public class vPickupItem : MonoBehaviour
{
    AudioSource _audioSource;
    public AudioClip _audioClip;
    public GameObject _particle;

    private CollectableManager collectableManager;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        collectableManager = FindObjectOfType<CollectableManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Player") && !_audioSource.isPlaying)
        {
            Renderer[] renderers = GetComponentsInChildren<Renderer>();
            foreach (Renderer r in renderers)            
                r.enabled = false;            

            _audioSource.PlayOneShot(_audioClip);
            collectableManager.DecreaseCollectable(this);
            Destroy(gameObject, _audioClip.length);
        }
    }
}