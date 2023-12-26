using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camfollow : MonoBehaviour
{
    public Transform Player_;
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        transform.position = new Vector3(Player_.position.x, transform.position.y, transform.position.z);
    }
}
