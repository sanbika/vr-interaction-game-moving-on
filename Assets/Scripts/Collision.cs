using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.tag == "obstacle")
        {
            Debug.Log("Collide with obstacles");
            // False effect
            // Points deducted
        }
    }
}
