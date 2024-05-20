using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChracterSound : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource sound;
    [SerializeField]
    private AudioClip attackSound1, attackSound2, diesound;
    void Awake()
    {
        sound= GetComponent<AudioSource>();
    }

    // Update is called once per frame
   public void Attack_1()
    {
        sound.clip = attackSound1;
        sound.Play();
    }
    public void Attack_2()
    {
        sound.clip = attackSound2;
        sound.Play();
    }
    public void Dead()
    {
        sound.clip = diesound;
        sound.Play();
    }
}
