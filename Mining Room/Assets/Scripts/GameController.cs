using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public float myScore;
    public float mithrilCounter;
    public float adamantiteCounter;
    public float goldCounter;
    public float pyroniumCounter;
    public float silverCounter;
    public float grapiteCounter;

    public Text mithrilText;
    public Text adamantiteText;
    public Text goldText;
    public Text pyroniumText;
    public Text silverText;
    public Text grapiteText;

    public Material mithrilDisplayMaterial;
    public Material adamantiteDisplayMaterial;
    public Material goldDisplayMaterial;
    public Material pyroniumDisplayMaterial;
    public Material silverDisplayMaterial;
    public Material grapiteDisplayMaterial;

    private AudioSource source;


    void Start () {
        mithrilDisplayMaterial.color = new Color(0.38f, 0.46f, 0.66f, 0f);
        adamantiteDisplayMaterial.color = new Color(0.03f, 0.44f, 0f, 0f);
        goldDisplayMaterial.color = new Color(1f, 0.84f, 0f, 0f);
        pyroniumDisplayMaterial.color = new Color(1f, 0f, 0f, 0f);
        silverDisplayMaterial.color = new Color(0.75f, 0.75f, 0.75f, 0f);
        grapiteDisplayMaterial.color = new Color(0.5f, 0f, 0.5f, 0f);
        source = GetComponent<AudioSource>();
        source.Play();
    }
	

	void Update () {
        
    }



}
