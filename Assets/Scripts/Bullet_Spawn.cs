using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Spawn : MonoBehaviour
{
    [SerializeField] private Transform turret_postion;
    [SerializeField] private Transform pfShell;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float bullet_sp = 5.0f;
    

   private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        turret_postion = GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        //When space is pressed
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("Passes statement");
            //spawn shell near tank postion

            Spawn();

            // launch shell

            Launch();

        }
    }

    private void Spawn()
    {
        Debug.Log("In Spawn");
        Debug.Log(turret_postion.position.ToString());
        // Get Postion of Tank's Turrent, then spanwn
        float turret_x = turret_postion.position.x;
        float turret_y = turret_postion.position.y;
        float turret_z = turret_postion.position.z;
        Vector3 shell_postion = new Vector3(turret_x,turret_y,turret_z);
        
    }

    private void Launch()
    {
        Debug.Log("In Luanch");
        // Shell move in foward direction
    
    }

}
