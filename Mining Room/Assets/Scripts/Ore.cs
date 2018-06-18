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
        Silver,
        Grapite
    }

    public OreType oreType;
    public AudioClip oreObtained;
    public AudioClip oreBreak;

    Collider oreCollider;
    private AudioSource source;

    OreList oreList;
    
    

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
            source.PlayOneShot(oreBreak, 5f);
            Destroy(this.gameObject, 5);
        }
        if (collider.gameObject.tag == "Player")
        {
            oreCollider.enabled = false;
            source.PlayOneShot(oreObtained, 5f);
            oreList.ores.Add(gameObject.GetComponent<Ore>());
            Destroy(this.gameObject, 5);
        }
    }
}
