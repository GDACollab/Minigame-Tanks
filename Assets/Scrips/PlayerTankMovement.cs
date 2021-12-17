using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTankMovement : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField] public float movementSpeed = 100, velocity = 0, gravity = 9.8f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal") * movementSpeed;
        float y = Input.GetAxis("Vertical") * movementSpeed;

        Vector3 input = new Vector3(x,0,y);
        rb.MovePosition(transform.position + input * Time.deltaTime * velocity);
    }
}
