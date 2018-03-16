using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreSwitcher : MonoBehaviour {

    public GameObject mithrilDisplayOre;
    public GameObject adamantiteDisplayOre;
    public GameObject goldDisplayOre;
    public GameObject pyroniumDisplayOre;
    public GameObject silverDisplayOre;
    public GameObject grapiteDisplayOre;

    public Material mithrilDisplayMaterial;
    public Material adamantiteDisplayMaterial;
    public Material goldDisplayMaterial;
    public Material pyroniumDisplayMaterial;
    public Material silverDisplayMaterial;
    public Material grapiteDisplayMaterial;

    private GameObject instance;

    private Material oreToFade;
    private Color alphaColorStart;
    private Color alphaColorFinish;
    private float startTime;
    private float targetTime;
    private float timeToFade = 5.0f;
    private bool isLerp = false;

	void Start () {
        InvokeRepeating("DisplayOre", 0f, 10f);
        
	}
	
	void Update () {
        var progress = Time.time - startTime;

        if (isLerp)
        {
            oreToFade.color = Color.Lerp(alphaColorStart, alphaColorFinish, progress / timeToFade);

            if (timeToFade < progress)
            {
                isLerp = false;
                Destroy(instance);
                oreToFade.color = alphaColorStart;
                print("isLerp finished");
            }
        }

        
    }

    public void DisplayOre()
    {
        var displayOre = Random.Range(1, 6);
        
        switch (displayOre)
        {
            case 1:
                instance = Instantiate(mithrilDisplayOre, new Vector3(-165.5f, 9.2f, 23.7f), Quaternion.identity);
                alphaColorStart = new Color(0.38f, 0.46f, 0.66f, 1f);
                alphaColorFinish = new Color(0.38f, 0.46f, 0.66f, 0f);
                oreToFade = mithrilDisplayMaterial;
                startTime = Time.time;
                isLerp = true;
                break;
            case 2:
                instance = Instantiate(adamantiteDisplayOre, new Vector3(-86f, 9.2f, 23.7f), Quaternion.identity);
                alphaColorStart = new Color(0.03f, 0.44f, 0f, 1f);
                alphaColorFinish = new Color(0.03f, 0.44f, 0f, 0f);
                oreToFade = adamantiteDisplayMaterial;
                startTime = Time.time;
                isLerp = true;
                break;
            case 3:
                instance = Instantiate(goldDisplayOre, new Vector3(-22f, 9.2f, 23.7f), Quaternion.identity);
                alphaColorStart = new Color(1f, 0.84f, 0f, 1f);
                alphaColorFinish = new Color(1f, 0.84f, 0f, 0f);
                oreToFade = goldDisplayMaterial;
                startTime = Time.time;
                isLerp = true;
                break;
            case 4:
                instance = Instantiate(pyroniumDisplayOre, new Vector3(39f, 9.2f, 23.7f), Quaternion.identity);
                alphaColorStart = new Color(1f, 0f, 0f, 1f);
                alphaColorFinish = new Color(4f, 0f, 0f, 0f);
                oreToFade = pyroniumDisplayMaterial;
                startTime = Time.time;
                isLerp = true;
                break;
            case 5:
                instance = Instantiate(silverDisplayOre, new Vector3(103f, 9.2f, 23.7f), Quaternion.identity);
                alphaColorStart = new Color(0.75f, 0.75f, 0.75f, 1f);
                alphaColorFinish = new Color(0.75f, 0.75f, 0.75f, 0f);
                oreToFade = silverDisplayMaterial;
                startTime = Time.time;
                isLerp = true;
                break;
            case 6:
                instance = Instantiate(grapiteDisplayOre, new Vector3(163f, 9.2f, 23.7f), Quaternion.identity);
                alphaColorStart = new Color(0.5f, 0f, 0.5f, 1f);
                alphaColorFinish = new Color(0.5f, 0f, 0.5f, 0f);
                oreToFade = grapiteDisplayMaterial;
                startTime = Time.time;
                isLerp = true;
                break;
        }
    }

}
