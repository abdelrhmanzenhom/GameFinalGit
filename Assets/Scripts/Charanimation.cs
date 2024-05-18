using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charanimation : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void Walk(bool walk)
    {
        anim.SetBool(AnimationTags.WALK_PARATEMER, walk);
    }
    public void Defend(bool defend)
    {
        anim.SetBool(AnimationTags.DEFEND_PARATEMER, defend);
    }
    public void Attack1()
    {
        anim.SetTrigger(AnimationTags.ATTACK_TRIGGER_1);
    }
    public void Attack2()
    {
        anim.SetTrigger(AnimationTags.ATTACK_TRIGGER_2);
    }
    void FreezeAnimation()
    {
        anim.speed = 0f;
    }
    public void UnfreezAnimation()
    {
        anim.speed = 1f;
    }
}
