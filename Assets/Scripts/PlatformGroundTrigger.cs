using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//PURPOSE: A trigger that dictates whther a player is on the ground, and thus, whether they can jump
//USAGE: A trigger box parented by the player sprite
public class PlatformGroundTrigger : MonoBehaviour
{
    public GameObject myPlayer;


    void OnTriggerStay2D(Collider2D activator) {
        myPlayer.PlayerJump.isGrounded = true;
    }

    void OnTriggerExit2D(Collider2D activator) {
        myPlayer.PlayerJump.isGrounded = false;
    }
}
