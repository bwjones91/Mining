using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ore : MonoBehaviour {

    public enum OreType
    {
        Mithril,
        Adamantite,
        Gold,
        Pyronium,
        Silver
    }

    public OreType oreType;
    public AudioClip oreObtained;
    public AudioClip oreBreak;

    Collider oreCollider;
    private AudioSource source;
    
    void Start () {
        source = GetComponent<AudioSource>();
        oreCollider = GetComponent<Collider>();
    }
	
	void Update () {
        
	}

    private void OnTriggerEnter(Collider collider)
    {
        
        if (collider.gameObject.tag == "Ground")
        {
            oreCollider.enabled = false;
            source.PlayOneShot(oreBreak, 2f);
            Destroy(this.gameObject, 5);
        }
        if (collider.gameObject.tag == "Player")
        {
            oreCollider.enabled = false;
            source.PlayOneShot(oreObtained, 2f);
            Destroy(this.gameObject, 5);
        }
    }
}
