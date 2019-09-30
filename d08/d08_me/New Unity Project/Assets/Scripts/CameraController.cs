using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;
    public float speed = 5;
    public float transSpeed = 5;

    Vector3 offset;

    void Start()
    {
        offset = target.transform.position - gameObject.transform.position;
    }

    void LateUpdate()
    {
        // Look
        var newRotation = Quaternion.LookRotation(target.transform.position - gameObject.transform.position);
        transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, newRotation, speed * Time.deltaTime);

        // Move
        Vector3 newPosition = target.transform.position - target.transform.forward * offset.z - target.transform.up * offset.y;
        transform.position = Vector3.Slerp(gameObject.transform.position, newPosition, Time.deltaTime * transSpeed);
    }
}