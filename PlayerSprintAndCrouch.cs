using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprintAndCrouch : MonoBehaviour
{

    private PlayerMovement playerMovement;

    public float sprint_Speed = 10f;
    public float move_Speed = 5f;
    public float crouch_Speed = 2f;

    private Transform look_Root;

    private float stand_Height = 1.6f;
    private float crouch_Height = 1f;

    private bool is_Crouching;

    private PlayerFootsteps player_Foorsteps;

   //  private float sprint_Volume;

    private float sprint_Volume = 1f; // meaning 100%
    private float crounch_Volume = 0.1f;
    private float walk_Volume_Min = 0.2f, walk_Volume_Max = 0.6f;

    void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();

        look_Root = transform.GetChild(0); //Gets the first child in the heirarchy, here, it is the look_Root child of the parent Player

        player_Foorsteps = GetComponent<PlayerFootsteps>();
        //player_Foorsteps = GetComponentInChild<PlayerFootsteps>();
    }

    // Update is called once per frame
    void Update()
    {
        Sprint();
        Crouch();
    }

    void Sprint()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift) && !is_Crouching)
        {
            playerMovement.speed = sprint_Speed;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift) && !is_Crouching)
        {
            playerMovement.speed = move_Speed;
        }
    }

    void Crouch()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            if(is_Crouching)
            {
                look_Root.localPosition = new Vector3(0f, stand_Height, 0f); // we are using localPositon instead of just Position because localPosition is with respect to
                                                                             // the player (parent of look_Root) whereas using just Position will modify look_Root with respect
                                                                             // to Unity World which is beyond the game map in this case and modifying it will lead to loads of
                                                                             // changes
                playerMovement.speed = move_Speed;

                is_Crouching = false;
            }

            else
            {
                look_Root.localPosition = new Vector3(0f, crouch_Height, 0f);
                playerMovement.speed = crouch_Speed;

                is_Crouching = true;
            }
        }

    }
}
