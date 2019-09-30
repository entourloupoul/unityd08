using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject ennemy;
    private EnnemyController ennemyController;
    public Animator myAnim;
    public GameObject sword;
    private Collider swordCollider;
    public int enterColl;

    // Start is called before the first frame update
    void Start()
    {
        swordCollider = sword.GetComponent<Collider>();
        enterColl = 0;
    }

    void Attack()
    {
        transform.LookAt(ennemy.transform);
        float dist = Vector3.Distance(ennemy.transform.position, transform.position);
        Debug.Log("dist: " + dist);
        if (dist < 2f && swordCollider.enabled == false && !myAnim.GetCurrentAnimatorStateInfo(0).IsName("AttackMaya"))
        {
            swordCollider.enabled = true;
            myAnim.Play("AttackMaya");
            //myAnim.SetBool("attack", true);
            myAnim.SetBool("run", false);
        }
        else if (enterColl == 1)
        {
            swordCollider.enabled = false;
            enterColl = 0;
            //myAnim.SetBool("attack", false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ennemy)
        {
            ennemyController = ennemy.GetComponent<EnnemyController>();
            if (ennemyController.lifePoint > 0)
                Attack();
        }
        else 
        {
            myAnim.SetBool("attack", false);
        }
    }
}
