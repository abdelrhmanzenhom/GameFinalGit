using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Charanimation playerAnimation;


    public GameObject attackPoint;
    private PlayerShield shield;
    void Start()
    {
     playerAnimation=GetComponent<Charanimation>(); 
     shield=GetComponent<PlayerShield>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q)) {
            playerAnimation.Defend(true);
            shield.AcitvateShield(true);
        }
        if(Input.GetKeyUp(KeyCode.Q)) {
            playerAnimation.UnfreezAnimation();
            playerAnimation.Defend(false);
            shield.AcitvateShield(false);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(Random.Range(0,2)>0)
            {
                playerAnimation.Attack1();
            }
            else
            {
                playerAnimation.Attack2();
            }
        }
       

    }
    void Acitvate_AttackPoint()
    {
        attackPoint.SetActive(true);
    }
    void Deacitvate_AttackPoint()
    {
        if (attackPoint.activeInHierarchy)
        {
            attackPoint.SetActive(false);
        }
    }
}
