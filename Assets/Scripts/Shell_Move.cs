using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell_Move : MonoBehaviour
{
    public float speed;
    public float rate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (speed != 0) 
        {
           transform.position += transform.forward * (speed * Time.deltaTime);
        
        } else { Debug.Log("Speed is zero"); }
    }
}
