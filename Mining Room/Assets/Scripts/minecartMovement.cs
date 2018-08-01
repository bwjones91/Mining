using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minecartMovement : MonoBehaviour {
    
    public float  minecartSpeed;
    public OreList oreList;
    public GameController gameController;
    public float thrustVariable;
    public float localSpeed;
    public float maxSpeed;
    public OreSwitcher oreSwitcher;
    public AudioClip goblinCackle;
    public AudioClip wheelSqueak;
    public AudioClip goblinScream;
    public float soundDelay;
    public float soundCheck;
    public float soundInput;
    public AudioSource cackleSource;

    public Rigidbody mithrilOre;
    public Rigidbody adamantiteOre;
    public Rigidbody goldOre;
    public Rigidbody pyroniumOre;
    public Rigidbody silverOre;

    private bool wheelSqueakPlay;
    private AudioSource source;
    private float thrust;
    private bool right;
    private float thrustDirection;
    private float leverMovement;
    private ArduinoCommunicator AC;
    private float force;
    private Rigidbody rb;
    private bool speedLimiterLeft;
    
    


    void Start () {
        rb = this.GetComponent<Rigidbody>();
        AC = GameObject.Find("Arduino Communication").GetComponent<ArduinoCommunicator>();
        thrustDirection = -1f;
        speedLimiterLeft = true;
        source = GetComponent<AudioSource>();
        wheelSqueakPlay = true;
        Invoke("SoundLoop", 0);
    }

	void Update () {
        leverMovement = Mathf.Abs(AC.GetMessageIN());

        minecartSpeed = GetComponent<Rigidbody>().velocity.magnitude;
        var localSpeed = transform.InverseTransformDirection(GetComponent<Rigidbody>().velocity);
        
        if(localSpeed.x < maxSpeed && speedLimiterLeft == false)
        {
            thrustDirection = 1f;
        }

        if (localSpeed.x > -maxSpeed && speedLimiterLeft == true)
        {
            thrustDirection = -1f;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            speedLimiterLeft = true;
            if (localSpeed.x > -maxSpeed)
            {
                thrustDirection = -1f;
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && localSpeed.x < maxSpeed)
        {
            speedLimiterLeft = false;
            if (localSpeed.x < maxSpeed)
            {
                thrustDirection = 1f;
            }
        }

        if (localSpeed.x >= maxSpeed && speedLimiterLeft == false)
        {
            thrustDirection = 0f;
        }

        if (localSpeed.x <= -maxSpeed && speedLimiterLeft == true)
        {
            thrustDirection = 0f;
        }
        
        soundInput = minecartSpeed * -1;
        soundCheck = Mathf.InverseLerp(-500f, -10f, soundInput);
        soundDelay = soundCheck + 1;
        
    }

    private void SoundLoop()
    {
        if (minecartSpeed > 10)
        {
            source.PlayOneShot(wheelSqueak);
            Invoke("SoundLoop", soundDelay);
        }
        else
        {
            Invoke("SoundLoop", 0);
        }
    }

    private void FixedUpdate()
    {
        thrust = (leverMovement) * thrustVariable;
        rb.AddForce(new Vector3(thrustDirection, 0f, 0f) * thrust);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Left Wall" || collision.gameObject.tag == "Right Wall")
        {
            minecartSpeed = 0;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        GameObject theController = GameObject.Find("GameController");
        GameController gameController = theController.GetComponent<GameController>();
        if (collider.gameObject.tag == "Ore")
        {
            Ore.OreType type = collider.gameObject.GetComponent<Ore>().oreType;
            switch (type)
            {
                case Ore.OreType.Mithril:
                    gameController.mithrilCounter++;
                    oreList.ores.Add(mithrilOre.GetComponent<Ore>());
                    oreSwitcher.oresNeeded.Remove(mithrilOre.GetComponent<Ore>());
                    break;
                case Ore.OreType.Adamantite:
                    gameController.adamantiteCounter++;
                    oreList.ores.Add(adamantiteOre.GetComponent<Ore>());
                    oreSwitcher.oresNeeded.Remove(adamantiteOre.GetComponent<Ore>());
                    break;
                case Ore.OreType.Gold:
                    gameController.goldCounter++;
                    oreList.ores.Add(goldOre.GetComponent<Ore>());
                    oreSwitcher.oresNeeded.Remove(goldOre.GetComponent<Ore>());
                    break;
                case Ore.OreType.Pyronium:
                    gameController.pyroniumCounter++;
                    oreList.ores.Add(pyroniumOre.GetComponent<Ore>());
                    oreSwitcher.oresNeeded.Remove(pyroniumOre.GetComponent<Ore>());
                    break;
                case Ore.OreType.Silver:
                    gameController.silverCounter++;
                    oreList.ores.Add(silverOre.GetComponent<Ore>());
                    oreSwitcher.oresNeeded.Remove(silverOre.GetComponent<Ore>());
                    break;
            }
        }
        gameController.SetCurrentOreText();
    }


}
