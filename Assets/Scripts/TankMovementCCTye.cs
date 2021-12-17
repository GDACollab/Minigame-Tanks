using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovementCCTye : MonoBehaviour{ // to implement an expected tank control scheme where keys a & d rotate the tank we will manipulate given pieces of data so that we can fulfill said functionality.
    private CharacterController controller;
    private Vector3 playerMovement; 
    private float inputX; // +-1 = w/s pushed 0 = w/s not pushed
    private float inputZ; // +-1 = a/d pushed 0 = a/d not pushed
    private float playerSpeed = 12.0f;
    private float playerRotation = 180f;

    void Start(){
        controller = gameObject.AddComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update(){
        inputX = Input.GetAxis("Horizontal"); // check for x axis keystroke
        inputZ = Input.GetAxis("Vertical"); // check for y axis keystroke
    }

    private void FixedUpdate(){ // run movement script on a fixed update schedule
        playerMovement = controller.transform.forward * inputZ; // When w/s pushed, then store the vector data of said movement under playerMovement

        controller.transform.Rotate(Vector3.up * inputX * (playerRotation * Time.deltaTime)); // When a/d pushed, then rotate the character at a fixed y axis position with respect to playerRotation and time difference.

        controller.Move(playerMovement * playerSpeed * Time.deltaTime); // Move the character using stored vector data (only when w/s is pushed) with respect to playerSpeed and time difference.
    }
}
