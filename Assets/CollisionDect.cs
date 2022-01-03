using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDect : MonoBehaviour
{
    public GameObject self;
    public GameObject target1;
    public GameObject target2;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == target1.tag)
        {
            Debug.Log(gameObject.name);

            Destroy(target1);

        } else if (collision.gameObject.tag == target2.tag)
        {
            Debug.Log(gameObject.tag);

            Destroy(target2);
            

        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == target1.tag)
        {
            Debug.Log("Target 1 destroyed");

            Destroy(self);

        }
        else if (collision.gameObject.tag == target2.tag)
        {
            Debug.Log("Target 2 destroyed");

            Destroy(self);


        }
    }
}
