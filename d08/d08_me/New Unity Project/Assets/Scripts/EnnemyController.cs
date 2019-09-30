using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnnemyController : MonoBehaviour
{
    public GameObject spawner;
    private EnnemySpawner spawnerScript;
    public int lifePoint;
    private Animator myAnim;
    private int dead;
    public NavMeshAgent myAgent;
    private float dTime;

    // Start is called before the first frame update
    void Start()
    {
        myAnim = gameObject.GetComponent<Animator>();
        spawner = transform.parent.gameObject;
        spawnerScript = spawner.GetComponent<EnnemySpawner>();
        lifePoint = 3;
        dead = 0;
    }


    // set behaviour on death
    void death()
    {
        if (dead == 0)
        {
            dead = 1;
            myAnim.Play("Death");
            dTime = Time.time;
        }
        if (dead == 1 && Time.time - dTime > 2.85f)
        {
            spawnerScript.alive = false;
            myAgent.enabled = false;
            transform.Translate(Vector3.down * Time.deltaTime, Space.Self);
            if (Time.time - dTime > 4f)
                Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collider)
    {
        Debug.Log("collision" + collider.transform.name);
        if (collider.transform.gameObject.tag == "PlayerWeapon")
        {
            lifePoint -= 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (lifePoint <= 0)
        {
            death();
        }
    }
}
