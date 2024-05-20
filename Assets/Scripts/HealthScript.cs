using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.Collections.LowLevel.Unsafe;

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
    public GameObject pausethemenu;
    public GameObject nextlev;
    private static int cnt;
    private static bool f;
    private ChracterSound sound;
    void Start()
    {
        sound = GetComponentInChildren<ChracterSound>();
        cnt = 0;
    }
    void Update()
    {
        if (playerDied)
        {
            RotateAfterDeath();
        }
    }

    public void ApplyDamege(float damege)
    {
        //if ( f == true) { health += 100; f = false; }
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
            sound.Dead();
            GetComponent<Animator>().enabled = false;
           
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            //pausethemenu.SetActive(true);
          
            StartCoroutine(AllowRotate());
            if(isPlayer)
            {

                pausethemenu.SetActive(true);

                GetComponent<PlayerMovement>().enabled = false;
                GetComponent<PlayerAttackMovement>().enabled = false;
                Camera.main.transform.SetParent(null);
                GameObject.FindGameObjectWithTag(Tags.ENEMY_TAG).GetComponent<EnemyController>().enabled = false;
            }
            else
            {
                cnt++;

               


                print(cnt);
                //SceneManager.LoadSceneAsync(2);
                GetComponent<EnemyController>().enabled = false;
                GetComponentInChildren<NavMeshAgent>().enabled = false;

                Scene activeScene = SceneManager.GetActiveScene();
                
                if (cnt==1&& activeScene.buildIndex == 1)
                {
                    nextlev.SetActive(true);

                }
                else if (cnt>=3&&activeScene.buildIndex == 2)
                {
                    Time.timeScale = 0.0f;
                    nextlev.SetActive(true);
                }
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













