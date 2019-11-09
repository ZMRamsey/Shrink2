using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TannoyTrigger : MonoBehaviour
{
    AudioSource source;
    Collider trigger;
    
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        source.Play();
    }
}
