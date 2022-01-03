using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell_Spawn : MonoBehaviour
{

    // Spawns projectile by end of tank's turrent

    public GameObject projetile_postion;
    public List<GameObject> vfx = new List<GameObject>();
    public Transform m_Fire_transform;
    public bool player; // if true player 1 shoots, else if false player 2 shoots

    private GameObject effectToSpawn; //specifed projectile

   private void Start()
    {
        m_Fire_transform = GetComponent<Transform>();
        effectToSpawn = vfx[0];
    }

    // Update is called once per frame
    private void Update()
    {
        if (player == true && Input.GetKeyDown(KeyCode.RightShift))
        {
            Spawn_vfx();
        }
        else if(player == false && Input.GetKeyDown(KeyCode.LeftShift))
        {
            Spawn_vfx();
        }
        
    }
   
    private void Spawn_vfx() 
    {
        GameObject vfx;

        if (effectToSpawn != null)
        {
            Vector3 spawPos = projetile_postion.transform.position;
            Quaternion spawnRot = m_Fire_transform.rotation;
            vfx = Instantiate(effectToSpawn, spawPos, spawnRot);

        }
        else
        {
            Debug.Log("No fire point");
        } 
    }

 

}
