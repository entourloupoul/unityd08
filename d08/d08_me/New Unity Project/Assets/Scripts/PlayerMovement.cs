using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    private NavMeshAgent myAgent;
    private Animator myAnim;
    public GameObject ennemy;
    public PlayerAttack playAttack;
    string tag;

    // Start is called before the first frame update
    void Start()
    {
        myAgent = gameObject.GetComponent<NavMeshAgent>();
        myAnim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(myRay, out hitInfo, 300))
            {
                tag = hitInfo.transform.gameObject.tag;
                if (tag == "Terrain" || tag == "Ennemy")
                {
                    if (tag == "Terrain")
                    {
                        myAgent.SetDestination(hitInfo.point);
                        ennemy = null;
                        myAnim.SetBool("run", true);
                    }
                    if (tag == "Ennemy")
                    {
                        transform.LookAt(hitInfo.transform);
                        ennemy = hitInfo.transform.gameObject;
                        myAgent.SetDestination(hitInfo.point);
                        myAnim.SetBool("run", true);
                    }
                    Debug.Log(hitInfo.transform.gameObject.name);
                }
                else
                    tag = null;
                //Debug.Log(tag);
            }
        }
        //myAnim.SetBool("Run", true);
        else
        {
            if (tag == "Ennemy")
            {
                if (myAgent.remainingDistance <= 1)
                {
                    myAgent.ResetPath();
                    myAnim.SetBool("run", false);
                }
            }
            if (tag == "Terrain")
            {
                if (myAgent.remainingDistance <= 0.1)
                {
                    myAgent.ResetPath();
                    myAnim.SetBool("run", false);
                }
            }
        }
        if (ennemy)
        {
            playAttack.ennemy = ennemy;
        }
        else
        {
            playAttack.ennemy = null;
        }
    }
}
