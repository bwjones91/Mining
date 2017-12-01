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


    void Start () {
		
	}
	

	void Update () {
        
    }

    public void SetCurrentOreText()
    {
        mithrilText.text = mithrilCounter.ToString();
        adamantiteText.text = adamantiteCounter.ToString();
        goldText.text = goldCounter.ToString();
        pyroniumText.text = pyroniumCounter.ToString();
        silverText.text = silverCounter.ToString();
        grapiteText.text = grapiteCounter.ToString();
    }

}
