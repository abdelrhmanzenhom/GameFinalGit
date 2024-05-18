using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    public float health = 100f;
    private float x_death = -90f;
    private float deathSmooth = .9f;
    private float rotate_time = .23f;
    private bool playerDied;
    public bool isPlayer;
    [SerializeField]
    private Image health_UI;
    [HideInInspector]
    public bool shieldActivated;
    void Update()
    {
        if (playerDied)
        {
            RotateAfterDeath();
        }
    }

    public void ApplyDamege(float damege)
    {
        if (shieldActivated)
        {
            return;
        }
        health -= damege;
        if (health_UI!= null)
        {
            health_UI.fillAmount = health/100f;
            
        }
        if (health <= 0)
        {
            GetComponent<Animator>().enabled = false;
            print("dead");

           StartCoroutine(AllowRotate());
            if(isPlayer)
            {
                GetComponent<PlayerMovement>().enabled = false;
                GetComponent<PlayerAttackMovement>().enabled = false;
                Camera.main.transform.SetParent(null);
                GameObject.FindGameObjectWithTag(Tags.ENEMY_TAG).GetComponent<EnemyController>().enabled = false;
            }
            else
            {
                GetComponent<EnemyController>().enabled = false;
                GetComponentInChildren<NavMeshAgent>().enabled = false;
            }
        }
    }
    void RotateAfterDeath()
    {
        transform.eulerAngles=new Vector3(
            Mathf.Lerp(transform.eulerAngles.x,x_death,Time.deltaTime*deathSmooth),
            transform.eulerAngles.y,transform.eulerAngles.z);
    }
    IEnumerator AllowRotate()
    {
        playerDied = true;
        yield return new WaitForSeconds(rotate_time);
        playerDied=false;
    }
}













