﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ore : MonoBehaviour {

    public enum OreType
    {
        Coal,
        Copper,
        Gold,
        Iron,
        Silver,
        Tin
    }

    public OreType oreType;

    OreList oreList;

	void Start () {
        oreList = GameObject.FindGameObjectWithTag("Player").GetComponent<OreList>();
    }
	
	void Update () {
        
	}

    private void OnTriggerEnter(Collider collider)
    {
        
        if (collider.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject);
        }
        if (collider.gameObject.tag == "Player")
        {
            oreList.ores.Add(gameObject.GetComponent<Ore>());
        }
    }

}
