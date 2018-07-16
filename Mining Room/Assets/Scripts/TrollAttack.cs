using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrollAttack : MonoBehaviour {

    public bool isAttacking = false;
    public bool attackOne;
    public bool attackTwo;
    public Collider attackCollider;
    public OreList oreList;
    public TrollController trollController;

    Animator anim;

    void Start () {
        anim = GetComponent<Animator>();
    }
	
	void Update () {
        anim.SetBool("AttackOne", attackOne);
        anim.SetBool("AttackTwo", attackTwo);
        if (oreList.hasBeenHit)
        {
            attackCollider.enabled = false;
        }
    }

    public void AttackBegin()
    {
        trollController.MoveTroll();
        attackOne = false;
    }

    public void AttackDecider()
    {
        var decider = Random.Range(1, 3);
        if(decider == 1)
        {
            attackOne = true;
            StartCoroutine(AttackOne());
        }
        else if(decider == 2)
        {
            attackTwo = true;
            StartCoroutine(AttackTwo());
        }
    }
    
    IEnumerator AttackOne()
    {
        if (isAttacking)
        {
            yield break;
        }
        isAttacking = true;
        while (attackOne)
        {
            //anim.Update(0f);
            if (anim.GetBehaviour<AttackOneBehaviour>().attackOneTime >= .4f)
            {
                attackCollider.enabled = true;
                if (oreList.hasBeenHit)
                {
                    attackCollider.enabled = false;
                }

                if (anim.GetBehaviour<AttackOneBehaviour>().attackOneTime >= .7f)
                {
                    attackCollider.enabled = false;
                }
            }

            if(anim.GetBehaviour<AttackOneBehaviour>().attackOneTime >= 1)
            {
                attackOne = false;
                trollController.MoveTroll();
            }
            yield return null;
        }
        isAttacking = false;
        
    }

    IEnumerator AttackTwo()
    {
        if (isAttacking)
        {
            yield break;
        }
        isAttacking = true;
        while (attackTwo)
        {
            //anim.Update(0f);
            if (anim.GetBehaviour<AttackTwoBehaviour>().attackTwoTime >= .4f)
            {
                attackCollider.enabled = true;
                if (oreList.hasBeenHit)
                {
                    attackCollider.enabled = false;
                }

                if (anim.GetBehaviour<AttackTwoBehaviour>().attackTwoTime >= .7f)
                {
                    attackCollider.enabled = false;
                }
            }

            if (anim.GetBehaviour<AttackTwoBehaviour>().attackTwoTime >= 1)
            {
                attackTwo = false;
                trollController.MoveTroll();
            }
            yield return null;
        }
        isAttacking = false;

    }


}
