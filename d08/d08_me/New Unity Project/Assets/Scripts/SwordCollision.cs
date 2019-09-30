using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCollision : MonoBehaviour
{
    public GameObject maya;
    private PlayerAttack plAttack;

    // Start is called before the first frame update
    void Start()
    {
        plAttack = maya.GetComponent<PlayerAttack>();    
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.transform.tag == "Ennemy")
        {
            plAttack.enterColl = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
