using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootsteps : MonoBehaviour
{

    private AudioSource footstep_Sound;

    [SerializeField]
    private AudioClip[] footstep_Clip;

    private CharacterController character_Controller; // to know if we are on the ground or moving or not in order to play the sounds

    [HideInInspector]
    public float volume_Min, volume_Max;

    private float accumulated_Distance; // how far we can go before we can play the sound

    [HideInInspector]
    private float step_Distance; // how far we can go when we are walking, sprinting and crouching if we want to play the sound for them

    void Awake()
    {
        footstep_Sound = GetComponent<AudioSource>();

        character_Controller = GetComponentInParent<CharacterController>(); // Doesn't work if we have multiple instances. Like if we have two audio components or colliders, the system
                                                                            // gets confused which one to select 
    }

    void Update()
    {
        CheckToPlayFootstepSound();   
    }

    void CheckToPlayFootstepSound()
    {
        if (!character_Controller.isGrounded)
            return;

        if(character_Controller.velocity.sqrMagnitude > 0)
        {
            accumulated_Distance += Time.deltaTime;

            if(accumulated_Distance > step_Distance)
            {
                footstep_Sound.volume = Random.Range(volume_Min, volume_Max);
                footstep_Sound.clip = footstep_Clip[Random.Range(0, footstep_Clip.Length)];
                footstep_Sound.Play();

                accumulated_Distance = 0f;
            }

            else
            {
                accumulated_Distance = 0f;
            }
        }
    }
}
