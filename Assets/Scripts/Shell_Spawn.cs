using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell_Spawn : MonoBehaviour
{

    // Spawns projectile by end of tank's turrent

    public GameObject projetile_postion;
    public List<GameObject> vfx = new List<GameObject>();

    private GameObject effectToSpawn;

   private void Start()
    {
        effectToSpawn = vfx[0];
    }

    // Update is called once per frame
    private void Update()
    {
        //Condtion is when mouse button pressed
        if(Input.GetMouseButton (0))
        {
            Spawn_vfx();
        }
        
    }
   
    private void Spawn_vfx() 
    {
        GameObject vfx;

        if (effectToSpawn != null)
        {
            vfx = Instantiate(effectToSpawn, projetile_postion.transform.position, Quaternion.identity);

        }
        else
        {
            Debug.Log("No fire point");
        } 
    }

 

}
