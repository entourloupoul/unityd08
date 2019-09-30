using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemySpawner : MonoBehaviour
{
    public GameObject[] ennemies = new GameObject[2];
    public bool alive = false;
    GameObject ennemy;
    private float tDeath;
    private int addT;

    // Start is called before the first frame update
    void Start()
    {
        alive = false;
        tDeath = 0f;
        addT = 1;
    }

    // instanciate a new ennemy at the position
    void instantiateNewEnnemy()
    {
        int choice = Random.Range(0, 2);
        ennemy = Instantiate(ennemies[choice], gameObject.transform.position, gameObject.transform.rotation);
        alive = true;
        ennemy.transform.localScale = new Vector3(1f, 1f, 1f);
        ennemy.transform.parent = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (alive == false)
        {
            if (addT == 0)
            {
                tDeath = Time.time + 10;
                addT = 1;
            }
            if (addT == 1 && Time.time > tDeath)
            {
                instantiateNewEnnemy();
                addT = 0;
            }
        }

    }
}
