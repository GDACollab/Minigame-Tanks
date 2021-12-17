using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovementCCTye : MonoBehaviour{
    private CharacterController controller;
    private Vector3 playerMovement;
    private float inputX;
    private float inputZ;
    private float playerSpeed = 12.0f;
    private float playerRotation = 180f;

    void Start(){
        controller = gameObject.AddComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update(){
        inputX = Input.GetAxis("Horizontal");
        inputZ = Input.GetAxis("Vertical");
    }

    private void FixedUpdate(){
        playerMovement = controller.transform.forward * inputZ;

        controller.transform.Rotate(Vector3.up * inputX * (playerRotation * Time.deltaTime));

        controller.Move(playerMovement * playerSpeed * Time.deltaTime);
    }
}
