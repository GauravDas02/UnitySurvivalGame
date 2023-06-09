using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private CharacterController character_Controller;

    private Vector3 move_Direction;

    public float speed = 5f;

    private float gravity = 20f;

    public float jump_Force = 10f;

    private float vertical_Velocity;

    void Awake() {
        character_Controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveThePlayer();
    }

    void MoveThePlayer() {
        move_Direction = new Vector3(Input.GetAxis(Axis.HORIZONTAL), 0f, Input.GetAxis(Axis.VERTICAL));

        move_Direction = transform.TransformDirection(move_Direction);

        move_Direction *= speed * Time.deltaTime;

        character_Controller.Move(move_Direction);
    } // move the player

    void ApplyGravity(){

            vertical_Velocity -= gravity * Time.deltaTime;

            //jump OR test in order to jump
            PlayerJump();

            move_Direction.y = vertical_Velocity * Time.deltaTime;  //To smooth things out

    } // apply gravity

    /*bool isJumpPressed;  */

    void PlayerJump(){

        if(character_Controller.isGrounded && Input.GetKeyDown(KeyCode.Space)) { //GetKeyDown lets the system know when the key is pressed down, doesn't matter if it's held down or released
                                                                                //Similarly, GetUpKey lets the system know when the key is released
                                                                                //And GetKey lets the system know when the key is pressed
            vertical_Velocity = jump_Force;
        }

    }

    /*public static KeyCode SpacebarKey()                                         // To overcome bug for spacebar key
    {
        if (Application.isEditor) return KeyCode.O;
        else return KeyCode.Space;

    }
    */

    /*private void FixedUpdate()
    {
        if (isJumpPressed)
        {
            Debug.Log("FixedUpdate Jump");
            isJumpPressed = false;
        }
    }
    */

}
