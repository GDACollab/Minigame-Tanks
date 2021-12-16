using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTankMovement : MonoBehaviour
{
    CharacterController characterController;

    [SerializeField] public float movementSpeed = 100, velocity = 0, gravity = 9.8f;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal") * movementSpeed;
        float y = Input.GetAxis("Vertical") * movementSpeed;

        characterController.Move((Vector3.right * x + Vector3.forward * y) * Time.deltaTime);
    }
}
